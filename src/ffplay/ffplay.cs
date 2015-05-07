/*
 * Copyright (c) 2003 Fabrice Bellard
 *
 * This file is part of FFmpeg.
 *
 * FFmpeg is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * FFmpeg is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with FFmpeg; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 */

/*
 * This is a byte-to-byte translation from ffplay.c
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpFFmpeg;
using SDLLib;
using System.Runtime.InteropServices;

namespace ffplay
{
    internal class ffplay
    {
        const string program_name = "ffplay";
        const int program_birth_year = 2003;
        static readonly uint MAX_QUEUE_SIZE = (15 * 1024 * 1024);
        static readonly uint MIN_FRAMES = 5;

        /* SDL audio buffer size, in samples. Should be small to have precise
   A/V sync as SDL does not have hardware buffer fullness info. */
        static readonly uint SDL_AUDIO_BUFFER_SIZE = 1024;

        /* no AV sync correction is done if below the minimum AV sync threshold */
        static readonly double AV_SYNC_THRESHOLD_MIN = 0.01;
        /* AV sync correction is done if above the maximum AV sync threshold */
        static readonly double AV_SYNC_THRESHOLD_MAX = 0.1;
        /* If a frame duration is longer than this, it will not be duplicated to compensate AV sync */
        static readonly double AV_SYNC_FRAMEDUP_THRESHOLD = 0.1;
        /* no AV correction is done if too big error */
        static readonly double AV_NOSYNC_THRESHOLD = 10.0;

        /* maximum audio speed change to get correct sync */
        static readonly uint SAMPLE_CORRECTION_PERCENT_MAX = 10;

        /* external clock speed adjustment constants for realtime sources based on buffer fullness */
        static readonly double EXTERNAL_CLOCK_SPEED_MIN = 0.900;
        static readonly double EXTERNAL_CLOCK_SPEED_MAX = 1.010;
        static readonly double EXTERNAL_CLOCK_SPEED_STEP = 0.001;

        /* we use about AUDIO_DIFF_AVG_NB A-V differences to make the average */
        static readonly uint AUDIO_DIFF_AVG_NB = 20;

        /* polls for possible required screen refresh at least this often, should be less than 1/fps */
        static readonly double REFRESH_RATE = 0.01;

        /* NOTE: the size must be big enough to compensate the hardware audio buffersize size */
        /* TODO: We assume that a decoded and resampled frame fits into this buffer */
        static readonly uint SAMPLE_ARRAY_SIZE = (8 * 65536);

        static readonly uint CURSOR_HIDE_DELAY = 1000000;

        static Int64 sws_flags = AV.SWS_BICUBIC;


        class MyAVPacketList
        {
            public Native<AV.AVPacket> pkt;
            public MyAVPacketList next;
            public int serial;
        }

        class PacketQueue
        {
            public MyAVPacketList first_pkt;
            public MyAVPacketList last_pkt;
            public int nb_packets;
            public int size;
            public int abort_request;
            public int serial;
            /*SDL_mutex * */
            public IntPtr mutex;
            /*SDL_cond * */
            public IntPtr cond;
        }

        static readonly uint VIDEO_PICTURE_QUEUE_SIZE = 3;
        static readonly uint SUBPICTURE_QUEUE_SIZE = 4;

        class VideoPicture
        {
            public double pts;             // presentation timestamp for this picture
            public double duration;        // estimated duration based on frame rate
            public Int64 pos;            // byte position in file
            /*SDL_Overlay * */
            public IntPtr bmp;
            public int width, height; /* source height & width */
            public int allocated;
            public int reallocate;
            public int serial;

            public AV.AVRational sar;
        }

        class SubPicture
        {
            public double pts; /* presentation time stamp for this picture */
            public AV.AVSubtitle sub;
            public int serial;
        }

        class AudioParams
        {
            public int freq;
            public int channels;
            public Int64 channel_layout;
            public AV.AVSampleFormat fmt;
            public int frame_size;
            public int bytes_per_sec;
        }

        class Clock
        {
            public double pts;           /* clock base */
            public double pts_drift;     /* clock base minus time at which we updated the clock */
            public double last_updated;
            public double speed;
            public int serial;           /* clock is based on a packet with this serial */
            public int paused;
            /*int * */
            public int[] queue_serial;    /* pointer to the current packet queue serial, used for obsolete clock detection */
        }

        enum AV_SYNC_OPTION
        {
            AV_SYNC_AUDIO_MASTER, /* default choice */
            AV_SYNC_VIDEO_MASTER,
            AV_SYNC_EXTERNAL_CLOCK, /* synchronize to an external clock */
        };
        enum ShowMode
        {
            SHOW_MODE_NONE = -1, SHOW_MODE_VIDEO = 0, SHOW_MODE_WAVES, SHOW_MODE_RDFT, SHOW_MODE_NB
        };

        class VideoState
        {
            public VideoState()
            {
                silence_buf = new byte[SDL_AUDIO_BUFFER_SIZE];
                sample_array = new short[SAMPLE_ARRAY_SIZE];
                subpq = new SubPicture[SUBPICTURE_QUEUE_SIZE];
                pictq = new VideoPicture[VIDEO_PICTURE_QUEUE_SIZE];
            }
            /*SDL_Thread * */
            public IntPtr read_tid;
            /*SDL_Thread * */
            public IntPtr video_tid;
            public Native<AV.AVInputFormat> iformat;
            public int no_background;
            public int abort_request;
            public int force_refresh;
            public int paused;
            public int last_paused;
            public int queue_attachments_req;
            public int seek_req;
            public int seek_flags;
            public Int64 seek_pos;
            public Int64 seek_rel;
            public int read_pause_return;
            public Native<AV.AVFormatContext> ic;
            public int realtime;
            public int audio_finished;
            public int video_finished;

            public Clock audclk;
            public Clock vidclk;
            public Clock extclk;

            public int audio_stream;

            public int av_sync_type;

            public double audio_clock;
            public int audio_clock_serial;
            public double audio_diff_cum; /* used for AV difference average computation */
            public double audio_diff_avg_coef;
            public double audio_diff_threshold;
            public int audio_diff_avg_count;
            public Native<AV.AVStream> audio_st;
            public PacketQueue audioq;
            public int audio_hw_buf_size;
            public byte[] silence_buf;
            public byte[] audio_buf;
            public byte[] audio_buf1;
            public uint audio_buf_size; /* in bytes */
            public uint audio_buf1_size;
            public int audio_buf_index; /* in bytes */
            public int audio_write_buf_size;
            public int audio_buf_frames_pending;
            public Native<AV.AVPacket> audio_pkt_temp;
            public Native<AV.AVPacket> audio_pkt;
            public int audio_pkt_temp_serial;
            public int audio_last_serial;
            public AudioParams audio_src;
            public AudioParams audio_tgt;
            /*SwrContext **/
            public IntPtr swr_ctx;
            public int frame_drops_early;
            public int frame_drops_late;
            public Native<AV.AVFrame> frame;
            public Int64 audio_frame_next_pts;


            public Int16[] sample_array;
            public int sample_array_index;
            public int last_i_start;
            /*RDFTContext * */
            public IntPtr rdft;
            public int rdft_bits;
            /*FFTSample * */
            public IntPtr rdft_data;
            public int xpos;
            public double last_vis_time;

            /*SDL_Thread * */
            public IntPtr subtitle_tid;
            public int subtitle_stream;
            public Native<AV.AVStream> subtitle_st;
            public PacketQueue subtitleq;
            public SubPicture[] subpq;
            public int subpq_size, subpq_rindex, subpq_windex;
            /*SDL_mutex * */
            public IntPtr subpq_mutex;
            /*SDL_cond * */
            public IntPtr subpq_cond;

            public double frame_timer;
            public double frame_last_returned_time;
            public double frame_last_filter_delay;
            public int video_stream;
            public Native<AV.AVStream> video_st;
            public PacketQueue videoq;
            public Int64 video_current_pos;      // current displayed file pos
            public double max_frame_duration;      // maximum duration of a frame - above this, we consider the jump a timestamp discontinuity
            public VideoPicture[] pictq;
            public int pictq_size, pictq_rindex, pictq_windex;
            /*SDL_mutex * */
            public IntPtr pictq_mutex;
            /*SDL_cond * */
            public IntPtr pictq_cond;
            public SDL.SDL_Rect last_display_rect;

            public string filename;
            public int width, height, xleft, ytop;
            public int step;
            public int last_video_stream, last_audio_stream, last_subtitle_stream;

            /*SDL_cond * */
            public IntPtr continue_read_thread;
        }

        /* options specified by the user */
        static Native<AV.AVInputFormat> file_iformat;
        static string input_filename;
        static string window_title;
        static int fs_screen_width;
        static int fs_screen_height;
        static int default_width = 640;
        static int default_height = 480;
        static int screen_width = 0;
        static int screen_height = 0;
        static int audio_disable;
        static int video_disable;
        static int subtitle_disable;
        static int[] wanted_stream = new int[(int)AV.AVMediaType.AVMEDIA_TYPE_NB + 1] { 0, -1, -1, 0, -1, 0 };
        static int seek_by_bytes = -1;
        static int display_disable;
        static int show_status = 1;
        static AV_SYNC_OPTION av_sync_type = AV_SYNC_OPTION.AV_SYNC_AUDIO_MASTER;
        static UInt64 start_time = AV.AV_NOPTS_VALUE;
        static UInt64 duration = AV.AV_NOPTS_VALUE;
        static int workaround_bugs = 1;
        static int fast = 0;
        static int genpts = 0;
        static int lowres = 0;
        static int error_concealment = 3;
        static int decoder_reorder_pts = -1;
        static int autoexit;
        static int exit_on_keydown;
        static int exit_on_mousedown;
        static int loop = 1;
        static int framedrop = -1;
        static int infinite_buffer = -1;
        static ShowMode show_mode = ShowMode.SHOW_MODE_NONE;
        static string audio_codec_name;
        static string subtitle_codec_name;
        static string video_codec_name;
        double rdftspeed = 0.02;
        static Int64 cursor_last_shown;
        static int cursor_hidden = 0;


        /* current context */
        static int is_full_screen;
        static Int64 audio_callback_time;

        static Native<AV.AVPacket> flush_pkt;

        static readonly SDL.SDL_EventType FF_ALLOC_EVENT = (SDL.SDL_EventType.SDL_USEREVENT);
        static readonly SDL.SDL_EventType FF_QUIT_EVENT = (SDL.SDL_EventType.SDL_USEREVENT + 2);

        static /*SDL_Surface * */ IntPtr screen;
        static /*SDL_Renderer* */ IntPtr render;

        static bool cmp_audio_fmts(AV.AVSampleFormat fmt1, UInt64 channel_count1,
                   AV.AVSampleFormat fmt2, UInt64 channel_count2)
        {
            /* If channel count == 1, planar and non-planar formats are the same */
            if (channel_count1 == 1 && channel_count2 == 1)
                return AV.av_get_packed_sample_fmt(fmt1) != AV.av_get_packed_sample_fmt(fmt2);
            else
                return channel_count1 != channel_count2 || fmt1 != fmt2;
        }

        static UInt64 get_valid_channel_layout(UInt64 channel_layout, int channels)
        {
            if ((channel_layout != 0) && AV.av_get_channel_layout_nb_channels(channel_layout) == channels)
                return channel_layout;
            else
                return 0;
        }

        static int packet_queue_put_private(PacketQueue q, Native<AV.AVPacket> pkt)
        {
            MyAVPacketList pkt1 = new MyAVPacketList();

            if (q.abort_request != 0)
                return -1;

            pkt1.pkt = pkt;
            pkt1.next = null;
            if (pkt.P == flush_pkt.P)
                q.serial++;
            pkt1.serial = q.serial;

            if (q.last_pkt == null)
                q.first_pkt = pkt1;
            else
                q.last_pkt.next = pkt1;
            q.last_pkt = pkt1;
            q.nb_packets++;
            q.size += pkt1.pkt.O.size + Marshal.SizeOf(pkt.O) + 12;
            /* XXX: should duplicate packet data in DV case */
            SDL.SDL_CondSignal(q.cond);
            return 0;
        }

        static int packet_queue_put(PacketQueue q, Native<AV.AVPacket> pkt)
        {
            int ret;

            /* duplicate the packet */
            if (pkt.P != flush_pkt.P && AV.av_dup_packet(pkt.P) < 0)
                return -1;

            SDL.SDL_LockMutex(q.mutex);
            ret = packet_queue_put_private(q, pkt);
            SDL.SDL_UnlockMutex(q.mutex);

            if (pkt.P != flush_pkt.P && ret < 0)
                AV.av_free_packet(pkt.P);

            return ret;
        }

        static int packet_queue_put_nullpacket(PacketQueue q, int stream_index)
        {
            Native<AV.AVPacket> pkt1 = new Native<AV.AVPacket>(new AV.AVPacket());
            Native<AV.AVPacket> pkt = new Native<AV.AVPacket>(pkt1.P);
            AV.av_init_packet(pkt.P);
            var O = pkt.O;
            O.data = IntPtr.Zero;
            O.size = 0;
            O.stream_index = stream_index;
            pkt.O = O;
            return packet_queue_put(q, pkt);
        }

        /* packet queue handling */
        static void packet_queue_init(PacketQueue q)
        {
            q.mutex = SDL.SDL_CreateMutex();
            q.cond = SDL.SDL_CreateCond();
            q.abort_request = 1;
        }

        static void packet_queue_flush(PacketQueue q)
        {
            MyAVPacketList pkt, pkt1;

            SDL.SDL_LockMutex(q.mutex);
            for (pkt = q.first_pkt; pkt != null; pkt = pkt1)
            {
                pkt1 = pkt.next;
                AV.av_free_packet(pkt.pkt.P);
                //AV.av_freep(pkt);
            }
            q.last_pkt = null;
            q.first_pkt = null;
            q.nb_packets = 0;
            q.size = 0;
            SDL.SDL_UnlockMutex(q.mutex);
        }

        static void packet_queue_destroy(PacketQueue q)
        {
            packet_queue_flush(q);
            SDL.SDL_DestroyMutex(q.mutex);
            SDL.SDL_DestroyCond(q.cond);
        }

        static void packet_queue_abort(PacketQueue q)
        {
            SDL.SDL_LockMutex(q.mutex);

            q.abort_request = 1;

            SDL.SDL_CondSignal(q.cond);

            SDL.SDL_UnlockMutex(q.mutex);
        }

        static void packet_queue_start(PacketQueue q)
        {
            SDL.SDL_LockMutex(q.mutex);
            q.abort_request = 0;
            packet_queue_put_private(q, flush_pkt);
            SDL.SDL_UnlockMutex(q.mutex);
        }

        /* return < 0 if aborted, 0 if no packet and > 0 if packet.  */
        static int packet_queue_get(PacketQueue q, out Native<AV.AVPacket> pkt, int block, out int serial)
        {
            MyAVPacketList pkt1;
            int ret;

            pkt = null;
            serial = 0;

            SDL.SDL_LockMutex(q.mutex);

            for (; ; )
            {
                if (q.abort_request != 0)
                {
                    ret = -1;
                    break;
                }

                pkt1 = q.first_pkt;
                if (pkt1 != null)
                {
                    q.first_pkt = pkt1.next;
                    if (q.first_pkt == null)
                        q.last_pkt = null;
                    q.nb_packets--;
                    q.size -= pkt1.pkt.O.size + Marshal.SizeOf(pkt1.pkt.O) + 12;
                    pkt = pkt1.pkt;
                    //if (serial != 0)
                        serial = pkt1.serial;
                    //AV.av_free(pkt1);
                    ret = 1;
                    break;
                }
                else if (block == 0)
                {
                    ret = 0;
                    break;
                }
                else
                {
                    SDL.SDL_CondWait(q.cond, q.mutex);
                }
            }
            SDL.SDL_UnlockMutex(q.mutex);
            return ret;
        }

        static void fill_rectangle(/*SDL_Surface * */ IntPtr screen, IntPtr render,
                                  int x, int y, int w, int h, int color, int update)
        {
            SDL.SDL_Rect rect = new SDL.SDL_Rect();
            Native<SDL.SDL_Rect> n = new Native<SDL.SDL_Rect>(rect);

            rect.x = x;
            rect.y = y;
            rect.w = w;
            rect.h = h;
            n.O = rect;
            SDL.SDL_FillRect(screen, n.P, (uint)color);
            if (update != 0 && w > 0 && h > 0)
                SDL.SDL_RenderPresent(render);
            //    SDL.SDL_UpdateRect(screen, x, y, w, h);
        }

        /* draw only the border of a rectangle */
        static void fill_border(int xleft, int ytop, int width, int height, int x, int y, int w, int h, int color, int update)
        {
            int w1, w2, h1, h2;

            /* fill the background */
            w1 = x;
            if (w1 < 0)
                w1 = 0;
            w2 = width - (x + w);
            if (w2 < 0)
                w2 = 0;
            h1 = y;
            if (h1 < 0)
                h1 = 0;
            h2 = height - (y + h);
            if (h2 < 0)
                h2 = 0;
            fill_rectangle(screen, render,
                           xleft, ytop,
                           w1, height,
                           color, update);
            fill_rectangle(screen, render,
                           xleft + width - w2, ytop,
                           w2, height,
                           color, update);
            fill_rectangle(screen, render,
                           xleft + w1, ytop,
                           width - w1 - w2, h1,
                           color, update);
            fill_rectangle(screen, render,
                           xleft + w1, ytop + height - h2,
                           width - w1 - w2, h2,
                           color, update);
        }

        static uint[] ReadInt32(uint i)
        {
            uint[] ret = new uint[4];
            ret[0] = (uint)((byte)i);
            ret[1] = (uint)((byte)(i >> 8));
            ret[2] = (uint)((byte)(i >> 16));
            ret[3] = (uint)((byte)(i >> 24));
            return ret;
        }
        
