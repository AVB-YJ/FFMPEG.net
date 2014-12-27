using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SharpFFmpeg;
using System.Runtime.InteropServices;
using System.Threading;
using WaveLib;
using Multimedia;

namespace MediaTest
{

    public partial class Form1 : Form
    {
        private Graphics graph;
        private Thread workingThread = null;
        private IntPtr waveOut = IntPtr.Zero;
        private SizeQueue<WaveDataType> queue = new SizeQueue<WaveDataType>(50,
            new FreeQueueItemDelegate<WaveDataType>(item =>
            {
                return;
            }
        ));
        private Thread[] waveThread = new Thread[5];
        public Form1()
        {
            InitializeComponent();
            string myExeDir = (new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory.FullName;
            Environment.CurrentDirectory = myExeDir;
            graph = Graphics.FromHwnd(panelShow.Handle);
            for (var i = 0; i < waveThread.Length; i++)
            {
                waveThread[i] = new Thread(new ThreadStart(WaveoutThread));
                waveThread[i].Start();

            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            string file = dialog.FileName;
            workingThread = new Thread(new ThreadStart(() =>
            {
                var stream = FFMpegBase.Instance.GetAVStream(file);
                IAVFrame frame = null;
                while ( ((frame = stream.GetNext()) != null) && (!closing))
                {
                    if (frame.FrameType == AVFrameType.Video)
                    {
                        SharpFFmpeg.VideoFrame video = (SharpFFmpeg.VideoFrame)frame;
                        frame.Decode();
                        var data = video.ImgData;
                        DrawImage(data);
                    }
                    else if(frame.FrameType == AVFrameType.Audio)
                    {
                        SharpFFmpeg.AudioFrame audio = (SharpFFmpeg.AudioFrame)frame;
                        audio.Decode();
                        var data = audio.WaveDate;
                        if (waveOut == IntPtr.Zero)
                        {
                            WaveLib.WaveFormat fmt = new WaveLib.WaveFormat(data.rate, data.bit, data.channel);
                            int ret = WaveNative.waveOutOpen(out waveOut, -1, fmt, null, 0, WaveNative.CALLBACK_NULL);
                            if (ret != WaveNative.MMSYSERR_NOERROR)
                                throw new Exception("can not open wave device");
                        }
                        queue.Enqueue(data);
                    }
                    frame.Close();
                }
                stream.Close();
                if (waveOut != IntPtr.Zero)
                {
                    WaveNative.waveOutClose(waveOut);
                    waveOut = IntPtr.Zero;
                }
            }));
            workingThread.Start();
        }

        private bool closing = false;


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }



        private void DrawImage(VideoFrameType type)
        {
            Stream str = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(str);
            // LITTLE ENDIAN!!
            writer.Write(new byte[] { 0x42, 0x4D });
            writer.Write((int)(type.managedData.Length + 0x36));
            writer.Write((int)0);
            writer.Write((int)0x36);
            writer.Write((int)40);
            writer.Write((int)type.width);
            writer.Write((int)type.height);
            writer.Write((short)1);
            writer.Write((short)24);
            writer.Write((int)0);
            writer.Write((int)type.managedData.Length);
            writer.Write((int)3780);
            writer.Write((int)3780);
            writer.Write((int)0);
            writer.Write((int)0);
            for (int y = type.height - 1; y >= 0; y--)
                writer.Write(type.managedData, y * type.linesize, type.width * 3);
            writer.Flush();
            writer.Seek(0, SeekOrigin.Begin);
            Bitmap bitmap = new Bitmap(str);
            graph.DrawImage(bitmap, 0, 0, panelShow.Width, panelShow.Height);
            writer.Close();

        }

        private void WaveoutThread()
        {
            //int buffedSize = 0;
            List<byte> list = new List<byte>();
            int currentIndex = 0;
            while (!closing)
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

        private FFmpegBase playerBase = null;

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            string file = dialog.FileName;

            playerBase = new FFmpegBase(panelShow.Handle);
            playerBase.RenderFile(file);
            playerBase.Play();
        }

        private void progressBar_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            queue.Close();
            if (workingThread != null)
            {
                workingThread.Join();
                workingThread = null;
            }

            if (playerBase != null)
                playerBase.Stop();
        }
    }
}
