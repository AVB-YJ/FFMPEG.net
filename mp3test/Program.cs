
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multimedia;

namespace mp3test
{
    class Program
    {
        static void Main(string[] args)
        {
			var b = new FFmpegBase();
            b.RenderFile(@"1.mp3");
            b.Play();
            Console.ReadLine();
        }
    }
}
