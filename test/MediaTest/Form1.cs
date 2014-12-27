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

namespace MediaTest
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string myExeDir = (new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory.FullName;
            Environment.CurrentDirectory = myExeDir;
            graph = Graphics.FromHwnd(panelShow.Handle);

        }
        private Graphics graph;
        private Thread workingThread = null;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            if (workingThread != null)
            {
                workingThread.Join();
                workingThread = null;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void progressBar_MouseClick(object sender, MouseEventArgs e)
        {

        }


    }
}
