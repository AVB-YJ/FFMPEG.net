using Multimedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp3test
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new FFmpegBase();
            b.RenderFile(@"C:\Users\Public\Music\Sample Music\1.mp3");
            b.Play();
            Console.ReadLine();
        }
    }
}
