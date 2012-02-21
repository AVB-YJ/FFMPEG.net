using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
namespace Multimedia
{
    public class VideoRender : IPipe
    {
        #region IPipe Members

        public bool ConnectTo(IPipe pipe)
        {
            throw new NotImplementedException();
        }

        public bool OnReceiveData(object packet)
        {
            throw new NotImplementedException();
        }

        public bool Start()
        {
            throw new NotImplementedException();
        }

        public bool Stop()
        {
            throw new NotImplementedException();
        }

        public bool Close()
        {
            throw new NotImplementedException();
        }

        public bool Flush()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
