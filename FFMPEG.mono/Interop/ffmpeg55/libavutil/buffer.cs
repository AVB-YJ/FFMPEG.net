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
public const string BUFFER = "avutil-52.dll";


public static readonly uint AV_BUFFER_FLAG_READONLY = (1 << 0);
[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVBufferRef*  */ av_buffer_alloc(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVBufferRef*  */ av_buffer_allocz(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVBufferRef*  */ av_buffer_create(
	IntPtr/* System.Byte*  */ data, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size, 
	[MarshalAs(UnmanagedType.FunctionPtr)]
	buffer_func_0 free, 
	IntPtr/* void*  */ opaque, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern void av_buffer_default_free(
	IntPtr/* void*  */ opaque, 
	IntPtr/* System.Byte*  */ data);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVBufferRef*  */ av_buffer_ref(
	IntPtr/* AVBufferRef*  */ buf);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern void av_buffer_unref(
	IntPtr/* IntPtr*  */ buf);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_buffer_is_writable(
	IntPtr/* AVBufferRef*  */ buf);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_buffer_get_opaque(
	IntPtr/* AVBufferRef*  */ buf);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_buffer_get_ref_count(
	IntPtr/* AVBufferRef*  */ buf);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_buffer_make_writable(
	IntPtr/* IntPtr*  */ buf);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_buffer_realloc(
	IntPtr/* IntPtr*  */ buf, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVBufferPool*  */ av_buffer_pool_init(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size, 
	[MarshalAs(UnmanagedType.FunctionPtr)]
	buffer_func_1 alloc);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern void av_buffer_pool_uninit(
	IntPtr/* IntPtr*  */ pool);

[DllImport(BUFFER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVBufferRef*  */ av_buffer_pool_get(
	IntPtr/* AVBufferPool*  */ pool);

public struct AVBufferRef{
	public IntPtr/* AVBuffer*  */ buffer;

	public IntPtr/* System.Byte*  */ data;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 size;

};

public delegate void buffer_func_0(
	IntPtr/* void*  */ opaque, 
	IntPtr/* System.Byte*  */ data);

public delegate IntPtr/* AVBufferRef*  */ buffer_func_1(
	[MarshalAs(UnmanagedType.I4)]System.Int32 size);

}
}

