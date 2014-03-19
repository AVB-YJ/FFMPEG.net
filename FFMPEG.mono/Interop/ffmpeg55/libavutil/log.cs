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
    public partial class AV 
{
		#if WIN32
		public const string LOG = "avutil-52.dll";
		#else
		public const string LOG = "avutil";
		#endif

public static readonly int AV_LOG_QUIET = -8;
public static readonly uint AV_LOG_PANIC = 0;
public static readonly uint AV_LOG_FATAL = 8;
public static readonly uint AV_LOG_ERROR = 16;
public static readonly uint AV_LOG_WARNING = 24;
public static readonly uint AV_LOG_INFO = 32;
public static readonly uint AV_LOG_VERBOSE = 40;
public static readonly uint AV_LOG_DEBUG = 48;
public static readonly uint AV_LOG_MAX_OFFSET = (uint)(AV_LOG_DEBUG - AV_LOG_QUIET);
public static readonly uint AV_LOG_SKIP_REPEATED = 1;
public enum AVClassCategory
{
	AV_CLASS_CATEGORY_NA = 0,
	AV_CLASS_CATEGORY_INPUT = 1,
	AV_CLASS_CATEGORY_OUTPUT = 2,
	AV_CLASS_CATEGORY_MUXER = 3,
	AV_CLASS_CATEGORY_DEMUXER = 4,
	AV_CLASS_CATEGORY_ENCODER = 5,
	AV_CLASS_CATEGORY_DECODER = 6,
	AV_CLASS_CATEGORY_FILTER = 7,
	AV_CLASS_CATEGORY_BITSTREAM_FILTER = 8,
	AV_CLASS_CATEGORY_SWSCALER = 9,
	AV_CLASS_CATEGORY_SWRESAMPLER = 10,
	AV_CLASS_CATEGORY_NB = 11,
}

[DllImport(LOG), SuppressUnmanagedCodeSecurity]
public static extern void av_log(
	IntPtr/* void*  */ avcl, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 level, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(LOG), SuppressUnmanagedCodeSecurity]
public static extern void av_vlog(
	IntPtr/* void*  */ avcl, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 level, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt, 
	[MarshalAs(UnmanagedType.LPStr)]
	string vl);

[DllImport(LOG), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_log_get_level(
);

[DllImport(LOG), SuppressUnmanagedCodeSecurity]
public static extern void av_log_set_level(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 level);

[DllImport(LOG), SuppressUnmanagedCodeSecurity]
public static extern void av_log_set_callback(
	[MarshalAs(UnmanagedType.FunctionPtr)]
	log_func_0 callback);

[DllImport(LOG), SuppressUnmanagedCodeSecurity]
public static extern void av_log_default_callback(
	IntPtr/* void*  */ ptr, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 level, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt, 
	[MarshalAs(UnmanagedType.LPStr)]
	string vl);

[DllImport(LOG), SuppressUnmanagedCodeSecurity]
public static extern string av_default_item_name(
	IntPtr/* void*  */ ctx);

[DllImport(LOG), SuppressUnmanagedCodeSecurity]
public static extern AVClassCategory av_default_get_category(
	IntPtr/* void*  */ ptr);

[DllImport(LOG), SuppressUnmanagedCodeSecurity]
public static extern void av_log_format_line(
	IntPtr/* void*  */ ptr, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 level, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt, 
	[MarshalAs(UnmanagedType.LPStr)]
	string vl, 
	[MarshalAs(UnmanagedType.LPStr)]
	string line, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 line_size, 
	IntPtr/* System.Int32*  */ print_prefix);

[DllImport(LOG), SuppressUnmanagedCodeSecurity]
public static extern void av_log_set_flags(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 arg);

public struct AVClass{
	[MarshalAs(UnmanagedType.LPStr)]
	public string class_name;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public log_func_1 item_name;

	public IntPtr/* AVOption*  */ option;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 version;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 log_level_offset_offset;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 parent_log_context_offset;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public log_func_2 child_next;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public log_func_3 child_class_next;

	public AVClassCategory category;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public log_func_4 get_category;

	[MarshalAs(UnmanagedType.FunctionPtr)]
	public log_func_5 query_ranges;

};

public delegate void log_func_0(
	IntPtr/* void*  */ __arg0, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 __arg1, 
	[MarshalAs(UnmanagedType.LPStr)]string __arg2, 
	[MarshalAs(UnmanagedType.LPStr)]string __arg3);

public delegate string log_func_1(
	IntPtr/* void*  */ ctx);

public delegate IntPtr/* void*  */ log_func_2(
	IntPtr/* void*  */ obj, 
	IntPtr/* void*  */ prev);

public delegate IntPtr/* AVClass*  */ log_func_3(
	IntPtr/* AVClass*  */ prev);

public delegate AVClassCategory log_func_4(
	IntPtr/* void*  */ ctx);

public delegate System.Int32 log_func_5(
	IntPtr/* IntPtr*  */ __arg0, 
	IntPtr/* void*  */ obj, 
	[MarshalAs(UnmanagedType.LPStr)]string key, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 flags);

}
}

