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
public const string SDL = "SDL2.dll";


public static readonly uint SDL_INIT_TIMER = 0x00000001;
public static readonly uint SDL_INIT_AUDIO = 0x00000010;
public static readonly uint SDL_INIT_VIDEO = 0x00000020;
public static readonly uint SDL_INIT_JOYSTICK = 0x00000200;
public static readonly uint SDL_INIT_HAPTIC = 0x00001000;
public static readonly uint SDL_INIT_GAMECONTROLLER = 0x00002000;
public static readonly uint SDL_INIT_EVENTS = 0x00004000;
public static readonly uint SDL_INIT_NOPARACHUTE = 0x00100000;
public static readonly uint SDL_INIT_EVERYTHING = ( 
                SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO | SDL_INIT_EVENTS | 
                SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC | SDL_INIT_GAMECONTROLLER 
            );
[DllImport(SDL), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_Init(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags);

[DllImport(SDL), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_InitSubSystem(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags);

[DllImport(SDL), SuppressUnmanagedCodeSecurity]
public static extern void SDL_QuitSubSystem(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags);

[DllImport(SDL), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_WasInit(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags);

[DllImport(SDL), SuppressUnmanagedCodeSecurity]
public static extern void SDL_Quit(
);

}
}

