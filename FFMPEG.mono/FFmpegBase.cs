using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.Runtime.InteropServices;

namespace Multimedia
{
    public class FFmpegBase
    {
        private NativeWrapper<FFmpeg.AVFormatContext> pFormatCtx = null;

        private AvDecoder audioDecoder = null;
        private AvDecoder videoDecoder = null;
        private FileReader fileReader = null;
        private Demux demux = null;
        private IPipe audioRender = null;
        private IPipe videoRender = null;
        private IntPtr videohandle = IntPtr.Zero;


 

        public FFmpegBase()
        {
            FFmpeg.av_register_all();
        }

        public FFmpegBase(IntPtr videoHandle)
        {
            FFmpeg.av_register_all();
            this.videohandle = videoHandle;
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

        public void RenderFile(string fileName)
        {

            GeneratePipesFromFile(fileName);

            if( audioRender == null ) // use default render
                audioRender = new AudioRender();
            if (videoRender == null) // use default render
            {
                videoRender = new VideoRender();
                (videoRender as VideoRender).VideoWindow = videohandle;
            }

            //connect pipe
            fileReader.ConnectTo(demux);
            demux.ConnectTo(audioDecoder);
            demux.ConnectTo(videoDecoder);
            audioDecoder.ConnectTo(audioRender);
            videoDecoder.ConnectTo(videoRender);

        }

        private void GeneratePipesFromFile(string fileName)
        {
            
            IntPtr str = Marshal.StringToHGlobalAnsi(fileName);
            IntPtr fileContext = IntPtr.Zero;
            int ret = FFmpeg.av_open_input_file(out fileContext, str, IntPtr.Zero, 0, IntPtr.Zero);
            Marshal.FreeHGlobal(str);
            if (ret < 0)
                throw new InvalidOperationException("can not open input file");
            ret = FFmpeg.av_find_stream_info(fileContext);
            if (ret < 0)
                throw new InvalidOperationException("can not find stream info");
            pFormatCtx = new NativeWrapper<FFmpeg.AVFormatContext>(fileContext);

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
            fileReader.Stop();
            // then go back
            demux.Seek(0);
        }


        // user can setup his/her own av render
        // for example, different os has different audio playback
        // and av render can be file on disk
        public IPipe AudioRender
        {
            get { return audioRender; }
            set { audioRender = value; }
        }

        public IVideoRender VideoRender
        {
            get { return videoRender as IVideoRender; }
            set { videoRender = (IPipe)value; }
        }

        // user can get out reader / av decoder / demux
        // and put their own pip in graph
        // and connect them by themselves
        // for example people can put a diaginositc pipe between
        // reander and demux
        public void PutFile(string file)
        {
            GeneratePipesFromFile(file);
        }

        public IPipe FileReader
        {
            get { return fileReader; }
        }

        public IPipe Demux
        {
            get { return demux; }
        }

        public IDecoder AudioDecoder
        {
            get { return audioDecoder; }
        }

        public IDecoder VideoDecoder
        {
            get { return videoDecoder; }
        }

    }
}
