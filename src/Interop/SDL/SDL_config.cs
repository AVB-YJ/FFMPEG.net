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
public const string SDL_CONFIG = "SDL2.dll";


public static readonly uint SIZEOF_VOIDP = 4;
public static readonly uint HAVE_STDARG_H = 1;
public static readonly uint HAVE_STDDEF_H = 1;
public static readonly uint SDL_AUDIO_DRIVER_DSOUND = 1;
public static readonly uint SDL_AUDIO_DRIVER_XAUDIO2 = 1;
public static readonly uint SDL_AUDIO_DRIVER_WINMM = 1;
public static readonly uint SDL_AUDIO_DRIVER_DISK = 1;
public static readonly uint SDL_AUDIO_DRIVER_DUMMY = 1;
public static readonly uint SDL_JOYSTICK_DINPUT = 1;
public static readonly uint SDL_HAPTIC_DINPUT = 1;
public static readonly uint SDL_LOADSO_WINDOWS = 1;
public static readonly uint SDL_THREAD_WINDOWS = 1;
public static readonly uint SDL_TIMER_WINDOWS = 1;
public static readonly uint SDL_VIDEO_DRIVER_DUMMY = 1;
public static readonly uint SDL_VIDEO_DRIVER_WINDOWS = 1;
public static readonly uint SDL_VIDEO_RENDER_D3D = 1;
public static readonly uint SDL_VIDEO_RENDER_D3D11 = 0;
public static readonly uint SDL_VIDEO_OPENGL = 1;
public static readonly uint SDL_VIDEO_OPENGL_WGL = 1;
public static readonly uint SDL_VIDEO_RENDER_OGL = 1;
public static readonly uint SDL_VIDEO_RENDER_OGL_ES2 = 1;
public static readonly uint SDL_VIDEO_OPENGL_ES2 = 1;
public static readonly uint SDL_VIDEO_OPENGL_EGL = 1;
public static readonly uint SDL_POWER_WINDOWS = 1;
public static readonly uint SDL_FILESYSTEM_WINDOWS = 1;
public static readonly uint SDL_ASSEMBLY_ROUTINES = 1;
}
}

