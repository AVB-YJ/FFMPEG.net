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
public const string ERROR = "avutil-52.dll";


public static readonly uint AVERROR_BSF_NOT_FOUND = FFERRTAG(0xF8,'B','S','F');
public static readonly uint AVERROR_BUG = FFERRTAG( 'B','U','G','!');
public static readonly uint AVERROR_BUFFER_TOO_SMALL = FFERRTAG( 'B','U','F','S');
public static readonly uint AVERROR_DECODER_NOT_FOUND = FFERRTAG(0xF8,'D','E','C');
public static readonly uint AVERROR_DEMUXER_NOT_FOUND = FFERRTAG(0xF8,'D','E','M');
public static readonly uint AVERROR_ENCODER_NOT_FOUND = FFERRTAG(0xF8,'E','N','C');
public static readonly uint AVERROR_EOF = FFERRTAG( 'E','O','F',' ');
public static readonly uint AVERROR_EXIT = FFERRTAG( 'E','X','I','T');
public static readonly uint AVERROR_EXTERNAL = FFERRTAG( 'E','X','T',' ');
public static readonly uint AVERROR_FILTER_NOT_FOUND = FFERRTAG(0xF8,'F','I','L');
public static readonly uint AVERROR_INVALIDDATA = FFERRTAG( 'I','N','D','A');
public static readonly uint AVERROR_MUXER_NOT_FOUND = FFERRTAG(0xF8,'M','U','X');
public static readonly uint AVERROR_OPTION_NOT_FOUND = FFERRTAG(0xF8,'O','P','T');
public static readonly uint AVERROR_PATCHWELCOME = FFERRTAG( 'P','A','W','E');
public static readonly uint AVERROR_PROTOCOL_NOT_FOUND = FFERRTAG(0xF8,'P','R','O');
public static readonly uint AVERROR_STREAM_NOT_FOUND = FFERRTAG(0xF8,'S','T','R');
public static readonly uint AVERROR_BUG2 = FFERRTAG( 'B','U','G',' ');
public static readonly uint AVERROR_UNKNOWN = FFERRTAG( 'U','N','K','N');
public static readonly uint AVERROR_EXPERIMENTAL = (-0x2bb2afa8);
public static readonly uint AV_ERROR_MAX_STRING_SIZE = 64;
[DllImport(ERROR), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_strerror(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 errnum, 
	[MarshalAs(UnmanagedType.LPStr)]
	string errbuf, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 errbuf_size);

[DllImport(ERROR), SuppressUnmanagedCodeSecurity]
public static extern string av_make_error_string(
	[MarshalAs(UnmanagedType.LPStr)]
	string errbuf, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 errbuf_size, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 errnum);

}
}

