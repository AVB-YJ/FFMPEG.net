using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multimedia
{
    public class AudioFrame
    {
        public IntPtr sample;
        public int size;
        public int rate;
        public int bit;
        public int channel;
        public int fmt;
        public int nb_samples;
        public byte[] managedData;
    }


}
