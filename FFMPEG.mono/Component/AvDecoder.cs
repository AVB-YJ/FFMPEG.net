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
        private NativeWrapper<NativeMethods55.AVStream> pStream = null;
        private NativeWrapper<NativeMethods55.AVCodecContext> pCodecCtx = null;
        private NativeWrapper<NativeMethods55.AVCodec> pCodec = null;
        private int streamIndex = 0;
        public int StreamIndex
        {
            get
            {
                return streamIndex;
            }
        }

        public AvDecoder(NativeWrapper<NativeMethods55.AVStream> stream, NativeWrapper<NativeMethods55.AVCodecContext> codecCtx, int index)
        {
            streamIndex = index;
            pStream = stream;
            pCodecCtx = codecCtx;
            NativeMethods55.AVCodecContext codecContext = codecCtx.Handle;
            IntPtr decoder = NativeMethods55.avcodec_find_decoder(codecContext.codec_id);
            if (decoder != IntPtr.Zero)
            {
                pCodec = new NativeWrapper<NativeMethods55.AVCodec>(decoder);
                if ((pCodec.Handle.capabilities & NativeMethods55.CODEC_FLAG_TRUNCATED) != 0)
                {
                    codecContext.flags |= NativeMethods55.CODEC_FLAG_TRUNCATED;
                    pCodecCtx.Handle = codecContext;
                }
            }
            else
                throw new InvalidOperationException("no such decoder");

            int ret = NativeMethods55.avcodec_open2(pCodecCtx.Ptr, pCodec.Ptr, IntPtr.Zero);
            if (ret < 0)
                throw new InvalidOperationException("no such decoder");
        }



        private SizeQueue<NativeWrapper<NativeMethods55.AVPacket>> queue = new SizeQueue<NativeWrapper<NativeMethods55.AVPacket>>(200);
        public bool OnReceiveData(object packet)
        {
            return queue.Enqueue(packet as NativeWrapper<NativeMethods55.AVPacket>);
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
                NativeWrapper<NativeMethods55.AVPacket> packet = null;
                if (queue.Dequeue(out packet) == false)
                    return;

                // decode
                if (pCodecCtx.Handle.codec_type == NativeMethods55.AVMediaType.AVMEDIA_TYPE_AUDIO)
                {
                    int size = 0;
                    NativeWrapper<NativeMethods55.AVFrame> tframe =
                        new NativeWrapper<NativeMethods55.AVFrame>(NativeMethods55.avcodec_alloc_frame());
                    int ret = NativeMethods55.avcodec_decode_audio4(pCodecCtx.Ptr, 
                        tframe.Ptr, out size, packet.Ptr);
                    if (ret <= 0)
                    {
                        NativeMethods55.avcodec_free_frame(tframe.Ptr);
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

                    NativeMethods55.av_free(tframe.Ptr);

                }
                else if (pCodecCtx.Handle.codec_type == NativeMethods55.AVMediaType.AVMEDIA_TYPE_VIDEO)
                {
                    NativeWrapper<NativeMethods55.AVFrame> frame = new NativeWrapper<NativeMethods55.AVFrame>(NativeMethods55.avcodec_alloc_frame());

                    int finish = 0; ;
                    int ret = NativeMethods55.avcodec_decode_video2(pCodecCtx.Ptr, frame.Ptr, out finish, packet.Ptr);
                    if (ret < 0)
                    {
                        NativeMethods55.av_free(frame.Ptr);
                        break;
                    }

                    // ugly quick fix
                    if (finish == 0)
                    {
                        if (videoFailCount != 0)
                        {
                            NativeMethods55.av_free(frame.Ptr);
                            break;
                        }
                        else
                        {
                            videoFailCount++;
                            NativeMethods55.av_free(frame.Ptr);
                            continue;
                        }
                    }

                    VideoFrame nextObj = new VideoFrame();
                    nextObj.ffmpegFrame = frame;
                    nextObj.format = (int)pCodecCtx.Handle.pix_fmt;
                    nextObj.width = pCodecCtx.Handle.width;
                    nextObj.height = pCodecCtx.Handle.height;
                    PushToNext(nextObj);
                    NativeMethods55.av_free(frame.Ptr);
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
            if (pCodecCtx != null)
                NativeMethods55.avcodec_close(pCodecCtx.Ptr);
            return true;
        }


        public bool ConnectTo(IPipe pipe)
        {
            this.AddPipe(pipe);
            return true;
        }


        public bool Flush()
        {
            throw new NotImplementedException();
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
