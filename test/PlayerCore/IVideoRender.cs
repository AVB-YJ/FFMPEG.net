using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;


namespace Multimedia
{

    public interface IVideoRender
    {
        IntPtr VideoWindow { get; set; }
    }
}
