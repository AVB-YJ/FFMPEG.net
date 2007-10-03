using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

using Multimedia.FFmpeg;

namespace Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            AvFormatContext context = AvFormatContext.Open(@"D:\Breach.DVDRip.XviD-DMT\CD1\dmt-breach-cd1.avi");
            string s = context.ToString();
            AvStream[] streams = context.GetStreams();
                    
            AvStream videoStream = null, audioStream = null;

            foreach (AvStream stream in streams)
            {
                switch (stream.CodecContext.Type)
                {
                    case CodecType.Video:
                        videoStream = stream;
                        break;
                    case CodecType.Audio:
                        audioStream = stream;
                        break;
                }
            }

            if (videoStream == null)
                return;

            AvCodec videoCodec = videoStream.CodecContext.GetCodec();
            AvCodec audioCodec = audioStream.CodecContext.GetCodec();

            videoCodec.Open(videoStream.CodecContext);
            audioCodec.Open(audioStream.CodecContext);

            AvFrame finsihedFrame = null;
            AvPacket pkt;
            int frame = 0;
            for (int i = 0; i < 500000; i++)
            {
                pkt = context.ReadFrame(null);
                if (pkt.StreamIndex == videoStream.Index ) {
                        finsihedFrame = videoCodec.DecodeVideo(pkt);
                        if (finsihedFrame != null)
                        {
                            Console.WriteLine("Frame format: " + finsihedFrame.Format + " (" + finsihedFrame.Width + "x" + finsihedFrame.Height + ")");
                            Bitmap p = finsihedFrame.ConvertToBitmap();
                            p.Save(@"C:\out\frame" + frame + @".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            p.Dispose();
                            finsihedFrame.Dispose();
                            finsihedFrame = null;
                            ++frame;
                        }
                }
                else if(pkt.StreamIndex == audioStream.Index)
                {
                        AvSamples samples = audioCodec.DecodeAudio(pkt);
                        if (samples.Count > 0)
                            Console.WriteLine("Audio Format: " + samples.Format + " (" + samples.Count + " samples)");
                }
                else
                    Console.WriteLine("Erorr");
                pkt.Dispose();
            }
            return;
        }
    }
}
