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
    public partial class AV 
{
		#if WIN32
public const string AVCONFIG = "avutil-52.dll";
		#else
		public const string AVCONFIG = "avutil";
		#endif

public static readonly uint AV_HAVE_BIGENDIAN = 0;
public static readonly uint AV_HAVE_FAST_UNALIGNED = 1;
public static readonly uint AV_HAVE_INCOMPATIBLE_LIBAV_ABI = 0;
public static readonly uint AV_HAVE_INCOMPATIBLE_FORK_ABI = 0;
}
}

