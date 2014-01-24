using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.Runtime.InteropServices;

namespace Multimedia
{
    public class FFmpegBase
    {
        private NativeWrapper<NativeMethods.AVFormatContext> pFormatCtx = null;

        private AvDecoder audioDecoder = null;
        private AvDecoder videoDecoder = null;
        private FileReader reader = null;
        private Demux demux = null;
        private IPipe audioRender = null;
        private IPipe videoRender = null;
        private IntPtr videohandle = IntPtr.Zero;


 

        public FFmpegBase()
        {
            NativeMethods.av_register_all();
        }

        public FFmpegBase(IntPtr videoHandle)
        {
            NativeMethods.av_register_all();
            this.videohandle = videoHandle;
        }

        public void Close()
        {
            if (reader != null)
                reader.Close();
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

        }

        public bool Render()
        {
            if (reader == null)
                throw new Exception("No reader pip!");

            if (demux == null)
                throw new Exception("No demux pip!");

            if (videoDecoder == null && audioDecoder == null)
            {
                throw new Exception("No decoder pip!");
            }

            reader.ConnectTo(demux);

            if (videoDecoder != null)
            {
                demux.ConnectTo(videoDecoder);
                if (videoRender != null)
                    videoDecoder.ConnectTo(videoRender);
            }

            if (audioDecoder != null)
            {
                demux.ConnectTo(audioDecoder);
                if (audioRender != null)
                    audioDecoder.ConnectTo(audioRender);
            }

            return true;

        }

        public void RenderFile(string fileName)
        {

            GeneratePipesFromFile(fileName);

            if( audioRender == null && audioDecoder != null) // use default render
                audioRender = new AudioRender();
            if (videoRender == null && videoDecoder != null) // use default render
            {
                videoRender = new VideoRender();
                (videoRender as VideoRender).VideoWindow = videohandle;
            }

            //connect pipe
            reader.ConnectTo(demux);

            if (videoDecoder != null)
            {
                demux.ConnectTo(videoDecoder);
                if (videoRender != null)
                    videoDecoder.ConnectTo(videoRender);
            }
            if (audioDecoder != null)
            {
                demux.ConnectTo(audioDecoder);
                if (audioRender != null)
                    audioDecoder.ConnectTo(audioRender);
            }

        }

        private void GeneratePipesFromFile(string fileName)
        {
            
            IntPtr str = Marshal.StringToHGlobalAnsi(fileName);
            IntPtr fileContext = IntPtr.Zero;
            int ret = NativeMethods.av_open_input_file(out fileContext, str, IntPtr.Zero, 0, IntPtr.Zero);
            Marshal.FreeHGlobal(str);
            if (ret < 0)
                throw new InvalidOperationException("can not open input file");
            ret = NativeMethods.av_find_stream_info(fileContext);
            if (ret < 0)
                throw new InvalidOperationException("can not find stream info");
            pFormatCtx = new NativeWrapper<NativeMethods.AVFormatContext>(fileContext);

            NativeMethods.AVFormatContext context = pFormatCtx.Handle;
            for (int index = 0; index < context.nb_streams; index++)
            {
                NativeWrapper<NativeMethods.AVStream> stream = new NativeWrapper<NativeMethods.AVStream>(context.streams[index]);
                NativeWrapper<NativeMethods.AVCodecContext> codec = new NativeWrapper<NativeMethods.AVCodecContext>(stream.Handle.codec);
                NativeMethods.AVCodecContext codecContext = codec.Handle;
                if (codecContext.codec_type == NativeMethods.CodecType.CODEC_TYPE_AUDIO)
                {
                    audioDecoder = new AvDecoder(stream, codec, index);
                }
                else if (codecContext.codec_type == NativeMethods.CodecType.CODEC_TYPE_VIDEO)
                {
                    videoDecoder = new AvDecoder(stream, codec, index);

                }
            }
            reader = new FileReader(pFormatCtx);
            demux = new Demux(pFormatCtx);
        }

        public void Play()
        {
            reader.Start();
        }

        public void Pause()
        {
            reader.Stop();
        }

        public void Stop()
        {
            reader.Stop();
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

        public IPipe Reader
        {
            get { return reader; }
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
