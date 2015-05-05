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
public const string SDL_EVENTS = "SDL2.dll";


public static readonly uint SDL_RELEASED = 0;
public static readonly uint SDL_PRESSED = 1;
public static readonly uint SDL_TEXTEDITINGEVENT_TEXT_SIZE = (32);
public static readonly uint SDL_TEXTINPUTEVENT_TEXT_SIZE = (32);
public static readonly uint SDL_QUERY = 0xffffffff;
public static readonly uint SDL_IGNORE = 0;
public static readonly uint SDL_DISABLE = 0;
public static readonly uint SDL_ENABLE = 1;
public enum SDL_EventType
{
	SDL_FIRSTEVENT = 0,
	SDL_QUIT = 256,
	SDL_APP_TERMINATING = 257,
	SDL_APP_LOWMEMORY = 258,
	SDL_APP_WILLENTERBACKGROUND = 259,
	SDL_APP_DIDENTERBACKGROUND = 260,
	SDL_APP_WILLENTERFOREGROUND = 261,
	SDL_APP_DIDENTERFOREGROUND = 262,
	SDL_WINDOWEVENT = 512,
	SDL_SYSWMEVENT = 513,
	SDL_KEYDOWN = 768,
	SDL_KEYUP = 769,
	SDL_TEXTEDITING = 770,
	SDL_TEXTINPUT = 771,
	SDL_MOUSEMOTION = 1024,
	SDL_MOUSEBUTTONDOWN = 1025,
	SDL_MOUSEBUTTONUP = 1026,
	SDL_MOUSEWHEEL = 1027,
	SDL_JOYAXISMOTION = 1536,
	SDL_JOYBALLMOTION = 1537,
	SDL_JOYHATMOTION = 1538,
	SDL_JOYBUTTONDOWN = 1539,
	SDL_JOYBUTTONUP = 1540,
	SDL_JOYDEVICEADDED = 1541,
	SDL_JOYDEVICEREMOVED = 1542,
	SDL_CONTROLLERAXISMOTION = 1616,
	SDL_CONTROLLERBUTTONDOWN = 1617,
	SDL_CONTROLLERBUTTONUP = 1618,
	SDL_CONTROLLERDEVICEADDED = 1619,
	SDL_CONTROLLERDEVICEREMOVED = 1620,
	SDL_CONTROLLERDEVICEREMAPPED = 1621,
	SDL_FINGERDOWN = 1792,
	SDL_FINGERUP = 1793,
	SDL_FINGERMOTION = 1794,
	SDL_DOLLARGESTURE = 2048,
	SDL_DOLLARRECORD = 2049,
	SDL_MULTIGESTURE = 2050,
	SDL_CLIPBOARDUPDATE = 2304,
	SDL_DROPFILE = 4096,
	SDL_RENDER_TARGETS_RESET = 8192,
	SDL_USEREVENT = 32768,
	SDL_LASTEVENT = 65535,
}

public enum SDL_eventaction
{
	SDL_ADDEVENT = 0,
	SDL_PEEKEVENT = 1,
	SDL_GETEVENT = 2,
}

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_PumpEvents(
);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_PeepEvents(
	IntPtr/* SDL_Event*  */ events, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 numevents, 
	SDL_eventaction action, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 minType, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 maxType);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasEvent(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 type);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasEvents(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 minType, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 maxType);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_FlushEvent(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 type);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_FlushEvents(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 minType, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 maxType);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_PollEvent(
	IntPtr/* SDL_Event*  */ _event);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_WaitEvent(
	IntPtr/* SDL_Event*  */ _event);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_WaitEventTimeout(
	IntPtr/* SDL_Event*  */ _event, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 timeout);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_PushEvent(
	IntPtr/* SDL_Event*  */ _event);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetEventFilter(
	IntPtr filter, 
	IntPtr/* void*  */ userdata);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_GetEventFilter(
	IntPtr/* IntPtr*  */ filter, 
	IntPtr/* IntPtr*  */ userdata);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_AddEventWatch(
	IntPtr filter, 
	IntPtr/* void*  */ userdata);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_DelEventWatch(
	IntPtr filter, 
	IntPtr/* void*  */ userdata);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_FilterEvents(
	IntPtr filter, 
	IntPtr/* void*  */ userdata);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern System.Byte SDL_EventState(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 type, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 state);

[DllImport(SDL_EVENTS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_RegisterEvents(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 numevents);

public struct SDL_CommonEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

};

public struct SDL_WindowEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 windowID;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte _event;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding1;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding2;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding3;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 data1;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 data2;

};

