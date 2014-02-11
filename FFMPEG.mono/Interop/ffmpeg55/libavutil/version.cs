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
public const string VERSION = "avutil-52.dll";


public static readonly uint LIBAVUTIL_VERSION_MAJOR = 52;
public static readonly uint LIBAVUTIL_VERSION_MINOR = 63;
public static readonly uint LIBAVUTIL_VERSION_MICRO = 100;
public static readonly uint LIBAVUTIL_VERSION_INT = AV_VERSION_INT(LIBAVUTIL_VERSION_MAJOR, \
                                               LIBAVUTIL_VERSION_MINOR, \
                                               LIBAVUTIL_VERSION_MICRO);
public static readonly uint LIBAVUTIL_VERSION = AV_VERSION(LIBAVUTIL_VERSION_MAJOR,     \
                                           LIBAVUTIL_VERSION_MINOR,     \
                                           LIBAVUTIL_VERSION_MICRO);
public static readonly uint LIBAVUTIL_BUILD = LIBAVUTIL_VERSION_INT;
public static readonly uint LIBAVUTIL_IDENT = "Lavu" AV_STRINGIFY(LIBAVUTIL_VERSION);
public static readonly uint FF_API_GET_BITS_PER_SAMPLE_FMT = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_FIND_OPT = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_OLD_AVOPTIONS = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_PIX_FMT = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_CONTEXT_SIZE = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_PIX_FMT_DESC = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_AV_REVERSE = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_AUDIOCONVERT = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_CPU_FLAG_MMX2 = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_SAMPLES_UTILS_RETURN_ZERO = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_LLS_PRIVATE = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_LLS1 = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_AVFRAME_LAVC = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_VDPAU = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_GET_CHANNEL_LAYOUT_COMPAT = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_OLD_OPENCL = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_XVMC = (LIBAVUTIL_VERSION_MAJOR < 54);
public static readonly uint FF_API_INTFLOAT = (LIBAVUTIL_VERSION_MAJOR < 54);
}
}

