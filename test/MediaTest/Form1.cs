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
using SDLLib;
using Multimedia;
using System.Diagnostics;

namespace MediaTest
{

    public partial class Form1 : Form
    {
        private Graphics graph;
        private Thread workingThread = null;
        private IntPtr waveOut = IntPtr.Zero;
        private SDLNative.SDL_AudioSpec wanted_spec;
        private bool salOpend = false;
        private SizeQueue<WaveDataType> queue = new SizeQueue<WaveDataType>(10,
            (t => { return; }));

        public Form1()
        {
            InitializeComponent();
            string myExeDir = (new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory.FullName;
            Environment.CurrentDirectory = myExeDir;
            graph = Graphics.FromHwnd(panelShow.Handle);
            var ret = SDLNative.SDL_Init(SDLNative.SDL_INIT_AUDIO | SDLNative.SDL_INIT_TIMER);
            if (ret != 0)
                Debug.WriteLine("SDL_Init fail");
        }

        //private void WriteWaveHeader(BinaryWriter writer, WaveDataType format)
        //{
        //    WAVE_Header wav_Header = new WAVE_Header();
        //    wav_Header.RIFF_ID[0] = 'R';
        //    wav_Header.RIFF_ID[1] = 'I';
        //    wav_Header.RIFF_ID[2] = 'F';
        //    wav_Header.RIFF_ID[3] = 'F';
        //    wav_Header.File_Size = waveDataSize + 36;
        //    wav_Header.RIFF_Type[0] = 'W';
        //    wav_Header.RIFF_Type[1] = 'A';
        //    wav_Header.RIFF_Type[2] = 'V';
        //    wav_Header.RIFF_Type[3] = 'E';

        //    wav_Header.FMT_ID[0] = 'f';
        //    wav_Header.FMT_ID[1] = 'm';
        //    wav_Header.FMT_ID[2] = 't';
        //    wav_Header.FMT_ID[3] = ' ';
        //    wav_Header.FMT_Size = 16;
        //    wav_Header.FMT_Tag = 0x0001;
        //    wav_Header.FMT_Channel = (ushort)format.channel;
        //    wav_Header.FMT_SamplesPerSec = format.sample_rate;

        //    var nBlockAlign = (short)(format.channel * (format.bit_per_sample / 8));
        //    var nAvgBytesPerSec = format.sample_rate * nBlockAlign;

        //    wav_Header.AvgBytesPerSec = nAvgBytesPerSec;
        //    wav_Header.BlockAlign = (ushort)nBlockAlign;
        //    wav_Header.BitsPerSample = (ushort)format.bit_per_sample;

        //    wav_Header.DATA_ID[0] = 'd';
        //    wav_Header.DATA_ID[1] = 'a';
        //    wav_Header.DATA_ID[2] = 't';
        //    wav_Header.DATA_ID[3] = 'a';
        //    wav_Header.DATA_Size = waveDataSize;


        //    int waveHdrSize = Marshal.SizeOf(wav_Header);
        //    var ptr = Marshal.AllocHGlobal(waveHdrSize);
        //    byte[] data = new byte[waveHdrSize];
        //    Marshal.StructureToPtr(wav_Header, ptr, false);
        //    Marshal.Copy(ptr, data, 0, waveHdrSize);
        //    writer.Seek(0, SeekOrigin.Begin);
        //    writer.Write(data);
        //    writer.Flush();
        //    Marshal.FreeHGlobal(ptr);
        //}
        private void AudioCallback(IntPtr userdata, IntPtr stream, int len)
        {
            WaveDataType frame;
            int left = len;
            if (queue.Dequeue(out frame))
            {
                uint sampleSize = (uint)(frame.size > len ? len : frame.size);
                IntPtr rawData = Marshal.AllocHGlobal(frame.managedData.Length);
                Marshal.Copy(frame.managedData, 0, rawData, frame.managedData.Length);
                SDLNative.SDL_MixAudio(stream, rawData, sampleSize, (int)SDLNative.SDL_MIX_MAXVOLUME);
                Marshal.Copy(frame.managedData, 0, stream, frame.managedData.Length);
                left -= (int)sampleSize;
                Marshal.FreeHGlobal(rawData);
                if (left <= 0)
                {
                    Debug.WriteLine(string.Format("left if {0}", left));
                    return;
                }
            }

        }

        private void OpenSDLAudio(WaveDataType data)
        {
            wanted_spec = new SDLNative.SDL_AudioSpec();
            wanted_spec.freq = data.sample_rate;
            wanted_spec.format = (ushort)((data.fmt == AV.AVSampleFormat.AV_SAMPLE_FMT_S16) ? SDLNative.AUDIO_S16SYS :
                (data.fmt == AV.AVSampleFormat.AV_SAMPLE_FMT_S32) ? SDLNative.AUDIO_S32SYS :
                SDLNative.AUDIO_S16SYS);
            wanted_spec.channels = (byte)data.channel;
            wanted_spec.silence = 0;
            wanted_spec.samples = (ushort)data.nb_samples;
            wanted_spec.callback = new SDLNative.SDL_AudioCallback(AudioCallback);
            wanted_spec.userdata = IntPtr.Zero;
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(wanted_spec));
            Marshal.StructureToPtr(wanted_spec, ptr, false);
            if (SDLNative.SDL_OpenAudio(ptr, IntPtr.Zero) < 0)
            {
                Debug.WriteLine("can't open audio.");
            }
            Marshal.FreeHGlobal(ptr);

            SDLNative.SDL_PauseAudio(0);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            string file = dialog.FileName;
            //writer.Seek(44, SeekOrigin.Begin);
            WaveDataType first = null;
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

                        queue.Enqueue(data);
                        if (salOpend == false)
                        {
                            OpenSDLAudio(data);
                            salOpend = true;
                        }
                    }
                    frame.Close();
                }
                stream.Close();
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


        private PlayerBase playerBase = null;

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            string file = dialog.FileName;

            playerBase = new PlayerBase(panelShow.Handle);
            playerBase.RenderFile(file);
            playerBase.Play();
        }

        private void progressBar_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
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
