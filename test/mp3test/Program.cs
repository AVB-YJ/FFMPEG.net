using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpFFmpeg;
using ASoundLIb;
using System.IO;

namespace mp3test
{
    class Program
    {
		static void TestCodec ()
		{
			AV.avcodec_register_all();

			System.Type type = typeof(AV.AVCodecID);
			foreach (string name in type.GetEnumNames()) {
				AV.AVCodecID v = (AV.AVCodecID)Enum.Parse(type, name);
				IntPtr codec = AV.avcodec_find_decoder(v);
				string enabled = (codec == IntPtr.Zero) ? "disable" : "enable";
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
            string myExeDir = (new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory.FullName;
            Environment.CurrentDirectory = myExeDir;

			TestCodec();
            if (Environment.OSVersion.Platform == PlatformID.Unix)
			    TestAsound();
           Console.ReadLine();
            
        }
    }
}
