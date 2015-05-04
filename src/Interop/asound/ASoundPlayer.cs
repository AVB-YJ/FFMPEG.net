using System;
using System.Threading;
using ASoundLIb;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace SharpFFmpeg
{
	public class ASoundPlayer
	{
		public ASoundPlayer ()
		{


		}

		private Thread[] threads = new Thread[1];
		private bool threadWorking = false;
		private SizeQueue<WaveDataType> queue = new SizeQueue<WaveDataType>(200,
		                                                                    new FreeQueueItemDelegate<WaveDataType>(item =>
		                                        {
			return;
		}
		));
		private IntPtr pcm = IntPtr.Zero;



		public bool Start()
		{

			for (int i = 0; i < threads.Length; i++)
			{
				threads[i] = new Thread(new ThreadStart(WaveoutThread));
				threads[i].Start();
			}

			threadWorking = true;
			return true;
		}

		public void Stop()
		{
			//threadWorking = false;
			queue.Close();
			foreach (var thread in threads)
				thread.Join();
			//queue.Close ();
			if (pcm != IntPtr.Zero)
			{
				Asound.snd_pcm_close (pcm);
				pcm = IntPtr.Zero;
			}
		}

		public void PutSample(WaveDataType type)
		{
			int ret;
			int size = type.size;
			int rate = type.sample_rate == 0 ? 44100 : type.sample_rate;
			int bit = type.bit_per_sample == 0 ? 16 : type.bit_per_sample;
			int channel = type.channel == 0 ? 2 : type.channel;
			if (pcm == IntPtr.Zero)
			{
				int dir;

				string device = "default";
				ret = Asound.snd_pcm_open (out pcm, device, 
				                           Asound.snd_pcm_stream_t.SND_PCM_STREAM_PLAYBACK,
				                           0);
				if (ret < 0) {
					string err = Asound._snd_strerror(ret);
					Console.WriteLine(err);
					pcm = IntPtr.Zero;
					return;
				}
				else
				{
					Console.WriteLine("open audio device ok, pcm is {0}", pcm);
				}
				IntPtr param = Asound.snd_pcm_hw_params_alloca ();
				ret = Asound.snd_pcm_hw_params_any (pcm, param);
				ret = Asound.snd_pcm_hw_params_set_access (pcm, param, Asound.snd_pcm_access_t.SND_PCM_ACCESS_RW_INTERLEAVED);
				ret = Asound.snd_pcm_hw_params_set_format (pcm, param, Asound.snd_pcm_format_t.SND_PCM_FORMAT_S16_LE);
				ret = Asound.snd_pcm_hw_params_set_channels (pcm, param, channel);
				int val = rate;
				ret = Asound.snd_pcm_hw_params_set_rate_near (pcm, param, ref val, out dir);
				ulong frames = (ulong)type.nb_samples;
				ret = Asound.snd_pcm_hw_params_set_period_size_near (pcm, param, ref frames, out dir);
				ret = Asound.snd_pcm_hw_params (pcm, param);
				Asound.snd_pcm_params_free(param);

			}


			queue.Enqueue(type);
		}

		private int WriteWaveOut(IntPtr buf, int size)
		{
			int ret;
			uint pcmsize = (uint)size;
			ret = (int)Asound.snd_pcm_writei (pcm, buf, pcmsize);
			return ret;
		}

		private void WaveoutThread()
		{
			//int buffedSize = 0;
			List<byte> list = new List<byte>();
			int currentIndex = 0;
			while (threadWorking)
			{
				WaveDataType frame;
				if (!queue.Dequeue(out frame))
					break;

				if (currentIndex + frame.size < frame.size * 2)
				{
					list.AddRange(frame.managedData);
					currentIndex += frame.size;
				}
				else
				{
					int len = currentIndex;
					IntPtr buf = Marshal.AllocHGlobal(currentIndex);
					Marshal.Copy(list.ToArray(), 0, buf, currentIndex);
					list.Clear();
					currentIndex = 0;

					list.AddRange(frame.managedData);
					currentIndex += frame.size;

					WriteWaveOut(buf, frame.nb_samples);
					Marshal.FreeHGlobal(buf);
				}
				//WriteWaveOut(frame);
			}
		}
	}
}

