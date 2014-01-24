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
        private NativeWrapper<NativeMethods.AVFormatContext> pFormatCtx;
        public FileReader(NativeWrapper<NativeMethods.AVFormatContext> pFormatCtx)
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
                IntPtr pPacket = Marshal.AllocHGlobal(Marshal.SizeOf(new NativeMethods.AVPacket()));
                NativeWrapper<NativeMethods.AVPacket> hPacket = new NativeWrapper<NativeMethods.AVPacket>(pPacket);
                if (NativeMethods.av_read_frame(pFormatCtx.Ptr, hPacket.Ptr) != 0)
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
                NativeMethods.av_close_input_file(pFormatCtx.Ptr);
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
