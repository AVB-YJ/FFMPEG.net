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
		public const string MEM = "avutil-52.dll";
		#else
		public const string MEM = "avutil";
		#endif

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_malloc(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_malloc_array(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 nmemb, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_realloc(
	IntPtr/* void*  */ ptr, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_realloc_f(
	IntPtr/* void*  */ ptr, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 nelem, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 elsize);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_reallocp(
	IntPtr/* void*  */ ptr, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_realloc_array(
	IntPtr/* void*  */ ptr, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 nmemb, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_reallocp_array(
	IntPtr/* void*  */ ptr, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 nmemb, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern void av_free(
	IntPtr/* void*  */ ptr);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_mallocz(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_calloc(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 nmemb, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_mallocz_array(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 nmemb, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern string av_strdup(
	[MarshalAs(UnmanagedType.LPStr)]
	string s);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_memdup(
	IntPtr/* void*  */ p, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern void av_freep(
	IntPtr/* void*  */ ptr);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern void av_dynarray_add(
	IntPtr/* void*  */ tab_ptr, 
	IntPtr/* System.Int32*  */ nb_ptr, 
	IntPtr/* void*  */ elem);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_dynarray2_add(
	IntPtr/* IntPtr*  */ tab_ptr, 
	IntPtr/* System.Int32*  */ nb_ptr, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 elem_size, 
	IntPtr/* System.Byte*  */ elem_data);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_size_mult(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 a, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 b, 
	IntPtr/* System.UInt32*  */ r);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern void av_max_alloc(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 max);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern void av_memcpy_backptr(
	IntPtr/* System.Byte*  */ dst, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 back, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 cnt);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ av_fast_realloc(
	IntPtr/* void*  */ ptr, 
	IntPtr/* System.UInt32*  */ size, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 min_size);

[DllImport(MEM), SuppressUnmanagedCodeSecurity]
public static extern void av_fast_malloc(
	IntPtr/* void*  */ ptr, 
	IntPtr/* System.UInt32*  */ size, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 min_size);

}
}

