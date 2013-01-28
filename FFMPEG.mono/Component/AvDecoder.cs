using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.Threading;

namespace Multimedia
{
    public class AvDecoder : BaseComponent, IPipe
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
            while (true)
            {
                if (!threadWorking)
                    return;
                NativeWrapper<FFmpeg.AVPacket> packet = null;
                if (queue.Dequeue(out packet) == false)
                    return;

                NativeWrapper<FFmpeg.AVFrame> frame = new NativeWrapper<FFmpeg.AVFrame>();
                // decode
                if (pCodecCtx.Handle.codec_type == FFmpeg.CodecType.CODEC_TYPE_AUDIO)
                {
                    int size = 0;
                    FFmpeg.avcodec_decode_audio(pCodecCtx.Ptr, frame.Ptr, out size, packet.Handle.data, packet.Handle.size); 

                }
                else if (pCodecCtx.Handle.codec_type == FFmpeg.CodecType.CODEC_TYPE_VIDEO)
                {
                    int finish = 0; ;
                    FFmpeg.avcodec_decode_video(pCodecCtx.Ptr, frame.Ptr, ref finish, packet.Handle.data, packet.Handle.size);

                }

                PushToNext(frame);
            }
        }


        public bool Stop()
        {
            threadWorking = false;
            queue.Close();
            workingThread.Join();
            workingThread = null;

            StopNext();
            return true;
        }

        public bool Close()
        {
            throw new NotImplementedException();
        }


        public bool ConnectTo(IPipe pipe)
        {
            throw new NotImplementedException();
        }


        public bool Flush()
        {
            throw new NotImplementedException();
        }


    }
}