public struct SDL_KeyboardEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 windowID;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte state;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte repeat;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding2;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding3;

	public SDL_Keysym keysym;

};

public struct SDL_TextEditingEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 windowID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
	public Char[] text;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 start;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 length;

};

public struct SDL_TextInputEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 windowID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
	public Char[] text;

};

public struct SDL_MouseMotionEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 windowID;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 which;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 state;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 x;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 y;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 xrel;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 yrel;

};

public struct SDL_MouseButtonEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 windowID;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 which;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte button;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte state;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte clicks;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding1;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 x;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 y;

};

public struct SDL_MouseWheelEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 windowID;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 which;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 x;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 y;

};

public struct SDL_JoyAxisEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 which;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte axis;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding1;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding2;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding3;

	[MarshalAs(UnmanagedType.I2)]
	public System.Int16 value;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 padding4;

};

public struct SDL_JoyBallEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 which;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte ball;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding1;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding2;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding3;

	[MarshalAs(UnmanagedType.I2)]
	public System.Int16 xrel;

	[MarshalAs(UnmanagedType.I2)]
	public System.Int16 yrel;

};

public struct SDL_JoyHatEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 which;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte hat;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte value;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding1;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding2;

};

public struct SDL_JoyButtonEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 which;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte button;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte state;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding1;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding2;

};

public struct SDL_JoyDeviceEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 which;

};

public struct SDL_ControllerAxisEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 which;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte axis;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding1;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding2;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding3;

	[MarshalAs(UnmanagedType.I2)]
	public System.Int16 value;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 padding4;

};

public struct SDL_ControllerButtonEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 which;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte button;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte state;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding1;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte padding2;

};

public struct SDL_ControllerDeviceEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 which;

};

public struct SDL_TouchFingerEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 touchId;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 fingerId;

	[MarshalAs(UnmanagedType.R4)]
	public float x;

	[MarshalAs(UnmanagedType.R4)]
	public float y;

	[MarshalAs(UnmanagedType.R4)]
	public float dx;

	[MarshalAs(UnmanagedType.R4)]
	public float dy;

	[MarshalAs(UnmanagedType.R4)]
	public float pressure;

};

public struct SDL_MultiGestureEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 touchId;

	[MarshalAs(UnmanagedType.R4)]
	public float dTheta;

	[MarshalAs(UnmanagedType.R4)]
	public float dDist;

	[MarshalAs(UnmanagedType.R4)]
	public float x;

	[MarshalAs(UnmanagedType.R4)]
	public float y;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 numFingers;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 padding;

};

public struct SDL_DollarGestureEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 touchId;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 gestureId;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 numFingers;

	[MarshalAs(UnmanagedType.R4)]
	public float error;

	[MarshalAs(UnmanagedType.R4)]
	public float x;

	[MarshalAs(UnmanagedType.R4)]
	public float y;

};

public struct SDL_DropEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.LPStr)]
	public string file;

};

public struct SDL_QuitEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

};

public struct SDL_OSEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

};

public struct SDL_UserEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 windowID;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 code;

	public IntPtr/* void*  */ data1;

	public IntPtr/* void*  */ data2;

};

public struct SDL_SysWMEvent{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 timestamp;

	public IntPtr/* SDL_SysWMmsg*  */ msg;

};

public struct SDL_Event{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 type;

	public SDL_CommonEvent common;

	public SDL_WindowEvent window;

	public SDL_KeyboardEvent key;

	public SDL_TextEditingEvent edit;

	public SDL_TextInputEvent text;

	public SDL_MouseMotionEvent motion;

	public SDL_MouseButtonEvent button;

	public SDL_MouseWheelEvent wheel;

	public SDL_JoyAxisEvent jaxis;

	public SDL_JoyBallEvent jball;

	public SDL_JoyHatEvent jhat;

	public SDL_JoyButtonEvent jbutton;

	public SDL_JoyDeviceEvent jdevice;

	public SDL_ControllerAxisEvent caxis;

	public SDL_ControllerButtonEvent cbutton;

	public SDL_ControllerDeviceEvent cdevice;

	public SDL_QuitEvent quit;

	public SDL_UserEvent user;

	public SDL_SysWMEvent syswm;

	public SDL_TouchFingerEvent tfinger;

	public SDL_MultiGestureEvent mgesture;

	public SDL_DollarGestureEvent dgesture;

	public SDL_DropEvent drop;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=56)]
	public byte[] padding;

};

}
}

