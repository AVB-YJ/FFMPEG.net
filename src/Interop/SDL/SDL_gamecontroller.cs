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
public const string SDL_GAMECONTROLLER = "SDL2.dll";


public enum SDL_GameControllerBindType
{
	SDL_CONTROLLER_BINDTYPE_NONE = 0,
	SDL_CONTROLLER_BINDTYPE_BUTTON = 1,
	SDL_CONTROLLER_BINDTYPE_AXIS = 2,
	SDL_CONTROLLER_BINDTYPE_HAT = 3,
}

public enum SDL_GameControllerAxis : ulong
{
	SDL_CONTROLLER_AXIS_INVALID = 18446744073709551615,
	SDL_CONTROLLER_AXIS_LEFTX = 0,
	SDL_CONTROLLER_AXIS_LEFTY = 1,
	SDL_CONTROLLER_AXIS_RIGHTX = 2,
	SDL_CONTROLLER_AXIS_RIGHTY = 3,
	SDL_CONTROLLER_AXIS_TRIGGERLEFT = 4,
	SDL_CONTROLLER_AXIS_TRIGGERRIGHT = 5,
	SDL_CONTROLLER_AXIS_MAX = 6,
}

public enum SDL_GameControllerButton : ulong
{
	SDL_CONTROLLER_BUTTON_INVALID = 18446744073709551615,
	SDL_CONTROLLER_BUTTON_A = 0,
	SDL_CONTROLLER_BUTTON_B = 1,
	SDL_CONTROLLER_BUTTON_X = 2,
	SDL_CONTROLLER_BUTTON_Y = 3,
	SDL_CONTROLLER_BUTTON_BACK = 4,
	SDL_CONTROLLER_BUTTON_GUIDE = 5,
	SDL_CONTROLLER_BUTTON_START = 6,
	SDL_CONTROLLER_BUTTON_LEFTSTICK = 7,
	SDL_CONTROLLER_BUTTON_RIGHTSTICK = 8,
	SDL_CONTROLLER_BUTTON_LEFTSHOULDER = 9,
	SDL_CONTROLLER_BUTTON_RIGHTSHOULDER = 10,
	SDL_CONTROLLER_BUTTON_DPAD_UP = 11,
	SDL_CONTROLLER_BUTTON_DPAD_DOWN = 12,
	SDL_CONTROLLER_BUTTON_DPAD_LEFT = 13,
	SDL_CONTROLLER_BUTTON_DPAD_RIGHT = 14,
	SDL_CONTROLLER_BUTTON_MAX = 15,
}

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GameControllerAddMappingsFromRW(
	IntPtr/* SDL_RWops*  */ rw, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 freerw);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GameControllerAddMapping(
	[MarshalAs(UnmanagedType.LPStr)]
	string mappingString);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GameControllerMappingForGUID(
	SDL_JoystickGUID guid);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GameControllerMapping(
	IntPtr/* _SDL_GameController*  */ gamecontroller);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_IsGameController(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 joystick_index);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GameControllerNameForIndex(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 joystick_index);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* _SDL_GameController*  */ SDL_GameControllerOpen(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 joystick_index);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GameControllerName(
	IntPtr/* _SDL_GameController*  */ gamecontroller);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_GameControllerGetAttached(
	IntPtr/* _SDL_GameController*  */ gamecontroller);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* _SDL_Joystick*  */ SDL_GameControllerGetJoystick(
	IntPtr/* _SDL_GameController*  */ gamecontroller);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GameControllerEventState(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 state);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GameControllerUpdate(
);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern SDL_GameControllerAxis SDL_GameControllerGetAxisFromString(
	[MarshalAs(UnmanagedType.LPStr)]
	string pchString);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GameControllerGetStringForAxis(
	SDL_GameControllerAxis axis);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(
	IntPtr/* _SDL_GameController*  */ gamecontroller, 
	SDL_GameControllerAxis axis);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern System.Int16 SDL_GameControllerGetAxis(
	IntPtr/* _SDL_GameController*  */ gamecontroller, 
	SDL_GameControllerAxis axis);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern SDL_GameControllerButton SDL_GameControllerGetButtonFromString(
	[MarshalAs(UnmanagedType.LPStr)]
	string pchString);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GameControllerGetStringForButton(
	SDL_GameControllerButton button);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(
	IntPtr/* _SDL_GameController*  */ gamecontroller, 
	SDL_GameControllerButton button);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern System.Byte SDL_GameControllerGetButton(
	IntPtr/* _SDL_GameController*  */ gamecontroller, 
	SDL_GameControllerButton button);

[DllImport(SDL_GAMECONTROLLER), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GameControllerClose(
	IntPtr/* _SDL_GameController*  */ gamecontroller);

public struct SDL_GameControllerButtonBind{
	public SDL_GameControllerBindType bindType;

	//public  IntPtr value;

};

}
}

