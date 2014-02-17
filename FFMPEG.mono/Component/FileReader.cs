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
        private Native<AV.AVFormatContext> pFormatCtx;
        public FileReader(Native<AV.AVFormatContext> pFormatCtx)
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
                IntPtr pPacket = Marshal.AllocHGlobal(Marshal.SizeOf(new AV.AVPacket()));
                Native<AV.AVPacket> hPacket = new Native<AV.AVPacket>(pPacket);
                if (AV.av_read_frame(pFormatCtx.Ptr, hPacket.Ptr) != 0)
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
                AV.av_close_input_file(pFormatCtx.Ptr);
                pFormatCtx = null;
            }

            CloseNext();

            return true;
        }

        public bool Flush()
        {
            FlushNext();
            return true;
        }

        #endregion
    }
}
