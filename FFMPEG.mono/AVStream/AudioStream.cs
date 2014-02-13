using SharpFFmpeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Multimedia
{
    public delegate void OnAudioDecodecdDelegate(IntPtr sample, int size, int sample_rate, int channels, int bit_persample);

    public interface IAudioStream
    {
        event OnAudioDecodecdDelegate OnPacketDecoded;
    }

    internal class AudioFrame
    {
        public IntPtr sample;
        public int size;
        public int rate;
        public int bit;
        public int channel;
        public int fmt;
        public int nb_samples;
    }

    internal class AudioStream : IMediaStream, IAudioStream
    {
        private NativeWrapper<NativeMethods55.AVCodecContext> pCodecCtx;
        NativeWrapper<NativeMethods55.AVCodec> pCodec;
        public AudioStream(NativeWrapper<NativeMethods55.AVStream> stream,
            NativeWrapper<NativeMethods55.AVCodecContext> codec,
            int codecIndex)
        {
            StreamIndex = codecIndex;
            pCodecCtx = codec;
            OpenCodec();

        }

        private void OpenCodec()
        {

            NativeMethods55.AVCodecContext codecContext = pCodecCtx.Handle;
            IntPtr decoder = NativeMethods55.avcodec_find_decoder(codecContext.codec_id);
            if (decoder != IntPtr.Zero)
            {
                pCodec = new NativeWrapper<NativeMethods55.AVCodec>(decoder);
                if ((pCodec.Handle.capabilities & NativeMethods55.CODEC_FLAG_TRUNCATED) != 0)
                {
                    codecContext.flags |= NativeMethods55.CODEC_FLAG_TRUNCATED;
                    pCodecCtx.Handle = codecContext;
                }
            }
            else
                throw new InvalidOperationException("no such decoder");

            int ret = NativeMethods55.avcodec_open2(pCodecCtx.Ptr, pCodec.Ptr, IntPtr.Zero);
            if (ret < 0)
                throw new InvalidOperationException("no such decoder");
        }

        public int StreamIndex { get; set; }

        public bool Process(NativeWrapper<NativeMethods55.AVPacket> packet)
        {
            int size = 0;
            NativeWrapper<NativeMethods55.AVFrame> tframe =
                new NativeWrapper<NativeMethods55.AVFrame>(NativeMethods55.avcodec_alloc_frame());
            int ret = NativeMethods55.avcodec_decode_audio4(pCodecCtx.Ptr,
                tframe.Ptr, out size, packet.Ptr);
            if (ret <= 0)
            {
                NativeMethods55.avcodec_free_frame(tframe.Ptr);
                return false;

            }


            AudioFrame frame = new AudioFrame();
            frame.fmt = (int)pCodecCtx.Handle.sample_fmt;
            frame.sample = tframe.Handle.data[0];
            frame.size = tframe.Handle.linesize[0];
            frame.rate = pCodecCtx.Handle.sample_rate;
            frame.bit = pCodecCtx.Handle.bits_per_coded_sample;
            frame.channel = pCodecCtx.Handle.channels;
            frame.nb_samples = tframe.Handle.nb_samples;

            AudioFrame target = ConvertAudioSample(frame);

            if (frame != null && OnPacketDecoded != null)
                OnPacketDecoded(target.sample, target.size, target.rate, target.channel, target.bit);

            NativeMethods55.av_free(tframe.Ptr);
            Marshal.FreeHGlobal(target.sample);
            return true;
        }

        private AudioFrame ConvertAudioSample(AudioFrame input)
        {

            AudioFrame output = new AudioFrame();
            output.channel = input.channel;
            output.rate = input.rate;
            output.bit = 16;
            output.nb_samples = input.nb_samples;
            output.fmt = (int)(NativeMethods55.AVSampleFormat.AV_SAMPLE_FMT_S16);
            output.sample = Marshal.AllocHGlobal(NativeMethods55.AVCODEC_MAX_AUDIO_FRAME_SIZE * 2 + 16);
            int bytePerSample = NativeMethods55.av_get_bytes_per_sample((NativeMethods55.AVSampleFormat)output.fmt);
            output.size = output.nb_samples * bytePerSample;

            if (input.fmt == (int)NativeMethods55.AVSampleFormat.AV_SAMPLE_FMT_FLTP)
            {
                System.Single val = new System.Single();
                if (input.channel == 1)
                {
                    for (int i = 0; i < input.nb_samples; i++)
                    {
                        IntPtr address = new IntPtr(input.sample.ToInt64() + i * Marshal.SizeOf(val));
                        val = (System.Single)Marshal.PtrToStructure(address, typeof(System.Single));
                        if (val < -1.0)
                            val = -1.0f;
                        else if (val > 1.0)
                            val = 1.0f;
                        Int16 target = (Int16)(val * 32767.0f);

                        IntPtr address2 = new IntPtr(input.sample.ToInt64() + i * Marshal.SizeOf(target));
                        Marshal.WriteInt16(address2, target);
                    }
                }
                else if (input.channel == 2)
                {
                    for (int i = 0; i < input.nb_samples; i++)
                    {
                        // channel 1
                        IntPtr address = new IntPtr(input.sample.ToInt64() + i * Marshal.SizeOf(val));
                        val = (System.Single)Marshal.PtrToStructure(address, typeof(System.Single));
                        if (val < -1.0)
                            val = -1.0f;
                        else if (val > 1.0)
                            val = 1.0f;
                        Int16 target = (Int16)(val * 32767.0f);

                        IntPtr address2 = new IntPtr(input.sample.ToInt64() + (i * 2) * Marshal.SizeOf(target));
                        Marshal.WriteInt16(address2, target);

                        // channel 2
                        address = new IntPtr(input.sample.ToInt64() + (i + 1) * Marshal.SizeOf(val));
                        val = (System.Single)Marshal.PtrToStructure(address, typeof(System.Single));
                        if (val < -1.0)
                            val = -1.0f;
                        else if (val > 1.0)
                            val = 1.0f;
                        target = (Int16)(val * 32767.0f);

                        address2 = new IntPtr(input.sample.ToInt64() + (i * 2 + 1) * Marshal.SizeOf(target));
                        Marshal.WriteInt16(address2, target);
                    }
                }
            }
            else
            {
                // FIXME
                // add convert from other format to AV_SAMPLE_FMT_S16
                Marshal.FreeHGlobal(output.sample);
                output = null;
            }

            return output;
        }



        public event OnAudioDecodecdDelegate OnPacketDecoded;
    }
}
