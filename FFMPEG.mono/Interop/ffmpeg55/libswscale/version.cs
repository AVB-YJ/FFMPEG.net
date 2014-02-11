/*
 * copyright (c) 20013 Crazyender
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
namespace SharpFFmpeg
{
    public partial class NativeMethods55 
{
public const string VERSION = "swscale-2.dll";


public static readonly uint LIBSWSCALE_VERSION_MAJOR = 2;
public static readonly uint LIBSWSCALE_VERSION_MINOR = 5;
public static readonly uint LIBSWSCALE_VERSION_MICRO = 101;
public static readonly uint LIBSWSCALE_VERSION_INT = AV_VERSION_INT(LIBSWSCALE_VERSION_MAJOR, \
                                               LIBSWSCALE_VERSION_MINOR, \
                                               LIBSWSCALE_VERSION_MICRO);
public static readonly uint LIBSWSCALE_VERSION = AV_VERSION(LIBSWSCALE_VERSION_MAJOR, \
                                           LIBSWSCALE_VERSION_MINOR, \
                                           LIBSWSCALE_VERSION_MICRO);
public static readonly uint LIBSWSCALE_BUILD = LIBSWSCALE_VERSION_INT;
public static readonly uint LIBSWSCALE_IDENT = "SwS" AV_STRINGIFY(LIBSWSCALE_VERSION);
public static readonly uint FF_API_SWS_GETCONTEXT = (LIBSWSCALE_VERSION_MAJOR < 3);
public static readonly uint FF_API_SWS_CPU_CAPS = (LIBSWSCALE_VERSION_MAJOR < 3);
public static readonly uint FF_API_SWS_FORMAT_NAME = (LIBSWSCALE_VERSION_MAJOR < 3);
}
}

