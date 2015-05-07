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
public const string SDL_VIDEO = "SDL2.dll";


public static readonly uint SDL_WINDOWPOS_UNDEFINED_MASK = 0x1FFF0000;
public static readonly uint SDL_WINDOWPOS_CENTERED_MASK = 0x2FFF0000;
public enum SDL_WindowFlags
{
	SDL_WINDOW_FULLSCREEN = 1,
	SDL_WINDOW_OPENGL = 2,
	SDL_WINDOW_SHOWN = 4,
	SDL_WINDOW_HIDDEN = 8,
	SDL_WINDOW_BORDERLESS = 16,
	SDL_WINDOW_RESIZABLE = 32,
	SDL_WINDOW_MINIMIZED = 64,
	SDL_WINDOW_MAXIMIZED = 128,
	SDL_WINDOW_INPUT_GRABBED = 256,
	SDL_WINDOW_INPUT_FOCUS = 512,
	SDL_WINDOW_MOUSE_FOCUS = 1024,
	SDL_WINDOW_FULLSCREEN_DESKTOP = 4097,
	SDL_WINDOW_FOREIGN = 2048,
	SDL_WINDOW_ALLOW_HIGHDPI = 8192,
}

public enum SDL_WindowEventID
{
	SDL_WINDOWEVENT_NONE = 0,
	SDL_WINDOWEVENT_SHOWN = 1,
	SDL_WINDOWEVENT_HIDDEN = 2,
	SDL_WINDOWEVENT_EXPOSED = 3,
	SDL_WINDOWEVENT_MOVED = 4,
	SDL_WINDOWEVENT_RESIZED = 5,
	SDL_WINDOWEVENT_SIZE_CHANGED = 6,
	SDL_WINDOWEVENT_MINIMIZED = 7,
	SDL_WINDOWEVENT_MAXIMIZED = 8,
	SDL_WINDOWEVENT_RESTORED = 9,
	SDL_WINDOWEVENT_ENTER = 10,
	SDL_WINDOWEVENT_LEAVE = 11,
	SDL_WINDOWEVENT_FOCUS_GAINED = 12,
	SDL_WINDOWEVENT_FOCUS_LOST = 13,
	SDL_WINDOWEVENT_CLOSE = 14,
}

public enum SDL_GLattr
{
	SDL_GL_RED_SIZE = 0,
	SDL_GL_GREEN_SIZE = 1,
	SDL_GL_BLUE_SIZE = 2,
	SDL_GL_ALPHA_SIZE = 3,
	SDL_GL_BUFFER_SIZE = 4,
	SDL_GL_DOUBLEBUFFER = 5,
	SDL_GL_DEPTH_SIZE = 6,
	SDL_GL_STENCIL_SIZE = 7,
	SDL_GL_ACCUM_RED_SIZE = 8,
	SDL_GL_ACCUM_GREEN_SIZE = 9,
	SDL_GL_ACCUM_BLUE_SIZE = 10,
	SDL_GL_ACCUM_ALPHA_SIZE = 11,
	SDL_GL_STEREO = 12,
	SDL_GL_MULTISAMPLEBUFFERS = 13,
	SDL_GL_MULTISAMPLESAMPLES = 14,
	SDL_GL_ACCELERATED_VISUAL = 15,
	SDL_GL_RETAINED_BACKING = 16,
	SDL_GL_CONTEXT_MAJOR_VERSION = 17,
	SDL_GL_CONTEXT_MINOR_VERSION = 18,
	SDL_GL_CONTEXT_EGL = 19,
	SDL_GL_CONTEXT_FLAGS = 20,
	SDL_GL_CONTEXT_PROFILE_MASK = 21,
	SDL_GL_SHARE_WITH_CURRENT_CONTEXT = 22,
	SDL_GL_FRAMEBUFFER_SRGB_CAPABLE = 23,
}

public enum SDL_GLprofile
{
	SDL_GL_CONTEXT_PROFILE_CORE = 1,
	SDL_GL_CONTEXT_PROFILE_COMPATIBILITY = 2,
	SDL_GL_CONTEXT_PROFILE_ES = 4,
}

