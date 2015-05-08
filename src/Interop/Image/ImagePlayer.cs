using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SharpFFmpeg
{
    public class ImagePlayer
    {
        private Thread[] threads = new Thread[1];
        private bool threadWorking = false;
        private SizeQueue<VideoFrameType> queue = new SizeQueue<VideoFrameType>(200,
            new FreeQueueItemDelegate<VideoFrameType>(item =>
            {
                return;
            }
        ));
        private Graphics graphics = null;
        private int width, height;

        public ImagePlayer(IntPtr wnd, int width, int height)
        {
            graphics = Graphics.FromHwnd(wnd);
            this.width = width;
            this.height = height;
        }

        public bool Start()
        {

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(ImageThread));
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

            if (graphics != null)
            {
                graphics.Dispose();
            }
        }

        public void PutImage(VideoFrameType type)
        {
            queue.Enqueue(type);
        }

        private void ImageThread()
        {
            while (threadWorking)
            {
                VideoFrameType type;
                if (!queue.Dequeue(out type))
                    break;

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
                graphics.DrawImage(bitmap, 0, 0, width, height);
                bitmap.Dispose();
                writer.Close();
            }

        }


    }
}
