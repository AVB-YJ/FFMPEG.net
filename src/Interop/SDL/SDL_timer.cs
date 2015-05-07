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
public const string SDL_TIMER = "SDL2.dll";


[DllImport(SDL_TIMER), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_GetTicks(
);

[DllImport(SDL_TIMER), SuppressUnmanagedCodeSecurity]
public static extern System.UInt64 SDL_GetPerformanceCounter(
);

[DllImport(SDL_TIMER), SuppressUnmanagedCodeSecurity]
public static extern System.UInt64 SDL_GetPerformanceFrequency(
);

[DllImport(SDL_TIMER), SuppressUnmanagedCodeSecurity]
public static extern void SDL_Delay(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 ms);

[DllImport(SDL_TIMER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_AddTimer(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 interval, 
	IntPtr callback, 
	IntPtr/* void*  */ param);

[DllImport(SDL_TIMER), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_RemoveTimer(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 id);

}
}

