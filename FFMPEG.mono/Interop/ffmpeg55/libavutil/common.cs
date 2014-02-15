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
		public const string COMMON = "avutil-52.dll";
		#else
		public const string COMMON = "avutil";
		#endif


[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_log2(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 v);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_log2_16bit(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 v);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_clip_c(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 a, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 amin, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 amax);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_clip64_c(
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 a, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 amin, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 amax);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Byte av_clip_uint8_c(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 a);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Char av_clip_int8_c(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 a);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.UInt16 av_clip_uint16_c(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 a);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Int16 av_clip_int16_c(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 a);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_clipl_int32_c(
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 a);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 av_clip_uintp2_c(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 a, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 p);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_sat_add32_c(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 a, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 b);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_sat_dadd32_c(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 a, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 b);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern float av_clipf_c(
	[MarshalAs(UnmanagedType.R4)]
	float a, 
	[MarshalAs(UnmanagedType.R4)]
	float amin, 
	[MarshalAs(UnmanagedType.R4)]
	float amax);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Double av_clipd_c(
	[MarshalAs(UnmanagedType.R8)]
	System.Double a, 
	[MarshalAs(UnmanagedType.R8)]
	System.Double amin, 
	[MarshalAs(UnmanagedType.R8)]
	System.Double amax);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_ceil_log2_c(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_popcount_c(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 x);

[DllImport(COMMON), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_popcount64_c(
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 x);

}
}

