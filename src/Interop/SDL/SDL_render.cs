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
public const string SDL_RENDER = "SDL2.dll";


public enum SDL_RendererFlags
{
	SDL_RENDERER_SOFTWARE = 1,
	SDL_RENDERER_ACCELERATED = 2,
	SDL_RENDERER_PRESENTVSYNC = 4,
	SDL_RENDERER_TARGETTEXTURE = 8,
}

public enum SDL_TextureAccess
{
	SDL_TEXTUREACCESS_STATIC = 0,
	SDL_TEXTUREACCESS_STREAMING = 1,
	SDL_TEXTUREACCESS_TARGET = 2,
}

public enum SDL_TextureModulate
{
	SDL_TEXTUREMODULATE_NONE = 0,
	SDL_TEXTUREMODULATE_COLOR = 1,
	SDL_TEXTUREMODULATE_ALPHA = 2,
}

public enum SDL_RendererFlip
{
	SDL_FLIP_NONE = 0,
	SDL_FLIP_HORIZONTAL = 1,
	SDL_FLIP_VERTICAL = 2,
}

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetNumRenderDrivers(
);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetRenderDriverInfo(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 index, 
	IntPtr/* SDL_RendererInfo*  */ info);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_CreateWindowAndRenderer(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 width, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 height, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 window_flags, 
	IntPtr/* IntPtr*  */ window, 
	IntPtr/* IntPtr*  */ renderer);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Renderer*  */ SDL_CreateRenderer(
	IntPtr/* SDL_Window*  */ window, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 index, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Renderer*  */ SDL_CreateSoftwareRenderer(
	IntPtr/* SDL_Surface*  */ surface);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Renderer*  */ SDL_GetRenderer(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetRendererInfo(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_RendererInfo*  */ info);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetRendererOutputSize(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* System.Int32*  */ w, 
	IntPtr/* System.Int32*  */ h);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Texture*  */ SDL_CreateTexture(
	IntPtr/* SDL_Renderer*  */ renderer, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 format, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 access, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 w, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 h);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Texture*  */ SDL_CreateTextureFromSurface(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Surface*  */ surface);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_QueryTexture(
	IntPtr/* SDL_Texture*  */ texture, 
	IntPtr/* System.UInt32*  */ format, 
	IntPtr/* System.Int32*  */ access, 
	IntPtr/* System.Int32*  */ w, 
	IntPtr/* System.Int32*  */ h);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetTextureColorMod(
	IntPtr/* SDL_Texture*  */ texture, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte r, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte g, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte b);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetTextureColorMod(
	IntPtr/* SDL_Texture*  */ texture, 
	IntPtr/* System.Byte*  */ r, 
	IntPtr/* System.Byte*  */ g, 
	IntPtr/* System.Byte*  */ b);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetTextureAlphaMod(
	IntPtr/* SDL_Texture*  */ texture, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte alpha);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetTextureAlphaMod(
	IntPtr/* SDL_Texture*  */ texture, 
	IntPtr/* System.Byte*  */ alpha);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetTextureBlendMode(
	IntPtr/* SDL_Texture*  */ texture, 
	SDL_BlendMode blendMode);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetTextureBlendMode(
	IntPtr/* SDL_Texture*  */ texture, 
	IntPtr/* SDL_BlendMode*  */ blendMode);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_UpdateTexture(
	IntPtr/* SDL_Texture*  */ texture, 
	IntPtr/* SDL_Rect*  */ rect, 
	IntPtr/* void*  */ pixels, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 pitch);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_UpdateYUVTexture(
	IntPtr/* SDL_Texture*  */ texture, 
	IntPtr/* SDL_Rect*  */ rect, 
	IntPtr/* System.Byte*  */ Yplane, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 Ypitch, 
	IntPtr/* System.Byte*  */ Uplane, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 Upitch, 
	IntPtr/* System.Byte*  */ Vplane, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 Vpitch);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_LockTexture(
	IntPtr/* SDL_Texture*  */ texture, 
	IntPtr/* SDL_Rect*  */ rect, 
	IntPtr/* IntPtr*  */ pixels, 
	IntPtr/* System.Int32*  */ pitch);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern void SDL_UnlockTexture(
	IntPtr/* SDL_Texture*  */ texture);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_RenderTargetSupported(
	IntPtr/* SDL_Renderer*  */ renderer);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetRenderTarget(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Texture*  */ texture);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Texture*  */ SDL_GetRenderTarget(
	IntPtr/* SDL_Renderer*  */ renderer);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderSetLogicalSize(
	IntPtr/* SDL_Renderer*  */ renderer, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 w, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 h);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern void SDL_RenderGetLogicalSize(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* System.Int32*  */ w, 
	IntPtr/* System.Int32*  */ h);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderSetViewport(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Rect*  */ rect);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern void SDL_RenderGetViewport(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Rect*  */ rect);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderSetClipRect(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Rect*  */ rect);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern void SDL_RenderGetClipRect(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Rect*  */ rect);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderSetScale(
	IntPtr/* SDL_Renderer*  */ renderer, 
	[MarshalAs(UnmanagedType.R4)]
	float scaleX, 
	[MarshalAs(UnmanagedType.R4)]
	float scaleY);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern void SDL_RenderGetScale(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* float*  */ scaleX, 
	IntPtr/* float*  */ scaleY);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetRenderDrawColor(
	IntPtr/* SDL_Renderer*  */ renderer, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte r, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte g, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte b, 
	[MarshalAs(UnmanagedType.I1)]
	System.Byte a);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetRenderDrawColor(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* System.Byte*  */ r, 
	IntPtr/* System.Byte*  */ g, 
	IntPtr/* System.Byte*  */ b, 
	IntPtr/* System.Byte*  */ a);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetRenderDrawBlendMode(
	IntPtr/* SDL_Renderer*  */ renderer, 
	SDL_BlendMode blendMode);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetRenderDrawBlendMode(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_BlendMode*  */ blendMode);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderClear(
	IntPtr/* SDL_Renderer*  */ renderer);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderDrawPoint(
	IntPtr/* SDL_Renderer*  */ renderer, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 y);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderDrawPoints(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Point*  */ points, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 count);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderDrawLine(
	IntPtr/* SDL_Renderer*  */ renderer, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x1, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 y1, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x2, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 y2);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderDrawLines(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Point*  */ points, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 count);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderDrawRect(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Rect*  */ rect);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderDrawRects(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Rect*  */ rects, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 count);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderFillRect(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Rect*  */ rect);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderFillRects(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Rect*  */ rects, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 count);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderCopy(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Texture*  */ texture, 
	IntPtr/* SDL_Rect*  */ srcrect, 
	IntPtr/* SDL_Rect*  */ dstrect);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderCopyEx(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Texture*  */ texture, 
	IntPtr/* SDL_Rect*  */ srcrect, 
	IntPtr/* SDL_Rect*  */ dstrect, 
	[MarshalAs(UnmanagedType.R8)]
	System.Double angle, 
	IntPtr/* SDL_Point*  */ center, 
	SDL_RendererFlip flip);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_RenderReadPixels(
	IntPtr/* SDL_Renderer*  */ renderer, 
	IntPtr/* SDL_Rect*  */ rect, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 format, 
	IntPtr/* void*  */ pixels, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 pitch);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern void SDL_RenderPresent(
	IntPtr/* SDL_Renderer*  */ renderer);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern void SDL_DestroyTexture(
	IntPtr/* SDL_Texture*  */ texture);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern void SDL_DestroyRenderer(
	IntPtr/* SDL_Renderer*  */ renderer);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GL_BindTexture(
	IntPtr/* SDL_Texture*  */ texture, 
	IntPtr/* float*  */ texw, 
	IntPtr/* float*  */ texh);

[DllImport(SDL_RENDER), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GL_UnbindTexture(
	IntPtr/* SDL_Texture*  */ texture);

public struct SDL_RendererInfo{
	[MarshalAs(UnmanagedType.LPStr)]
	public string name;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 flags;

	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 num_texture_formats;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=16)]
	public UInt32[] texture_formats;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 max_texture_width;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 max_texture_height;

};

}
}

