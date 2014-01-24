using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;


namespace Multimedia
{
    public class VideoFrame
    {
        public object ffmpegFrame;
        public int format;
        public int width;
        public int height;
    }


    public interface IVideoRender
    {
        IntPtr VideoWindow { get; set; }
    }
}
