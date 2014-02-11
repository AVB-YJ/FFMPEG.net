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
        private NativeWrapper<NativeMethods55.AVFormatContext> pFormatCtx;
        public FileReader(NativeWrapper<NativeMethods55.AVFormatContext> pFormatCtx)
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
                IntPtr pPacket = Marshal.AllocHGlobal(Marshal.SizeOf(new NativeMethods55.AVPacket()));
                NativeWrapper<NativeMethods55.AVPacket> hPacket = new NativeWrapper<NativeMethods55.AVPacket>(pPacket);
                if (NativeMethods55.av_read_frame(pFormatCtx.Ptr, hPacket.Ptr) != 0)
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
             Stop();

            if (pFormatCtx != null)
            {
                NativeMethods55.av_close_input_file(pFormatCtx.Ptr);
                pFormatCtx = null;
            }

            return true;
        }

        public bool Flush()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
