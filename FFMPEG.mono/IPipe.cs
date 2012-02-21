using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
namespace Multimedia
{
    public interface IPipe
    {
        bool ConnectTo(IPipe pipe);
        bool OnReceiveData(object packet);
        bool Start();
        bool Stop();
        bool Close();
        bool Flush();
    }
}
