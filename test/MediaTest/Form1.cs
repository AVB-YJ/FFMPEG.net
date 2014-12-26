using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Multimedia;
using System.IO;
using SharpFFmpeg;
using System.Runtime.InteropServices;
using System.Threading;

namespace MediaTest
{
    public delegate void UpdateUI(Bitmap img);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string myExeDir = (new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location)).Directory.FullName;
            Environment.CurrentDirectory = myExeDir;

        }


        private FFmpegBase b = null;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            b = new FFmpegBase(panelShow.Handle);
            b.RenderFile(dialog.FileName);
            b.Play();

        }

        private bool closing = false;


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            if (b != null)
                b.Stop();

        }

        private void DrawImage(Bitmap img)
        {
            var videoGraphics = Graphics.FromHwnd(panelShow.Handle);
            videoGraphics.DrawImage(img, panelShow.Width, panelShow.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            string file = dialog.FileName;
            Thread t = new Thread(new ThreadStart(() => {
                var stream = FFMpegBase.Instance.GetAVStream(file);
                IAVFrame frame = null;
                while ((frame = stream.GetNext()) != null)
                {
                    if (frame.FrameType == AVFrameType.Video)
                    {
                        SharpFFmpeg.VideoFrame video = (SharpFFmpeg.VideoFrame)frame;
                        frame.Decode();
                        Bitmap img = video.Image;
                        if (InvokeRequired)
                        {
                            Invoke(new UpdateUI((i) => DrawImage(i)), new object[] { img });
                        }
                        else
                        {
                            DrawImage(img);
                        }
                    }
                    frame.Close();
                }
                GC.Collect();
            }));
            t.Start();

        }

        private void progressBar_MouseClick(object sender, MouseEventArgs e)
        {

        }


    }
}
