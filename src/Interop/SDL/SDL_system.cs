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
public const string SDL_SYSTEM = "SDL2.dll";


[DllImport(SDL_SYSTEM), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_Direct3D9GetAdapterIndex(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 displayIndex);

[DllImport(SDL_SYSTEM), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* IDirect3DDevice9*  */ SDL_RenderGetD3D9Device(
	IntPtr/* SDL_Renderer*  */ renderer);

[DllImport(SDL_SYSTEM), SuppressUnmanagedCodeSecurity]
public static extern void SDL_DXGIGetOutputInfo(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 displayIndex, 
	IntPtr/* System.Int32*  */ adapterIndex, 
	IntPtr/* System.Int32*  */ outputIndex);

}
}

