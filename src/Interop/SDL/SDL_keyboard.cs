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
public const string SDL_KEYBOARD = "SDL2.dll";


[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Window*  */ SDL_GetKeyboardFocus(
);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* System.Byte*  */ SDL_GetKeyboardState(
	IntPtr/* System.Int32*  */ numkeys);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern SDL_Keymod SDL_GetModState(
);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetModState(
	SDL_Keymod modstate);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetKeyFromScancode(
	SDL_Scancode scancode);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern SDL_Scancode SDL_GetScancodeFromKey(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 key);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GetScancodeName(
	SDL_Scancode scancode);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern SDL_Scancode SDL_GetScancodeFromName(
	[MarshalAs(UnmanagedType.LPStr)]
	string name);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GetKeyName(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 key);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetKeyFromName(
	[MarshalAs(UnmanagedType.LPStr)]
	string name);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern void SDL_StartTextInput(
);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_IsTextInputActive(
);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern void SDL_StopTextInput(
);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetTextInputRect(
	IntPtr/* SDL_Rect*  */ rect);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasScreenKeyboardSupport(
);

[DllImport(SDL_KEYBOARD), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_IsScreenKeyboardShown(
	IntPtr/* SDL_Window*  */ window);

public struct SDL_Keysym{
	public SDL_Scancode scancode;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 sym;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 mod;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 unused;

};

}
}

