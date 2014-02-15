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
		#if WIN32
public const string SWRESAMPLE = "swresample-0.dll";
		#else
		public const string SWRESAMPLE = "swresample";
		#endif

public static readonly uint SWR_CH_MAX = 32;
public static readonly uint SWR_FLAG_RESAMPLE = 1;
public enum SwrDitherType
{
	SWR_DITHER_NONE = 0,
	SWR_DITHER_RECTANGULAR = 1,
	SWR_DITHER_TRIANGULAR = 2,
	SWR_DITHER_TRIANGULAR_HIGHPASS = 3,
	SWR_DITHER_NS = 64,
	SWR_DITHER_NS_LIPSHITZ = 65,
	SWR_DITHER_NS_F_WEIGHTED = 66,
	SWR_DITHER_NS_MODIFIED_E_WEIGHTED = 67,
	SWR_DITHER_NS_IMPROVED_E_WEIGHTED = 68,
	SWR_DITHER_NS_SHIBATA = 69,
	SWR_DITHER_NS_LOW_SHIBATA = 70,
	SWR_DITHER_NS_HIGH_SHIBATA = 71,
	SWR_DITHER_NB = 72,
}

public enum SwrEngine
{
	SWR_ENGINE_SWR = 0,
	SWR_ENGINE_SOXR = 1,
	SWR_ENGINE_NB = 2,
}

public enum SwrFilterType
{
	SWR_FILTER_TYPE_CUBIC = 0,
	SWR_FILTER_TYPE_BLACKMAN_NUTTALL = 1,
	SWR_FILTER_TYPE_KAISER = 2,
}

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVClass*  */ swr_get_class(
);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SwrContext*  */ swr_alloc(
);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 swr_init(
	IntPtr/* SwrContext*  */ s);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SwrContext*  */ swr_alloc_set_opts(
	IntPtr/* SwrContext*  */ s, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 out_ch_layout, 
	AVSampleFormat out_sample_fmt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 out_sample_rate, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 in_ch_layout, 
	AVSampleFormat in_sample_fmt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 in_sample_rate, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 log_offset, 
	IntPtr/* void*  */ log_ctx);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern void swr_free(
	IntPtr/* IntPtr*  */ s);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 swr_convert(
	IntPtr/* SwrContext*  */ s, 
	IntPtr/* IntPtr*  */ _out, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 out_count, 
	IntPtr/* IntPtr*  */ _in, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 in_count);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 swr_next_pts(
	IntPtr/* SwrContext*  */ s, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 pts);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 swr_set_compensation(
	IntPtr/* SwrContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 sample_delta, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 compensation_distance);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 swr_set_channel_mapping(
	IntPtr/* SwrContext*  */ s, 
	IntPtr/* System.Int32*  */ channel_map);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 swr_set_matrix(
	IntPtr/* SwrContext*  */ s, 
	IntPtr/* System.Double*  */ matrix, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 stride);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 swr_drop_output(
	IntPtr/* SwrContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 count);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 swr_inject_silence(
	IntPtr/* SwrContext*  */ s, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 count);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 swr_get_delay(
	IntPtr/* SwrContext*  */ s, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 _base);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 swresample_version(
);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern string swresample_configuration(
);

[DllImport(SWRESAMPLE), SuppressUnmanagedCodeSecurity]
public static extern string swresample_license(
);

}
}

