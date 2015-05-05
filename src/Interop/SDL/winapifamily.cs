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
public const string WINAPIFAMILY = "SDL2.dll";


public static readonly uint WINAPI_FAMILY_PC_APP = 2;
public static readonly uint WINAPI_FAMILY_PHONE_APP = 3;
public static readonly uint WINAPI_FAMILY_DESKTOP_APP = 100;
public static readonly uint WINAPI_FAMILY_APP = WINAPI_FAMILY_PC_APP;
public static readonly uint WINAPI_FAMILY = WINAPI_FAMILY_DESKTOP_APP;
public static readonly bool WINAPI_PARTITION_DESKTOP = (WINAPI_FAMILY == WINAPI_FAMILY_DESKTOP_APP);
public static readonly uint WINAPI_PARTITION_APP = 1;
public static readonly bool WINAPI_PARTITION_PC_APP = (WINAPI_FAMILY == WINAPI_FAMILY_DESKTOP_APP || WINAPI_FAMILY == WINAPI_FAMILY_PC_APP);
public static readonly bool WINAPI_PARTITION_PHONE_APP = (WINAPI_FAMILY == WINAPI_FAMILY_PHONE_APP);
public static readonly bool WINAPI_PARTITION_PHONE = WINAPI_PARTITION_PHONE_APP;
}
}

