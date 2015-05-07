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
public const string SDL_THREAD = "SDL2.dll";


public enum SDL_ThreadPriority
{
	SDL_THREAD_PRIORITY_LOW = 0,
	SDL_THREAD_PRIORITY_NORMAL = 1,
	SDL_THREAD_PRIORITY_HIGH = 2,
}

[DllImport(SDL_THREAD), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Thread*  */ SDL_CreateThread(
	IntPtr fn, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	IntPtr/* void*  */ data, 
	IntPtr pfnBeginThread, 
	IntPtr pfnEndThread);

[DllImport(SDL_THREAD), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GetThreadName(
	IntPtr/* SDL_Thread*  */ thread);

[DllImport(SDL_THREAD), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_ThreadID(
);

[DllImport(SDL_THREAD), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_GetThreadID(
	IntPtr/* SDL_Thread*  */ thread);

[DllImport(SDL_THREAD), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetThreadPriority(
	SDL_ThreadPriority priority);

[DllImport(SDL_THREAD), SuppressUnmanagedCodeSecurity]
public static extern void SDL_WaitThread(
	IntPtr/* SDL_Thread*  */ thread, 
	IntPtr/* System.Int32*  */ status);

[DllImport(SDL_THREAD), SuppressUnmanagedCodeSecurity]
public static extern void SDL_DetachThread(
	IntPtr/* SDL_Thread*  */ thread);

[DllImport(SDL_THREAD), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_TLSCreate(
);

[DllImport(SDL_THREAD), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_TLSGet(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 id);

[DllImport(SDL_THREAD), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_TLSSet(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 id, 
	IntPtr/* void*  */ value, 
	[MarshalAs(UnmanagedType.FunctionPtr)]
	SDL_thread_func_0 destructor);

public delegate void SDL_thread_func_0(
	IntPtr/* void*  */ __arg0);

}
}

