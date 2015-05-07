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
public const string SDL_MESSAGEBOX = "SDL2.dll";


public enum SDL_MessageBoxFlags
{
	SDL_MESSAGEBOX_ERROR = 16,
	SDL_MESSAGEBOX_WARNING = 32,
	SDL_MESSAGEBOX_INFORMATION = 64,
}

public enum SDL_MessageBoxButtonFlags
{
	SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT = 1,
	SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT = 2,
}

public enum SDL_MessageBoxColorType
{
	SDL_MESSAGEBOX_COLOR_BACKGROUND = 0,
	SDL_MESSAGEBOX_COLOR_TEXT = 1,
	SDL_MESSAGEBOX_COLOR_BUTTON_BORDER = 2,
	SDL_MESSAGEBOX_COLOR_BUTTON_BACKGROUND = 3,
	SDL_MESSAGEBOX_COLOR_BUTTON_SELECTED = 4,
	SDL_MESSAGEBOX_COLOR_MAX = 5,
}

[DllImport(SDL_MESSAGEBOX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_ShowMessageBox(
	IntPtr/* SDL_MessageBoxData*  */ messageboxdata, 
	IntPtr/* System.Int32*  */ buttonid);

[DllImport(SDL_MESSAGEBOX), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_ShowSimpleMessageBox(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags, 
	[MarshalAs(UnmanagedType.LPStr)]
	string title, 
	[MarshalAs(UnmanagedType.LPStr)]
	string message, 
	IntPtr/* SDL_Window*  */ window);

public struct SDL_MessageBoxButtonData{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 flags;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 buttonid;

	[MarshalAs(UnmanagedType.LPStr)]
	public string text;

};

public struct SDL_MessageBoxColor{
	[MarshalAs(UnmanagedType.I1)]
	public System.Byte r;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte g;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte b;

};

public struct SDL_MessageBoxColorScheme{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst=5)]
	public SDL_MessageBoxColor[] colors;

};

public struct SDL_MessageBoxData{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 flags;

	public IntPtr/* SDL_Window*  */ window;

	[MarshalAs(UnmanagedType.LPStr)]
	public string title;

	[MarshalAs(UnmanagedType.LPStr)]
	public string message;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 numbuttons;

	public IntPtr/* SDL_MessageBoxButtonData*  */ buttons;

	public IntPtr/* SDL_MessageBoxColorScheme*  */ colorScheme;

};

}
}

