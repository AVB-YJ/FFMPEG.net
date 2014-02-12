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
namespace SharpFFmpeg
{
    public partial class NativeMethods55 
{
public const string VERSION = "swresample-0.dll";


public static readonly uint LIBSWRESAMPLE_VERSION_MAJOR = 0;
public static readonly uint LIBSWRESAMPLE_VERSION_MINOR = 17;
public static readonly uint LIBSWRESAMPLE_VERSION_MICRO = 104;
public static readonly uint LIBSWRESAMPLE_VERSION_INT = AV_VERSION_INT(LIBSWRESAMPLE_VERSION_MAJOR, \
                                                  LIBSWRESAMPLE_VERSION_MINOR, \
                                                  LIBSWRESAMPLE_VERSION_MICRO);
public static readonly uint LIBSWRESAMPLE_VERSION = AV_VERSION(LIBSWRESAMPLE_VERSION_MAJOR, \
                                              LIBSWRESAMPLE_VERSION_MINOR, \
                                              LIBSWRESAMPLE_VERSION_MICRO);
public static readonly uint LIBSWRESAMPLE_BUILD = LIBSWRESAMPLE_VERSION_INT;
public static readonly uint LIBSWRESAMPLE_IDENT = "SwR" AV_STRINGIFY(LIBSWRESAMPLE_VERSION);
}
}

