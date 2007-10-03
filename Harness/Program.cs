﻿using System;
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
            AvFormatContext context = AvFormatContext.Open(@"E:\BBC\Light Fantastic\01 - Let There Be Light.avi");
            string s = context.ToString();
            AvStream[] streams = context.GetStreams();

            AvStream videoStream = null;

            foreach (AvStream stream in streams)
            {
                switch (stream.CodecContext.Type)
                {
                    case CodecType.Video:
                        videoStream = stream;
                        break;
                }
            }

            if (videoStream == null)
                return;

            AvCodec videoCodec = videoStream.CodecContext.GetCodec();

            videoCodec.Open(videoStream.CodecContext);
            AvFrame finsihedFrame = null;
            AvPacket pkt;
            int frame = 0;
            for (int i = 0; i < 500000; i++)
            {
                pkt = context.ReadFrame(null);
                if (pkt.StreamIndex == videoStream.Index)
                {
                    finsihedFrame = videoCodec.DecodeVideo(pkt);
                    if (finsihedFrame != null)
                    {
                        Bitmap p = finsihedFrame.ConvertToBitmap(videoCodec.Context);
                        p.Save(@"C:\out\frame" + frame + @".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        p.Dispose();
                        finsihedFrame = null;
                        ++frame;
                    }
                }
                else
                    Console.WriteLine("Not");
                pkt.Dispose();
            }
            return;

            AvCodec codec = streams[0].CodecContext.GetCodec();
            codec.Open(streams[0].CodecContext);

            Stream str = File.OpenWrite(@"C:\out.wav");
            for (int i = 0; i < 5000; i++)
            {
                AvPacket packet = context.ReadFrame(null);
                if (packet.StreamIndex == streams[0].Index)
                {
                    short[] x = codec.DecodeAudio(packet);
                    if (x.Length != 0)
                        Console.WriteLine(x.Length);
                    for (int j = 0; j < x.Length; j++)
                    {
                        byte[] array = new byte[] { (byte)(x[j] >> 8), (byte)x[j] };
                        str.Write(array, 0, 2);
                    }
                }
            }
            str.Close();
            codec.Close();
        }
    }
}