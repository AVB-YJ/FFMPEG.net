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
public const string SDL_RECT = "SDL2.dll";


[DllImport(SDL_RECT), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_RectEmpty(
	IntPtr/* SDL_Rect*  */ r);

[DllImport(SDL_RECT), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_RectEquals(
	IntPtr/* SDL_Rect*  */ a, 
	IntPtr/* SDL_Rect*  */ b);

[DllImport(SDL_RECT), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasIntersection(
	IntPtr/* SDL_Rect*  */ A, 
	IntPtr/* SDL_Rect*  */ B);

[DllImport(SDL_RECT), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_IntersectRect(
	IntPtr/* SDL_Rect*  */ A, 
	IntPtr/* SDL_Rect*  */ B, 
	IntPtr/* SDL_Rect*  */ result);

[DllImport(SDL_RECT), SuppressUnmanagedCodeSecurity]
public static extern void SDL_UnionRect(
	IntPtr/* SDL_Rect*  */ A, 
	IntPtr/* SDL_Rect*  */ B, 
	IntPtr/* SDL_Rect*  */ result);

[DllImport(SDL_RECT), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_EnclosePoints(
	IntPtr/* SDL_Point*  */ points, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 count, 
	IntPtr/* SDL_Rect*  */ clip, 
	IntPtr/* SDL_Rect*  */ result);

[DllImport(SDL_RECT), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_IntersectRectAndLine(
	IntPtr/* SDL_Rect*  */ rect, 
	IntPtr/* System.Int32*  */ X1, 
	IntPtr/* System.Int32*  */ Y1, 
	IntPtr/* System.Int32*  */ X2, 
	IntPtr/* System.Int32*  */ Y2);

public struct SDL_Point{
	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 x;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 y;

};

public struct SDL_Rect{
	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 x;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 y;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 w;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 h;

};

}
}

