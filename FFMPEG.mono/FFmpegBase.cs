using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.Runtime.InteropServices;
using System.IO;

namespace Multimedia
{
    public class FFmpegBase
    {
        private Native<AV.AVFormatContext> pFormatCtx = null;

        private AvDecoder audioDecoder = null;
        private AvDecoder videoDecoder = null;
        private FileReader reader = null;
        private Demux demux = null;
        private IPipe audioRender = null;
        private IPipe videoRender = null;
        private IntPtr videohandle = IntPtr.Zero;


 

        public FFmpegBase()
        {
            AV.av_register_all();
			AV.avcodec_register_all();
        }

        public FFmpegBase(IntPtr videoHandle)
        {
            AV.av_register_all();
			AV.avcodec_register_all();
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

            FileInfo info = new FileInfo(fileName);
            string file = info.FullName;

            GeneratePipesFromFile(file);

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
            
			FileInfo info = new FileInfo(fileName);
			//string file = info.FullName;
            IntPtr fileContext = IntPtr.Zero;
            int ret = AV.avformat_open_input(out fileContext, fileName, IntPtr.Zero, IntPtr.Zero);
            //int ret = NativeMethods.avformat_open_input(out fileContext, str, IntPtr.Zero, 0);

            if (ret < 0)
                throw new InvalidOperationException("can not open input file");
            ret = AV.av_find_stream_info(fileContext);
            if (ret < 0)
                throw new InvalidOperationException("can not find stream info");
            pFormatCtx = new Native<AV.AVFormatContext>(fileContext);

            AV.AVFormatContext context = pFormatCtx.Handle;
            for (int index = 0; index < context.nb_streams; index++)
            {
                Native<AV.AVStream> stream = new Native<AV.AVStream>(context.Streams[index]);
                Native<AV.AVCodecContext> codec = new Native<AV.AVCodecContext>(stream.Handle.codec);
                AV.AVCodecContext codecContext = codec.Handle;
                if (codecContext.codec_type == AV.AVMediaType.AVMEDIA_TYPE_AUDIO)
                {
                    audioDecoder = new AvDecoder(stream, codec, index);
                }
                else if (codecContext.codec_type == AV.AVMediaType.AVMEDIA_TYPE_VIDEO)
                {
                    videoDecoder = new AvDecoder(stream, codec, index);

                }
            }
            reader = new FileReader(pFormatCtx);
            demux = new Demux(pFormatCtx);
        }

        public long Duration
        {
            get
            {
                if (pFormatCtx != null)
                    return pFormatCtx.Handle.duration;
                else
                    return 0;
            }
        }

        public long Position
        {
            get
            {
                if (pFormatCtx != null)
                    return pFormatCtx.Handle.offset;
                else
                    return 0;
            }
            //set
            //{
            //    if (pFormatCtx != null)
            //    {
            //        AV.av_seek_frame(pFormatCtx.Ptr)
            //    }
            //    else
            //        throw new Exception("Can not seek to position {0}", value);
            //}
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
