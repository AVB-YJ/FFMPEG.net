using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Multimedia.FFmpeg;

namespace v
{
    class AudioTranscode
    {
        public static void Main()
        {
            AvFormatContext context = AvFormatContext.Open(@"D:\BBC.Absolute.Zero.2of2.The.Race.for.Absolute.Zero.2007.DVBC.XviD.MP3.www.mvgroup.org.avi");
            AvStream[] streams = context.GetStreams();
            AvStream audioStream = null;

            foreach (AvStream stream in streams)
                if (stream.CodecContext.Type == CodecType.Audio)
                    audioStream = stream;
            
            if (audioStream == null)
            {
                Console.WriteLine("No Audio Stream found!");
                return;
            }

            // set up output
            AvOutputFormat oFormat = AvOutputFormat.GuessOutputFormat(null, @"D:\output.m4a", null);
            AvFormatContext oContext = new AvFormatContext();
            oContext.OutputFormat = oFormat;
            oContext.IOStream = File.OpenWrite(@"D:\output.m4a");
            AvStream oStream = oContext.AddAudioStream(oFormat.AudioCodec);

            AvCodec inCodec = audioStream.CodecContext.GetDecoder();
            AvCodec outCodec = oStream.CodecContext.GetEncoder();

            outCodec.Context.SampleRate = inCodec.Context.SampleRate;
            outCodec.Context.Channels = inCodec.Context.Channels;

            inCodec.Open();
            outCodec.Open();

            //oContext.IOStream.Write(new byte[] { 0x66, 0x4C, 0x61, 0x43, 0x80, 0x00, 0x00, 0x22 }, 0, 8);
            oContext.WriteHeader();
            for (int i = 0; i < 5000; i++)
            {
                // get an audio frame from the input.
                AvPacket frame = context.ReadFrame(null);
                if (frame.StreamIndex == audioStream.Index)
                {
                    AvSamples audioFrame = inCodec.DecodeAudio(frame);
                    AvPacket outPacket = outCodec.EncodeAudio(audioFrame);
                    oContext.IOStream.Write(outPacket.Data, 0, outPacket.Length);
                    //oContext.WritePacket(outPacket, oStream);
                }
            }
            oContext.WriteTrailer();
            oContext.IOStream.Close();
        }
    }
}
