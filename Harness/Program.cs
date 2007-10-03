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
            AvFormatContext context = AvFormatContext.Open(@"D:\BBC.Absolute.Zero.1of2.The.Conquest.of.Cold.2007.DVBC.XviD.MP3.www.mvgroup.org.avi");
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

            BinaryWriter writer = new BinaryWriter(File.OpenWrite(@"C:\out\out.wav"));
            writer.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);
            writer.Write((int)0);
            writer.Write(Encoding.ASCII.GetBytes("WAVEfmt "), 0, 8);
            writer.Write((int)16);
            writer.Write((short)1);
            writer.Write((short)audioCodec.Context.Channels);
            writer.Write((int)audioCodec.Context.SampleRate);
            writer.Write((int)(audioCodec.Context.SampleRate * audioCodec.Context.Channels * 16 / 8));
            writer.Write((short)(audioCodec.Context.Channels * 16 / 8));
            writer.Write((short)16);

            MemoryStream str = new MemoryStream();
            BinaryWriter sampleWriter = new BinaryWriter(str);
            for (int i = 0; i < 2000; i++)
            {
                pkt = context.ReadFrame(null);
                if (pkt.StreamIndex == videoStream.Index ) {
                        /*finsihedFrame = videoCodec.DecodeVideo(pkt);
                        if (finsihedFrame != null)
                        {
                            Console.WriteLine("Frame format: " + finsihedFrame.Format + " (" + finsihedFrame.Width + "x" + finsihedFrame.Height + ")");
                            Bitmap p = finsihedFrame.ConvertToBitmap();
                            p.Save(@"C:\out\frame" + frame + @".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            p.Dispose();
                            finsihedFrame.Dispose();
                            finsihedFrame = null;
                            ++frame;
                        }*/
                }
                else if(pkt.StreamIndex == audioStream.Index)
                {
                        AvSamples samples = audioCodec.DecodeAudio(pkt);
                        if (samples.Count > 0)
                        {
                            Console.WriteLine("Audio Format: " + samples.Format + " (" + samples.Count + " samples)");
                            for (int xi = 0; xi < samples.Count; xi++)
                                sampleWriter.Write(samples.ShortSamples[xi]);
                        }   
                }
                else
                    Console.WriteLine("Erorr");
                pkt.Dispose();
            }
            sampleWriter.Close();
            byte[] sampleBytes = str.ToArray();
            writer.Write(Encoding.ASCII.GetBytes("data"), 0, 4);
            writer.Write(sampleBytes.Length);
            writer.Write(sampleBytes);
            writer.Seek(4, SeekOrigin.Begin);
            writer.Write((int)36 + sampleBytes.Length);
            writer.Close();
            return;
        }
    }
}
