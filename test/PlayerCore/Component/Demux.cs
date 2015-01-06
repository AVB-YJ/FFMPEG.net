using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;

namespace Multimedia
{
    public class Demux : BaseComponent, IPipe
    {

        private Native<AV.AVFormatContext> pFormatCtx;
        public Demux(Native<AV.AVFormatContext> ctx)
        {
            InitPerfLog("[demux]");
            this.pFormatCtx = ctx;
        }

        public void Seek(long location)
        {
            foreach (var streamIndex in router.Keys)
            {
                AV.av_seek_frame(pFormatCtx.Ptr, streamIndex, location, AV.AVSEEK_FLAG_ANY);

            }
        }


        #region IPipe Members

        public bool ConnectTo(IPipe pipe)
        {
            AddPipe(pipe);
            return true;
        }

        private Dictionary<int, IPipe> router = new Dictionary<int, IPipe>();
        public bool OnReceiveData(object obj)
        {
            Native<AV.AVPacket> packet = obj as Native<AV.AVPacket>;
            if (packet == null)
                return false;
            AV.AVPacket handle = packet.Handle;
            IPipe pipe = null;
            lock (router)
            {
                if (router.ContainsKey(handle.stream_index))
                    pipe = router[handle.stream_index];
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
                        router.Add(decoder.StreamIndex, p);
                    }
                    if (decoder.StreamIndex == handle.stream_index)
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
