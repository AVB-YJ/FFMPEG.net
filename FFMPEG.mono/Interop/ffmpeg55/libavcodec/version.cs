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
public const string VERSION = "avcodec-55.dll";


public static readonly uint LIBAVCODEC_VERSION_MAJOR = 55;
public static readonly uint LIBAVCODEC_VERSION_MINOR = 49;
public static readonly uint LIBAVCODEC_VERSION_MICRO = 101;
public static readonly uint LIBAVCODEC_VERSION_INT = AV_VERSION_INT(LIBAVCODEC_VERSION_MAJOR, \
                                               LIBAVCODEC_VERSION_MINOR, \
                                               LIBAVCODEC_VERSION_MICRO);
public static readonly uint LIBAVCODEC_VERSION = AV_VERSION(LIBAVCODEC_VERSION_MAJOR,    \
                                           LIBAVCODEC_VERSION_MINOR,    \
                                           LIBAVCODEC_VERSION_MICRO);
public static readonly uint LIBAVCODEC_BUILD = LIBAVCODEC_VERSION_INT;
public static readonly uint LIBAVCODEC_IDENT = "Lavc" AV_STRINGIFY(LIBAVCODEC_VERSION);
public static readonly uint FF_API_REQUEST_CHANNELS = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_OLD_DECODE_AUDIO = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_OLD_ENCODE_AUDIO = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_OLD_ENCODE_VIDEO = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_CODEC_ID = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_AUDIO_CONVERT = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_AVCODEC_RESAMPLE = FF_API_AUDIO_CONVERT;
public static readonly uint FF_API_DEINTERLACE = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_DESTRUCT_PACKET = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_GET_BUFFER = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_MISSING_SAMPLE = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_LOWRES = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_CAP_VDPAU = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_BUFS_VDPAU = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_VOXWARE = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_SET_DIMENSIONS = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_DEBUG_MV = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_AC_VLC = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_OLD_MSMPEG4 = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_ASPECT_EXTENDED = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_THREAD_OPAQUE = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_CODEC_PKT = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_ARCH_ALPHA = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_ERROR_RATE = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_QSCALE_TYPE = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_MB_TYPE = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_MAX_BFRAMES = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_FAST_MALLOC = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_NEG_LINESIZES = (LIBAVCODEC_VERSION_MAJOR < 56);
public static readonly uint FF_API_EMU_EDGE = (LIBAVCODEC_VERSION_MAJOR < 56);
}
}

