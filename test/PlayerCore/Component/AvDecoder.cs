using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Multimedia
{
    public class AvDecoder : BaseComponent, IPipe, IDecoder
    {
        private AVFrameType type;
        public AVFrameType FrameType
        {
            get
            {
                return type;
            }
        }

        public AvDecoder(AVFrameType type)
        {
            this.type = type;
            InitPerfLog("[decoder " + type.ToString() + "]");
        }



        private SizeQueue<IAVFrame> queue = new SizeQueue<IAVFrame>(200,
            new FreeQueueItemDelegate<IAVFrame>(
                item => 
                    item.Close()
                ));

        public bool OnReceiveData(object packet)
        {
            return queue.Enqueue(packet as IAVFrame);
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
            //int videoFailCount = 0;
            //int audioFailCount = 0;

            while (true)
            {
                if (!threadWorking)
                    return;
                IAVFrame packet = null;
                if (queue.Dequeue(out packet) == false)
                    return;


                packet.Decode();

                PushToNext(packet);
                packet.Close();                
            }
        }


        public bool Stop()
        {
            threadWorking = false;
            queue.Close();
            StopNext();
            workingThread.Join();
            workingThread = null;
            return true;
        }

        public bool Close()
        {
            Stop();

            CloseNext();
            return true;
        }


        public bool ConnectTo(IPipe pipe)
        {
            this.AddPipe(pipe);
            return true;
        }


        public bool Flush()
        {
            queue.Flush();
            FlushNext();
            return true;
        }



        public int BufferDepth
        {
            get
            {
                return queue.Size;
            }
            set
            {
                queue.Size = value;
            }
        }
    }
}
