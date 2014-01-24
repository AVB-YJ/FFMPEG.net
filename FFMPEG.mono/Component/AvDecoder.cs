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
        private NativeWrapper<FFmpeg.AVStream> pStream = null;
        private NativeWrapper<FFmpeg.AVCodecContext> pCodecCtx = null;
        private NativeWrapper<FFmpeg.AVCodec> pCodec = null;
        private int streamIndex = 0;
        public int StreamIndex
        {
            get
            {
                return streamIndex;
            }
        }

        public AvDecoder(NativeWrapper<FFmpeg.AVStream> stream, NativeWrapper<FFmpeg.AVCodecContext> codecCtx, int index)
        {
            streamIndex = index;
            pStream = stream;
            pCodecCtx = codecCtx;
            FFmpeg.AVCodecContext codecContext = codecCtx.Handle;
            IntPtr decoder = FFmpeg.avcodec_find_decoder(codecContext.codec_id);
            if (decoder != IntPtr.Zero)
            {
                pCodec = new NativeWrapper<FFmpeg.AVCodec>(decoder);
                if ((pCodec.Handle.capabilities & FFmpeg.CODEC_FLAG_TRUNCATED) != 0)
                {
                    codecContext.flags |= FFmpeg.CODEC_FLAG_TRUNCATED;
                    pCodecCtx.Handle = codecContext;
                }
            }
            else
                throw new InvalidOperationException("no such decoder");

            int ret = FFmpeg.avcodec_open(pCodecCtx.Ptr, pCodec.Ptr);
            if (ret < 0)
                throw new InvalidOperationException("no such decoder");
        }



        private SizeQueue<NativeWrapper<FFmpeg.AVPacket>> queue = new SizeQueue<NativeWrapper<FFmpeg.AVPacket>>(200);
        public bool OnReceiveData(object packet)
        {
            return queue.Enqueue(packet as NativeWrapper<FFmpeg.AVPacket>);
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
                NativeWrapper<FFmpeg.AVPacket> packet = null;
                if (queue.Dequeue(out packet) == false)
                    return;

                // decode
                if (pCodecCtx.Handle.codec_type == FFmpeg.CodecType.CODEC_TYPE_AUDIO)
                {
                    int size = FFmpeg.AVCODEC_MAX_AUDIO_FRAME_SIZE;
                    IntPtr buf = Marshal.AllocHGlobal(FFmpeg.AVCODEC_MAX_AUDIO_FRAME_SIZE);
                    int ret = FFmpeg.avcodec_decode_audio2(pCodecCtx.Ptr, buf, out size, packet.Handle.data, packet.Handle.size);
                    if (ret < 0)
                    {
                        break;
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
                else if (pCodecCtx.Handle.codec_type == FFmpeg.CodecType.CODEC_TYPE_VIDEO)
                {
                    NativeWrapper<FFmpeg.AVFrame> frame = new NativeWrapper<FFmpeg.AVFrame>(FFmpeg.avcodec_alloc_frame());

                    int finish = 0; ;
                    int ret = FFmpeg.avcodec_decode_video(pCodecCtx.Ptr, frame.Ptr, ref finish, packet.Handle.data, packet.Handle.size);
                    if (ret < 0)
                    {
                        FFmpeg.av_free(frame.Ptr);
                        break;
                    }

                    // ugly quick fix
                    if (finish == 0)
                    {
                        if (videoFailCount != 0)
                        {
                            FFmpeg.av_free(frame.Ptr);
                            break;
                        }
                        else
                        {
                            videoFailCount++;
                            FFmpeg.av_free(frame.Ptr);
                            continue;
                        }
                    }

                    VideoFrame nextObj = new VideoFrame();
                    nextObj.ffmpegFrame = frame;
                    nextObj.format = (int)pCodecCtx.Handle.pix_fmt;
                    nextObj.width = pCodecCtx.Handle.width;
                    nextObj.height = pCodecCtx.Handle.height;
                    PushToNext(nextObj);
                    FFmpeg.av_free(frame.Ptr);
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
            throw new NotImplementedException();
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
