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
public const string SDL_HAPTIC = "SDL2.dll";


public static readonly uint SDL_HAPTIC_CONSTANT = (1<<0);
public static readonly uint SDL_HAPTIC_SINE = (1<<1);
public static readonly uint SDL_HAPTIC_LEFTRIGHT = (1<<2);
public static readonly uint SDL_HAPTIC_TRIANGLE = (1<<3);
public static readonly uint SDL_HAPTIC_SAWTOOTHUP = (1<<4);
public static readonly uint SDL_HAPTIC_SAWTOOTHDOWN = (1<<5);
public static readonly uint SDL_HAPTIC_RAMP = (1<<6);
public static readonly uint SDL_HAPTIC_SPRING = (1<<7);
public static readonly uint SDL_HAPTIC_DAMPER = (1<<8);
public static readonly uint SDL_HAPTIC_INERTIA = (1<<9);
public static readonly uint SDL_HAPTIC_FRICTION = (1<<10);
public static readonly uint SDL_HAPTIC_CUSTOM = (1<<11);
public static readonly uint SDL_HAPTIC_GAIN = (1<<12);
public static readonly uint SDL_HAPTIC_AUTOCENTER = (1<<13);
public static readonly uint SDL_HAPTIC_STATUS = (1<<14);
public static readonly uint SDL_HAPTIC_PAUSE = (1<<15);
public static readonly uint SDL_HAPTIC_POLAR = 0;
public static readonly uint SDL_HAPTIC_CARTESIAN = 1;
public static readonly uint SDL_HAPTIC_SPHERICAL = 2;
public static readonly uint SDL_HAPTIC_INFINITY = 4294967295U;
[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_NumHaptics(
);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_HapticName(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 device_index);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* _SDL_Haptic*  */ SDL_HapticOpen(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 device_index);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticOpened(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 device_index);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticIndex(
	IntPtr/* _SDL_Haptic*  */ haptic);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_MouseIsHaptic(
);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* _SDL_Haptic*  */ SDL_HapticOpenFromMouse(
);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_JoystickIsHaptic(
	IntPtr/* _SDL_Joystick*  */ joystick);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* _SDL_Haptic*  */ SDL_HapticOpenFromJoystick(
	IntPtr/* _SDL_Joystick*  */ joystick);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern void SDL_HapticClose(
	IntPtr/* _SDL_Haptic*  */ haptic);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticNumEffects(
	IntPtr/* _SDL_Haptic*  */ haptic);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticNumEffectsPlaying(
	IntPtr/* _SDL_Haptic*  */ haptic);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_HapticQuery(
	IntPtr/* _SDL_Haptic*  */ haptic);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticNumAxes(
	IntPtr/* _SDL_Haptic*  */ haptic);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticEffectSupported(
	IntPtr/* _SDL_Haptic*  */ haptic, 
	IntPtr/* SDL_HapticEffect*  */ effect);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticNewEffect(
	IntPtr/* _SDL_Haptic*  */ haptic, 
	IntPtr/* SDL_HapticEffect*  */ effect);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticUpdateEffect(
	IntPtr/* _SDL_Haptic*  */ haptic, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 effect, 
	IntPtr/* SDL_HapticEffect*  */ data);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticRunEffect(
	IntPtr/* _SDL_Haptic*  */ haptic, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 effect, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 iterations);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticStopEffect(
	IntPtr/* _SDL_Haptic*  */ haptic, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 effect);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern void SDL_HapticDestroyEffect(
	IntPtr/* _SDL_Haptic*  */ haptic, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 effect);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticGetEffectStatus(
	IntPtr/* _SDL_Haptic*  */ haptic, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 effect);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticSetGain(
	IntPtr/* _SDL_Haptic*  */ haptic, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 gain);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticSetAutocenter(
	IntPtr/* _SDL_Haptic*  */ haptic, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 autocenter);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticPause(
	IntPtr/* _SDL_Haptic*  */ haptic);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticUnpause(
	IntPtr/* _SDL_Haptic*  */ haptic);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticStopAll(
	IntPtr/* _SDL_Haptic*  */ haptic);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticRumbleSupported(
	IntPtr/* _SDL_Haptic*  */ haptic);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticRumbleInit(
	IntPtr/* _SDL_Haptic*  */ haptic);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticRumblePlay(
	IntPtr/* _SDL_Haptic*  */ haptic, 
	[MarshalAs(UnmanagedType.R4)]
	float strength, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 length);

[DllImport(SDL_HAPTIC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_HapticRumbleStop(
	IntPtr/* _SDL_Haptic*  */ haptic);

public struct SDL_HapticDirection{
	[MarshalAs(UnmanagedType.I1)]
	public System.Byte type;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
	public Int32[] dir;

};

public struct SDL_HapticConstant{
	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 type;

	public SDL_HapticDirection direction;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 delay;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 button;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 interval;

	[MarshalAs(UnmanagedType.I2)]
	public System.Int16 level;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 attack_length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 attack_level;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 fade_length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 fade_level;

};

public struct SDL_HapticPeriodic{
	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 type;

	public SDL_HapticDirection direction;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 delay;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 button;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 interval;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 period;

	[MarshalAs(UnmanagedType.I2)]
	public System.Int16 magnitude;

	[MarshalAs(UnmanagedType.I2)]
	public System.Int16 offset;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 phase;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 attack_length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 attack_level;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 fade_length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 fade_level;

};

public struct SDL_HapticCondition{
	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 type;

	public SDL_HapticDirection direction;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 delay;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 button;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 interval;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
	public UInt16[] right_sat;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
	public UInt16[] left_sat;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
	public Int16[] right_coeff;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
	public Int16[] left_coeff;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
	public UInt16[] deadband;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
	public Int16[] center;

};

public struct SDL_HapticRamp{
	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 type;

	public SDL_HapticDirection direction;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 delay;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 button;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 interval;

	[MarshalAs(UnmanagedType.I2)]
	public System.Int16 start;

	[MarshalAs(UnmanagedType.I2)]
	public System.Int16 end;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 attack_length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 attack_level;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 fade_length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 fade_level;

};

public struct SDL_HapticLeftRight{
	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 large_magnitude;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 small_magnitude;

};

public struct SDL_HapticCustom{
	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 type;

	public SDL_HapticDirection direction;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 delay;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 button;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 interval;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte channels;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 period;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 samples;

	public IntPtr/* System.UInt16*  */ data;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 attack_length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 attack_level;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 fade_length;

	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 fade_level;

};

public struct SDL_HapticEffect{
	[MarshalAs(UnmanagedType.I2)]
	public System.UInt16 type;

	public SDL_HapticConstant constant;

	public SDL_HapticPeriodic periodic;

	public SDL_HapticCondition condition;

	public SDL_HapticRamp ramp;

	public SDL_HapticLeftRight leftright;

	public SDL_HapticCustom custom;

};

}
}

