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
public const string SDL_LOADSO = "SDL2.dll";


[DllImport(SDL_LOADSO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_LoadObject(
	[MarshalAs(UnmanagedType.LPStr)]
	string sofile);

[DllImport(SDL_LOADSO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_LoadFunction(
	IntPtr/* void*  */ handle, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name);

[DllImport(SDL_LOADSO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_UnloadObject(
	IntPtr/* void*  */ handle);

}
}

