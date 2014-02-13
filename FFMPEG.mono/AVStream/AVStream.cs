using SharpFFmpeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Multimedia
{
    internal interface IMediaStream
    {
        bool Process(NativeWrapper<NativeMethods55.AVPacket> hPacket);
    }

    public class MediaStream
    {
        private NativeWrapper<NativeMethods55.AVFormatContext> pFormatCtx;

        private AudioStream _audio;
        private VideoStream _video;
        public IAudioStream Audio
        {
            get 
            {
                return _audio;
            }
        }

        public IVideoStream Video
        {
            get
            {
                return _video;
            }
        }

        public MediaStream()
        {
            NativeMethods55.av_register_all();
        }

        public MediaStream(string fileName)
        {
            NativeMethods55.av_register_all();

            IntPtr fileContext = IntPtr.Zero;
            int ret = NativeMethods55.avformat_open_input(out fileContext, fileName, IntPtr.Zero, IntPtr.Zero);
            //int ret = NativeMethods.avformat_open_input(out fileContext, str, IntPtr.Zero, 0);

            if (ret < 0)
                throw new InvalidOperationException("can not open input file");
            ret = NativeMethods55.av_find_stream_info(fileContext);
            if (ret < 0)
                throw new InvalidOperationException("can not find stream info");
            pFormatCtx = new NativeWrapper<NativeMethods55.AVFormatContext>(fileContext);

            NativeMethods55.AVFormatContext context = pFormatCtx.Handle;
            for (int index = 0; index < context.nb_streams; index++)
            {
                NativeWrapper<NativeMethods55.AVStream> stream = new NativeWrapper<NativeMethods55.AVStream>(context.Streams[index]);
                NativeWrapper<NativeMethods55.AVCodecContext> codec = new NativeWrapper<NativeMethods55.AVCodecContext>(stream.Handle.codec);
                NativeMethods55.AVCodecContext codecContext = codec.Handle;
                if (codecContext.codec_type == NativeMethods55.AVMediaType.AVMEDIA_TYPE_AUDIO)
                {
                    _audio = new AudioStream(stream, codec, index);
                }
                else if (codecContext.codec_type == NativeMethods55.AVMediaType.AVMEDIA_TYPE_VIDEO)
                {
                    _video = new VideoStream(stream, codec, index);

                }
            }
        }

        public bool ProcessNext()
        {
            IntPtr pPacket = Marshal.AllocHGlobal(Marshal.SizeOf(new NativeMethods55.AVPacket()));
            NativeWrapper<NativeMethods55.AVPacket> hPacket = new NativeWrapper<NativeMethods55.AVPacket>(pPacket);
            if (NativeMethods55.av_read_frame(pFormatCtx.Ptr, hPacket.Ptr) != 0)
            {
                Marshal.FreeHGlobal(pPacket);
                return false;
            }

            if (hPacket.Handle.stream_index == _audio.StreamIndex)
            {
                if (_audio != null)
                {
                    bool ret = _audio.Process(hPacket);
                    Marshal.FreeHGlobal(pPacket);
                    return ret;
                }
                else
                {
                    Marshal.FreeHGlobal(pPacket);
                    return false;
                }
            }
            else if (hPacket.Handle.stream_index == _video.StreamIndex)
            {
                if (_video != null)
                {
                    bool ret = _video.Process(hPacket);
                    Marshal.FreeHGlobal(pPacket);
                    return ret;
                }
                else
                {
                    Marshal.FreeHGlobal(pPacket);
                    return false;
                }
            }
            else
            {
                bool ret = (new UnimplStream()).Process(hPacket);
                Marshal.FreeHGlobal(pPacket);
                return ret;
            }
        }

    }
}
