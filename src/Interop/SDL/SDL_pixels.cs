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
public const string SDL_PIXELS = "SDL2.dll";


public static readonly uint SDL_ALPHA_OPAQUE = 255;
public static readonly uint SDL_ALPHA_TRANSPARENT = 0;
public enum SDL_PIXELTYPE 
{
	SDL_PIXELTYPE_UNKNOWN = 0,
	SDL_PIXELTYPE_INDEX1 = 1,
	SDL_PIXELTYPE_INDEX4 = 2,
	SDL_PIXELTYPE_INDEX8 = 3,
	SDL_PIXELTYPE_PACKED8 = 4,
	SDL_PIXELTYPE_PACKED16 = 5,
	SDL_PIXELTYPE_PACKED32 = 6,
	SDL_PIXELTYPE_ARRAYU8 = 7,
	SDL_PIXELTYPE_ARRAYU16 = 8,
	SDL_PIXELTYPE_ARRAYU32 = 9,
	SDL_PIXELTYPE_ARRAYF16 = 10,
	SDL_PIXELTYPE_ARRAYF32 = 11,
}

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GetPixelFormatName(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 format);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_PixelFormatEnumToMasks(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 format, 
	IntPtr/* System.Int32*  */ bpp, 
	IntPtr/* System.UInt32*  */ Rmask, 
	IntPtr/* System.UInt32*  */ Gmask, 
	IntPtr/* System.UInt32*  */ Bmask, 
	IntPtr/* System.UInt32*  */ Amask);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_MasksToPixelFormatEnum(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 bpp, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Rmask, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Gmask, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Bmask, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Amask);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_PixelFormat*  */ SDL_AllocFormat(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 pixel_format);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_FreeFormat(
	IntPtr/* SDL_PixelFormat*  */ format);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Palette*  */ SDL_AllocPalette(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 ncolors);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetPixelFormatPalette(
	IntPtr/* SDL_PixelFormat*  */ format, 
	IntPtr/* SDL_Palette*  */ palette);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetPaletteColors(
	IntPtr/* SDL_Palette*  */ palette, 
	IntPtr/* SDL_Color*  */ colors, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 firstcolor, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 ncolors);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_FreePalette(
	IntPtr/* SDL_Palette*  */ palette);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_MapRGB(
	IntPtr/* SDL_PixelFormat*  */ format, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte r, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte g, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte b);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_MapRGBA(
	IntPtr/* SDL_PixelFormat*  */ format, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte r, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte g, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte b, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte a);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GetRGB(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 pixel, 
	IntPtr/* SDL_PixelFormat*  */ format, 
	IntPtr/* System.Byte*  */ r, 
	IntPtr/* System.Byte*  */ g, 
	IntPtr/* System.Byte*  */ b);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GetRGBA(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 pixel, 
	IntPtr/* SDL_PixelFormat*  */ format, 
	IntPtr/* System.Byte*  */ r, 
	IntPtr/* System.Byte*  */ g, 
	IntPtr/* System.Byte*  */ b, 
	IntPtr/* System.Byte*  */ a);

[DllImport(SDL_PIXELS), SuppressUnmanagedCodeSecurity]
public static extern void SDL_CalculateGammaRamp(
	[MarshalAs(UnmanagedType.R4)]
	float gamma, 
	IntPtr/* System.UInt16*  */ ramp);

public struct SDL_Color{
	[MarshalAs(UnmanagedType.I1)]
	public System.Byte r;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte g;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte b;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte a;

};

public struct SDL_Palette{
	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 ncolors;

	public IntPtr/* SDL_Color*  */ colors;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 version;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 refcount;

};

public struct SDL_PixelFormat{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 format;

	public IntPtr/* SDL_Palette*  */ palette;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte BitsPerPixel;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte BytesPerPixel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
	public byte[] padding;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 Rmask;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 Gmask;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 Bmask;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 Amask;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte Rloss;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte Gloss;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte Bloss;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte Aloss;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte Rshift;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte Gshift;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte Bshift;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte Ashift;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 refcount;

	public IntPtr/* SDL_PixelFormat*  */ next;

};

}
}

