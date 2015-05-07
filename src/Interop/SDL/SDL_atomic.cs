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
public const string SDL_ATOMIC = "SDL2.dll";


[DllImport(SDL_ATOMIC), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_AtomicTryLock(
	IntPtr/* System.Int32*  */ _lock);

[DllImport(SDL_ATOMIC), SuppressUnmanagedCodeSecurity]
public static extern void SDL_AtomicLock(
	IntPtr/* System.Int32*  */ _lock);

[DllImport(SDL_ATOMIC), SuppressUnmanagedCodeSecurity]
public static extern void SDL_AtomicUnlock(
    IntPtr/* System.Int32*  */ _lock);

[DllImport(SDL_ATOMIC), SuppressUnmanagedCodeSecurity]
public static extern void _ReadWriteBarrier(
);

[DllImport(SDL_ATOMIC), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_AtomicCAS(
	IntPtr/* SDL_atomic_t*  */ a, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 oldval, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 newval);

[DllImport(SDL_ATOMIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_AtomicSet(
	IntPtr/* SDL_atomic_t*  */ a, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 v);

[DllImport(SDL_ATOMIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_AtomicGet(
	IntPtr/* SDL_atomic_t*  */ a);

[DllImport(SDL_ATOMIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_AtomicAdd(
	IntPtr/* SDL_atomic_t*  */ a, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 v);

[DllImport(SDL_ATOMIC), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_AtomicCASPtr(
	IntPtr/* IntPtr*  */ a, 
	IntPtr/* void*  */ oldval, 
	IntPtr/* void*  */ newval);

[DllImport(SDL_ATOMIC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_AtomicSetPtr(
	IntPtr/* IntPtr*  */ a, 
	IntPtr/* void*  */ v);

[DllImport(SDL_ATOMIC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_AtomicGetPtr(
	IntPtr/* IntPtr*  */ a);

public struct SDL_atomic_t{
	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 value;

};

}
}

