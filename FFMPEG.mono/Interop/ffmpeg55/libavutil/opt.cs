/*
 * copyright (c) 2013 Crazyender
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
    public partial class NativeMethods55 
{
public const string OPT = "avutil-52.dll";


public static readonly uint AV_OPT_FLAG_ENCODING_PARAM = 1;
public static readonly uint AV_OPT_FLAG_DECODING_PARAM = 2;
public static readonly uint AV_OPT_FLAG_METADATA = 4;
public static readonly uint AV_OPT_FLAG_AUDIO_PARAM = 8;
public static readonly uint AV_OPT_FLAG_VIDEO_PARAM = 16;
public static readonly uint AV_OPT_FLAG_SUBTITLE_PARAM = 32;
public static readonly uint AV_OPT_FLAG_FILTERING_PARAM = (1<<16);
public static readonly uint AV_OPT_SEARCH_CHILDREN = 0x0001;
public static readonly uint AV_OPT_SEARCH_FAKE_OBJ = 0x0002;
public enum AVOptionType
{
	AV_OPT_TYPE_FLAGS = 0,
	AV_OPT_TYPE_INT = 1,
	AV_OPT_TYPE_INT64 = 2,
	AV_OPT_TYPE_DOUBLE = 3,
	AV_OPT_TYPE_FLOAT = 4,
	AV_OPT_TYPE_STRING = 5,
	AV_OPT_TYPE_RATIONAL = 6,
	AV_OPT_TYPE_BINARY = 7,
	AV_OPT_TYPE_CONST = 128,
	AV_OPT_TYPE_IMAGE_SIZE = 1397316165,
	AV_OPT_TYPE_PIXEL_FMT = 1346784596,
	AV_OPT_TYPE_SAMPLE_FMT = 1397116244,
	AV_OPT_TYPE_VIDEO_RATE = 1448231252,
	AV_OPT_TYPE_DURATION = 1146442272,
	AV_OPT_TYPE_COLOR = 1129270354,
	AV_OPT_TYPE_CHANNEL_LAYOUT = 1128811585,
	FF_OPT_TYPE_FLAGS = 0,
	FF_OPT_TYPE_INT = 1,
	FF_OPT_TYPE_INT64 = 2,
	FF_OPT_TYPE_DOUBLE = 3,
	FF_OPT_TYPE_FLOAT = 4,
	FF_OPT_TYPE_STRING = 5,
	FF_OPT_TYPE_RATIONAL = 6,
	FF_OPT_TYPE_BINARY = 7,
	FF_OPT_TYPE_CONST = 128,
}

public enum AVOptFlag
{
	AV_OPT_FLAG_IMPLICIT_KEY = 1,
}

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVOption*  */ av_find_opt(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.LPStr)]
	string unit, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 mask, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_set_string3(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.LPStr)]
	string val, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 alloc, 
	IntPtr/* IntPtr*  */ o_out);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVOption*  */ av_set_double(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.R8)]
	System.Double n);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVOption*  */ av_set_q(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	AVRational n);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVOption*  */ av_set_int(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 n);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Double av_get_double(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	IntPtr/* IntPtr*  */ o_out);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern AVRational av_get_q(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	IntPtr/* IntPtr*  */ o_out);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_get_int(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	IntPtr/* IntPtr*  */ o_out);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern string av_get_string(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	IntPtr/* IntPtr*  */ o_out, 
	[MarshalAs(UnmanagedType.LPStr)]
	string buf, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 buf_len);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVOption*  */ av_next_option(
	IntPtr/* void*  */ obj, 
	IntPtr/* AVOption*  */ last);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_show2(
	IntPtr/* void*  */ obj, 
	IntPtr/* void*  */ av_log_obj, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 req_flags, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 rej_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern void av_opt_set_defaults(
	IntPtr/* void*  */ s);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern void av_opt_set_defaults2(
	IntPtr/* void*  */ s, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 mask, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_set_options_string(
	IntPtr/* void*  */ ctx, 
	[MarshalAs(UnmanagedType.LPStr)]
	string opts, 
	[MarshalAs(UnmanagedType.LPStr)]
	string key_val_sep, 
	[MarshalAs(UnmanagedType.LPStr)]
	string pairs_sep);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set_from_string(
	IntPtr/* void*  */ ctx, 
	[MarshalAs(UnmanagedType.LPStr)]
	string opts, 
	IntPtr/* string*  */ shorthand, 
	[MarshalAs(UnmanagedType.LPStr)]
	string key_val_sep, 
	[MarshalAs(UnmanagedType.LPStr)]
	string pairs_sep);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern void av_opt_free(
	IntPtr/* void*  */ obj);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_flag_is_set(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string field_name, 
	[MarshalAs(UnmanagedType.LPStr)]
	string flag_name);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set_dict(
	IntPtr/* void*  */ obj, 
	IntPtr/* IntPtr*  */ options);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_get_key_value(
	IntPtr/* string*  */ ropts, 
	[MarshalAs(UnmanagedType.LPStr)]
	string key_val_sep, 
	[MarshalAs(UnmanagedType.LPStr)]
	string pairs_sep, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags, 
	IntPtr/* string*  */ rkey, 
	IntPtr/* string*  */ rval);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_eval_flags(
	IntPtr/* void*  */ obj, 
	IntPtr/* AVOption*  */ o, 
	[MarshalAs(UnmanagedType.LPStr)]
	string val, 
	IntPtr/* System.Int32*  */ flags_out);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_eval_int(
	IntPtr/* void*  */ obj, 
	IntPtr/* AVOption*  */ o, 
	[MarshalAs(UnmanagedType.LPStr)]
	string val, 
	IntPtr/* System.Int32*  */ int_out);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_eval_int64(
	IntPtr/* void*  */ obj, 
	IntPtr/* AVOption*  */ o, 
	[MarshalAs(UnmanagedType.LPStr)]
	string val, 
	IntPtr/* System.Int64*  */ int64_out);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_eval_float(
	IntPtr/* void*  */ obj, 
	IntPtr/* AVOption*  */ o, 
	[MarshalAs(UnmanagedType.LPStr)]
	string val, 
	IntPtr/* float*  */ float_out);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_eval_double(
	IntPtr/* void*  */ obj, 
	IntPtr/* AVOption*  */ o, 
	[MarshalAs(UnmanagedType.LPStr)]
	string val, 
	IntPtr/* System.Double*  */ double_out);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_eval_q(
	IntPtr/* void*  */ obj, 
	IntPtr/* AVOption*  */ o, 
	[MarshalAs(UnmanagedType.LPStr)]
	string val, 
	IntPtr/* AVRational*  */ q_out);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVOption*  */ av_opt_find(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.LPStr)]
	string unit, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 opt_flags, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVOption*  */ av_opt_find2(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.LPStr)]
	string unit, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 opt_flags, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags, 
	IntPtr/* IntPtr*  */ target_obj);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVOption*  */ av_opt_next(
	IntPtr/* void*  */ obj, 
	IntPtr/* AVOption*  */ prev);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_opt_child_next(
	IntPtr/* void*  */ obj, 
	IntPtr/* void*  */ prev);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVClass*  */ av_opt_child_class_next(
	IntPtr/* AVClass*  */ parent, 
	IntPtr/* AVClass*  */ prev);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.LPStr)]
	string val, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set_int(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 val, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set_double(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.R8)]
	System.Double val, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set_q(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	AVRational val, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set_bin(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	IntPtr/* System.Byte*  */ val, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set_image_size(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 w, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 h, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set_pixel_fmt(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	AVPixelFormat fmt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set_sample_fmt(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	AVSampleFormat fmt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set_video_rate(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	AVRational val, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_set_channel_layout(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 ch_layout, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_get(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags, 
	IntPtr/* IntPtr*  */ out_val);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_get_int(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags, 
	IntPtr/* System.Int64*  */ out_val);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_get_double(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags, 
	IntPtr/* System.Double*  */ out_val);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_get_q(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags, 
	IntPtr/* AVRational*  */ out_val);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_get_image_size(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags, 
	IntPtr/* System.Int32*  */ w_out, 
	IntPtr/* System.Int32*  */ h_out);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_get_pixel_fmt(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags, 
	IntPtr/* AVPixelFormat*  */ out_fmt);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_get_sample_fmt(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags, 
	IntPtr/* AVSampleFormat*  */ out_fmt);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_get_video_rate(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags, 
	IntPtr/* AVRational*  */ out_val);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_get_channel_layout(
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 search_flags, 
	IntPtr/* System.Int64*  */ ch_layout);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_opt_ptr(
	IntPtr/* AVClass*  */ avclass, 
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern void av_opt_freep_ranges(
	IntPtr/* IntPtr*  */ ranges);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_query_ranges(
	IntPtr/* IntPtr*  */  __arg0, 
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string key, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

[DllImport(OPT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_opt_query_ranges_default(
	IntPtr/* IntPtr*  */  __arg0, 
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]
	string key, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

public struct AVOption{
	[MarshalAs(UnmanagedType.LPStr)]
	public string name;

	[MarshalAs(UnmanagedType.LPStr)]
	public string help;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 offset;

	public AVOptionType type;

    [MarshalAs(UnmanagedType.I8)]
	public Int64 default_val;

	[MarshalAs(UnmanagedType.R8)]
	public System.Double min;

	[MarshalAs(UnmanagedType.R8)]
	public System.Double max;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 flags;

	[MarshalAs(UnmanagedType.LPStr)]
	public string unit;

};

public struct AVOptionRanges{
	public IntPtr/* IntPtr*  */ range;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 nb_ranges;

};

public struct AVOptionRange{
	[MarshalAs(UnmanagedType.LPStr)]
	public string str;

	[MarshalAs(UnmanagedType.R8)]
	public System.Double value_min;

	[MarshalAs(UnmanagedType.R8)]
	public System.Double value_max;

	[MarshalAs(UnmanagedType.R8)]
	public System.Double component_min;

	[MarshalAs(UnmanagedType.R8)]
	public System.Double component_max;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 is_range;

};

}
}

