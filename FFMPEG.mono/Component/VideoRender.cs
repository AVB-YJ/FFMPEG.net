using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
namespace Multimedia
{
    public class VideoRender : IPipe, IVideoRender
    {

        private IntPtr videoWindow;
        #region IPipe Members

        public bool ConnectTo(IPipe pipe)
        {
            throw new InvalidOperationException("Render should be the last one!");
        }

        public bool OnReceiveData(object packet)
        {
            NativeWrapper<FFmpeg.AVFrame> frame = (NativeWrapper<FFmpeg.AVFrame>)packet;

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
            }
        }

        #endregion
    }
}
