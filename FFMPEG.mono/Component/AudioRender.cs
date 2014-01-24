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
            // throw new InvalidOperationException("Render should be the last one!");
            // FIXME
            return true;
        }

        public bool OnReceiveData(object packet)
        {
            // FIXME
            AudioFrame frame = (AudioFrame)packet;

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                PlayUsingWaveOut(frame);
            }

            return true;
            //throw new NotImplementedException();
        }

        #region windows only
        private IntPtr waveOut = IntPtr.Zero;
        BaseComponent.SizeQueue<AudioFrame> queue = new BaseComponent.SizeQueue<AudioFrame>(50);
        Thread[] threads = new Thread[1];
        private bool threadWorking = false;
        private void PlayUsingWaveOut(AudioFrame frame)
        {
            //return;

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

                if (currentIndex + frame.size < 196001)
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
            for (int i = 0; i < threads.Length; i++ )
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
            foreach(var thread in threads)
            {
                thread.Join();
            }

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
