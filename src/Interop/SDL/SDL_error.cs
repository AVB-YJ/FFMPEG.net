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
public const string SDL_ERROR = "SDL2.dll";


public enum SDL_errorcode
{
	SDL_ENOMEM = 0,
	SDL_EFREAD = 1,
	SDL_EFWRITE = 2,
	SDL_EFSEEK = 3,
	SDL_UNSUPPORTED = 4,
	SDL_LASTERROR = 5,
}

[DllImport(SDL_ERROR), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetError(
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(SDL_ERROR), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GetError(
);

[DllImport(SDL_ERROR), SuppressUnmanagedCodeSecurity]
public static extern void SDL_ClearError(
);

[DllImport(SDL_ERROR), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_Error(
	SDL_errorcode code);

}
}

