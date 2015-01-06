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
        private IFFMpeg ffmpeg;
        private string fileName;
        private IAVStream stream = null;
        public FileReader(IFFMpeg ffmpeg, string fileName)
        {
            this.ffmpeg = ffmpeg;
            this.fileName = fileName;
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
            stream = ffmpeg.GetAVStream(fileName);
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
                IAVFrame frame = stream.GetNext();
                PushToNext(frame);
            }
        }

        public bool Stop()
        {
            threadWorking = false;
            StopNext();
            workingThread.Join();
            workingThread = null;
            stream.Close();
            return true;
        }

        public bool Close()
        {
             Stop();

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
