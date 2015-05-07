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
public const string SDL_JOYSTICK = "SDL2.dll";


public static readonly uint SDL_HAT_CENTERED = 0x00;
public static readonly uint SDL_HAT_UP = 0x01;
public static readonly uint SDL_HAT_RIGHT = 0x02;
public static readonly uint SDL_HAT_DOWN = 0x04;
public static readonly uint SDL_HAT_LEFT = 0x08;
public static readonly uint SDL_HAT_RIGHTUP = (SDL_HAT_RIGHT|SDL_HAT_UP);
public static readonly uint SDL_HAT_RIGHTDOWN = (SDL_HAT_RIGHT|SDL_HAT_DOWN);
public static readonly uint SDL_HAT_LEFTUP = (SDL_HAT_LEFT|SDL_HAT_UP);
public static readonly uint SDL_HAT_LEFTDOWN = (SDL_HAT_LEFT|SDL_HAT_DOWN);
[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_NumJoysticks(
);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern string SDL_JoystickNameForIndex(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 device_index);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* _SDL_Joystick*  */ SDL_JoystickOpen(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 device_index);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern string SDL_JoystickName(
	IntPtr/* _SDL_Joystick*  */ joystick);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern SDL_JoystickGUID SDL_JoystickGetDeviceGUID(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 device_index);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern SDL_JoystickGUID SDL_JoystickGetGUID(
	IntPtr/* _SDL_Joystick*  */ joystick);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern void SDL_JoystickGetGUIDString(
	SDL_JoystickGUID guid, 
	[MarshalAs(UnmanagedType.LPStr)]
	string pszGUID, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 cbGUID);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern SDL_JoystickGUID SDL_JoystickGetGUIDFromString(
	[MarshalAs(UnmanagedType.LPStr)]
	string pchGUID);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_JoystickGetAttached(
	IntPtr/* _SDL_Joystick*  */ joystick);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_JoystickInstanceID(
	IntPtr/* _SDL_Joystick*  */ joystick);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_JoystickNumAxes(
	IntPtr/* _SDL_Joystick*  */ joystick);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_JoystickNumBalls(
	IntPtr/* _SDL_Joystick*  */ joystick);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_JoystickNumHats(
	IntPtr/* _SDL_Joystick*  */ joystick);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_JoystickNumButtons(
	IntPtr/* _SDL_Joystick*  */ joystick);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern void SDL_JoystickUpdate(
);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_JoystickEventState(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 state);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern System.Int16 SDL_JoystickGetAxis(
	IntPtr/* _SDL_Joystick*  */ joystick, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 axis);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern System.Byte SDL_JoystickGetHat(
	IntPtr/* _SDL_Joystick*  */ joystick, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 hat);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_JoystickGetBall(
	IntPtr/* _SDL_Joystick*  */ joystick, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 ball, 
	IntPtr/* System.Int32*  */ dx, 
	IntPtr/* System.Int32*  */ dy);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern System.Byte SDL_JoystickGetButton(
	IntPtr/* _SDL_Joystick*  */ joystick, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 button);

[DllImport(SDL_JOYSTICK), SuppressUnmanagedCodeSecurity]
public static extern void SDL_JoystickClose(
	IntPtr/* _SDL_Joystick*  */ joystick);

public struct SDL_JoystickGUID{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst=16)]
	public byte[] data;

};

}
}

