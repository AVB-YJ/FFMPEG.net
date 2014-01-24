using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace Multimedia
{
    public class FileReader : BaseComponent, IPipe
    {
        private NativeWrapper<FFmpeg.AVFormatContext> pFormatCtx;
        public FileReader(NativeWrapper<FFmpeg.AVFormatContext> pFormatCtx)
        {
            this.pFormatCtx = pFormatCtx;
        }


        #region IPipe Members

        public bool ConnectTo(IPipe pipe)
        {
            AddPipe(pipe);
            return true;
        }

        public bool OnReceiveData(object packet)
        {
            // nobody send packet to a reader!
            throw new InvalidOperationException("No one can send data to reader!");
        }

        private Thread workingThread = null;
        private bool threadWorking = false;
        public bool Start()
        {
            StartNext();
            workingThread = new Thread(new ThreadStart(() => DoThreadWork()));
            threadWorking = true;
            workingThread.Start();
            return true;

        }

        private void DoThreadWork()
        {
            while(true)
            {
                if( !threadWorking )
                    return;
                IntPtr pPacket = Marshal.AllocHGlobal(Marshal.SizeOf(new FFmpeg.AVPacket()));
                NativeWrapper<FFmpeg.AVPacket> hPacket = new NativeWrapper<FFmpeg.AVPacket>(pPacket);
                if (FFmpeg.av_read_frame(pFormatCtx.Ptr, hPacket.Ptr) != 0)
                {
                    break;
                }
                PushToNext(hPacket);
            }
        }

        public bool Stop()
        {
            threadWorking = false;
            StopNext();
            workingThread.Join();
            workingThread = null;
            return true;
        }

        public bool Close()
        {
            return Stop();
        }

        public bool Flush()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
