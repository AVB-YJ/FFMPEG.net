using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multimedia
{
    internal class UnimplStream : IMediaStream
    {
        public bool Process(NativeWrapper<SharpFFmpeg.NativeMethods55.AVPacket> hPacket)
        {
            throw new NotImplementedException();
        }
    }
}
