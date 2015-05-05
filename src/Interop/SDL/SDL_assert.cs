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
public const string SDL_ASSERT = "SDL2.dll";


public static readonly uint SDL_ASSERT_LEVEL = 1;

public enum SDL_assert_state
{
	SDL_ASSERTION_RETRY = 0,
	SDL_ASSERTION_BREAK = 1,
	SDL_ASSERTION_ABORT = 2,
	SDL_ASSERTION_IGNORE = 3,
	SDL_ASSERTION_ALWAYS_IGNORE = 4,
}

[DllImport(SDL_ASSERT), SuppressUnmanagedCodeSecurity]
public static extern SDL_assert_state SDL_ReportAssertion(
	IntPtr/* SDL_assert_data*  */  __arg0, 
	[MarshalAs(UnmanagedType.LPStr)]
	string  __arg1, 
	[MarshalAs(UnmanagedType.LPStr)]
	string  __arg2, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32  __arg3);

[DllImport(SDL_ASSERT), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetAssertionHandler(
	IntPtr handler, 
	IntPtr/* void*  */ userdata);

[DllImport(SDL_ASSERT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr SDL_GetDefaultAssertionHandler(
);

[DllImport(SDL_ASSERT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr SDL_GetAssertionHandler(
	IntPtr/* IntPtr*  */ puserdata);

[DllImport(SDL_ASSERT), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_assert_data*  */ SDL_GetAssertionReport(
);

[DllImport(SDL_ASSERT), SuppressUnmanagedCodeSecurity]
public static extern void SDL_ResetAssertionReport(
);

public struct SDL_assert_data{
	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 always_ignore;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 trigger_count;

	[MarshalAs(UnmanagedType.LPStr)]
	public string condition;

	[MarshalAs(UnmanagedType.LPStr)]
	public string filename;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 linenum;

	[MarshalAs(UnmanagedType.LPStr)]
	public string function;

	public IntPtr/* SDL_assert_data*  */ next;

};

}
}

