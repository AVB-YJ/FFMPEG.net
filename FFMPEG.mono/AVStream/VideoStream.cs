using SharpFFmpeg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Multimedia
{
    public delegate void OnVideoDecodecdDelegate(Bitmap packet);
    public interface IVideoStream
    {
        event OnVideoDecodecdDelegate OnPacketDecodecd;
    }

    internal class VideoFrame
    {
         public NativeWrapper<NativeMethods55.AVFrame> ffmpegFrame;
         public int format;
         public int width;
         public int height;
    }

    internal class VideoStream : IMediaStream, IVideoStream
    {
        private NativeWrapper<NativeMethods55.AVCodecContext> pCodecCtx;
        NativeWrapper<NativeMethods55.AVCodec> pCodec;
        public VideoStream(NativeWrapper<NativeMethods55.AVStream> stream,
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
            NativeWrapper<NativeMethods55.AVFrame> frame = new NativeWrapper<NativeMethods55.AVFrame>(NativeMethods55.avcodec_alloc_frame());

            int finish = 0; ;
            int ret = NativeMethods55.avcodec_decode_video2(pCodecCtx.Ptr, frame.Ptr, out finish, packet.Ptr);
            if (ret < 0)
            {
                NativeMethods55.av_free(frame.Ptr);
                return false;
            }

            if (finish == 0)
            {
                NativeMethods55.av_free(frame.Ptr);
                return false;

            }

            VideoFrame nextObj = new VideoFrame();
            nextObj.ffmpegFrame = frame;
            nextObj.format = (int)pCodecCtx.Handle.pix_fmt;
            nextObj.width = pCodecCtx.Handle.width;
            nextObj.height = pCodecCtx.Handle.height;

            ConvertToBitmap(nextObj);

            NativeMethods55.av_free(frame.Ptr);
            
            return true;

        }

        private void ConvertToBitmap(VideoFrame This)
        {
            var frame = ((NativeWrapper<NativeMethods55.AVFrame>)This.ffmpegFrame).Handle;
            //FFmpeg.AVFrame final = gcnew AvFrame(PIX_FMT_BGR24, this->size);
            NativeWrapper<NativeMethods55.AVFrame> final = new NativeWrapper<NativeMethods55.AVFrame>(NativeMethods55.avcodec_alloc_frame());

            var dst_fmt = NativeMethods55.AVPixelFormat.AV_PIX_FMT_BGR24;

            int count = NativeMethods55.avpicture_get_size(dst_fmt, This.width, This.height);

            IntPtr bufferArr = Marshal.AllocHGlobal(count);

            NativeMethods55.avpicture_fill(final.Ptr, bufferArr, dst_fmt, This.width, This.height);

            IntPtr swsContext = NativeMethods55.sws_getContext(This.width, This.height, (NativeMethods55.AVPixelFormat)This.format,
                This.width, This.height, dst_fmt, NativeMethods55.SWS_BICUBIC, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            if (swsContext == IntPtr.Zero)
                throw new Exception();

            NativeMethods55.sws_scale(swsContext, frame.data, frame.linesize, 0, This.height, final.Handle.data, final.Handle.linesize);

            Stream str = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(str);
            // LITTLE ENDIAN!!
            writer.Write(new byte[] { 0x42, 0x4D });
            writer.Write((int)(count + 0x36));
            writer.Write((int)0);
            writer.Write((int)0x36);
            writer.Write((int)40);
            writer.Write((int)This.width);
            writer.Write((int)This.height);
            writer.Write((short)1);
            writer.Write((short)24);
            writer.Write((int)0);
            writer.Write((int)count);
            writer.Write((int)3780);
            writer.Write((int)3780);
            writer.Write((int)0);
            writer.Write((int)0);
            // Array::Reverse(bufferArr);

            byte[] buffer = new byte[count];
            Marshal.Copy(bufferArr, buffer, 0, count);
            for (int y = This.height - 1; y >= 0; y--)
                writer.Write(buffer, y * final.Handle.linesize[0], This.width * 3);
            writer.Flush();
            writer.Seek(0, SeekOrigin.Begin);

            Bitmap bitmap = new Bitmap(str);
            NativeMethods55.av_free(final.Ptr);
            Marshal.FreeHGlobal(bufferArr);
            //writer.Close();

            if (OnPacketDecodecd != null)
                OnPacketDecodecd(bitmap);

            writer.Close();
            return;
        }


        public event OnVideoDecodecdDelegate OnPacketDecodecd;
    }
}
