using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
namespace Multimedia
{
    public class AudioRender : IPipe
    {
        #region IPipe Members

        public bool ConnectTo(IPipe pipe)
        {
            throw new InvalidOperationException("Render should be the last one!");
        }

        public bool OnReceiveData(object packet)
        {
            // FIXME
            return true;
            //throw new NotImplementedException();
        }

        public bool Start()
        {
            return true;
            //throw new NotImplementedException();
        }

        public bool Stop()
        {
            return true;
            //throw new NotImplementedException();
        }

        public bool Close()
        {
            return true;
            //throw new NotImplementedException();
        }

        public bool Flush()
        {
            return true;
            //throw new NotImplementedException();
        }

        #endregion
    }
}
