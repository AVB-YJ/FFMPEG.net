using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;

namespace Multimedia
{
    public class Demux : BaseComponent, IPipe
    {

        private NativeWrapper<NativeMethods.AVFormatContext> pFormatCtx;
        public Demux(NativeWrapper<NativeMethods.AVFormatContext> ctx)
        {
            this.pFormatCtx = ctx;
        }

        public void Seek(long location)
        {
            foreach (var streamIndex in router.Keys)
            {
                NativeMethods.av_seek_frame(pFormatCtx.Ptr, streamIndex, location, NativeMethods.AVSEEK_FLAG_ANY);

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
            NativeWrapper<NativeMethods.AVPacket> packet = obj as NativeWrapper<NativeMethods.AVPacket>;
            if (packet == null)
                return false;
            NativeMethods.AVPacket handle = packet.Handle;
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
