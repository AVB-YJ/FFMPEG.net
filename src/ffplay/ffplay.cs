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
            AV.AVPacket pkt;
            MyAVPacketList next;
            int serial;
        }

        class PacketQueue
        {
            MyAVPacketList first_pkt;
            MyAVPacketList last_pkt;
            int nb_packets;
            int size;
            int abort_request;
            int serial;
            /*SDL_mutex * */
            IntPtr mutex;
            /*SDL_cond * */
            IntPtr cond;
        }

        static readonly uint VIDEO_PICTURE_QUEUE_SIZE = 3;
        static readonly uint SUBPICTURE_QUEUE_SIZE = 4;

        class VideoPicture
        {
            double pts;             // presentation timestamp for this picture
            double duration;        // estimated duration based on frame rate
            Int64 pos;            // byte position in file
            /*SDL_Overlay * */
            IntPtr bmp;
            int width, height; /* source height & width */
            int allocated;
            int reallocate;
            int serial;

            AV.AVRational sar;
        }

        class SubPicture
        {
            double pts; /* presentation time stamp for this picture */
            AV.AVSubtitle sub;
            int serial;
        }

        class AudioParams
        {
            int freq;
            int channels;
            Int64 channel_layout;
            AV.AVSampleFormat fmt;
            int frame_size;
            int bytes_per_sec;
        }

        class Clock
        {
            double pts;           /* clock base */
            double pts_drift;     /* clock base minus time at which we updated the clock */
            double last_updated;
            double speed;
            int serial;           /* clock is based on a packet with this serial */
            int paused;
            /*int * */
            int[] queue_serial;    /* pointer to the current packet queue serial, used for obsolete clock detection */
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
            IntPtr read_tid;
            /*SDL_Thread * */
            IntPtr video_tid;
            Native<AV.AVInputFormat> iformat;
            int no_background;
            int abort_request;
            int force_refresh;
            int paused;
            int last_paused;
            int queue_attachments_req;
            int seek_req;
            int seek_flags;
            Int64 seek_pos;
            Int64 seek_rel;
            int read_pause_return;
            Native<AV.AVFormatContext> ic;
            int realtime;
            int audio_finished;
            int video_finished;

            Clock audclk;
            Clock vidclk;
            Clock extclk;

            int audio_stream;

            int av_sync_type;

            double audio_clock;
            int audio_clock_serial;
            double audio_diff_cum; /* used for AV difference average computation */
            double audio_diff_avg_coef;
            double audio_diff_threshold;
            int audio_diff_avg_count;
            Native<AV.AVStream> audio_st;
            PacketQueue audioq;
            int audio_hw_buf_size;
            byte[] silence_buf;
            byte[] audio_buf;
            byte[] audio_buf1;
            uint audio_buf_size; /* in bytes */
            uint audio_buf1_size;
            int audio_buf_index; /* in bytes */
            int audio_write_buf_size;
            int audio_buf_frames_pending;
            AV.AVPacket audio_pkt_temp;
            AV.AVPacket audio_pkt;
            int audio_pkt_temp_serial;
            int audio_last_serial;
            AudioParams audio_src;
            AudioParams audio_tgt;
            /*SwrContext **/
            IntPtr swr_ctx;
            int frame_drops_early;
            int frame_drops_late;
            Native<AV.AVFrame> frame;
            Int64 audio_frame_next_pts;


            Int16[] sample_array;
            int sample_array_index;
            int last_i_start;
            /*RDFTContext * */
            IntPtr rdft;
            int rdft_bits;
            /*FFTSample * */
            IntPtr rdft_data;
            int xpos;
            double last_vis_time;

            /*SDL_Thread * */
            IntPtr subtitle_tid;
            int subtitle_stream;
            Native<AV.AVStream> subtitle_st;
            PacketQueue subtitleq;
            SubPicture[] subpq;
            int subpq_size, subpq_rindex, subpq_windex;
            /*SDL_mutex * */
            IntPtr subpq_mutex;
            /*SDL_cond * */
            IntPtr subpq_cond;

            double frame_timer;
            double frame_last_returned_time;
            double frame_last_filter_delay;
            int video_stream;
            Native<AV.AVStream> video_st;
            PacketQueue videoq;
            Int64 video_current_pos;      // current displayed file pos
            double max_frame_duration;      // maximum duration of a frame - above this, we consider the jump a timestamp discontinuity
            VideoPicture[] pictq;
            int pictq_size, pictq_rindex, pictq_windex;
            /*SDL_mutex * */
            IntPtr pictq_mutex;
            /*SDL_cond * */
            IntPtr pictq_cond;
            SDLNative.SDL_Rect last_display_rect;

            string filename;
            int width, height, xleft, ytop;
            int step;
            int last_video_stream, last_audio_stream, last_subtitle_stream;

            /*SDL_cond * */
            IntPtr continue_read_thread;
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

        static AV.AVPacket flush_pkt;

        static readonly SDLNative.SDL_EventType FF_ALLOC_EVENT = (SDLNative.SDL_EventType.SDL_USEREVENT);
        static readonly SDLNative.SDL_EventType FF_QUIT_EVENT = (SDLNative.SDL_EventType.SDL_USEREVENT + 2);

        static /*SDL_Surface * */ IntPtr screen;

        public void main(string[] arg)
        {

        }
    }
}
