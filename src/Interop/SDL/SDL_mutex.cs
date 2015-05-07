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
public const string SDL_MUTEX = "SDL2.dll";


public static readonly uint SDL_MUTEX_TIMEDOUT = 1;
public static readonly uint SDL_MUTEX_MAXWAIT = 0xffffffff;
[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_mutex*  */ SDL_CreateMutex(
);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_LockMutex(
	IntPtr/* SDL_mutex*  */ mutex);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_TryLockMutex(
	IntPtr/* SDL_mutex*  */ mutex);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_UnlockMutex(
	IntPtr/* SDL_mutex*  */ mutex);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern void SDL_DestroyMutex(
	IntPtr/* SDL_mutex*  */ mutex);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_semaphore*  */ SDL_CreateSemaphore(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 initial_value);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern void SDL_DestroySemaphore(
	IntPtr/* SDL_semaphore*  */ sem);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SemWait(
	IntPtr/* SDL_semaphore*  */ sem);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SemTryWait(
	IntPtr/* SDL_semaphore*  */ sem);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SemWaitTimeout(
	IntPtr/* SDL_semaphore*  */ sem, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 ms);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SemPost(
	IntPtr/* SDL_semaphore*  */ sem);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_SemValue(
	IntPtr/* SDL_semaphore*  */ sem);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_cond*  */ SDL_CreateCond(
);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern void SDL_DestroyCond(
	IntPtr/* SDL_cond*  */ cond);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_CondSignal(
	IntPtr/* SDL_cond*  */ cond);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_CondBroadcast(
	IntPtr/* SDL_cond*  */ cond);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_CondWait(
	IntPtr/* SDL_cond*  */ cond, 
	IntPtr/* SDL_mutex*  */ mutex);

[DllImport(SDL_MUTEX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_CondWaitTimeout(
	IntPtr/* SDL_cond*  */ cond, 
	IntPtr/* SDL_mutex*  */ mutex, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 ms);

}
}

