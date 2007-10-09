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
            AvFormatContext context = AvFormatContext.Open(@"E:\BBC\Light Fantastic\03 - The Stuff of Light.avi");
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
            AvOutputFormat oFormat = AvOutputFormat.GuessOutputFormat(null, @"D:\output.flac", null);
            AvFormatContext oContext = new AvFormatContext();
            oContext.OutputFormat = oFormat;
            oContext.IOStream = File.OpenWrite(@"D:\output.flac");
            AvStream oStream = oContext.AddAudioStream(oFormat.AudioCodec);

            AvCodec inCodec = audioStream.CodecContext.GetDecoder();
            AvCodec outCodec = oStream.CodecContext.GetEncoder();

            outCodec.Context.SampleRate = inCodec.Context.SampleRate;
            outCodec.Context.Channels = inCodec.Context.Channels;

            inCodec.Open();
            outCodec.Open();

            oContext.WriteHeader();
            for (int i = 0; i < 5000; i++)
            {
                // get an audio frame from the input.
                AvPacket frame = context.ReadFrame(null);
                if (frame.StreamIndex == audioStream.Index)
                {
                    AvSamples audioFrame = inCodec.DecodeAudio(frame);
                    AvPacket outPacket = outCodec.EncodeAudio(audioFrame);
                    //oContext.IOStream.Write(outPacket.Data, 0, outPacket.Length);
                    oContext.WritePacket(outPacket, oStream);
                }
            }
            oContext.WriteTrailer();
            oContext.IOStream.Close();
        }
    }
}
