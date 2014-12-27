/*
 * copyright (c) 20013 Crazyender
 *
 * This file is part of FFmpeg.mono
 *
 * FFmpeg.mono is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * FFmpeg.mono is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with FFmpeg; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
 */


using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;
namespace SharpFFmpeg
{
    public partial class AV 
{
		#if WIN32
public const string AVFORMAT = "avformat-55.dll";
		#else
		public const string AVFORMAT = "avformat";
		#endif

public static readonly uint AVPROBE_SCORE_RETRY = (AVPROBE_SCORE_MAX/4);
public static readonly uint AVPROBE_SCORE_STREAM_RETRY = (AVPROBE_SCORE_MAX/4-1);
public static readonly uint AVPROBE_SCORE_EXTENSION = 50;
public static readonly uint AVPROBE_SCORE_MAX = 100;
public static readonly uint AVPROBE_PADDING_SIZE = 32;
public static readonly uint AVFMT_NOFILE = 0x0001;
public static readonly uint AVFMT_NEEDNUMBER = 0x0002;
public static readonly uint AVFMT_SHOW_IDS = 0x0008;
public static readonly uint AVFMT_RAWPICTURE = 0x0020;
public static readonly uint AVFMT_GLOBALHEADER = 0x0040;
public static readonly uint AVFMT_NOTIMESTAMPS = 0x0080;
public static readonly uint AVFMT_GENERIC_INDEX = 0x0100;
public static readonly uint AVFMT_TS_DISCONT = 0x0200;
public static readonly uint AVFMT_VARIABLE_FPS = 0x0400;
public static readonly uint AVFMT_NODIMENSIONS = 0x0800;
public static readonly uint AVFMT_NOSTREAMS = 0x1000;
public static readonly uint AVFMT_NOBINSEARCH = 0x2000;
public static readonly uint AVFMT_NOGENSEARCH = 0x4000;
public static readonly uint AVFMT_NO_BYTE_SEEK = 0x8000;
public static readonly uint AVFMT_ALLOW_FLUSH = 0x10000;
public static readonly uint AVFMT_TS_NONSTRICT = 0x20000;
public static readonly uint AVFMT_TS_NEGATIVE = 0x40000;
public static readonly uint AVFMT_SEEK_TO_PTS = 0x4000000;
public static readonly uint AVINDEX_KEYFRAME = 0x0001;
public static readonly uint AV_DISPOSITION_DEFAULT = 0x0001;
public static readonly uint AV_DISPOSITION_DUB = 0x0002;
public static readonly uint AV_DISPOSITION_ORIGINAL = 0x0004;
public static readonly uint AV_DISPOSITION_COMMENT = 0x0008;
public static readonly uint AV_DISPOSITION_LYRICS = 0x0010;
public static readonly uint AV_DISPOSITION_KARAOKE = 0x0020;
public static readonly uint AV_DISPOSITION_FORCED = 0x0040;
public static readonly uint AV_DISPOSITION_HEARING_IMPAIRED = 0x0080;
public static readonly uint AV_DISPOSITION_VISUAL_IMPAIRED = 0x0100;
public static readonly uint AV_DISPOSITION_CLEAN_EFFECTS = 0x0200;
public static readonly uint AV_DISPOSITION_ATTACHED_PIC = 0x0400;
public static readonly uint AV_DISPOSITION_CAPTIONS = 0x10000;
public static readonly uint AV_DISPOSITION_DESCRIPTIONS = 0x20000;
public static readonly uint AV_DISPOSITION_METADATA = 0x40000;
public static readonly uint AV_PTS_WRAP_IGNORE = 0;
public static readonly uint AV_PTS_WRAP_ADD_OFFSET = 1;
public static readonly int AV_PTS_WRAP_SUB_OFFSET = -1;
public static readonly uint MAX_STD_TIMEBASES = (60*12+6);
public static readonly uint MAX_PROBE_PACKETS = 2500;
public static readonly uint MAX_REORDER_DELAY = 16;
public static readonly uint AV_PROGRAM_RUNNING = 1;
public static readonly uint AVFMTCTX_NOHEADER = 0x0001;
public static readonly uint AVFMT_FLAG_GENPTS = 0x0001;
public static readonly uint AVFMT_FLAG_IGNIDX = 0x0002;
public static readonly uint AVFMT_FLAG_NONBLOCK = 0x0004;
public static readonly uint AVFMT_FLAG_IGNDTS = 0x0008;
public static readonly uint AVFMT_FLAG_NOFILLIN = 0x0010;
public static readonly uint AVFMT_FLAG_NOPARSE = 0x0020;
public static readonly uint AVFMT_FLAG_NOBUFFER = 0x0040;
public static readonly uint AVFMT_FLAG_CUSTOM_IO = 0x0080;
public static readonly uint AVFMT_FLAG_DISCARD_CORRUPT = 0x0100;
public static readonly uint AVFMT_FLAG_FLUSH_PACKETS = 0x0200;
public static readonly uint AVFMT_FLAG_MP4A_LATM = 0x8000;
public static readonly uint AVFMT_FLAG_SORT_DTS = 0x10000;
public static readonly uint AVFMT_FLAG_PRIV_OPT = 0x20000;
public static readonly uint AVFMT_FLAG_KEEP_SIDE_DATA = 0x40000;
public static readonly uint FF_FDEBUG_TS = 0x0001;
public static readonly uint RAW_PACKET_BUFFER_SIZE = 2500000;
public static readonly int AVSEEK_FLAG_BACKWARD = 1;
public static readonly int AVSEEK_FLAG_BYTE = 2;
public static readonly int AVSEEK_FLAG_ANY = 4;
public static readonly int AVSEEK_FLAG_FRAME = 8;
public enum AVStreamParseType
{
	AVSTREAM_PARSE_NONE = 0,
	AVSTREAM_PARSE_FULL = 1,
	AVSTREAM_PARSE_HEADERS = 2,
	AVSTREAM_PARSE_TIMESTAMPS = 3,
	AVSTREAM_PARSE_FULL_ONCE = 4,
	AVSTREAM_PARSE_FULL_RAW = 1463898624,
}

public enum AVDurationEstimationMethod
{
	AVFMT_DURATION_FROM_PTS = 0,
	AVFMT_DURATION_FROM_STREAM = 1,
	AVFMT_DURATION_FROM_BITRATE = 2,
}

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_get_packet(
	IntPtr/* AVIOContext*  */ s, 
	IntPtr/* AVPacket*  */ pkt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_append_packet(
	IntPtr/* AVIOContext*  */ s, 
	IntPtr/* AVPacket*  */ pkt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern AVRational av_stream_get_r_frame_rate(
	IntPtr/* AVStream*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_stream_set_r_frame_rate(
	IntPtr/* AVStream*  */ s, 
	AVRational r);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_format_get_probe_score(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVCodec*  */ av_format_get_video_codec(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_format_set_video_codec(
	IntPtr/* AVFormatContext*  */ s, 
	IntPtr/* AVCodec*  */ c);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVCodec*  */ av_format_get_audio_codec(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_format_set_audio_codec(
	IntPtr/* AVFormatContext*  */ s, 
	IntPtr/* AVCodec*  */ c);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVCodec*  */ av_format_get_subtitle_codec(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_format_set_subtitle_codec(
	IntPtr/* AVFormatContext*  */ s, 
	IntPtr/* AVCodec*  */ c);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_format_get_metadata_header_padding(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_format_set_metadata_header_padding(
	IntPtr/* AVFormatContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 c);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_format_get_opaque(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_format_set_opaque(
	IntPtr/* AVFormatContext*  */ s, 
	IntPtr/* void*  */ opaque);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern avformat_func_6 av_format_get_control_message_cb(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_format_set_control_message_cb(
	IntPtr/* AVFormatContext*  */ s, 
	[MarshalAs(UnmanagedType.FunctionPtr)]
	avformat_func_6 callback);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern AVDurationEstimationMethod av_fmt_ctx_get_duration_estimation_method(
	IntPtr/* AVFormatContext*  */ ctx);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 avformat_version(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern string avformat_configuration(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern string avformat_license(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_register_all(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_register_input_format(
	IntPtr/* AVInputFormat*  */ format);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_register_output_format(
	IntPtr/* AVOutputFormat*  */ format);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 avformat_network_init(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 avformat_network_deinit(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVInputFormat*  */ av_iformat_next(
	IntPtr/* AVInputFormat*  */ f);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVOutputFormat*  */ av_oformat_next(
	IntPtr/* AVOutputFormat*  */ f);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVFormatContext*  */ avformat_alloc_context(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void avformat_free_context(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVClass*  */ avformat_get_class(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVStream*  */ avformat_new_stream(
	IntPtr/* AVFormatContext*  */ s, 
	IntPtr/* AVCodec*  */ c);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVProgram*  */ av_new_program(
	IntPtr/* AVFormatContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 id);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVFormatContext*  */ avformat_alloc_output_context(
	[MarshalAs(UnmanagedType.LPStr)]
	string format, 
	IntPtr/* AVOutputFormat*  */ oformat, 
	[MarshalAs(UnmanagedType.LPStr)]
	string filename);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 avformat_alloc_output_context2(
	IntPtr/* IntPtr*  */ ctx, 
	IntPtr/* AVOutputFormat*  */ oformat, 
	[MarshalAs(UnmanagedType.LPStr)]
	string format_name, 
	[MarshalAs(UnmanagedType.LPStr)]
	string filename);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVInputFormat*  */ av_find_input_format(
	[MarshalAs(UnmanagedType.LPStr)]
	string short_name);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVInputFormat*  */ av_probe_input_format(
	IntPtr/* AVProbeData*  */ pd, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 is_opened);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVInputFormat*  */ av_probe_input_format2(
	IntPtr/* AVProbeData*  */ pd, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 is_opened, 
	IntPtr/* System.Int32*  */ score_max);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVInputFormat*  */ av_probe_input_format3(
	IntPtr/* AVProbeData*  */ pd, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 is_opened, 
	IntPtr/* System.Int32*  */ score_ret);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_probe_input_buffer2(
	IntPtr/* AVIOContext*  */ pb, 
	IntPtr/* IntPtr*  */ fmt, 
	[MarshalAs(UnmanagedType.LPStr)]
	string filename, 
	IntPtr/* void*  */ logctx, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 offset, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 max_probe_size);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_probe_input_buffer(
	IntPtr/* AVIOContext*  */ pb, 
	IntPtr/* IntPtr*  */ fmt, 
	[MarshalAs(UnmanagedType.LPStr)]
	string filename, 
	IntPtr/* void*  */ logctx, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 offset, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 max_probe_size);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 avformat_open_input(
    [Out]out IntPtr pFormatContext, 
	[MarshalAs(UnmanagedType.LPStr)]
	string filename, 
	IntPtr/* AVInputFormat*  */ fmt, 
	IntPtr/* IntPtr*  */ options);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_demuxer_open(
	IntPtr/* AVFormatContext*  */ ic);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_find_stream_info(
	IntPtr/* AVFormatContext*  */ ic);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 avformat_find_stream_info(
	IntPtr/* AVFormatContext*  */ ic, 
	IntPtr/* IntPtr*  */ options);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVProgram*  */ av_find_program_from_stream(
	IntPtr/* AVFormatContext*  */ ic, 
	IntPtr/* AVProgram*  */ last, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_find_best_stream(
	IntPtr/* AVFormatContext*  */ ic, 
	AVMediaType type, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 wanted_stream_nb, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 related_stream, 
	IntPtr/* IntPtr*  */ decoder_ret, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_read_packet(
	IntPtr/* AVFormatContext*  */ s, 
	IntPtr/* AVPacket*  */ pkt);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_read_frame(
	IntPtr/* AVFormatContext*  */ s, 
	IntPtr/* AVPacket*  */ pkt);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_seek_frame(
	IntPtr/* AVFormatContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 stream_index, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 timestamp, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 avformat_seek_file(
	IntPtr/* AVFormatContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 stream_index, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 min_ts, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 ts, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 max_ts, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_read_play(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_read_pause(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_close_input_file(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void avformat_close_input(
	IntPtr/* IntPtr*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVStream*  */ av_new_stream(
	IntPtr/* AVFormatContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 id);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_set_pts_info(
	IntPtr/* AVStream*  */ s, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 pts_wrap_bits, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 pts_num, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 pts_den);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 avformat_write_header(
	IntPtr/* AVFormatContext*  */ s, 
	IntPtr/* IntPtr*  */ options);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_write_frame(
	IntPtr/* AVFormatContext*  */ s, 
	IntPtr/* AVPacket*  */ pkt);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_interleaved_write_frame(
	IntPtr/* AVFormatContext*  */ s, 
	IntPtr/* AVPacket*  */ pkt);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_write_trailer(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVOutputFormat*  */ av_guess_format(
	[MarshalAs(UnmanagedType.LPStr)]
	string short_name, 
	[MarshalAs(UnmanagedType.LPStr)]
	string filename, 
	[MarshalAs(UnmanagedType.LPStr)]
	string mime_type);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern AVCodecID av_guess_codec(
	IntPtr/* AVOutputFormat*  */ fmt, 
	[MarshalAs(UnmanagedType.LPStr)]
	string short_name, 
	[MarshalAs(UnmanagedType.LPStr)]
	string filename, 
	[MarshalAs(UnmanagedType.LPStr)]
	string mime_type, 
	AVMediaType type);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_get_output_timestamp(
	IntPtr/* AVFormatContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 stream, 
	IntPtr/* System.Int64*  */ dts, 
	IntPtr/* System.Int64*  */ wall);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_hex_dump(
	IntPtr/* _iobuf*  */ f, 
	IntPtr/* System.Byte*  */ buf, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_hex_dump_log(
	IntPtr/* void*  */ avcl, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 level, 
	IntPtr/* System.Byte*  */ buf, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_pkt_dump2(
	IntPtr/* _iobuf*  */ f, 
	IntPtr/* AVPacket*  */ pkt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 dump_payload, 
	IntPtr/* AVStream*  */ st);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_pkt_dump_log2(
	IntPtr/* void*  */ avcl, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 level, 
	IntPtr/* AVPacket*  */ pkt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 dump_payload, 
	IntPtr/* AVStream*  */ st);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern AVCodecID av_codec_get_id(
	IntPtr/* IntPtr*  */ tags, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 tag);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 av_codec_get_tag(
	IntPtr/* IntPtr*  */ tags, 
	AVCodecID id);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_codec_get_tag2(
	IntPtr/* IntPtr*  */ tags, 
	AVCodecID id, 
	IntPtr/* System.UInt32*  */ tag);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_find_default_stream_index(
	IntPtr/* AVFormatContext*  */ s);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_index_search_timestamp(
	IntPtr/* AVStream*  */ st, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 timestamp, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_add_index_entry(
	IntPtr/* AVStream*  */ st, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 pos, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 timestamp, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 distance, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_url_split(
	[MarshalAs(UnmanagedType.LPStr)]
	string proto, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 proto_size, 
	[MarshalAs(UnmanagedType.LPStr)]
	string authorization, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 authorization_size, 
	[MarshalAs(UnmanagedType.LPStr)]
	string hostname, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 hostname_size, 
	IntPtr/* System.Int32*  */ port_ptr, 
	[MarshalAs(UnmanagedType.LPStr)]
	string path, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 path_size, 
	[MarshalAs(UnmanagedType.LPStr)]
	string url);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern void av_dump_format(
	IntPtr/* AVFormatContext*  */ ic, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 index, 
	[MarshalAs(UnmanagedType.LPStr)]
	string url, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 is_output);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_get_frame_filename(
	[MarshalAs(UnmanagedType.LPStr)]
	string buf, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 buf_size, 
	[MarshalAs(UnmanagedType.LPStr)]
	string path, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 number);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_filename_number_test(
	[MarshalAs(UnmanagedType.LPStr)]
	string filename);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_sdp_create(
	IntPtr ac, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 n_files, 
	[MarshalAs(UnmanagedType.LPStr)]
	string buf, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_match_ext(
	[MarshalAs(UnmanagedType.LPStr)]
	string filename, 
	[MarshalAs(UnmanagedType.LPStr)]
	string extensions);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 avformat_query_codec(
	IntPtr/* AVOutputFormat*  */ ofmt, 
	AVCodecID codec_id, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 std_compliance);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVCodecTag*  */ avformat_get_riff_video_tags(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVCodecTag*  */ avformat_get_riff_audio_tags(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVCodecTag*  */ avformat_get_mov_video_tags(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVCodecTag*  */ avformat_get_mov_audio_tags(
);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern AVRational av_guess_sample_aspect_ratio(
	IntPtr/* AVFormatContext*  */ format, 
	IntPtr/* AVStream*  */ stream, 
	IntPtr/* AVFrame*  */ frame);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern AVRational av_guess_frame_rate(
	IntPtr/* AVFormatContext*  */ ctx, 
	IntPtr/* AVStream*  */ stream, 
	IntPtr/* AVFrame*  */ frame);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 avformat_match_stream_specifier(
	IntPtr/* AVFormatContext*  */ s, 
	IntPtr/* AVStream*  */ st, 
	[MarshalAs(UnmanagedType.LPStr)]
	string spec);

[DllImport(AVFORMAT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 avformat_queue_attached_pictures(
	IntPtr/* AVFormatContext*  */ s);

public struct AVFormatContext{
	public IntPtr/* AVClass*  */ av_class;

	public IntPtr/* AVInputFormat*  */ iformat;

	public IntPtr/* AVOutputFormat*  */ oformat;

	public IntPtr/* void*  */ priv_data;

	public IntPtr/* AVIOContext*  */ pb;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 ctx_flags;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 nb_streams;

   
    private IntPtr streams; // AVStream *
    public IntPtr[] Streams
    {
        get
        {
            IntPtr[] ret = new IntPtr[nb_streams];
            for (int i = 0; i < nb_streams; i++)
            {
                IntPtr address = new IntPtr(streams.ToInt64() + i * Marshal.SizeOf(IntPtr.Zero));
                ret[i] = Marshal.ReadIntPtr(address);
            }
            return ret;
        }
    }

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=1024)]
	public Char[] filename;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 start_time;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 duration;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 bit_rate;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 packet_size;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 max_delay;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 flags;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 probesize;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 max_analyze_duration;

	public IntPtr/* System.Byte*  */ key;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 keylen;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 nb_programs;

	public IntPtr/* IntPtr*  */ programs;

	public AVCodecID video_codec_id;

	public AVCodecID audio_codec_id;

	public AVCodecID subtitle_codec_id;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 max_index_size;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 max_picture_buffer;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 nb_chapters;

	public IntPtr/* IntPtr*  */ chapters;

	public IntPtr/* AVDictionary*  */ metadata;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 start_time_realtime;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 fps_probe_size;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 error_recognition;

	public AVIOInterruptCB interrupt_callback;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 debug;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 max_interleave_delta;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 ts_id;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 audio_preload;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 max_chunk_duration;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 max_chunk_size;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 use_wallclock_as_timestamps;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 avoid_negative_ts;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 avio_flags;

	public AVDurationEstimationMethod duration_estimation_method;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 skip_initial_bytes;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 correct_ts_overflow;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 seek2any;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 flush_packets;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 probe_score;

	public IntPtr/* AVPacketList*  */ packet_buffer;

	public IntPtr/* AVPacketList*  */ packet_buffer_end;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 data_offset;

	public IntPtr/* AVPacketList*  */ raw_packet_buffer;

	public IntPtr/* AVPacketList*  */ raw_packet_buffer_end;

	public IntPtr/* AVPacketList*  */ parse_queue;

	public IntPtr/* AVPacketList*  */ parse_queue_end;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 raw_packet_buffer_remaining_size;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 offset;

	public AVRational offset_timebase;

	public IntPtr/* AVFormatInternal*  */ _internal;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 io_repositioned;

	public IntPtr/* AVCodec*  */ video_codec;

	public IntPtr/* AVCodec*  */ audio_codec;

	public IntPtr/* AVCodec*  */ subtitle_codec;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 metadata_header_padding;

	public IntPtr/* void*  */ opaque;

	//[MarshalAs(UnmanagedType.FunctionPtr)]
	//public avformat_func_6 control_message_cb;

	//[MarshalAs(UnmanagedType.I8)]
	//public System.Int64 output_ts_offset;

};

public struct AVFrac{
	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 val;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 num;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 den;

};

public struct AVProbeData{
	[MarshalAs(UnmanagedType.LPStr)]
	public string filename;

	[MarshalAs(UnmanagedType.LPStr)]
	public string buf;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 buf_size;

};

public struct AVOutputFormat{
	[MarshalAs(UnmanagedType.LPStr)]
	public string name;

	[MarshalAs(UnmanagedType.LPStr)]
	public string long_name;

	[MarshalAs(UnmanagedType.LPStr)]
	public string mime_type;

	[MarshalAs(UnmanagedType.LPStr)]
	public string extensions;

	public AVCodecID audio_codec;

	public AVCodecID video_codec;

	public AVCodecID subtitle_codec;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 flags;

	public IntPtr/* IntPtr*  */ codec_tag;

	public IntPtr/* AVClass*  */ priv_class;

	public IntPtr/* AVOutputFormat*  */ next;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 priv_data_size;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avio_func_2 write_header;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avformat_func_7 write_packet;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avio_func_2 write_trailer;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avformat_func_8 interleave_packet;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avformat_func_9 query_codec;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avformat_func_10 get_output_timestamp;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avformat_func_6 control_message;

};

public struct AVInputFormat{
	[MarshalAs(UnmanagedType.LPStr)]
	public string name;

	[MarshalAs(UnmanagedType.LPStr)]
	public string long_name;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 flags;

	[MarshalAs(UnmanagedType.LPStr)]
	public string extensions;

	public IntPtr/* IntPtr*  */ codec_tag;

	public IntPtr/* AVClass*  */ priv_class;

	public IntPtr/* AVInputFormat*  */ next;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 raw_codec_id;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 priv_data_size;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avio_func_2 read_probe;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avio_func_2 read_header;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avformat_func_7 read_packet;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avio_func_2 read_close;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avformat_func_11 read_seek;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avformat_func_12 read_timestamp;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avio_func_2 read_play;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avio_func_2 read_pause;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public avformat_func_13 read_seek2;

};

public struct AVStream{
	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 index;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 id;

	public IntPtr/* AVCodecContext*  */ codec;

	public IntPtr/* void*  */ priv_data;

	public AVFrac pts;

	public AVRational time_base;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 start_time;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 duration;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 nb_frames;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 disposition;

	public AVDiscard discard;

	public AVRational sample_aspect_ratio;

	public IntPtr/* AVDictionary*  */ metadata;

	public AVRational avg_frame_rate;

	public AVPacket attached_pic;

	public IntPtr/* *  */ info;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 pts_wrap_bits;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 do_not_use;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 first_dts;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 cur_dts;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 last_IP_pts;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 last_IP_duration;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 probe_packets;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 codec_info_nb_frames;

	public AVStreamParseType need_parsing;

	public IntPtr/* AVCodecParserContext*  */ parser;

	public IntPtr/* AVPacketList*  */ last_in_packet_buffer;

	public AVProbeData probe_data;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=17)]
	public Int64[] pts_buffer;

	public IntPtr/* AVIndexEntry*  */ index_entries;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 nb_index_entries;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 index_entries_allocated_size;

	public AVRational r_frame_rate;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 stream_identifier;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 interleaver_chunk_size;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 interleaver_chunk_duration;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 request_probe;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 skip_to_keyframe;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 skip_samples;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 nb_decoded_frames;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 mux_ts_offset;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 pts_wrap_reference;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 pts_wrap_behavior;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 update_initial_durations_done;

};

public struct AVPacketList{
	public AVPacket pkt;

	public IntPtr/* AVPacketList*  */ next;

};

public struct AVIndexEntry{
	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 pos;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 flags;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 size;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 min_distance;

};

public struct AVProgram{
	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 id;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 flags;

	public AVDiscard discard;

	public IntPtr/* System.UInt32*  */ stream_index;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 nb_stream_indexes;

	public IntPtr/* AVDictionary*  */ metadata;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 program_num;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 pmt_pid;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 pcr_pid;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 start_time;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 end_time;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 pts_wrap_reference;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 pts_wrap_behavior;

};

public struct AVChapter{
	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 id;

	public AVRational time_base;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 start;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 end;

	public IntPtr/* AVDictionary*  */ metadata;

};

public delegate System.Int32 avio_func_0(
	IntPtr/* void*  */ opaque, 
	IntPtr/* System.Byte*  */ buf, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 buf_size);

public delegate System.Int64 avio_func_1(
	IntPtr/* void*  */ opaque, 
	[MarshalAs(UnmanagedType.I8)]System.Int64 offset, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 whence);

public delegate System.Int32 avio_func_2(
	IntPtr/* void*  */ __arg0);

public delegate System.UInt32 avio_func_3(
	[MarshalAs(UnmanagedType.I4)]System.UInt32 checksum, 
	IntPtr/* System.Byte*  */ buf, 
	[MarshalAs(UnmanagedType.I4)]System.UInt32 size);

public delegate System.Int32 avio_func_4(
	IntPtr/* void*  */ opaque, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 pause);

public delegate System.Int64 avio_func_5(
	IntPtr/* void*  */ opaque, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 stream_index, 
	[MarshalAs(UnmanagedType.I8)]System.Int64 timestamp, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 flags);

public delegate System.Int32 avformat_func_6(
	IntPtr/* AVFormatContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 type, 
	IntPtr/* void*  */ data, 
	[MarshalAs(UnmanagedType.I4)]System.UInt32 data_size);

public delegate System.Int32 avformat_func_7(
	IntPtr/* AVFormatContext*  */ __arg0, 
	IntPtr/* AVPacket*  */ pkt);

public delegate System.Int32 avformat_func_8(
	IntPtr/* AVFormatContext*  */ __arg0, 
	IntPtr/* AVPacket*  */ _out, 
	IntPtr/* AVPacket*  */ _in, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 flush);

public delegate System.Int32 avformat_func_9(
	AVCodecID id, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 std_compliance);

public delegate void avformat_func_10(
	IntPtr/* AVFormatContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 stream, 
	IntPtr/* System.Int64*  */ dts, 
	IntPtr/* System.Int64*  */ wall);

public delegate System.Int32 avformat_func_11(
	IntPtr/* AVFormatContext*  */ __arg0, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 stream_index, 
	[MarshalAs(UnmanagedType.I8)]System.Int64 timestamp, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 flags);

public delegate System.Int64 avformat_func_12(
	IntPtr/* AVFormatContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 stream_index, 
	IntPtr/* System.Int64*  */ pos, 
	[MarshalAs(UnmanagedType.I8)]System.Int64 pos_limit);

public delegate System.Int32 avformat_func_13(
	IntPtr/* AVFormatContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 stream_index, 
	[MarshalAs(UnmanagedType.I8)]System.Int64 min_ts, 
	[MarshalAs(UnmanagedType.I8)]System.Int64 ts, 
	[MarshalAs(UnmanagedType.I8)]System.Int64 max_ts, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 flags);

}
}

