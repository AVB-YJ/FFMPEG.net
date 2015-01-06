using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;

namespace Multimedia
{
    public class Demux : BaseComponent, IPipe
    {

        public Demux()
        {
            InitPerfLog("[Demux]");
        }

        public void Seek(long location)
        {
        }


        #region IPipe Members

        public bool ConnectTo(IPipe pipe)
        {
            AddPipe(pipe);
            return true;
        }

        private Dictionary<AVFrameType, IPipe> router = new Dictionary<AVFrameType, IPipe>();
        public bool OnReceiveData(object obj)
        {
            IAVFrame packet = (IAVFrame)obj;
            if (packet == null)
                return false;
            IPipe pipe = null;
            lock (router)
            {
                if (router.ContainsKey(packet.FrameType))
                    pipe = router[packet.FrameType];
            }
            if (pipe == null)
            {
                List<IPipe> list = null;
                lock (nextComponents)
                {
                    list = new List<IPipe>(nextComponents);
                }
                foreach (IPipe p in list)
                {
                    AvDecoder decoder = p as AvDecoder;
                    if (decoder == null)
                        continue;
                    lock (router)
                    {
                        router.Add(decoder.FrameType, p);
                    }
                    if (decoder.FrameType == packet.FrameType)
                        pipe = p;
                }
            }
            if (pipe == null)
                return false;
            RecordLog();
            pipe.OnReceiveData(obj);
            
            return true;
        }

        public bool Start()
        {
            StartNext();
            return true;
        }

        public bool Stop()
        {
            StopNext();
            router.Clear();
            return true;
        }

        public bool Close()
        {
            Stop();

            CloseNext();
            router.Clear();
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
