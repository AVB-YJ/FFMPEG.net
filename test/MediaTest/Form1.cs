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
        }


        private FFmpegBase b = null;
        private void button1_Click(object sender, EventArgs e)
        {
            b = new FFmpegBase(panelShow.Handle);
            b.RenderFile(@"/home/user/Wildlife.wmv");
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

        private void button2_Click(object sender, EventArgs e)
        {
            b = new FFmpegBase();
            b.RenderFile(@"C:\Users\Public\Music\Sample Music\1.mp3");
            b.Play();
        }

        private void progressBar_MouseClick(object sender, MouseEventArgs e)
        {

        }


    }
}
