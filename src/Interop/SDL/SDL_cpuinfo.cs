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
public const string SDL_CPUINFO = "SDL2.dll";


public static readonly uint SDL_CACHELINE_SIZE = 128;
[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetCPUCount(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetCPUCacheLineSize(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasRDTSC(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasAltiVec(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasMMX(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_Has3DNow(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasSSE(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasSSE2(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasSSE3(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasSSE41(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasSSE42(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern SDL_bool SDL_HasAVX(
);

[DllImport(SDL_CPUINFO), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_GetSystemRAM(
);

}
}