static uint ALPHA_BLEND(uint a, uint oldp, uint newp, uint s)
{
return (uint)((((oldp << (byte)s) * (255 - (a))) + (newp * (a))) / (255 << (byte)s));
}

static void RGBA_IN(ref uint r, ref uint g, ref uint b, ref uint a, uint s)
{
    // uint  v = ((const uint32_t *)(s))[0];
    uint v = ReadInt32(s)[0];
    a = (v >> 24) & 0xff;
    r = (v >> 16) & 0xff;
    g = (v >> 8) & 0xff;
    b = v & 0xff;
}

static void YUVA_IN(ref uint y, ref uint u, ref uint v, ref uint a, uint s, uint[] pal)
{
    //unsigned int val = ((const uint32_t *)(pal))[*(const uint8_t*)(s)];\
    uint val = pal[ReadInt32(s)[0]];
    a = (val >> 24) & 0xff;
    y = (val >> 16) & 0xff;
    u = (val >> 8) & 0xff;
    v = val & 0xff;
}

static void YUVA_OUT(uint[] d, uint y, uint u, uint v, uint a)
{
    //((uint32_t *)(d))[0] = (a << 24) | (y << 16) | (u << 8) | v;
    d[0] = (a << 24) | (y << 16) | (u << 8) | v;
}


        
static void blend_subrect(Native<AV.AVPicture> dst, Native<AV.AVSubtitleRect> rect, int imgw, int imgh)
{
    int wrap, wrap3, width2, skip2;
    int y, u, v, a, u1, v1, a1, w, h;
    IntPtr lum, cb, cr;
    IntPtr p;
    uint[] pal;
    int dstx, dsty, dstw, dsth;

    dstw = AV.av_clip(rect.O.w, 0, imgw);
    dsth = AV.av_clip(rect.O.h, 0, imgh);
    dstx = AV.av_clip(rect.O.x, 0, imgw - dstw);
    dsty = AV.av_clip(rect.O.y, 0, imgh - dsth);
    lum = new IntPtr(dst.O.data[0].ToInt64() + dsty * dst.O.linesize[0]);
    cb  = new IntPtr(dst.O.data[1].ToInt64() + (dsty >> 1) * dst.O.linesize[1]);
    cr  = new IntPtr(dst.O.data[2].ToInt64() + (dsty >> 1) * dst.O.linesize[2]);

    width2 = ((dstw + 1) >> 1) + (dstx & ~dstw & 1);
    skip2 = dstx >> 1;
    wrap = dst.O.linesize[0];
    wrap3 = rect.O.pict.linesize[0];
    p = rect.O.pict.data[0];
    pal = (const uint32_t *)rect->pict.data[1];  /* Now in YCrCb! */

    if (dsty & 1) {
        lum += dstx;
        cb += skip2;
        cr += skip2;

        if (dstx & 1) {
            YUVA_IN(y, u, v, a, p, pal);
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);
            cb[0] = ALPHA_BLEND(a >> 2, cb[0], u, 0);
            cr[0] = ALPHA_BLEND(a >> 2, cr[0], v, 0);
            cb++;
            cr++;
            lum++;
            p += BPP;
        }
        for (w = dstw - (dstx & 1); w >= 2; w -= 2) {
            YUVA_IN(y, u, v, a, p, pal);
            u1 = u;
            v1 = v;
            a1 = a;
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);

            YUVA_IN(y, u, v, a, p + BPP, pal);
            u1 += u;
            v1 += v;
            a1 += a;
            lum[1] = ALPHA_BLEND(a, lum[1], y, 0);
            cb[0] = ALPHA_BLEND(a1 >> 2, cb[0], u1, 1);
            cr[0] = ALPHA_BLEND(a1 >> 2, cr[0], v1, 1);
            cb++;
            cr++;
            p += 2 * BPP;
            lum += 2;
        }
        if (w) {
            YUVA_IN(y, u, v, a, p, pal);
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);
            cb[0] = ALPHA_BLEND(a >> 2, cb[0], u, 0);
            cr[0] = ALPHA_BLEND(a >> 2, cr[0], v, 0);
            p++;
            lum++;
        }
        p += wrap3 - dstw * BPP;
        lum += wrap - dstw - dstx;
        cb += dst->linesize[1] - width2 - skip2;
        cr += dst->linesize[2] - width2 - skip2;
    }
    for (h = dsth - (dsty & 1); h >= 2; h -= 2) {
        lum += dstx;
        cb += skip2;
        cr += skip2;

        if (dstx & 1) {
            YUVA_IN(y, u, v, a, p, pal);
            u1 = u;
            v1 = v;
            a1 = a;
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);
            p += wrap3;
            lum += wrap;
            YUVA_IN(y, u, v, a, p, pal);
            u1 += u;
            v1 += v;
            a1 += a;
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);
            cb[0] = ALPHA_BLEND(a1 >> 2, cb[0], u1, 1);
            cr[0] = ALPHA_BLEND(a1 >> 2, cr[0], v1, 1);
            cb++;
            cr++;
            p += -wrap3 + BPP;
            lum += -wrap + 1;
        }
        for (w = dstw - (dstx & 1); w >= 2; w -= 2) {
            YUVA_IN(y, u, v, a, p, pal);
            u1 = u;
            v1 = v;
            a1 = a;
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);

            YUVA_IN(y, u, v, a, p + BPP, pal);
            u1 += u;
            v1 += v;
            a1 += a;
            lum[1] = ALPHA_BLEND(a, lum[1], y, 0);
            p += wrap3;
            lum += wrap;

            YUVA_IN(y, u, v, a, p, pal);
            u1 += u;
            v1 += v;
            a1 += a;
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);

            YUVA_IN(y, u, v, a, p + BPP, pal);
            u1 += u;
            v1 += v;
            a1 += a;
            lum[1] = ALPHA_BLEND(a, lum[1], y, 0);

            cb[0] = ALPHA_BLEND(a1 >> 2, cb[0], u1, 2);
            cr[0] = ALPHA_BLEND(a1 >> 2, cr[0], v1, 2);

            cb++;
            cr++;
            p += -wrap3 + 2 * BPP;
            lum += -wrap + 2;
        }
        if (w) {
            YUVA_IN(y, u, v, a, p, pal);
            u1 = u;
            v1 = v;
            a1 = a;
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);
            p += wrap3;
            lum += wrap;
            YUVA_IN(y, u, v, a, p, pal);
            u1 += u;
            v1 += v;
            a1 += a;
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);
            cb[0] = ALPHA_BLEND(a1 >> 2, cb[0], u1, 1);
            cr[0] = ALPHA_BLEND(a1 >> 2, cr[0], v1, 1);
            cb++;
            cr++;
            p += -wrap3 + BPP;
            lum += -wrap + 1;
        }
        p += wrap3 + (wrap3 - dstw * BPP);
        lum += wrap + (wrap - dstw - dstx);
        cb += dst->linesize[1] - width2 - skip2;
        cr += dst->linesize[2] - width2 - skip2;
    }
    /* handle odd height */
    if (h) {
        lum += dstx;
        cb += skip2;
        cr += skip2;

        if (dstx & 1) {
            YUVA_IN(y, u, v, a, p, pal);
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);
            cb[0] = ALPHA_BLEND(a >> 2, cb[0], u, 0);
            cr[0] = ALPHA_BLEND(a >> 2, cr[0], v, 0);
            cb++;
            cr++;
            lum++;
            p += BPP;
        }
        for (w = dstw - (dstx & 1); w >= 2; w -= 2) {
            YUVA_IN(y, u, v, a, p, pal);
            u1 = u;
            v1 = v;
            a1 = a;
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);

            YUVA_IN(y, u, v, a, p + BPP, pal);
            u1 += u;
            v1 += v;
            a1 += a;
            lum[1] = ALPHA_BLEND(a, lum[1], y, 0);
            cb[0] = ALPHA_BLEND(a1 >> 2, cb[0], u, 1);
            cr[0] = ALPHA_BLEND(a1 >> 2, cr[0], v, 1);
            cb++;
            cr++;
            p += 2 * BPP;
            lum += 2;
        }
        if (w) {
            YUVA_IN(y, u, v, a, p, pal);
            lum[0] = ALPHA_BLEND(a, lum[0], y, 0);
            cb[0] = ALPHA_BLEND(a >> 2, cb[0], u, 0);
            cr[0] = ALPHA_BLEND(a >> 2, cr[0], v, 0);
        }
    }
}


static readonly uint BPP = 1;

        public void main(string[] arg)
        {

        }
    }
}
