using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using WaveLib;

namespace Multimedia
{


    public class AudioRender : IPipe
    {



        #region IPipe Members

        public bool ConnectTo(IPipe pipe)
        {
            return true;
        }

        private void ConvertAudioSample(AudioFrame input, out AudioFrame output)
        {
            output = new AudioFrame();
            output.channel = input.channel;
            output.rate = input.rate;
            output.bit = 16;
            output.nb_samples = input.nb_samples;
            output.fmt = (int)(NativeMethods55.AVSampleFormat.AV_SAMPLE_FMT_S16);
            output.sample = Marshal.AllocHGlobal(NativeMethods55.AVCODEC_MAX_AUDIO_FRAME_SIZE*2+16);
            int bytePerSample = NativeMethods55.av_get_bytes_per_sample((NativeMethods55.AVSampleFormat)output.fmt);
            output.size = output.nb_samples * bytePerSample;

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
                Marshal.FreeHGlobal(output.sample);
                output = null;
            }
        }

        public bool OnReceiveData(object packet)
        {

            AudioFrame frame = (AudioFrame)packet;
            AudioFrame o;
            ConvertAudioSample(frame, out o);
            if (o == null)
                return true;

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                PlayUsingWaveOut(frame);
            }

            //NativeMethods55.av_free(o.sample);
            Marshal.FreeHGlobal(o.sample);

            return true;
            //throw new NotImplementedException();
        }

        #region windows only
        private IntPtr waveOut = IntPtr.Zero;
        BaseComponent.SizeQueue<AudioFrame> queue = new BaseComponent.SizeQueue<AudioFrame>(50);
        Thread threads = null;
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
                Thread.Sleep(10);
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

                if (currentIndex + frame.size < 65536 * 10)
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

            threads = new Thread(new ThreadStart(WaveoutThread));
            threads.Start();
            threadWorking = true;
            return true;
            //throw new NotImplementedException();
        }

        private void _Stop()
        {
            threadWorking = false;
            queue.Close();
            threads.Join();

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
