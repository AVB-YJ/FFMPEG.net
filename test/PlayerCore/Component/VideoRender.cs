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
                ConvertToBitmapAndDraw(frame);
                
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
				if (value != IntPtr.Zero)
				{

                	videoWindow = value;
                	videoGraphics = Graphics.FromHwnd(videoWindow);
                    //if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                    //{
                    //    GetWindowRect(videoWindow, ref videoWindowSize);
                    //}
                    //else
					{
						videoWindowSize.Width= (int)videoGraphics.VisibleClipBounds.Width;
						videoWindowSize.Height = (int)videoGraphics.VisibleClipBounds.Height;
					}
				
				}

            }
        }



        #endregion


        private void ConvertToBitmapAndDraw(VideoFrame This)
		{
            var type = This.ImgData;
            Stream str = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(str);
            // LITTLE ENDIAN!!
            writer.Write(new byte[] { 0x42, 0x4D });
            writer.Write((int)(type.managedData.Length + 0x36));
            writer.Write((int)0);
            writer.Write((int)0x36);
            writer.Write((int)40);
            writer.Write((int)type.width);
            writer.Write((int)type.height);
            writer.Write((short)1);
            writer.Write((short)24);
            writer.Write((int)0);
            writer.Write((int)type.managedData.Length);
            writer.Write((int)3780);
            writer.Write((int)3780);
            writer.Write((int)0);
            writer.Write((int)0);
            for (int y = type.height - 1; y >= 0; y--)
                writer.Write(type.managedData, y * type.linesize, type.width * 3);
            writer.Flush();
            writer.Seek(0, SeekOrigin.Begin);
            Bitmap bitmap = new Bitmap(str);
            videoGraphics.DrawImage(bitmap, 0, 0, videoWindowSize.Width, videoWindowSize.Height);
            writer.Close();
        }





    }
}
