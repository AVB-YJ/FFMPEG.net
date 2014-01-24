using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.IO;
using System.Runtime.InteropServices;

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
        private WaveLib.WaveOutPlayer m_Player = null;
        private WaveLib.FifoStream m_Fifo = new WaveLib.FifoStream();
        private byte[] m_PlayBuffer;
        private byte[] m_RecBuffer;
        private void PlayUsingWaveOut(AudioFrame frame)
        {
            int size = frame.size;
            IntPtr data = frame.sample;
            if (m_Player == null)
            {
                int rate = frame.rate == 0 ? 44100 : frame.rate;
                int bit = frame.bit == 0 ? 16 : frame.bit;
                int channel = frame.channel == 0 ? 2 : frame.channel;
                WaveLib.WaveFormat fmt = new WaveLib.WaveFormat(rate, bit, channel);
                m_Player = new WaveLib.WaveOutPlayer(-1, fmt, 16384, 3, new WaveLib.BufferFillEventHandler(Filler));

            }

            if (m_RecBuffer == null || m_RecBuffer.Length < size)
                m_RecBuffer = new byte[size];
            Marshal.Copy(data, m_RecBuffer, 0, size);
            m_Fifo.Write(m_RecBuffer, 0, m_RecBuffer.Length);
        }

        private void Filler(IntPtr data, int size)
        {
            if (m_PlayBuffer == null || m_PlayBuffer.Length < size)
                m_PlayBuffer = new byte[size];
            if (m_Fifo.Length >= size)
                m_Fifo.Read(m_PlayBuffer, 0, size);
            else
                for (int i = 0; i < m_PlayBuffer.Length; i++)
                    m_PlayBuffer[i] = 0;
            Marshal.Copy(m_PlayBuffer, 0, data, size);
        }
        #endregion

        public bool Start()
        {
            return true;
            //throw new NotImplementedException();
        }

        private void _Stop()
        {
            if (m_Player != null)
                try
                {
                    m_Player.Dispose();
                }
                finally
                {
                    m_Player = null;
                }
            m_Fifo.Flush(); // clear all pending data
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
