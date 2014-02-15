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
		public const string MATHEMATICS = "avutil-52.dll";
		#else
		public const string MATHEMATICS = "avutil";
		#endif

public static readonly double M_E = 2.7182818284590452354;
public static readonly double M_LN2 = 0.69314718055994530942;
public static readonly double M_LN10 = 2.30258509299404568402;
public static readonly double M_LOG2_10 = 3.32192809488736234787;
public static readonly double M_PHI = 1.61803398874989484820;
public static readonly double M_PI = 3.14159265358979323846;
public static readonly double M_PI_2 = 1.57079632679489661923;
public static readonly double M_SQRT1_2 = 0.70710678118654752440;
public static readonly double M_SQRT2 = 1.41421356237309504880;
public static readonly double NAN = (double)(0x7fc00000);
public static readonly double INFINITY = (double)(0x7f800000);
public enum AVRounding
{
	AV_ROUND_ZERO = 0,
	AV_ROUND_INF = 1,
	AV_ROUND_DOWN = 2,
	AV_ROUND_UP = 3,
	AV_ROUND_NEAR_INF = 5,
	AV_ROUND_PASS_MINMAX = 8192,
}

[DllImport(MATHEMATICS), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_gcd(
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 a, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 b);

[DllImport(MATHEMATICS), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_rescale(
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 a, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 b, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 c);

[DllImport(MATHEMATICS), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_rescale_rnd(
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 a, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 b, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 c, 
	AVRounding  __arg3);

[DllImport(MATHEMATICS), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_rescale_q(
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 a, 
	AVRational bq, 
	AVRational cq);

[DllImport(MATHEMATICS), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_rescale_q_rnd(
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 a, 
	AVRational bq, 
	AVRational cq, 
	AVRounding  __arg3);

[DllImport(MATHEMATICS), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_compare_ts(
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 ts_a, 
	AVRational tb_a, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 ts_b, 
	AVRational tb_b);

[DllImport(MATHEMATICS), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_compare_mod(
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 a, 
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 b, 
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 mod);

[DllImport(MATHEMATICS), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_rescale_delta(
	AVRational in_tb, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 in_ts, 
	AVRational fs_tb, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 duration, 
	IntPtr/* System.Int64*  */ last, 
	AVRational out_tb);

[DllImport(MATHEMATICS), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_add_stable(
	AVRational ts_tb, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 ts, 
	AVRational inc_tb, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 inc);

}
}

