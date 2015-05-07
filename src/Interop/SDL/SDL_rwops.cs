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
namespace SDLLib
{
    public partial class SDL 
{
public const string SDL_RWOPS = "SDL2.dll";


public static readonly uint SDL_RWOPS_UNKNOWN = 0;
public static readonly uint SDL_RWOPS_WINFILE = 1;
public static readonly uint SDL_RWOPS_STDFILE = 2;
public static readonly uint SDL_RWOPS_JNIFILE = 3;
public static readonly uint SDL_RWOPS_MEMORY = 4;
public static readonly uint SDL_RWOPS_MEMORY_RO = 5;
public static readonly uint RW_SEEK_SET = 0;
public static readonly uint RW_SEEK_CUR = 1;
public static readonly uint RW_SEEK_END = 2;
[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_RWops*  */ SDL_RWFromFile(
	[MarshalAs(UnmanagedType.LPStr)]
	string file, 
	[MarshalAs(UnmanagedType.LPStr)]
	string mode);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_RWops*  */ SDL_RWFromFP(
	IntPtr/* void*  */ fp, 
	SDL_bool autoclose);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_RWops*  */ SDL_RWFromMem(
	IntPtr/* void*  */ mem, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_RWops*  */ SDL_RWFromConstMem(
	IntPtr/* void*  */ mem, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_RWops*  */ SDL_AllocRW(
);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_FreeRW(
	IntPtr/* SDL_RWops*  */ area);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.Byte SDL_ReadU8(
	IntPtr/* SDL_RWops*  */ src);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt16 SDL_ReadLE16(
	IntPtr/* SDL_RWops*  */ src);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt16 SDL_ReadBE16(
	IntPtr/* SDL_RWops*  */ src);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_ReadLE32(
	IntPtr/* SDL_RWops*  */ src);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_ReadBE32(
	IntPtr/* SDL_RWops*  */ src);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt64 SDL_ReadLE64(
	IntPtr/* SDL_RWops*  */ src);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt64 SDL_ReadBE64(
	IntPtr/* SDL_RWops*  */ src);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_WriteU8(
	IntPtr/* SDL_RWops*  */ dst, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte value);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_WriteLE16(
	IntPtr/* SDL_RWops*  */ dst, 
	[MarshalAs(UnmanagedType.I2)]
	System.UInt16 value);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_WriteBE16(
	IntPtr/* SDL_RWops*  */ dst, 
	[MarshalAs(UnmanagedType.I2)]
	System.UInt16 value);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_WriteLE32(
	IntPtr/* SDL_RWops*  */ dst, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 value);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_WriteBE32(
	IntPtr/* SDL_RWops*  */ dst, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 value);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_WriteLE64(
	IntPtr/* SDL_RWops*  */ dst, 
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 value);

[DllImport(SDL_RWOPS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_WriteBE64(
	IntPtr/* SDL_RWops*  */ dst, 
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 value);

public struct SDL_RWops{
	public IntPtr/* FIXME Unknow*  */ size;

	public IntPtr/* FIXME Unknow*  */ seek;

	public IntPtr/* FIXME Unknow*  */ read;

	public IntPtr/* FIXME Unknow*  */ write;

	public IntPtr/* FIXME Unknow*  */ close;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	//public  IntPtr hidden;

};

}
}

