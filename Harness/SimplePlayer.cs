using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Multimedia.FFmpeg;
using System.Threading;

namespace v
{
    public partial class SimplePlayer : Form
    {
        private LinkedList<AvFrame> frames = new LinkedList<AvFrame>();
        private ManualResetEvent waiter = new ManualResetEvent(false);

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new SimplePlayer());
        }

        public SimplePlayer()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                DecodeWorker.RunWorkerAsync(filename);
            }
        }

        delegate void DisplayFrame(Bitmap frame);
        private void DisplayFrameNow(Bitmap frame)
        {
            frameDisplay.Image = frame;
            frameDisplay.Refresh();
        }

        private void DecodeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            AvFormatContext context = AvFormatContext.Open(e.Argument.ToString());
            AvStream videoStream = null; 
            foreach (AvStream stream in context.GetStreams())
            {
                if (stream.CodecContext.Type == CodecType.Video)
                    videoStream = stream;
            }

            AvCodec codec = videoStream.CodecContext.GetDecoder();
            codec.Open();

            System.Threading.Timer timer = new System.Threading.Timer(GetFrame, 
                null, 0, 80);
            AvFrame finsihedFrame = null;
            AvPacket pkt;
            while ((pkt = context.ReadFrame(null)) != null)
            {
                if (pkt.StreamIndex == videoStream.Index)
                {
                    finsihedFrame = codec.DecodeVideo(pkt);
                    if (finsihedFrame != null)
                    {
                        lock (frames)
                        {
                            frames.AddLast(finsihedFrame);
                            finsihedFrame = null;
                        }
                    }
                }
            }
        }

        private DateTime lastCall = DateTime.MinValue;

        private void GetFrame(object state)
        {
            if (lastCall != DateTime.MinValue)
            {
                TimeSpan span = DateTime.Now - lastCall;
                Console.WriteLine(span.Milliseconds);
            }
            lastCall = DateTime.Now;
            if (frames.Count == 0)
                return;
            AvFrame frame;
            lock (frames)
            {
                frame = frames.First.Value;
                frames.RemoveFirst();
            }
            Bitmap bmp = frame.ConvertToBitmap();
            Invoke(new DisplayFrame(DisplayFrameNow), bmp);
        }
    }
}