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
		public const string INTFLOAT = "avutil-52.dll";
		#else
		public const string INTFLOAT = "avutil";
		#endif

[DllImport(INTFLOAT), SuppressUnmanagedCodeSecurity]
public static extern float av_int2float(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 i);

[DllImport(INTFLOAT), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 av_float2int(
	[MarshalAs(UnmanagedType.R4)]
	float f);

[DllImport(INTFLOAT), SuppressUnmanagedCodeSecurity]
public static extern System.Double av_int2double(
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 i);

[DllImport(INTFLOAT), SuppressUnmanagedCodeSecurity]
public static extern System.UInt64 av_double2int(
	[MarshalAs(UnmanagedType.R8)]
	System.Double f);

public struct av_intfloat32{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 i;

	[MarshalAs(UnmanagedType.R4)]
	public float f;

};

public struct av_intfloat64{
	[MarshalAs(UnmanagedType.I8)]
	public System.UInt64 i;

	[MarshalAs(UnmanagedType.R8)]
	public System.Double f;

};

}
}

