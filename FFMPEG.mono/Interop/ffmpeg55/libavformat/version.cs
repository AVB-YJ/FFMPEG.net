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
public const string VERSION = "avformat-55.dll";


public static readonly uint LIBAVFORMAT_VERSION_MAJOR = 55;
public static readonly uint LIBAVFORMAT_VERSION_MINOR = 30;
public static readonly uint LIBAVFORMAT_VERSION_MICRO = 100;
public static readonly uint LIBAVFORMAT_VERSION_INT = AV_VERSION_INT(LIBAVFORMAT_VERSION_MAJOR, \
                                               LIBAVFORMAT_VERSION_MINOR, \
                                               LIBAVFORMAT_VERSION_MICRO);
public static readonly uint LIBAVFORMAT_VERSION = AV_VERSION(LIBAVFORMAT_VERSION_MAJOR,   \
                                           LIBAVFORMAT_VERSION_MINOR,   \
                                           LIBAVFORMAT_VERSION_MICRO);
public static readonly uint LIBAVFORMAT_BUILD = LIBAVFORMAT_VERSION_INT;
public static readonly uint LIBAVFORMAT_IDENT = "Lavf" AV_STRINGIFY(LIBAVFORMAT_VERSION);
public static readonly uint FF_API_REFERENCE_DTS = (LIBAVFORMAT_VERSION_MAJOR < 56);
public static readonly uint FF_API_ALLOC_OUTPUT_CONTEXT = (LIBAVFORMAT_VERSION_MAJOR < 56);
public static readonly uint FF_API_FORMAT_PARAMETERS = (LIBAVFORMAT_VERSION_MAJOR < 56);
public static readonly uint FF_API_NEW_STREAM = (LIBAVFORMAT_VERSION_MAJOR < 56);
public static readonly uint FF_API_SET_PTS_INFO = (LIBAVFORMAT_VERSION_MAJOR < 56);
public static readonly uint FF_API_CLOSE_INPUT_FILE = (LIBAVFORMAT_VERSION_MAJOR < 56);
public static readonly uint FF_API_READ_PACKET = (LIBAVFORMAT_VERSION_MAJOR < 56);
public static readonly uint FF_API_ASS_SSA = (LIBAVFORMAT_VERSION_MAJOR < 56);
public static readonly uint FF_API_R_FRAME_RATE = 1;
}
}

