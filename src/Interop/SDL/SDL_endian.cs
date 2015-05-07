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
public const string SDL_ENDIAN = "SDL2.dll";


public static readonly uint SDL_LIL_ENDIAN = 1234;
public static readonly uint SDL_BIG_ENDIAN = 4321;
public static readonly uint SDL_BYTEORDER = SDL_LIL_ENDIAN;
[DllImport(SDL_ENDIAN), SuppressUnmanagedCodeSecurity]
public static extern System.UInt16 SDL_Swap16(
	[MarshalAs(UnmanagedType.I2)]
	System.UInt16 x);

[DllImport(SDL_ENDIAN), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_Swap32(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 x);

[DllImport(SDL_ENDIAN), SuppressUnmanagedCodeSecurity]
public static extern System.UInt64 SDL_Swap64(
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 x);

[DllImport(SDL_ENDIAN), SuppressUnmanagedCodeSecurity]
public static extern float SDL_SwapFloat(
	[MarshalAs(UnmanagedType.R4)]
	float x);

}
}

