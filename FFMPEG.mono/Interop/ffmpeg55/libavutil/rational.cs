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
		public const string RATIONAL = "avutil-52.dll";
		#else
		public const string RATIONAL = "avutil";
		#endif

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern AVRational av_make_q(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 num, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 den);

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_cmp_q(
	AVRational a, 
	AVRational b);

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern System.Double av_q2d(
	AVRational a);

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_reduce(
	IntPtr/* System.Int32*  */ dst_num, 
	IntPtr/* System.Int32*  */ dst_den, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 num, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 den, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 max);

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern AVRational av_mul_q(
	AVRational b, 
	AVRational c);

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern AVRational av_div_q(
	AVRational b, 
	AVRational c);

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern AVRational av_add_q(
	AVRational b, 
	AVRational c);

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern AVRational av_sub_q(
	AVRational b, 
	AVRational c);

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern AVRational av_inv_q(
	AVRational q);

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern AVRational av_d2q(
	[MarshalAs(UnmanagedType.R8)]
	System.Double d, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 max);

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_nearer_q(
	AVRational q, 
	AVRational q1, 
	AVRational q2);

[DllImport(RATIONAL), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_find_nearest_q_idx(
	AVRational q, 
	IntPtr/* AVRational*  */ q_list);

public struct AVRational{
	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 num;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 den;

};

}
}

