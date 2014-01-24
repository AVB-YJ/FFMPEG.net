using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Multimedia;

namespace MediaTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
            timer.Interval = 100;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int pos = (int) b.Position;
            if (pos != -1)
                progressBar.Value = pos;
            else
                progressBar.Value = progressBar.Maximum;
        }
        private FFmpegBase b = null;
        Timer timer = new Timer();
        private void button1_Click(object sender, EventArgs e)
        {
            b = new FFmpegBase(panelShow.Handle);
            b.RenderFile(@"C:\Users\Public\Videos\Sample Videos\Wildlife.wmv");
            b.Play();
            progressBar.Minimum = 0;
            progressBar.Maximum = (int)b.Duration;
            timer.Start();

        }

        private bool closing = false;


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            closing = true;
            if (b != null)
                b.Stop();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            b = new FFmpegBase();
            b.RenderFile(@"C:\Users\Public\Music\Sample Music\Kalimba.mp3");
            b.Play();
        }

        private void progressBar_MouseClick(object sender, MouseEventArgs e)
        {

        }


    }
}
