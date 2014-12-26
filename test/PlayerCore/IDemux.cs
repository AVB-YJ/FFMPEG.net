using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multimedia
{
    public interface IDecoder
    {
        int BufferDepth { get; set; }
    }
}
