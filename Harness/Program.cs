//#define ENC_ONLY
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Multimedia.FFmpeg;

namespace Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            //AvInputFormat iFormat = AvInputFormat.GuessInputFormat(@"D:\BBC.Absolute.Zero.2of2.The.Race.for.Absolute.Zero.2007.DVBC.XviD.MP3.www.mvgroup.org.avi");
#if ENC_ONLY
            AvOutputFormat format = AvOutputFormat.GuessOutputFormat("mp3", null, null);
            AvFormatContext outputContext = new AvFormatContext();
            outputContext.OutputFormat = format;
            outputContext.Filename = @"DotNet://";
            if (format.AudioCodec == CodecId.None)
                throw new InvalidOperationException();
            AvStream outputStream = outputContext.AddAudioStream(format.AudioCodec);

            outputStream.CodecContext.SampleRate = 44100;
            outputStream.CodecContext.Channels = 2;
            outputStream.CodecContext.Bitrate = 64000;
            AvCodec outCodec = outputStream.CodecContext.GetEncoder();
            outCodec.Open();
            outputContext.WriteHeader();
            outCodec.Close();
            outputContext.WriteTrailer();

#else
            AvOutputFormat format = AvOutputFormat.GuessOutputFormat(null, "asdf.flac", null);
            AvFormatContext outputContext = new AvFormatContext();
            //outputContext.IOStream = File.OpenWrite(@"C:\out\output.mp3");
            //outputContext.OutputFormat = format;
            //if (format.AudioCodec == CodecId.None)
            //    throw new InvalidOperationException();
            //AvStream outputStream = outputContext.AddAudioStream(format.AudioCodec);

            AvFormatContext context = AvFormatContext.Open(@"D:\BBC.Absolute.Zero.2of2.The.Race.for.Absolute.Zero.2007.DVBC.XviD.MP3.www.mvgroup.org.avi");
            // AvFormatContext context = AvFormatContext.Open(@"E:\BBC\Planet Earth\06 - Ice Worlds.avi");
            //string s = context.ToString();
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

            AvCodec videoCodec = videoStream.CodecContext.GetDecoder();
            AvCodec audioCodec = audioStream.CodecContext.GetDecoder();

            videoCodec.Open();
            audioCodec.Open();

            AvFrame finsihedFrame = null;
            AvPacket pkt;
            int frame = 0;

            AvCodec outcodec = AvCodec.FindEncoder(CodecId.Mp3);
            outcodec.Context.SampleRate = audioCodec.Context.SampleRate;
            outcodec.Context.Channels = audioCodec.Context.Channels;
            //outcodec.Context.Bitrate = 128000; // audioCodec.Context.Bitrate;
            //AvCodec outCodec = outputStream.CodecContext.GetEncoder();
            //outCodec.Open();
            outcodec.Open();

#if WAVE_OUTPUT
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
#endif

            DateTime start = DateTime.Now;

            short[] sampleCache = new short[outcodec.Context.FrameSize];
            
            int index = 0;
            //outputContext.WriteHeader();
            AvSamples final = null;
            for (int i = 0; i < 400; i++)
            {
                pkt = context.ReadFrame(null);
                if (pkt.StreamIndex == videoStream.Index ) {
                        finsihedFrame = videoCodec.DecodeVideo(pkt);
                        if (finsihedFrame != null)
                        {
                            Console.WriteLine("Frame format: " + finsihedFrame.Format + " (" + finsihedFrame.Width + "x" + finsihedFrame.Height + ")");
                            //Bitmap p = finsihedFrame.ConvertToBitmap();
                            //p.Save(@"C:\out\frame" + frame + @".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            //p.Dispose();
                            finsihedFrame.Dispose();
                            finsihedFrame = null;
                            ++frame;
                        }
                }
                else if (pkt.StreamIndex == audioStream.Index)
                {
                    AvSamples samples = audioCodec.DecodeAudio(pkt);
                    if (samples.Count > 0)
                    {
                        if (final == null)
                            final = samples;
                        else
                            final += samples;
#if WAVE_OUTPUT
                        for (int xi = 0; xi < samples.Count; xi++)
                            sampleWriter.Write(samples.ShortSamples[xi]);
#endif
                    }
                }
                else
                    Console.WriteLine("Errrr");
                pkt.Dispose();
            }

            // encode
            int outIndez = 0;
            Stream str = File.OpenWrite(@"C:\out\output.flac");
            while (outIndez < final.Count)
            {
                AvSamples decoded = final.GetSamples(outIndez, outcodec.Context.FrameSize);
                AvPacket encodedFrame = outcodec.EncodeAudio(decoded);
                str.Write(encodedFrame.Data, 0, encodedFrame.Length);
                //outputContext.WritePacket(encodedFrame, outputStream);
                outIndez += outcodec.Context.FrameSize;
            }
            str.Close();

            outcodec.Close();
            //outputContext.WriteTrailer();
            TimeSpan timeTaken = DateTime.Now - start;
            Console.WriteLine(String.Format("Time Taken: {0} seconds.  Frames Decoded: {1}.  Overall framerate: {2}", timeTaken.Seconds, frame, frame / timeTaken.Seconds));
            Console.ReadKey();
#if WAVE_OUTPUT
            sampleWriter.Close();
            byte[] sampleBytes = str.ToArray();
            writer.Write(Encoding.ASCII.GetBytes("data"), 0, 4);
            writer.Write(sampleBytes.Length);
            writer.Write(sampleBytes);
            writer.Seek(4, SeekOrigin.Begin);
            writer.Write((int)36 + sampleBytes.Length);
            writer.Close();
#endif
            context.Close();
            return;
#endif
        }
    }
}
