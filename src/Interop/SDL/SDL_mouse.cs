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
public const string SDL_MOUSE = "SDL2.dll";


public static readonly uint SDL_BUTTON_LEFT = 1;
public static readonly uint SDL_BUTTON_MIDDLE = 2;
public static readonly uint SDL_BUTTON_RIGHT = 3;
public static readonly uint SDL_BUTTON_X1 = 4;
public static readonly uint SDL_BUTTON_X2 = 5;
//public static readonly uint SDL_BUTTON_LMASK = SDL_BUTTON(SDL_BUTTON_LEFT);
//public static readonly uint SDL_BUTTON_MMASK = SDL_BUTTON(SDL_BUTTON_MIDDLE);
//public static readonly uint SDL_BUTTON_RMASK = SDL_BUTTON(SDL_BUTTON_RIGHT);
//public static readonly uint SDL_BUTTON_X1MASK = SDL_BUTTON(SDL_BUTTON_X1);
//public static readonly uint SDL_BUTTON_X2MASK = SDL_BUTTON(SDL_BUTTON_X2);
public enum SDL_SystemCursor
{
	SDL_SYSTEM_CURSOR_ARROW = 0,
	SDL_SYSTEM_CURSOR_IBEAM = 1,
	SDL_SYSTEM_CURSOR_WAIT = 2,
	SDL_SYSTEM_CURSOR_CROSSHAIR = 3,
	SDL_SYSTEM_CURSOR_WAITARROW = 4,
	SDL_SYSTEM_CURSOR_SIZENWSE = 5,
	SDL_SYSTEM_CURSOR_SIZENESW = 6,
	SDL_SYSTEM_CURSOR_SIZEWE = 7,
	SDL_SYSTEM_CURSOR_SIZENS = 8,
	SDL_SYSTEM_CURSOR_SIZEALL = 9,
	SDL_SYSTEM_CURSOR_NO = 10,
	SDL_SYSTEM_CURSOR_HAND = 11,
	SDL_NUM_SYSTEM_CURSORS = 12,
}

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Window*  */ SDL_GetMouseFocus(
);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_GetMouseState(
	IntPtr/* System.Int32*  */ x, 
	IntPtr/* System.Int32*  */ y);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_GetRelativeMouseState(
	IntPtr/* System.Int32*  */ x, 
	IntPtr/* System.Int32*  */ y);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern void SDL_WarpMouseInWindow(
	IntPtr/* SDL_Window*  */ window, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 y);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetRelativeMouseMode(
	SDL_bool enabled);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_GetRelativeMouseMode(
);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Cursor*  */ SDL_CreateCursor(
	IntPtr/* System.Byte*  */ data, 
	IntPtr/* System.Byte*  */ mask, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 w, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 h, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 hot_x, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 hot_y);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Cursor*  */ SDL_CreateColorCursor(
	IntPtr/* SDL_Surface*  */ surface, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 hot_x, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 hot_y);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Cursor*  */ SDL_CreateSystemCursor(
	SDL_SystemCursor id);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetCursor(
	IntPtr/* SDL_Cursor*  */ cursor);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Cursor*  */ SDL_GetCursor(
);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Cursor*  */ SDL_GetDefaultCursor(
);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern void SDL_FreeCursor(
	IntPtr/* SDL_Cursor*  */ cursor);

[DllImport(SDL_MOUSE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_ShowCursor(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 toggle);

}
}

