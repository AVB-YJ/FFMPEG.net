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
public const string SDL_POWER = "SDL2.dll";


public enum SDL_PowerState
{
	SDL_POWERSTATE_UNKNOWN = 0,
	SDL_POWERSTATE_ON_BATTERY = 1,
	SDL_POWERSTATE_NO_BATTERY = 2,
	SDL_POWERSTATE_CHARGING = 3,
	SDL_POWERSTATE_CHARGED = 4,
}

[DllImport(SDL_POWER), SuppressUnmanagedCodeSecurity]
public static extern SDL_PowerState SDL_GetPowerInfo(
	IntPtr/* System.Int32*  */ secs, 
	IntPtr/* System.Int32*  */ pct);

}
}

