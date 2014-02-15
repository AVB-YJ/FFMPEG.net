
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multimedia;
using SharpFFmpeg;

namespace mp3test
{
    class Program
    {
		static void TestCodec ()
		{
			NativeMethods55.avcodec_register_all();

			System.Type type = typeof(NativeMethods55.AVCodecID);
			foreach (string name in type.GetEnumNames()) {
				NativeMethods55.AVCodecID v = (NativeMethods55.AVCodecID)Enum.Parse(type, name);
				IntPtr codec = NativeMethods55.avcodec_find_decoder(v);
				string enabled = (codec == IntPtr.Zero) ? "disable" : "enable";
				if (codec == IntPtr.Zero)
					Console.WriteLine("{0}: {1}", name, enabled);
			}
		}

        static void Main(string[] args)
        {
			//TestCodec();


			var b = new FFmpegBase();
            b.RenderFile(@"/home/apa/1.mp3");
            b.Play();
            Console.ReadLine();
            
        }
    }
}
