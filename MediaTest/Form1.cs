using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Multimedia;
using System.Threading;
using WaveLib;
using System.Runtime.InteropServices;

namespace MediaTest
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hwnd, ref Rectangle lpRect);


        public Form1()
        {
            InitializeComponent();
            videoGraphics = Graphics.FromHwnd(this.panelShow.Handle);
            GetWindowRect(this.panelShow.Handle, ref videoWindowSize);
        }


        private MediaStream stream = null;
        Thread t = null;
        private void button1_Click(object sender, EventArgs e)
        {
            t = new Thread(new ThreadStart( () =>
                {
                    stream = new MediaStream(@"C:\Users\Public\Videos\Sample Videos\Wildlife.wmv");
                    //stream = new MediaStream(@"C:\Users\Public\Music\Sample Music\1.mp3");
                    //if (stream.Audio != null)
                    //    stream.Audio.OnPacketDecoded += Audio_OnPacketDecoded;

                    if (stream.Video != null)
                        stream.Video.OnPacketDecodecd += Video_OnPacketDecodecd;
                    while ((!closing))
                    {
                        stream.ProcessNext();
                    }
                }));
            t.Start();
        }

        private IntPtr waveOut = IntPtr.Zero;

        void Audio_OnPacketDecoded(IntPtr sample, int size, int sample_rate, int channels, int bit_persample)
        {
            PlayUsingWaveOut(sample, size, sample_rate, channels, bit_persample);
        }

        private void PlayUsingWaveOut(IntPtr sample, int size, int sample_rate, int channels, int bit_persample)
        {
            int ret;
            IntPtr data = sample;
            int rate = sample_rate == 0 ? 44100 : sample_rate;
            int bit = bit_persample == 0 ? 16 : bit_persample;
            int channel = channels == 0 ? 2 : channels;
            if (waveOut == IntPtr.Zero)
            {
                WaveLib.WaveFormat fmt = new WaveLib.WaveFormat(rate, bit, channel);
                ret = WaveNative.waveOutOpen(out waveOut, -1, fmt, null, 0, WaveNative.CALLBACK_NULL);
                if (ret != WaveNative.MMSYSERR_NOERROR)
                    throw new Exception("can not open wave device");
            }

            WriteWaveOut(sample, size);
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


            ret = WaveNative.waveOutWrite(waveOut, ref m_Header, Marshal.SizeOf(m_Header));

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



        private Graphics videoGraphics;
        private Rectangle videoWindowSize = new Rectangle();
        void Video_OnPacketDecodecd(Bitmap packet)
        {
            videoGraphics.DrawImage(packet, 0, 0, videoWindowSize.Width, videoWindowSize.Height);
        }


        private bool closing = false;


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            if (t != null)
                t.Join();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void progressBar_MouseClick(object sender, MouseEventArgs e)
        {

        }


    }
}
