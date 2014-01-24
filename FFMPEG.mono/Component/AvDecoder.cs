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
        private NativeWrapper<NativeMethods51.AVStream> pStream = null;
        private NativeWrapper<NativeMethods51.AVCodecContext> pCodecCtx = null;
        private NativeWrapper<NativeMethods51.AVCodec> pCodec = null;
        private int streamIndex = 0;
        public int StreamIndex
        {
            get
            {
                return streamIndex;
            }
        }

        public AvDecoder(NativeWrapper<NativeMethods51.AVStream> stream, NativeWrapper<NativeMethods51.AVCodecContext> codecCtx, int index)
        {
            streamIndex = index;
            pStream = stream;
            pCodecCtx = codecCtx;
            NativeMethods51.AVCodecContext codecContext = codecCtx.Handle;
            IntPtr decoder = NativeMethods51.avcodec_find_decoder(codecContext.codec_id);
            if (decoder != IntPtr.Zero)
            {
                pCodec = new NativeWrapper<NativeMethods51.AVCodec>(decoder);
                if ((pCodec.Handle.capabilities & NativeMethods51.CODEC_FLAG_TRUNCATED) != 0)
                {
                    codecContext.flags |= NativeMethods51.CODEC_FLAG_TRUNCATED;
                    pCodecCtx.Handle = codecContext;
                }
            }
            else
                throw new InvalidOperationException("no such decoder");

            int ret = NativeMethods51.avcodec_open(pCodecCtx.Ptr, pCodec.Ptr);
            if (ret < 0)
                throw new InvalidOperationException("no such decoder");
        }



        private SizeQueue<NativeWrapper<NativeMethods51.AVPacket>> queue = new SizeQueue<NativeWrapper<NativeMethods51.AVPacket>>(200);
        public bool OnReceiveData(object packet)
        {
            return queue.Enqueue(packet as NativeWrapper<NativeMethods51.AVPacket>);
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
                NativeWrapper<NativeMethods51.AVPacket> packet = null;
                if (queue.Dequeue(out packet) == false)
                    return;

                // decode
                if (pCodecCtx.Handle.codec_type == NativeMethods51.CodecType.CODEC_TYPE_AUDIO)
                {
                    int size = NativeMethods51.AVCODEC_MAX_AUDIO_FRAME_SIZE;
                    IntPtr buf = Marshal.AllocHGlobal(NativeMethods51.AVCODEC_MAX_AUDIO_FRAME_SIZE);
                    int ret = NativeMethods51.avcodec_decode_audio2(pCodecCtx.Ptr, buf, out size, packet.Handle.data, packet.Handle.size);
                    if (size == 0)
                    {
                        if (ret < 0)
                            break;
                        else
                            continue;
                    }
                    AudioFrame frame= new AudioFrame();
                    frame.sample = buf;
                    frame.size = size;
                    frame.rate = pCodecCtx.Handle.sample_rate;
                    frame.bit = pCodecCtx.Handle.bits_per_sample;
                    frame.channel = pCodecCtx.Handle.channels;
                    PushToNext(frame);
                    Marshal.FreeHGlobal(buf);

                }
                else if (pCodecCtx.Handle.codec_type == NativeMethods51.CodecType.CODEC_TYPE_VIDEO)
                {
                    NativeWrapper<NativeMethods51.AVFrame> frame = new NativeWrapper<NativeMethods51.AVFrame>(NativeMethods51.avcodec_alloc_frame());

                    int finish = 0; ;
                    int ret = NativeMethods51.avcodec_decode_video(pCodecCtx.Ptr, frame.Ptr, ref finish, packet.Handle.data, packet.Handle.size);
                    if (ret < 0)
                    {
                        NativeMethods51.av_free(frame.Ptr);
                        break;
                    }

                    // ugly quick fix
                    if (finish == 0)
                    {
                        if (videoFailCount != 0)
                        {
                            NativeMethods51.av_free(frame.Ptr);
                            break;
                        }
                        else
                        {
                            videoFailCount++;
                            NativeMethods51.av_free(frame.Ptr);
                            continue;
                        }
                    }

                    VideoFrame nextObj = new VideoFrame();
                    nextObj.ffmpegFrame = frame;
                    nextObj.format = (int)pCodecCtx.Handle.pix_fmt;
                    nextObj.width = pCodecCtx.Handle.width;
                    nextObj.height = pCodecCtx.Handle.height;
                    PushToNext(nextObj);
                    NativeMethods51.av_free(frame.Ptr);
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
                NativeMethods51.avcodec_close(pCodecCtx.Ptr);
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
