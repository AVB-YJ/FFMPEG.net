using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Multimedia
{
    public class AvDecoder : BaseComponent, IPipe, IDecoder
    {
        private Native<AV.AVStream> pStream = null;
        private Native<AV.AVCodecContext> pCodecCtx = null;
        private Native<AV.AVCodec> pCodec = null;
        private int streamIndex = 0;
        public int StreamIndex
        {
            get
            {
                return streamIndex;
            }
        }

        public AvDecoder(Native<AV.AVStream> stream, Native<AV.AVCodecContext> codecCtx, int index)
        {
            streamIndex = index;
            pStream = stream;
            pCodecCtx = codecCtx;
            AV.AVCodecContext codecContext = codecCtx.Handle;
            IntPtr decoder = AV.avcodec_find_decoder(codecContext.codec_id);
            if (decoder != IntPtr.Zero)
            {
                pCodec = new Native<AV.AVCodec>(decoder);
                if ((pCodec.Handle.capabilities & AV.CODEC_FLAG_TRUNCATED) != 0)
                {
                    codecContext.flags |= AV.CODEC_FLAG_TRUNCATED;
                    pCodecCtx.Handle = codecContext;
                }
            }
            else
                throw new InvalidOperationException("no such decoder");

            int ret = AV.avcodec_open2(pCodecCtx.Ptr, pCodec.Ptr, IntPtr.Zero);
            if (ret < 0)
                throw new InvalidOperationException("no such decoder");
        }



        private SizeQueue<Native<AV.AVPacket>> queue = new SizeQueue<Native<AV.AVPacket>>(200,
            new FreeQueueItemDelegate<Native<AV.AVPacket>>(
                item => 
                    Marshal.FreeHGlobal(item.Ptr)
                ));

        public bool OnReceiveData(object packet)
        {
            return queue.Enqueue(packet as Native<AV.AVPacket>);
        }


        private Thread workingThread = null;
        private bool threadWorking = false;

        public bool Start()
        {
            StartNext();
            workingThread = new Thread(new ThreadStart(() => DoThreadWork()));
            threadWorking = true;
            workingThread.Start();
            return true;
        }





        private void DoThreadWork()
        {
            int videoFailCount = 0;
            //int audioFailCount = 0;

            while (true)
            {
                if (!threadWorking)
                    return;
                Native<AV.AVPacket> packet = null;
                if (queue.Dequeue(out packet) == false)
                    return;

                // decode
                if (pCodecCtx.Handle.codec_type == AV.AVMediaType.AVMEDIA_TYPE_AUDIO)
                {
                    int size = 0;
                    Native<AV.AVFrame> tframe =
                        new Native<AV.AVFrame>(AV.avcodec_alloc_frame());
                    int ret = AV.avcodec_decode_audio4(pCodecCtx.Ptr, 
                        tframe.Ptr, out size, packet.Ptr);
                    if (ret <= 0)
                    {
                        AV.avcodec_free_frame(tframe.Ptr);
                        continue;

                    }


                    AudioFrame frame = new AudioFrame();
                    frame.fmt = (int)pCodecCtx.Handle.sample_fmt;
                    frame.sample = tframe.Handle.data[0];
                    frame.size = tframe.Handle.linesize[0];
                    frame.rate = pCodecCtx.Handle.sample_rate;
                    frame.bit = pCodecCtx.Handle.bits_per_coded_sample;
                    frame.channel = pCodecCtx.Handle.channels;
                    frame.nb_samples = tframe.Handle.nb_samples;
                    PushToNext(frame);

                    AV.av_free(tframe.Ptr);

                }
                else if (pCodecCtx.Handle.codec_type == AV.AVMediaType.AVMEDIA_TYPE_VIDEO)
                {
                    Native<AV.AVFrame> frame = new Native<AV.AVFrame>(AV.avcodec_alloc_frame());

                    int finish = 0; ;
                    int ret = AV.avcodec_decode_video2(pCodecCtx.Ptr, frame.Ptr, out finish, packet.Ptr);
                    if (ret < 0)
                    {
                        AV.av_free(frame.Ptr);
                        break;
                    }

                    VideoFrame nextObj = new VideoFrame();
                    nextObj.ffmpegFrame = frame;
                    nextObj.format = (int)pCodecCtx.Handle.pix_fmt;
                    nextObj.width = pCodecCtx.Handle.width;
                    nextObj.height = pCodecCtx.Handle.height;
                    PushToNext(nextObj);
                    AV.av_free(frame.Ptr);
                }

                
                

                
                Marshal.FreeHGlobal(packet.Ptr);
                
            }
        }


        public bool Stop()
        {
            threadWorking = false;
            queue.Close();
            StopNext();
            workingThread.Join();
            workingThread = null;
            return true;
        }

        public bool Close()
        {
            Stop();

            if (pCodecCtx != null)
                AV.avcodec_close(pCodecCtx.Ptr);

            CloseNext();
            return true;
        }


        public bool ConnectTo(IPipe pipe)
        {
            this.AddPipe(pipe);
            return true;
        }


        public bool Flush()
        {
            queue.Flush();
            FlushNext();
            return true;
        }



        public int BufferDepth
        {
            get
            {
                return queue.Size;
            }
            set
            {
                queue.Size = value;
            }
        }
    }
}
