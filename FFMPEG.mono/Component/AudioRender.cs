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



namespace Multimedia
{


    public class AudioRender : IPipe
    {



        #region IPipe Members

        public bool ConnectTo(IPipe pipe)
        {
            return true;
        }

        private void ConvertAudioSample(AudioFrame input)
        {

            if (input.fmt == (int)NativeMethods55.AVSampleFormat.AV_SAMPLE_FMT_FLTP)
            {
                System.Single val = new System.Single();
                if (input.channel == 1)
                {
                    for (int i = 0; i < input.nb_samples; i++)
                    {
                        IntPtr address =  new IntPtr(input.sample.ToInt64() + i * Marshal.SizeOf(val));
                        val = (System.Single)Marshal.PtrToStructure(address, typeof(System.Single));
                        if (val < -1.0)
                            val = -1.0f;
                        else if (val > 1.0)
                            val = 1.0f;
                        Int16 target = (Int16)( val * 32767.0f);

                        IntPtr address2 = new IntPtr(input.sample.ToInt64() + i * Marshal.SizeOf(target));
                        Marshal.WriteInt16(address2, target);
                    }
                }
                else if (input.channel == 2)
                {
                    for (int i = 0; i < input.nb_samples; i++)
                    {
                        // channel 1
                        IntPtr address = new IntPtr(input.sample.ToInt64() + i * Marshal.SizeOf(val));
                        val = (System.Single) Marshal.PtrToStructure(address, typeof(System.Single));
                        if (val < -1.0)
                            val = -1.0f;
                        else if (val > 1.0)
                            val = 1.0f;
                        Int16 target = (Int16)(val * 32767.0f);

                        IntPtr address2 = new IntPtr(input.sample.ToInt64() + (i*2) * Marshal.SizeOf(target));
                        Marshal.WriteInt16(address2, target);

                        // channel 2
                        address = new IntPtr(input.sample.ToInt64() + (i+1) * Marshal.SizeOf(val));
                        val = (System.Single)Marshal.PtrToStructure(address, typeof(System.Single));
                        if (val < -1.0)
                            val = -1.0f;
                        else if (val > 1.0)
                            val = 1.0f;
                        target = (Int16)(val * 32767.0f);

                        address2 = new IntPtr(input.sample.ToInt64() + (i * 2 + 1) * Marshal.SizeOf(target));
                        Marshal.WriteInt16(address2, target);
                    }
                }
            }
            else
            {
                // FIXME
                // add convert from other format to AV_SAMPLE_FMT_S16

            }
        }

        public bool OnReceiveData (object packet)
		{

			AudioFrame frame = (AudioFrame)packet;
			ConvertAudioSample (frame);


			if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
				PlayUsingWaveOut (frame);
			} else if (Environment.OSVersion.Platform == PlatformID.Unix) {
				PlayUsingASound(frame);
			}

            //NativeMethods55.av_free(o.sample);
            //Marshal.FreeHGlobal(o.sample);

            return true;
            //throw new NotImplementedException();
        }

		#region linux only

		private IntPtr pcm = IntPtr.Zero;

		void PlayUsingASound (AudioFrame frame)
		{
			int ret = 0;
			if (pcm == IntPtr.Zero) {
				int dir;
				int rate = frame.rate == 0 ? 44100 : frame.rate;
			
				int channel = frame.channel == 0 ? 2 : frame.channel;

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
				ulong frames = (ulong)frame.nb_samples;
				ret = Asound.snd_pcm_hw_params_set_period_size_near (pcm, param, ref frames, out dir);
				ret = Asound.snd_pcm_hw_params (pcm, param);
				Asound.snd_pcm_params_free(param);
			}
			if (pcm == IntPtr.Zero)
				return;

			long r = Asound.snd_pcm_writei(pcm,frame.sample,(ulong)frame.nb_samples);
			Console.WriteLine("snd_pcm_writei {0}:{1}, return {2}", frame.sample, frame.nb_samples, r);
		}
		#endregion

        #region windows only
        private IntPtr waveOut = IntPtr.Zero;
        BaseComponent.SizeQueue<AudioFrame> queue = new BaseComponent.SizeQueue<AudioFrame>(50);
        Thread[] threads = new Thread[1];
        private bool threadWorking = false;
        private void PlayUsingWaveOut(AudioFrame frame)
        {
            int ret;
            int size = frame.size;
            IntPtr data = frame.sample;
            int rate = frame.rate == 0 ? 44100 : frame.rate;
            int bit = frame.bit == 0 ? 16 : frame.bit;
            int channel = frame.channel == 0 ? 2 : frame.channel;
            if (waveOut == IntPtr.Zero){
                WaveLib.WaveFormat fmt = new WaveLib.WaveFormat(rate, bit, channel);
                ret = WaveNative.waveOutOpen(out waveOut, -1, fmt, null, 0, WaveNative.CALLBACK_NULL);
                if (ret != WaveNative.MMSYSERR_NOERROR)
                    throw new Exception("can not open wave device");
            }


            frame.managedData = new byte[frame.size];
            Marshal.Copy(frame.sample, frame.managedData, 0, frame.size);
            queue.Enqueue(frame);
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
                AudioFrame frame;
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
        }


        public bool Stop()
        {
            _Stop();
            return true;
            //throw new NotImplementedException();
        }

        public bool Close()
        {
            return true;
            //throw new NotImplementedException();
        }

        public bool Flush()
        {
            return true;
            //throw new NotImplementedException();
        }

        #endregion
    }
}
