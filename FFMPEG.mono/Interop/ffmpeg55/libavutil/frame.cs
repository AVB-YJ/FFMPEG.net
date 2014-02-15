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

		#if WIN32
		public const string FRAME = "avutil-52.dll";
		#else
		public const string FRAME = "avutil";
		#endif

public static readonly uint AVCOL_SPC_YCGCO = (uint)AVColorSpace.AVCOL_SPC_YCOCG;
public static readonly uint AV_NUM_DATA_POINTERS = 8;
public static readonly uint AV_FRAME_FLAG_CORRUPT = (1 << 0);
public static readonly uint FF_DECODE_ERROR_INVALID_BITSTREAM = 1;
public static readonly uint FF_DECODE_ERROR_MISSING_REFERENCE = 2;
public enum AVColorSpace
{
	AVCOL_SPC_RGB = 0,
	AVCOL_SPC_BT709 = 1,
	AVCOL_SPC_UNSPECIFIED = 2,
	AVCOL_SPC_FCC = 4,
	AVCOL_SPC_BT470BG = 5,
	AVCOL_SPC_SMPTE170M = 6,
	AVCOL_SPC_SMPTE240M = 7,
	AVCOL_SPC_YCOCG = 8,
	AVCOL_SPC_BT2020_NCL = 9,
	AVCOL_SPC_BT2020_CL = 10,
	AVCOL_SPC_NB = 11,
}

public enum AVColorRange
{
	AVCOL_RANGE_UNSPECIFIED = 0,
	AVCOL_RANGE_MPEG = 1,
	AVCOL_RANGE_JPEG = 2,
	AVCOL_RANGE_NB = 3,
}

public enum AVFrameSideDataType
{
	AV_FRAME_DATA_PANSCAN = 0,
	AV_FRAME_DATA_A53_CC = 1,
	AV_FRAME_DATA_STEREO3D = 2,
	AV_FRAME_DATA_MATRIXENCODING = 3,
}

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_frame_get_best_effort_timestamp(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_set_best_effort_timestamp(
	IntPtr/* AVFrame*  */ frame, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_frame_get_pkt_duration(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_set_pkt_duration(
	IntPtr/* AVFrame*  */ frame, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_frame_get_pkt_pos(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_set_pkt_pos(
	IntPtr/* AVFrame*  */ frame, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 av_frame_get_channel_layout(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_set_channel_layout(
	IntPtr/* AVFrame*  */ frame, 
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_frame_get_channels(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_set_channels(
	IntPtr/* AVFrame*  */ frame, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_frame_get_sample_rate(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_set_sample_rate(
	IntPtr/* AVFrame*  */ frame, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVDictionary*  */ av_frame_get_metadata(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_set_metadata(
	IntPtr/* AVFrame*  */ frame, 
	IntPtr/* AVDictionary*  */ val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_frame_get_decode_error_flags(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_set_decode_error_flags(
	IntPtr/* AVFrame*  */ frame, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_frame_get_pkt_size(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_set_pkt_size(
	IntPtr/* AVFrame*  */ frame, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* IntPtr*  */ avpriv_frame_get_metadatap(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* System.Char*  */ av_frame_get_qp_table(
	IntPtr/* AVFrame*  */ f, 
	IntPtr/* System.Int32*  */ stride, 
	IntPtr/* System.Int32*  */ type);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_frame_set_qp_table(
	IntPtr/* AVFrame*  */ f, 
	IntPtr/* AVBufferRef*  */ buf, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 stride, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 type);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern AVColorSpace av_frame_get_colorspace(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_set_colorspace(
	IntPtr/* AVFrame*  */ frame, 
	AVColorSpace val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern AVColorRange av_frame_get_color_range(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_set_color_range(
	IntPtr/* AVFrame*  */ frame, 
	AVColorRange val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern string av_get_colorspace_name(
	AVColorSpace val);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVFrame*  */ av_frame_alloc(
);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_free(
	IntPtr/* IntPtr*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_frame_ref(
	IntPtr/* AVFrame*  */ dst, 
	IntPtr/* AVFrame*  */ src);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVFrame*  */ av_frame_clone(
	IntPtr/* AVFrame*  */ src);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_unref(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern void av_frame_move_ref(
	IntPtr/* AVFrame*  */ dst, 
	IntPtr/* AVFrame*  */ src);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_frame_get_buffer(
	IntPtr/* AVFrame*  */ frame, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 align);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_frame_is_writable(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_frame_make_writable(
	IntPtr/* AVFrame*  */ frame);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 av_frame_copy_props(
	IntPtr/* AVFrame*  */ dst, 
	IntPtr/* AVFrame*  */ src);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVBufferRef*  */ av_frame_get_plane_buffer(
	IntPtr/* AVFrame*  */ frame, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 plane);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVFrameSideData*  */ av_frame_new_side_data(
	IntPtr/* AVFrame*  */ frame, 
	AVFrameSideDataType type, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

[DllImport(FRAME), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVFrameSideData*  */ av_frame_get_side_data(
	IntPtr/* AVFrame*  */ frame, 
	AVFrameSideDataType type);

public struct AVFrameSideData{
	public AVFrameSideDataType type;

	public IntPtr/* System.Byte*  */ data;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 size;

	public IntPtr/* AVDictionary*  */ metadata;

};

public struct AVFrame{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
	public IntPtr[] data;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
	public Int32[] linesize;

	public IntPtr/* IntPtr*  */ extended_data;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 width;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 height;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 nb_samples;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 format;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 key_frame;

	public AVPictureType pict_type;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
	public IntPtr[] _base;

	public AVRational sample_aspect_ratio;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 pts;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 pkt_pts;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 pkt_dts;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 coded_picture_number;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 display_picture_number;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 quality;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 reference;

	public IntPtr/* System.Char*  */ qscale_table;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 qstride;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 qscale_type;

	public IntPtr/* System.Byte*  */ mbskip_table;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
	public IntPtr[] motion_val;

	public IntPtr/* System.UInt32*  */ mb_type;

	public IntPtr/* System.Int16*  */ dct_coeff;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
	public IntPtr[] ref_index;

	public IntPtr/* void*  */ opaque;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
	public UInt64[] error;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 type;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 repeat_pict;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 interlaced_frame;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 top_field_first;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 palette_has_changed;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 buffer_hints;

	public IntPtr/* AVPanScan*  */ pan_scan;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 reordered_opaque;

	public IntPtr/* void*  */ hwaccel_picture_private;

	public IntPtr/* AVCodecContext*  */ owner;

	public IntPtr/* void*  */ thread_opaque;

	[MarshalAs(UnmanagedType.I1)]
	public System.Byte motion_subsample_log2;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 sample_rate;

	[MarshalAs(UnmanagedType.I8)]
	public System.UInt64 channel_layout;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
	public IntPtr[] buf;

	public IntPtr/* IntPtr*  */ extended_buf;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 nb_extended_buf;

	public IntPtr/* IntPtr*  */ side_data;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 nb_side_data;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 flags;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 best_effort_timestamp;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 pkt_pos;

	[MarshalAs(UnmanagedType.I8)]
	public System.Int64 pkt_duration;

	public IntPtr/* AVDictionary*  */ metadata;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 decode_error_flags;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 channels;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 pkt_size;

	public AVColorSpace colorspace;

	public AVColorRange color_range;

	public IntPtr/* AVBufferRef*  */ qp_table_buf;

};

}
}

