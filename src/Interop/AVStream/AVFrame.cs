using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpFFmpeg
{
    public enum AVFrameType
    {
        Audio,
        Video
    };

    public interface IAVFrame
    {
        AVFrameType FrameType { get; }
        bool Decode();
        void Close();
    }

    public class AVFrameAbs : IAVFrame
    {
        internal IntPtr Packet = IntPtr.Zero;
        internal IntPtr Codec = IntPtr.Zero;
        internal IntPtr rawData = IntPtr.Zero;
        internal AV.AVFrame avFrame;
        internal AV.AVCodecContext codecCtx;


        public AVFrameAbs(IntPtr pPacket, IntPtr codec)
        {
            Packet = pPacket;
            Codec = codec;
            codecCtx = new NativeGetter<AV.AVCodecContext>(codec).Get();
        }

        public AVFrameType FrameType
        {
            get { return SpecificFrameType; }
        }

        virtual internal AVFrameType SpecificFrameType
        {
            get { throw new NotImplementedException(); }
        }

        public bool Decode()
        {
            if (rawData != IntPtr.Zero)
                AV.av_free(rawData);

            rawData = DoDecode();
            if (rawData != IntPtr.Zero)
            {
                avFrame = new NativeGetter<AV.AVFrame>(rawData).Get();
                return true;
            }
            else
            {
                return false;
            }
        }


        virtual internal IntPtr DoDecode()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            Marshal.FreeHGlobal(Packet);

            if (rawData != IntPtr.Zero)
                AV.av_free(rawData);
        }
    }

    public class WaveDataType
    {
        public int size;
        public int bit_rate;
        public int bit_per_sample;
        public int sample_rate;
        public int channel;
        public AV.AVSampleFormat fmt;
        public int nb_samples;
        public byte[] managedData;
    }

    public class AudioFrame : AVFrameAbs
    {

        public AudioFrame(IntPtr pPacket, IntPtr codec)
            : base(pPacket, codec)
        {
        }

        internal override AVFrameType SpecificFrameType
        {
            get { return AVFrameType.Audio; }
        }


        internal override IntPtr DoDecode()
        {
            int size = 0;
            IntPtr rawData = AV.avcodec_alloc_frame();
            int ret = AV.avcodec_decode_audio4(Codec,
                rawData,
                out size,
                Packet);
            if (ret <= 0 || size == 0)
            {
                AV.av_free(rawData);
                return IntPtr.Zero;
            }
            return rawData;
        }

        public WaveDataType WaveDate
        {
            get
            {
                WaveDataType d = new WaveDataType();
                d.bit_per_sample = codecCtx.bits_per_coded_sample == 0 ? 16 : codecCtx.bits_per_coded_sample;
                d.channel = codecCtx.channels;
                d.fmt = codecCtx.sample_fmt;
                d.nb_samples = avFrame.nb_samples;
                d.size = avFrame.linesize[0];
                d.bit_rate = codecCtx.bit_rate;
                d.sample_rate = avFrame.sample_rate;
                ConvertAudioSample(ref d, avFrame.extended_data);
                return d;
            }
        }

        private void ConvertAudioSample(ref WaveDataType input, IntPtr sample)
        {
            int ret;
            IntPtr swr = AV.swr_alloc_set_opts(IntPtr.Zero,
                                            AV.av_get_default_channel_layout(codecCtx.channels),
                                            AV.AVSampleFormat.AV_SAMPLE_FMT_S16,
                                            codecCtx.sample_rate,
                                            AV.av_get_default_channel_layout(codecCtx.channels),
                                            codecCtx.sample_fmt,
                                            codecCtx.sample_rate,
                                            0,
                                            IntPtr.Zero);
            ret = AV.swr_init(swr);

            int needed_buf_size = AV.av_samples_get_buffer_size(IntPtr.Zero,
                                                                codecCtx.channels,
                                                                input.nb_samples,
                                                                AV.AVSampleFormat.AV_SAMPLE_FMT_S16, 0);
            IntPtr pOutput = Marshal.AllocCoTaskMem(needed_buf_size);
            IntPtr ppOutput = Marshal.AllocCoTaskMem(Marshal.SizeOf(pOutput));
            Marshal.WriteIntPtr(ppOutput, pOutput);

            int len = AV.swr_convert(swr, ppOutput, input.nb_samples, sample, input.nb_samples);

            int output_len = len * 2 * AV.av_get_bytes_per_sample(AV.AVSampleFormat.AV_SAMPLE_FMT_S16);
            input.managedData = new byte[output_len];
            Marshal.Copy(pOutput, input.managedData, 0, output_len);

            Marshal.FreeCoTaskMem(pOutput);
            Marshal.FreeCoTaskMem(ppOutput);

            IntPtr ppSwr = Marshal.AllocCoTaskMem(Marshal.SizeOf(swr));
            Marshal.WriteIntPtr(ppSwr, swr);
            AV.swr_free(ppSwr);
            Marshal.FreeCoTaskMem(ppSwr);

            input.bit_per_sample = AV.av_get_bits_per_sample_fmt(AV.AVSampleFormat.AV_SAMPLE_FMT_S16);
            input.channel = codecCtx.channels;
            input.fmt = AV.AVSampleFormat.AV_SAMPLE_FMT_S16;
            input.size = needed_buf_size;

        }

    }

    public struct VideoFrameType
    {
        public int width;
        public int height;
        public AV.AVPixelFormat SourceFormat;
        public AV.AVPixelFormat DestFormat;
        public int linesize;
        public byte[] managedData;
    };

    public class VideoFrame : AVFrameAbs
    {


        public VideoFrame(IntPtr pPacket, IntPtr codec)
            : base(pPacket, codec)
        {
        }

        internal override AVFrameType SpecificFrameType
        {
            get { return AVFrameType.Video; }
        }

        internal override IntPtr DoDecode()
        {
            IntPtr rawData = AV.avcodec_alloc_frame();

            int finish = 0; ;
            int ret = AV.avcodec_decode_video2(Codec,
                rawData,
                out finish,
                Packet);
            if (ret < 0)
            {
                AV.av_free(rawData);
                return IntPtr.Zero;
            }
            return rawData;
        }

        public VideoFrameType ImgData
        {
            get
            {
                VideoFrameType t = new VideoFrameType();
                ConvertToBitmap(ref t);
                return t;
            }
        }

        private void ConvertToBitmap(ref VideoFrameType t)
        {
            var frame = avFrame;
            //FFmpeg.AVFrame final = gcnew AvFrame(PIX_FMT_BGR24, this->size);
            IntPtr final = AV.avcodec_alloc_frame();
            AV.AVFrame finalFrame = new NativeGetter<AV.AVFrame>(final).Get();

            var dst_fmt = AV.AVPixelFormat.AV_PIX_FMT_BGR24;

            int count = AV.avpicture_get_size(dst_fmt, codecCtx.width, codecCtx.height);

            IntPtr bufferArr = Marshal.AllocHGlobal(count);

            AV.avpicture_fill(final, bufferArr, dst_fmt, codecCtx.width, codecCtx.height);

            IntPtr swsContext = AV.sws_getContext(codecCtx.width, codecCtx.height, codecCtx.pix_fmt,
                codecCtx.width, codecCtx.height, dst_fmt, AV.SWS_BICUBIC, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            if (swsContext == IntPtr.Zero)
                throw new Exception();

            finalFrame = new NativeGetter<AV.AVFrame>(final).Get();
            AV.sws_scale(swsContext, frame.data, frame.linesize, 0, codecCtx.height, finalFrame.data, finalFrame.linesize);

            new NativeSetter<AV.AVFrame>(final).Set(finalFrame);
            // Array::Reverse(bufferArr);

            byte[] buffer = new byte[count];
            Marshal.Copy(bufferArr, buffer, 0, count);
            AV.av_free(final);
            Marshal.FreeHGlobal(bufferArr);


            t.width = codecCtx.width;
            t.height = codecCtx.height;
            t.SourceFormat = codecCtx.pix_fmt;
            t.DestFormat = dst_fmt;
            t.managedData = buffer;
            t.linesize = finalFrame.linesize[0];
        }
    }
}