public enum SDL_GLcontextFlag
{
	SDL_GL_CONTEXT_DEBUG_FLAG = 1,
	SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG = 2,
	SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG = 4,
	SDL_GL_CONTEXT_RESET_ISOLATION_FLAG = 8,
}

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetNumVideoDrivers(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GetVideoDriver(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 index);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_VideoInit(
	[MarshalAs(UnmanagedType.LPStr)]
	string driver_name);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_VideoQuit(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GetCurrentVideoDriver(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetNumVideoDisplays(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GetDisplayName(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 displayIndex);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetDisplayBounds(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 displayIndex, 
	IntPtr/* SDL_Rect*  */ rect);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetNumDisplayModes(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 displayIndex);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetDisplayMode(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 displayIndex, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 modeIndex, 
	IntPtr/* SDL_DisplayMode*  */ mode);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetDesktopDisplayMode(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 displayIndex, 
	IntPtr/* SDL_DisplayMode*  */ mode);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetCurrentDisplayMode(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 displayIndex, 
	IntPtr/* SDL_DisplayMode*  */ mode);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_DisplayMode*  */ SDL_GetClosestDisplayMode(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 displayIndex, 
	IntPtr/* SDL_DisplayMode*  */ mode, 
	IntPtr/* SDL_DisplayMode*  */ closest);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetWindowDisplayIndex(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetWindowDisplayMode(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr/* SDL_DisplayMode*  */ mode);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetWindowDisplayMode(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr/* SDL_DisplayMode*  */ mode);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_GetWindowPixelFormat(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Window*  */ SDL_CreateWindow(
	[MarshalAs(UnmanagedType.LPStr)]
	string title, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 y, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 w, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 h, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Window*  */ SDL_CreateWindowFrom(
	IntPtr/* void*  */ data);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_GetWindowID(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Window*  */ SDL_GetWindowFromID(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 id);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_GetWindowFlags(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetWindowTitle(
	IntPtr/* SDL_Window*  */ window, 
	[MarshalAs(UnmanagedType.LPStr)]
	string title);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern string SDL_GetWindowTitle(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetWindowIcon(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr/* SDL_Surface*  */ icon);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_SetWindowData(
	IntPtr/* SDL_Window*  */ window, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	IntPtr/* void*  */ userdata);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_GetWindowData(
	IntPtr/* SDL_Window*  */ window, 
	[MarshalAs(UnmanagedType.LPStr)]
	string name);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetWindowPosition(
	IntPtr/* SDL_Window*  */ window, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 y);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GetWindowPosition(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr/* System.Int32*  */ x, 
	IntPtr/* System.Int32*  */ y);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetWindowSize(
	IntPtr/* SDL_Window*  */ window, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 w, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 h);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GetWindowSize(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr/* System.Int32*  */ w, 
	IntPtr/* System.Int32*  */ h);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetWindowMinimumSize(
	IntPtr/* SDL_Window*  */ window, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 min_w, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 min_h);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GetWindowMinimumSize(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr/* System.Int32*  */ w, 
	IntPtr/* System.Int32*  */ h);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetWindowMaximumSize(
	IntPtr/* SDL_Window*  */ window, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 max_w, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 max_h);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GetWindowMaximumSize(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr/* System.Int32*  */ w, 
	IntPtr/* System.Int32*  */ h);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetWindowBordered(
	IntPtr/* SDL_Window*  */ window, 
	SDL_bool bordered);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_ShowWindow(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_HideWindow(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_RaiseWindow(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_MaximizeWindow(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_MinimizeWindow(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_RestoreWindow(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetWindowFullscreen(
	IntPtr/* SDL_Window*  */ window, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 flags);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Surface*  */ SDL_GetWindowSurface(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_UpdateWindowSurface(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_UpdateWindowSurfaceRects(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr/* SDL_Rect*  */ rects, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 numrects);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_SetWindowGrab(
	IntPtr/* SDL_Window*  */ window, 
	SDL_bool grabbed);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_GetWindowGrab(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetWindowBrightness(
	IntPtr/* SDL_Window*  */ window, 
	[MarshalAs(UnmanagedType.R4)]
	float brightness);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern float SDL_GetWindowBrightness(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_SetWindowGammaRamp(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr/* System.UInt16*  */ red, 
	IntPtr/* System.UInt16*  */ green, 
	IntPtr/* System.UInt16*  */ blue);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetWindowGammaRamp(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr/* System.UInt16*  */ red, 
	IntPtr/* System.UInt16*  */ green, 
	IntPtr/* System.UInt16*  */ blue);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_DestroyWindow(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_IsScreenSaverEnabled(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_EnableScreenSaver(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_DisableScreenSaver(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GL_LoadLibrary(
	[MarshalAs(UnmanagedType.LPStr)]
	string path);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_GL_GetProcAddress(
	[MarshalAs(UnmanagedType.LPStr)]
	string proc);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GL_UnloadLibrary(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_GL_ExtensionSupported(
	[MarshalAs(UnmanagedType.LPStr)]
	string extension);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GL_ResetAttributes(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GL_SetAttribute(
	SDL_GLattr attr, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 value);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GL_GetAttribute(
	SDL_GLattr attr, 
	IntPtr/* System.Int32*  */ value);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr SDL_GL_CreateContext(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GL_MakeCurrent(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr context);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SDL_Window*  */ SDL_GL_GetCurrentWindow(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern IntPtr SDL_GL_GetCurrentContext(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GL_GetDrawableSize(
	IntPtr/* SDL_Window*  */ window, 
	IntPtr/* System.Int32*  */ w, 
	IntPtr/* System.Int32*  */ h);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GL_SetSwapInterval(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 interval);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GL_GetSwapInterval(
);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GL_SwapWindow(
	IntPtr/* SDL_Window*  */ window);

[DllImport(SDL_VIDEO), SuppressUnmanagedCodeSecurity]
public static extern void SDL_GL_DeleteContext(
	IntPtr context);

public struct SDL_DisplayMode{
	[MarshalAs(UnmanagedType.I4)]
	public System.UInt32 format;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 w;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 h;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 refresh_rate;

	public IntPtr/* void*  */ driverdata;

};

}
}

