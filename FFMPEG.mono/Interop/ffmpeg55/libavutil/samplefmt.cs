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
public const string SAMPLEFMT = "avutil-52.dll";


public enum AVSampleFormat
{
	AV_SAMPLE_FMT_NONE = -1,
	AV_SAMPLE_FMT_U8 = 0,
	AV_SAMPLE_FMT_S16 = 1,
	AV_SAMPLE_FMT_S32 = 2,
	AV_SAMPLE_FMT_FLT = 3,
	AV_SAMPLE_FMT_DBL = 4,
	AV_SAMPLE_FMT_U8P = 5,
	AV_SAMPLE_FMT_S16P = 6,
	AV_SAMPLE_FMT_S32P = 7,
	AV_SAMPLE_FMT_FLTP = 8,
	AV_SAMPLE_FMT_DBLP = 9,
	AV_SAMPLE_FMT_NB = 10,
}

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern string av_get_sample_fmt_name(
	AVSampleFormat sample_fmt);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern AVSampleFormat av_get_sample_fmt(
	[MarshalAs(UnmanagedType.LPStr)]
	string name);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern AVSampleFormat av_get_alt_sample_fmt(
	AVSampleFormat sample_fmt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 planar);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern AVSampleFormat av_get_packed_sample_fmt(
	AVSampleFormat sample_fmt);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern AVSampleFormat av_get_planar_sample_fmt(
	AVSampleFormat sample_fmt);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern string av_get_sample_fmt_string(
	[MarshalAs(UnmanagedType.LPStr)]
	string buf, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 buf_size, 
	AVSampleFormat sample_fmt);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_get_bits_per_sample_fmt(
	AVSampleFormat sample_fmt);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_get_bytes_per_sample(
	AVSampleFormat sample_fmt);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_sample_fmt_is_planar(
	AVSampleFormat sample_fmt);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_samples_get_buffer_size(
	IntPtr/* System.Int32*  */ linesize, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_channels, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_samples, 
	AVSampleFormat sample_fmt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 align);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_samples_fill_arrays(
	IntPtr/* IntPtr*  */ audio_data, 
	IntPtr/* System.Int32*  */ linesize, 
	IntPtr/* System.Byte*  */ buf, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_channels, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_samples, 
	AVSampleFormat sample_fmt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 align);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_samples_alloc(
	IntPtr/* IntPtr*  */ audio_data, 
	IntPtr/* System.Int32*  */ linesize, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_channels, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_samples, 
	AVSampleFormat sample_fmt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 align);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_samples_alloc_array_and_samples(
	IntPtr/* IntPtr*  */ audio_data, 
	IntPtr/* System.Int32*  */ linesize, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_channels, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_samples, 
	AVSampleFormat sample_fmt, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 align);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_samples_copy(
	IntPtr/* IntPtr*  */ dst, 
	IntPtr/* IntPtr*  */ src, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 dst_offset, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 src_offset, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_samples, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_channels, 
	AVSampleFormat sample_fmt);

[DllImport(SAMPLEFMT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_samples_set_silence(
	IntPtr/* IntPtr*  */ audio_data, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 offset, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_samples, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_channels, 
	AVSampleFormat sample_fmt);

}
}

