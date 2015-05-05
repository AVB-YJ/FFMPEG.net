using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using WaveLib;
using ASoundLIb;
#if WIN32

#else
using Gdk;
#endif


namespace Multimedia
{


    public class AudioRender : BaseComponent, IPipe
    {

        public AudioRender()
        {
            InitPerfLog("[Render Audio]");
        }

        #region IPipe Members

        public bool ConnectTo(IPipe pipe)
        {
            return true;
        }


        public bool OnReceiveData (object packet)
		{
            RecordLog();
			AudioFrame frame = (AudioFrame)packet;


			if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
				PlayUsingWaveOut (frame);
			} else if (Environment.OSVersion.Platform == PlatformID.Unix) {
				PlayUsingASound(frame);
			}

            //AV.av_free(o.sample);
            //Marshal.FreeHGlobal(o.sample);

            return true;
            //throw new NotImplementedException();
        }

		#region linux only

		private IntPtr pcm = IntPtr.Zero;

		void PlayUsingASound (AudioFrame frame)
		{
            var type = frame.WaveDate;
			int ret = 0;
			if (pcm == IntPtr.Zero) {
				int dir;
                int rate = type.bit_rate == 0 ? 44100 : type.bit_rate;

                int channel = type.channel == 0 ? 2 : type.channel;

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
			if (pcm == IntPtr.Zero)
				return;

            //long r = Asound.snd_pcm_writei(pcm, type, (ulong)type.nb_samples);
            //Console.WriteLine("snd_pcm_writei {0}:{1}, return {2}", type.sample, type.nb_samples, r);
		}
		#endregion

        #region windows only
        private IntPtr waveOut = IntPtr.Zero;
        BaseComponent.SizeQueue<WaveDataType> queue = new BaseComponent.SizeQueue<WaveDataType>(50,
            new BaseComponent.FreeQueueItemDelegate<WaveDataType>(item =>
            {
                return;
            }
                ));
        Thread[] threads = new Thread[2];
        private bool threadWorking = false;
        private void PlayUsingWaveOut(AudioFrame frame)
        {
            var type = frame.WaveDate;
            int ret;
            int size = type.size;
            int rate = type.sample_rate == 0 ? 44100 : type.sample_rate;
            int bit = type.bit_per_sample == 0 ? 16 : type.bit_per_sample;
            int channel = type.channel == 0 ? 2 : type.channel;
            if (waveOut == IntPtr.Zero){
                WaveLib.WaveFormat fmt = new WaveLib.WaveFormat(rate, bit, channel);
                ret = WaveNative.waveOutOpen(out waveOut, -1, fmt, null, 0, WaveNative.CALLBACK_NULL);
                if (ret != WaveNative.MMSYSERR_NOERROR)
                    throw new Exception("can not open wave device");
            }


            queue.Enqueue(type);
            //ret = WriteWaveOut(frame);
        }

        private int WriteWaveOut(IntPtr buf, int size)
        {
            int ret;
            WaveNative.WaveHdr m_Header = new WaveNative.WaveHdr(); ;
            GCHandle m_HeaderHandle = GCHandle.Alloc(m_Header, GCHandleType.Pinned);
            m_Header.dwUser = (IntPtr)GCHandle.Alloc(this);
            m_Header.lpData = buf;
            m_Header.dwBufferLength = size;
            ret = WaveNative.waveOutPrepareHeader(waveOut, ref m_Header, Marshal.SizeOf(m_Header));
            if (ret != WaveNative.MMSYSERR_NOERROR)
                throw new Exception("can not open wave device");

            lock (queue)
            {
                ret = WaveNative.waveOutWrite(waveOut, ref m_Header, Marshal.SizeOf(m_Header));
            }
            if (ret != WaveNative.MMSYSERR_NOERROR)
                throw new Exception("can not open wave device");

            while (WaveNative.waveOutUnprepareHeader(waveOut, ref m_Header, Marshal.SizeOf(m_Header)) == WaveNative.WAVERR_STILLPLAYING)
            {
                Thread.Sleep(5);
            }

            ((GCHandle)m_Header.dwUser).Free();
            m_HeaderHandle.Free();
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

                    WriteWaveOut(buf, len);
                    Marshal.FreeHGlobal(buf);
                }
                //WriteWaveOut(frame);
            }
        }
        #endregion

        public bool Start()
        {

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(WaveoutThread));
                threads[i].Start();
            }
            
            threadWorking = true;
            return true;
            //throw new NotImplementedException();
        }

        private void _Stop()
        {
            threadWorking = false;
            queue.Close();
            foreach (var thread in threads)
                thread.Join();

            if (waveOut != IntPtr.Zero)
            {
                WaveNative.waveOutClose(waveOut);
                waveOut = IntPtr.Zero;
            }

            if (pcm != IntPtr.Zero)
            {
                Asound.snd_pcm_close(pcm);
                pcm = IntPtr.Zero;
            }
        }


        public bool Stop()
        {
            _Stop();
            return true;
            //throw new NotImplementedException();
        }

        public bool Close()
        {
            Stop();
            return true;
            //throw new NotImplementedException();
        }

        public bool Flush()
        {
            queue.Flush();
            return true;
            //throw new NotImplementedException();
        }

        #endregion
    }
}
