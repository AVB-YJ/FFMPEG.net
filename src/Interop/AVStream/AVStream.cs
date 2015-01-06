using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpFFmpeg
{

    public interface IFFMpeg
    {
        IAVStream GetAVStream(string file);
    }

    public interface IAVStream
    {
        IAVFrame GetNext();
        void Close();
    }

    public class FFMpegBase : IFFMpeg
    {
        public string SourceFile { get; set; }

        private void InitCodecs()
        {
            AV.av_register_all();
            AV.avcodec_register_all();
        }

        private FFMpegBase()
        {
            InitCodecs();
        }

        private static IFFMpeg _instance = null;
        public static IFFMpeg Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FFMpegBase();
                return _instance;
            }
        }

        public IAVStream GetAVStream(string fileName)
        {
            if (fileName == string.Empty)
                throw new Exception("No Input file");

            FileInfo info = new FileInfo(fileName);
            string file = info.FullName;
            IntPtr fileContext = IntPtr.Zero;
            int ret = AV.avformat_open_input(out fileContext, file, IntPtr.Zero, IntPtr.Zero);
            if (ret < 0)
                throw new InvalidOperationException("can not open input file");

            ret = AV.av_find_stream_info(fileContext);
            if (ret < 0)
                throw new InvalidOperationException("can not find stream info");

            return new AVStream(fileContext);

        }
    }

    internal class AVStream : IAVStream
    {
        private AV.AVFormatContext pFormatCtx;
        private IntPtr rawFormatCtx = IntPtr.Zero;
        Dictionary<int, IntPtr> decoderTable = new Dictionary<int, IntPtr>();
        Dictionary<int, AV.AVMediaType> mediaTypeTable = new Dictionary<int, AV.AVMediaType>();

        public AVStream(IntPtr fileContext)
        {
            rawFormatCtx = fileContext;
            pFormatCtx = new NativeGetter<AV.AVFormatContext>(fileContext).Get();
            for (var i = 0; i < pFormatCtx.nb_streams; i++)
            {
                var stream = new NativeGetter<AV.AVStream>(pFormatCtx.Streams[i]).Get();
                var codecContext = new NativeGetter<AV.AVCodecContext>(stream.codec).Get();
                IntPtr codec = AV.avcodec_find_decoder(codecContext.codec_id);
                if (codec != IntPtr.Zero)
                {
                    var codecHandle = new NativeGetter<AV.AVCodec>(codec).Get();
                    if ((codecHandle.capabilities & AV.CODEC_FLAG_TRUNCATED) != 0)
                    {
                        codecContext.flags |= AV.CODEC_FLAG_TRUNCATED;
                        new NativeSetter<AV.AVCodecContext>(stream.codec).Set(codecContext);
                    }

                    int ret = AV.avcodec_open2(stream.codec, codec, IntPtr.Zero);
                    if (ret < 0)
                        throw new Exception("Can not open codec for type " + codecContext.codec_type.ToString());

                    decoderTable.Add(i, stream.codec);
                    mediaTypeTable.Add(i, codecContext.codec_type);
                }
            }

        }

        public void Close()
        {
            if (rawFormatCtx != null)
                AV.avformat_free_context(rawFormatCtx);

            foreach (var decoder in decoderTable)
            {
                AV.avcodec_close(decoder.Value);
            }
        }


        public IAVFrame GetNext()
        {
            IAVFrame frame = null;
            IntPtr pPacket = Marshal.AllocHGlobal(Marshal.SizeOf(new AV.AVPacket()));
            if (AV.av_read_frame(rawFormatCtx, pPacket) != 0)
            {
                Marshal.FreeHGlobal(pPacket);
                pPacket = IntPtr.Zero;
                return null;
            }


            AV.AVPacket packet = new NativeGetter<AV.AVPacket>(pPacket).Get();
            if (! decoderTable.ContainsKey(packet.stream_index) ||
                ! mediaTypeTable.ContainsKey(packet.stream_index))
            {
                Marshal.FreeHGlobal(pPacket);
                pPacket = IntPtr.Zero;
                return null;
            }

            var codec = decoderTable[packet.stream_index];
            var type = mediaTypeTable[packet.stream_index];
            switch(type)
            {
                case AV.AVMediaType.AVMEDIA_TYPE_AUDIO:
                    frame = new AudioFrame(pPacket, codec);
                    return frame;
                case AV.AVMediaType.AVMEDIA_TYPE_VIDEO:
                    frame = new VideoFrame(pPacket, codec);
                    return frame;
                default:
                    throw new Exception("Not support media type " + type.ToString());
            }
            return null;

        }

        public bool SetPosition(long position)
        {
            // AV.avformat_seek_file
            throw new Exception("Unimplement function with AV.avformat_seek_file");
        }
    }
}
