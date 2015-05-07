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
public const string SDL_SURFACE = "SDL2.dll";


public static readonly uint SDL_SWSURFACE = 0;
public static readonly uint SDL_PREALLOC = 0x00000001;
public static readonly uint SDL_RLEACCEL = 0x00000002;
public static readonly uint SDL_DONTFREE = 0x00000004;

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Surface*  */ SDL_CreateRGBSurface(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 width, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 height, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 depth, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Rmask, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Gmask, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Bmask, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Amask);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Surface*  */ SDL_CreateRGBSurfaceFrom(
	IntPtr/* void*  */ pixels, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 width, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 height, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 depth, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 pitch, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Rmask, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Gmask, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Bmask, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 Amask);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern void SDL_FreeSurface(
	IntPtr/* SDL_Surface*  */ surface);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetSurfacePalette(
	IntPtr/* SDL_Surface*  */ surface, 
	IntPtr/* SDL_Palette*  */ palette);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_LockSurface(
	IntPtr/* SDL_Surface*  */ surface);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern void SDL_UnlockSurface(
	IntPtr/* SDL_Surface*  */ surface);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Surface*  */ SDL_LoadBMP_RW(
	IntPtr/* SDL_RWops*  */ src, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 freesrc);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SaveBMP_RW(
	IntPtr/* SDL_Surface*  */ surface, 
	IntPtr/* SDL_RWops*  */ dst, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 freedst);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetSurfaceRLE(
	IntPtr/* SDL_Surface*  */ surface, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flag);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetColorKey(
	IntPtr/* SDL_Surface*  */ surface, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flag, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 key);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetColorKey(
	IntPtr/* SDL_Surface*  */ surface, 
	IntPtr/* System.UInt32*  */ key);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetSurfaceColorMod(
	IntPtr/* SDL_Surface*  */ surface, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte r, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte g, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte b);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetSurfaceColorMod(
	IntPtr/* SDL_Surface*  */ surface, 
	IntPtr/* System.Byte*  */ r, 
	IntPtr/* System.Byte*  */ g, 
	IntPtr/* System.Byte*  */ b);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetSurfaceAlphaMod(
	IntPtr/* SDL_Surface*  */ surface, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte alpha);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetSurfaceAlphaMod(
	IntPtr/* SDL_Surface*  */ surface, 
	IntPtr/* System.Byte*  */ alpha);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetSurfaceBlendMode(
	IntPtr/* SDL_Surface*  */ surface, 
	SDL_BlendMode blendMode);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetSurfaceBlendMode(
	IntPtr/* SDL_Surface*  */ surface, 
	IntPtr/* SDL_BlendMode*  */ blendMode);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_SetClipRect(
	IntPtr/* SDL_Surface*  */ surface, 
	IntPtr/* SDL_Rect*  */ rect);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GetClipRect(
	IntPtr/* SDL_Surface*  */ surface, 
	IntPtr/* SDL_Rect*  */ rect);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Surface*  */ SDL_ConvertSurface(
	IntPtr/* SDL_Surface*  */ src, 
	IntPtr/* SDL_PixelFormat*  */ fmt, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Surface*  */ SDL_ConvertSurfaceFormat(
	IntPtr/* SDL_Surface*  */ src, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 pixel_format, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_ConvertPixels(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 width, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 height, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 src_format, 
	IntPtr/* void*  */ src, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 src_pitch, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 dst_format, 
	IntPtr/* void*  */ dst, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 dst_pitch);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_FillRect(
	IntPtr/* SDL_Surface*  */ dst, 
	IntPtr/* SDL_Rect*  */ rect, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 color);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_FillRects(
	IntPtr/* SDL_Surface*  */ dst, 
	IntPtr/* SDL_Rect*  */ rects, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 count, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 color);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_UpperBlit(
	IntPtr/* SDL_Surface*  */ src, 
	IntPtr/* SDL_Rect*  */ srcrect, 
	IntPtr/* SDL_Surface*  */ dst, 
	IntPtr/* SDL_Rect*  */ dstrect);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_LowerBlit(
	IntPtr/* SDL_Surface*  */ src, 
	IntPtr/* SDL_Rect*  */ srcrect, 
	IntPtr/* SDL_Surface*  */ dst, 
	IntPtr/* SDL_Rect*  */ dstrect);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SoftStretch(
	IntPtr/* SDL_Surface*  */ src, 
	IntPtr/* SDL_Rect*  */ srcrect, 
	IntPtr/* SDL_Surface*  */ dst, 
	IntPtr/* SDL_Rect*  */ dstrect);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_UpperBlitScaled(
	IntPtr/* SDL_Surface*  */ src, 
	IntPtr/* SDL_Rect*  */ srcrect, 
	IntPtr/* SDL_Surface*  */ dst, 
	IntPtr/* SDL_Rect*  */ dstrect);

[DllImport(SDL_SURFACE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_LowerBlitScaled(
	IntPtr/* SDL_Surface*  */ src, 
	IntPtr/* SDL_Rect*  */ srcrect, 
	IntPtr/* SDL_Surface*  */ dst, 
	IntPtr/* SDL_Rect*  */ dstrect);

public struct SDL_Surface{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 flags;

	public IntPtr/* SDL_PixelFormat*  */ format;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 w;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 h;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 pitch;

	public IntPtr/* void*  */ pixels;

	public IntPtr/* void*  */ userdata;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 locked;

	public IntPtr/* void*  */ lock_data;

	public SDL_Rect clip_rect;

	public IntPtr/* SDL_BlitMap*  */ map;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 refcount;

};

}
}

