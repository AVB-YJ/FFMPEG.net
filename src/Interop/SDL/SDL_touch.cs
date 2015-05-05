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
    public partial class SDLNative 
{
public const string SDL_TOUCH = "SDL2.dll";


public static readonly uint SDL_TOUCH_MOUSEID = 0xffffffff;
[DllImport(SDL_TOUCH), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetNumTouchDevices(
);

[DllImport(SDL_TOUCH), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 SDL_GetTouchDevice(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 index);

[DllImport(SDL_TOUCH), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetNumTouchFingers(
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 touchID);

[DllImport(SDL_TOUCH), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Finger*  */ SDL_GetTouchFinger(
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 touchID, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 index);

public struct SDL_Finger{
	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 id;

	[MarshalAs(UnmanagedType.R4)]
	public float x;

	[MarshalAs(UnmanagedType.R4)]
	public float y;

	[MarshalAs(UnmanagedType.R4)]
	public float pressure;

};

}
}

