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
public const string CHANNEL_LAYOUT = "avutil-52.dll";


public static readonly uint AV_CH_FRONT_LEFT = 0x00000001;
public static readonly uint AV_CH_FRONT_RIGHT = 0x00000002;
public static readonly uint AV_CH_FRONT_CENTER = 0x00000004;
public static readonly uint AV_CH_LOW_FREQUENCY = 0x00000008;
public static readonly uint AV_CH_BACK_LEFT = 0x00000010;
public static readonly uint AV_CH_BACK_RIGHT = 0x00000020;
public static readonly uint AV_CH_FRONT_LEFT_OF_CENTER = 0x00000040;
public static readonly uint AV_CH_FRONT_RIGHT_OF_CENTER = 0x00000080;
public static readonly uint AV_CH_BACK_CENTER = 0x00000100;
public static readonly uint AV_CH_SIDE_LEFT = 0x00000200;
public static readonly uint AV_CH_SIDE_RIGHT = 0x00000400;
public static readonly uint AV_CH_TOP_CENTER = 0x00000800;
public static readonly uint AV_CH_TOP_FRONT_LEFT = 0x00001000;
public static readonly uint AV_CH_TOP_FRONT_CENTER = 0x00002000;
public static readonly uint AV_CH_TOP_FRONT_RIGHT = 0x00004000;
public static readonly uint AV_CH_TOP_BACK_LEFT = 0x00008000;
public static readonly uint AV_CH_TOP_BACK_CENTER = 0x00010000;
public static readonly uint AV_CH_TOP_BACK_RIGHT = 0x00020000;
public static readonly uint AV_CH_STEREO_LEFT = 0x20000000;
public static readonly uint AV_CH_STEREO_RIGHT = 0x40000000;
public static readonly ulong AV_CH_WIDE_LEFT = 0x0000000080000000UL;
public static readonly ulong AV_CH_WIDE_RIGHT = 0x0000000100000000UL;
public static readonly ulong AV_CH_SURROUND_DIRECT_LEFT = 0x0000000200000000UL;
public static readonly ulong AV_CH_SURROUND_DIRECT_RIGHT = 0x0000000400000000UL;
public static readonly ulong AV_CH_LOW_FREQUENCY_2 = 0x0000000800000000UL;
public static readonly ulong AV_CH_LAYOUT_NATIVE = 0x8000000000000000UL;
public static readonly uint AV_CH_LAYOUT_MONO = (AV_CH_FRONT_CENTER);
public static readonly uint AV_CH_LAYOUT_STEREO = (AV_CH_FRONT_LEFT|AV_CH_FRONT_RIGHT);
public static readonly uint AV_CH_LAYOUT_2POINT1 = (AV_CH_LAYOUT_STEREO|AV_CH_LOW_FREQUENCY);
public static readonly uint AV_CH_LAYOUT_2_1 = (AV_CH_LAYOUT_STEREO|AV_CH_BACK_CENTER);
public static readonly uint AV_CH_LAYOUT_SURROUND = (AV_CH_LAYOUT_STEREO|AV_CH_FRONT_CENTER);
public static readonly uint AV_CH_LAYOUT_3POINT1 = (AV_CH_LAYOUT_SURROUND|AV_CH_LOW_FREQUENCY);
public static readonly uint AV_CH_LAYOUT_4POINT0 = (AV_CH_LAYOUT_SURROUND|AV_CH_BACK_CENTER);
public static readonly uint AV_CH_LAYOUT_4POINT1 = (AV_CH_LAYOUT_4POINT0|AV_CH_LOW_FREQUENCY);
public static readonly uint AV_CH_LAYOUT_2_2 = (AV_CH_LAYOUT_STEREO|AV_CH_SIDE_LEFT|AV_CH_SIDE_RIGHT);
public static readonly uint AV_CH_LAYOUT_QUAD = (AV_CH_LAYOUT_STEREO|AV_CH_BACK_LEFT|AV_CH_BACK_RIGHT);
public static readonly uint AV_CH_LAYOUT_5POINT0 = (AV_CH_LAYOUT_SURROUND|AV_CH_SIDE_LEFT|AV_CH_SIDE_RIGHT);
public static readonly uint AV_CH_LAYOUT_5POINT1 = (AV_CH_LAYOUT_5POINT0|AV_CH_LOW_FREQUENCY);
public static readonly uint AV_CH_LAYOUT_5POINT0_BACK = (AV_CH_LAYOUT_SURROUND|AV_CH_BACK_LEFT|AV_CH_BACK_RIGHT);
public static readonly uint AV_CH_LAYOUT_5POINT1_BACK = (AV_CH_LAYOUT_5POINT0_BACK|AV_CH_LOW_FREQUENCY);
public static readonly uint AV_CH_LAYOUT_6POINT0 = (AV_CH_LAYOUT_5POINT0|AV_CH_BACK_CENTER);
public static readonly uint AV_CH_LAYOUT_6POINT0_FRONT = (AV_CH_LAYOUT_2_2|AV_CH_FRONT_LEFT_OF_CENTER|AV_CH_FRONT_RIGHT_OF_CENTER);
public static readonly uint AV_CH_LAYOUT_HEXAGONAL = (AV_CH_LAYOUT_5POINT0_BACK|AV_CH_BACK_CENTER);
public static readonly uint AV_CH_LAYOUT_6POINT1 = (AV_CH_LAYOUT_5POINT1|AV_CH_BACK_CENTER);
public static readonly uint AV_CH_LAYOUT_6POINT1_BACK = (AV_CH_LAYOUT_5POINT1_BACK|AV_CH_BACK_CENTER);
public static readonly uint AV_CH_LAYOUT_6POINT1_FRONT = (AV_CH_LAYOUT_6POINT0_FRONT|AV_CH_LOW_FREQUENCY);
public static readonly uint AV_CH_LAYOUT_7POINT0 = (AV_CH_LAYOUT_5POINT0|AV_CH_BACK_LEFT|AV_CH_BACK_RIGHT);
public static readonly uint AV_CH_LAYOUT_7POINT0_FRONT = (AV_CH_LAYOUT_5POINT0|AV_CH_FRONT_LEFT_OF_CENTER|AV_CH_FRONT_RIGHT_OF_CENTER);
public static readonly uint AV_CH_LAYOUT_7POINT1 = (AV_CH_LAYOUT_5POINT1|AV_CH_BACK_LEFT|AV_CH_BACK_RIGHT);
public static readonly uint AV_CH_LAYOUT_7POINT1_WIDE = (AV_CH_LAYOUT_5POINT1|AV_CH_FRONT_LEFT_OF_CENTER|AV_CH_FRONT_RIGHT_OF_CENTER);
public static readonly uint AV_CH_LAYOUT_7POINT1_WIDE_BACK = (AV_CH_LAYOUT_5POINT1_BACK|AV_CH_FRONT_LEFT_OF_CENTER|AV_CH_FRONT_RIGHT_OF_CENTER);
public static readonly uint AV_CH_LAYOUT_OCTAGONAL = (AV_CH_LAYOUT_5POINT0|AV_CH_BACK_LEFT|AV_CH_BACK_CENTER|AV_CH_BACK_RIGHT);
public static readonly uint AV_CH_LAYOUT_STEREO_DOWNMIX = (AV_CH_STEREO_LEFT|AV_CH_STEREO_RIGHT);
public enum AVMatrixEncoding
{
	AV_MATRIX_ENCODING_NONE = 0,
	AV_MATRIX_ENCODING_DOLBY = 1,
	AV_MATRIX_ENCODING_DPLII = 2,
	AV_MATRIX_ENCODING_DPLIIX = 3,
	AV_MATRIX_ENCODING_DPLIIZ = 4,
	AV_MATRIX_ENCODING_DOLBYEX = 5,
	AV_MATRIX_ENCODING_DOLBYHEADPHONE = 6,
	AV_MATRIX_ENCODING_NB = 7,
}

