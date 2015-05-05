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
public const string SDL_LOG = "SDL2.dll";


public static readonly uint SDL_MAX_LOG_MESSAGE = 4096;
public enum SDL_LOG_CATEGORY 
{
	SDL_LOG_CATEGORY_APPLICATION = 0,
	SDL_LOG_CATEGORY_ERROR = 1,
	SDL_LOG_CATEGORY_ASSERT = 2,
	SDL_LOG_CATEGORY_SYSTEM = 3,
	SDL_LOG_CATEGORY_AUDIO = 4,
	SDL_LOG_CATEGORY_VIDEO = 5,
	SDL_LOG_CATEGORY_RENDER = 6,
	SDL_LOG_CATEGORY_INPUT = 7,
	SDL_LOG_CATEGORY_TEST = 8,
	SDL_LOG_CATEGORY_RESERVED1 = 9,
	SDL_LOG_CATEGORY_RESERVED2 = 10,
	SDL_LOG_CATEGORY_RESERVED3 = 11,
	SDL_LOG_CATEGORY_RESERVED4 = 12,
	SDL_LOG_CATEGORY_RESERVED5 = 13,
	SDL_LOG_CATEGORY_RESERVED6 = 14,
	SDL_LOG_CATEGORY_RESERVED7 = 15,
	SDL_LOG_CATEGORY_RESERVED8 = 16,
	SDL_LOG_CATEGORY_RESERVED9 = 17,
	SDL_LOG_CATEGORY_RESERVED10 = 18,
	SDL_LOG_CATEGORY_CUSTOM = 19,
}

public enum SDL_LogPriority
{
	SDL_LOG_PRIORITY_VERBOSE = 1,
	SDL_LOG_PRIORITY_DEBUG = 2,
	SDL_LOG_PRIORITY_INFO = 3,
	SDL_LOG_PRIORITY_WARN = 4,
	SDL_LOG_PRIORITY_ERROR = 5,
	SDL_LOG_PRIORITY_CRITICAL = 6,
	SDL_NUM_LOG_PRIORITIES = 7,
}

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogSetAllPriority(
	SDL_LogPriority priority);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogSetPriority(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 category, 
	SDL_LogPriority priority);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern SDL_LogPriority SDL_LogGetPriority(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 category);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogResetPriorities(
);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_Log(
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogVerbose(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 category, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogDebug(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 category, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogInfo(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 category, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogWarn(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 category, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogError(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 category, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogCritical(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 category, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogMessage(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 category, 
	SDL_LogPriority priority, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogMessageV(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 category, 
	SDL_LogPriority priority, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt, 
	[MarshalAs(UnmanagedType.LPStr)]
	string ap);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogGetOutputFunction(
	IntPtr/* SDL_log_func_0*  */ callback, 
	IntPtr/* IntPtr*  */ userdata);

[DllImport(SDL_LOG), SuppressUnmanagedCodeSecurity]
public static extern void SDL_LogSetOutputFunction(
	[MarshalAs(UnmanagedType.FunctionPtr)]
	SDL_log_func_0 callback, 
	IntPtr/* void*  */ userdata);

public delegate void SDL_log_func_0(
	IntPtr/* void*  */ userdata, 
	[MarshalAs(UnmanagedType.I4)]System.Int32 category, 
	SDL_LogPriority priority, 
	[MarshalAs(UnmanagedType.LPStr)]string message);

}
}

