using SharpFFmpeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using WaveLib;

namespace SharpFFmpeg
{
    public class WavePlayer
    {
        private Thread[] threads = new Thread[2];
        private bool threadWorking = false;
        private SizeQueue<WaveDataType> queue = new SizeQueue<WaveDataType>(200,
            new FreeQueueItemDelegate<WaveDataType>(item =>
            {
                return;
            }
        ));
        private IntPtr waveOut = IntPtr.Zero;

        public WavePlayer()
        {

        }


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

        public void PutSample(WaveDataType type)
        {
            int ret;
            int size = type.size;
            int rate = type.sample_rate == 0 ? 44100 : type.sample_rate;
            int bit = type.bit_per_sample == 0 ? 16 : type.bit_per_sample;
            int channel = type.channel == 0 ? 2 : type.channel;
            if (waveOut == IntPtr.Zero)
            {
                WaveLib.WaveFormat fmt = new WaveLib.WaveFormat(rate, bit, channel);
                ret = WaveNative.waveOutOpen(out waveOut, -1, fmt, null, 0, WaveNative.CALLBACK_NULL);
                if (ret != WaveNative.MMSYSERR_NOERROR)
                    throw new Exception("can not open wave device");
            }


            queue.Enqueue(type);
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
    }
}
