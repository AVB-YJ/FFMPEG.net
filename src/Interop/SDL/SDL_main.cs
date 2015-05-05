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
public const string SDL_MAIN = "SDL2.dll";


//public static readonly uint C_LINKAGE = "C";
//public static readonly uint main = SDL_main;
[DllImport(SDL_MAIN), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_main(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 argc, 
	IntPtr argv);

[DllImport(SDL_MAIN), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetMainReady(
);

[DllImport(SDL_MAIN), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RegisterApp(
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 style, 
	IntPtr/* void*  */ hInst);

[DllImport(SDL_MAIN), SuppressUnmanagedCodeSecurity]
public static extern void SDL_UnregisterApp(
);

}
}

