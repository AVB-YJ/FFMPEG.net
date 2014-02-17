
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Multimedia;
using SharpFFmpeg;
using ASoundLIb;

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

		static void TestAsound()
		{
			IntPtr pcm = IntPtr.Zero;
			int ret = Asound.snd_pcm_open(out pcm, "default", Asound.snd_pcm_stream_t.SND_PCM_STREAM_PLAYBACK, 0);
			if (ret < 0)
			{
				Console.WriteLine("Open error, {0}", Asound._snd_strerror(ret));
				return;
			}
			else
			{
				Console.WriteLine("Open ok");
				Asound.snd_pcm_close(pcm);
			}
		}

        static void Main(string[] args)
        {
			//TestCodec();

			TestAsound();
			return;
			var b = new FFmpegBase();
            b.RenderFile(@"/home/apa/1.mp3");
            b.Play();
            Console.ReadLine();
            
        }
    }
}
