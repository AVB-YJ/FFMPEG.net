using System;
using System.Collections.Generic;
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
        void Decode();
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

        public void Decode()
        {
            if (rawData != IntPtr.Zero)
                AV.av_free(rawData);

            rawData = DoDecode();
            avFrame = new NativeGetter<AV.AVFrame>(rawData).Get();
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

    public struct WaveDataType
    {
        public int size;
        public int rate;
        public int bit;
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
            if (ret <= 0)
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
                d.bit = codecCtx.bits_per_coded_sample == 0 ? 16 : codecCtx.bits_per_coded_sample;
                d.channel = codecCtx.channels;
                d.fmt = codecCtx.sample_fmt;
                d.nb_samples = avFrame.nb_samples;
                d.size = avFrame.linesize[0];
                d.rate = codecCtx.bit_rate;
                ConvertAudioSample(ref d, avFrame.data[0]);
                return d;
            }
        }

        private void ConvertAudioSample(ref WaveDataType input, IntPtr sample)
        {

            if (input.fmt == AV.AVSampleFormat.AV_SAMPLE_FMT_FLTP)
            {
                System.Single val = new System.Single();
                if (input.channel == 1)
                {
                    for (int i = 0; i < input.nb_samples; i++)
                    {
                        IntPtr address = new IntPtr(sample.ToInt64() + i * Marshal.SizeOf(val));
                        val = (System.Single)Marshal.PtrToStructure(address, typeof(System.Single));
                        if (val < -1.0)
                            val = -1.0f;
                        else if (val > 1.0)
                            val = 1.0f;
                        Int16 target = (Int16)(val * 32767.0f);

                        IntPtr address2 = new IntPtr(sample.ToInt64() + i * Marshal.SizeOf(target));
                        Marshal.WriteInt16(address2, target);
                    }
                }
                else if (input.channel == 2)
                {
                    for (int i = 0; i < input.nb_samples; i++)
                    {
                        // channel 1
                        IntPtr address = new IntPtr(sample.ToInt64() + i * Marshal.SizeOf(val));
                        val = (System.Single)Marshal.PtrToStructure(address, typeof(System.Single));
                        if (val < -1.0)
                            val = -1.0f;
                        else if (val > 1.0)
                            val = 1.0f;
                        Int16 target = (Int16)(val * 32767.0f);

                        IntPtr address2 = new IntPtr(sample.ToInt64() + (i * 2) * Marshal.SizeOf(target));
                        Marshal.WriteInt16(address2, target);

                        // channel 2
                        address = new IntPtr(sample.ToInt64() + (i + 1) * Marshal.SizeOf(val));
                        val = (System.Single)Marshal.PtrToStructure(address, typeof(System.Single));
                        if (val < -1.0)
                            val = -1.0f;
                        else if (val > 1.0)
                            val = 1.0f;
                        target = (Int16)(val * 32767.0f);

                        address2 = new IntPtr(sample.ToInt64() + (i * 2 + 1) * Marshal.SizeOf(target));
                        Marshal.WriteInt16(address2, target);
                    }
                }
            }
            else
            {
                // FIXME
                // add convert from other format to AV_SAMPLE_FMT_S16

            }

            input.managedData = new byte[input.size];
            Marshal.Copy(sample, input.managedData, 0, input.size);
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
