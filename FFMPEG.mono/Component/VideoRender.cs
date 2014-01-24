using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
namespace Multimedia
{
    public class VideoRender : BaseComponent, IPipe, IVideoRender
    {
        private IntPtr videoWindow = IntPtr.Zero;
        private Graphics videoGraphics;
        private Rectangle videoWindowSize = new Rectangle();
        #region IPipe Members

        public bool ConnectTo(IPipe pipe)
        {
            throw new InvalidOperationException("Render should be the last one!");
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hwnd, ref Rectangle lpRect);

        public bool OnReceiveData(object packet)
        {
            VideoFrame frame = (VideoFrame)packet;

            if (videoWindow != IntPtr.Zero)
            {
                Bitmap pic = ConvertToBitmap(frame);
                videoGraphics.DrawImage(pic, 0, 0, videoWindowSize.Width, videoWindowSize.Height);
            }
            return true;
        }

        public bool Start()
        {
            return true;
        }

        public bool Stop()
        {
            return true;
        }

        public bool Close()
        {
            return true;
        }

        public bool Flush()
        {
            return true;
        }

        #endregion

        #region IVideoRender Members

        public IntPtr VideoWindow
        {
            get
            {
                return videoWindow;
            }
            set
            {
                videoWindow = value;
                videoGraphics = Graphics.FromHwnd(videoWindow);
                GetWindowRect(videoWindow, ref videoWindowSize);
            }
        }



        #endregion


        private Bitmap ConvertToBitmap(VideoFrame This)
		{
            var frame = ((NativeWrapper<NativeMethods.AVFrame>)This.ffmpegFrame).Handle;
			//FFmpeg.AVFrame final = gcnew AvFrame(PIX_FMT_BGR24, this->size);
            NativeWrapper<NativeMethods.AVFrame> final = new NativeWrapper<NativeMethods.AVFrame>(NativeMethods.avcodec_alloc_frame());

            int dst_fmt = (int)NativeMethods.PixelFormat.PIX_FMT_BGR24;

			int count = NativeMethods.avpicture_get_size(dst_fmt, This.width, This.height);

            IntPtr bufferArr = Marshal.AllocHGlobal(count);

            NativeMethods.avpicture_fill(final.Ptr, bufferArr, dst_fmt, This.width, This.height);

            IntPtr swsContext = NativeMethods.sws_getContext(This.width, This.height, (int)This.format,
                This.width, This.height, dst_fmt, NativeMethods.SWS_BICUBIC, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
			if(swsContext == IntPtr.Zero)
				throw new Exception();
            
            NativeMethods.sws_scale(swsContext, frame.data, frame.linesize, 0, This.height, final.Handle.data, final.Handle.linesize);

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
			for(int y = This.height - 1; y >= 0; y--)
				writer.Write(buffer, y * final.Handle.linesize[0], This.width * 3);
			writer.Flush();
			writer.Seek(0,  SeekOrigin.Begin);

			Bitmap bitmap = new Bitmap(str);
            NativeMethods.av_free(final.Ptr);
            Marshal.FreeHGlobal(bufferArr);
            //writer.Close();
			return bitmap;
		}





    }
}
