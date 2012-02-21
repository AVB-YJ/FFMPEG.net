using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;

namespace Multimedia
{
    public class FFmpegBase
    {
        private NativeWrapper<FFmpeg.AVFormatContext> pFormatCtx = null;

        private AvDecoder audioDecoder = null;
        private AvDecoder videoDecoder = null;
        private FileReader fileReader = null;
        private Demux demux = null;
        private AudioRender audioRender = null;
        private VideoRender videoRender = null;

 

        public FFmpegBase(string fileName)
        {
            IntPtr context = IntPtr.Zero;
            int ret = FFmpeg.av_open_input_file(out context, fileName, IntPtr.Zero, 0, IntPtr.Zero);
            if (ret < 0)
                throw new InvalidOperationException("can not open input file");
            ret = FFmpeg.av_find_stream_info(context);
            if (ret < 0)
                throw new InvalidOperationException("can not find stream info");
            pFormatCtx = new NativeWrapper<FFmpeg.AVFormatContext>(context);
            RenderFile();
        }

        public void Close()
        {
            if (fileReader != null)
                fileReader.Close();
            if (demux != null)
                demux.Close();
            if (audioDecoder != null)
                audioDecoder.Close();
            if (videoDecoder != null)
                videoDecoder.Close();
            if (audioRender != null)
                audioRender.Close();
            if (videoRender != null)
                videoRender.Close();
            if (pFormatCtx != null)
            {
                FFmpeg.av_close_input_file(pFormatCtx.Ptr);
                pFormatCtx = null;
            }
        }

        private void RenderFile()
        {
            FFmpeg.AVFormatContext context = pFormatCtx.Handle;
            for (int index = 0; index < context.nb_streams; index++)
            {
                NativeWrapper<FFmpeg.AVStream> stream = new NativeWrapper<FFmpeg.AVStream>(context.streams[index]);
                NativeWrapper<FFmpeg.AVCodecContext> codec = new NativeWrapper<FFmpeg.AVCodecContext>(stream.Handle.codec);
                FFmpeg.AVCodecContext codecContext = codec.Handle;
                if (codecContext.codec_type == FFmpeg.CodecType.CODEC_TYPE_AUDIO)
                {
                    audioDecoder = new AvDecoder(stream, codec, index);
                }
                else if (codecContext.codec_type == FFmpeg.CodecType.CODEC_TYPE_VIDEO)
                {
                    videoDecoder = new AvDecoder(stream, codec, index);

                }
            }
            fileReader = new FileReader(pFormatCtx);
            demux = new Demux(pFormatCtx);
            audioRender = new AudioRender();
            videoRender = new VideoRender();

            //connect pipe
            fileReader.ConnectTo(demux);
            demux.ConnectTo(audioDecoder);
            demux.ConnectTo(videoDecoder);
            audioDecoder.ConnectTo(audioRender);
            videoDecoder.ConnectTo(videoRender);

        }

        public void Play()
        {
            fileReader.Start();
        }

        public void Pause()
        {
            fileReader.Stop();
        }

        public void Stop()
        {
        }
    }
}