[DllImport(CHANNEL_LAYOUT), SuppressUnmanagedCodeSecurity]
public static extern System.UInt64 av_get_channel_layout(
	[MarshalAs(UnmanagedType.LPStr)]
	string name);

[DllImport(CHANNEL_LAYOUT), SuppressUnmanagedCodeSecurity]
public static extern void av_get_channel_layout_string(
	[MarshalAs(UnmanagedType.LPStr)]
	string buf, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 buf_size, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_channels, 
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 channel_layout);

[DllImport(CHANNEL_LAYOUT), SuppressUnmanagedCodeSecurity]
public static extern void av_bprint_channel_layout(
	IntPtr/* AVBPrint*  */ bp, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_channels, 
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 channel_layout);

[DllImport(CHANNEL_LAYOUT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_get_channel_layout_nb_channels(
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 channel_layout);

[DllImport(CHANNEL_LAYOUT), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_get_default_channel_layout(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 nb_channels);

[DllImport(CHANNEL_LAYOUT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_get_channel_layout_channel_index(
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 channel_layout, 
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 channel);

[DllImport(CHANNEL_LAYOUT), SuppressUnmanagedCodeSecurity]
public static extern System.UInt64 av_channel_layout_extract_channel(
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 channel_layout, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 index);

[DllImport(CHANNEL_LAYOUT), SuppressUnmanagedCodeSecurity]
public static extern string av_get_channel_name(
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 channel);

[DllImport(CHANNEL_LAYOUT), SuppressUnmanagedCodeSecurity]
public static extern string av_get_channel_description(
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 channel);

[DllImport(CHANNEL_LAYOUT), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_get_standard_channel_layout(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 index, 
	IntPtr/* System.UInt64*  */ layout, 
	IntPtr/* string*  */ name);

}
}

