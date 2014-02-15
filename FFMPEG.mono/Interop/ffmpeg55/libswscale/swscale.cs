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
		#if WIN32
public const string SWSCALE = "swscale-2.dll";
		#else
		public const string SWSCALE = "swscale";
		#endif

public static readonly int SWS_FAST_BILINEAR = 1;
public static readonly int SWS_BILINEAR = 2;
public static readonly int SWS_BICUBIC = 4;
public static readonly int SWS_X = 8;
public static readonly int SWS_POINT = 0x10;
public static readonly int SWS_AREA = 0x20;
public static readonly int SWS_BICUBLIN = 0x40;
public static readonly int SWS_GAUSS = 0x80;
public static readonly int SWS_SINC = 0x100;
public static readonly int SWS_LANCZOS = 0x200;
public static readonly int SWS_SPLINE = 0x400;
public static readonly int SWS_SRC_V_CHR_DROP_MASK = 0x30000;
public static readonly int SWS_SRC_V_CHR_DROP_SHIFT = 16;
public static readonly int SWS_PARAM_DEFAULT = 123456;
public static readonly int SWS_PRINT_INFO = 0x1000;
public static readonly int SWS_FULL_CHR_H_INT = 0x2000;
public static readonly int SWS_FULL_CHR_H_INP = 0x4000;
public static readonly int SWS_DIRECT_BGR = 0x8000;
public static readonly int SWS_ACCURATE_RND = 0x40000;
public static readonly int SWS_BITEXACT = 0x80000;
public static readonly int SWS_ERROR_DIFFUSION = 0x800000;
public static readonly uint SWS_CPU_CAPS_MMX = 0x80000000;
public static readonly int SWS_CPU_CAPS_MMXEXT = 0x20000000;
public static readonly int SWS_CPU_CAPS_MMX2 = 0x20000000;
public static readonly int SWS_CPU_CAPS_3DNOW = 0x40000000;
public static readonly int SWS_CPU_CAPS_ALTIVEC = 0x10000000;
public static readonly int SWS_CPU_CAPS_BFIN = 0x01000000;
public static readonly int SWS_CPU_CAPS_SSE2 = 0x02000000;
public static readonly double SWS_MAX_REDUCE_CUTOFF = 0.002;
public static readonly int SWS_CS_ITU709 = 1;
public static readonly int SWS_CS_FCC = 4;
public static readonly int SWS_CS_ITU601 = 5;
public static readonly int SWS_CS_ITU624 = 5;
public static readonly int SWS_CS_SMPTE170M = 5;
public static readonly int SWS_CS_SMPTE240M = 7;
public static readonly int SWS_CS_DEFAULT = 5;
[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 swscale_version(
);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern string swscale_configuration(
);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern string swscale_license(
);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* System.Int32*  */ sws_getCoefficients(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 colorspace);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 sws_isSupportedInput(
	AVPixelFormat pix_fmt);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 sws_isSupportedOutput(
	AVPixelFormat pix_fmt);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 sws_isSupportedEndiannessConversion(
	AVPixelFormat pix_fmt);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SwsContext*  */ sws_alloc_context(
);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 sws_init_context(
	IntPtr/* SwsContext*  */ sws_context, 
	IntPtr/* SwsFilter*  */ srcFilter, 
	IntPtr/* SwsFilter*  */ dstFilter);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_freeContext(
	IntPtr/* SwsContext*  */ swsContext);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SwsContext*  */ sws_getContext(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 srcW, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 srcH, 
	AVPixelFormat srcFormat, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 dstW, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 dstH, 
	AVPixelFormat dstFormat, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags, 
	IntPtr/* SwsFilter*  */ srcFilter, 
	IntPtr/* SwsFilter*  */ dstFilter, 
	IntPtr/* System.Double*  */ param);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 sws_scale(
    IntPtr context, IntPtr[] src, int[] srcStride, int srcSliceY,
              int srcSliceH, IntPtr[] dst, int[] dstStride);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 sws_setColorspaceDetails(
	IntPtr/* SwsContext*  */ c, 
	IntPtr inv_table, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 srcRange, 
	IntPtr table, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 dstRange, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 brightness, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 contrast, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 saturation);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 sws_getColorspaceDetails(
	IntPtr/* SwsContext*  */ c, 
	IntPtr/* IntPtr*  */ inv_table, 
	IntPtr/* System.Int32*  */ srcRange, 
	IntPtr/* IntPtr*  */ table, 
	IntPtr/* System.Int32*  */ dstRange, 
	IntPtr/* System.Int32*  */ brightness, 
	IntPtr/* System.Int32*  */ contrast, 
	IntPtr/* System.Int32*  */ saturation);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SwsVector*  */ sws_allocVec(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 length);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SwsVector*  */ sws_getGaussianVec(
	[MarshalAs(UnmanagedType.R8)]
	System.Double variance, 
	[MarshalAs(UnmanagedType.R8)]
	System.Double quality);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SwsVector*  */ sws_getConstVec(
	[MarshalAs(UnmanagedType.R8)]
	System.Double c, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 length);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SwsVector*  */ sws_getIdentityVec(
);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_scaleVec(
	IntPtr/* SwsVector*  */ a, 
	[MarshalAs(UnmanagedType.R8)]
	System.Double scalar);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_normalizeVec(
	IntPtr/* SwsVector*  */ a, 
	[MarshalAs(UnmanagedType.R8)]
	System.Double height);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_convVec(
	IntPtr/* SwsVector*  */ a, 
	IntPtr/* SwsVector*  */ b);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_addVec(
	IntPtr/* SwsVector*  */ a, 
	IntPtr/* SwsVector*  */ b);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_subVec(
	IntPtr/* SwsVector*  */ a, 
	IntPtr/* SwsVector*  */ b);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_shiftVec(
	IntPtr/* SwsVector*  */ a, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 shift);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SwsVector*  */ sws_cloneVec(
	IntPtr/* SwsVector*  */ a);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_printVec2(
	IntPtr/* SwsVector*  */ a, 
	IntPtr/* AVClass*  */ log_ctx, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 log_level);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_freeVec(
	IntPtr/* SwsVector*  */ a);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SwsFilter*  */ sws_getDefaultFilter(
	[MarshalAs(UnmanagedType.R4)]
	float lumaGBlur, 
	[MarshalAs(UnmanagedType.R4)]
	float chromaGBlur, 
	[MarshalAs(UnmanagedType.R4)]
	float lumaSharpen, 
	[MarshalAs(UnmanagedType.R4)]
	float chromaSharpen, 
	[MarshalAs(UnmanagedType.R4)]
	float chromaHShift, 
	[MarshalAs(UnmanagedType.R4)]
	float chromaVShift, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 verbose);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_freeFilter(
	IntPtr/* SwsFilter*  */ filter);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* SwsContext*  */ sws_getCachedContext(
	IntPtr/* SwsContext*  */ context, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 srcW, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 srcH, 
	AVPixelFormat srcFormat, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 dstW, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 dstH, 
	AVPixelFormat dstFormat, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 flags, 
	IntPtr/* SwsFilter*  */ srcFilter, 
	IntPtr/* SwsFilter*  */ dstFilter, 
	IntPtr/* System.Double*  */ param);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_convertPalette8ToPacked32(
	IntPtr/* System.Byte*  */ src, 
	IntPtr/* System.Byte*  */ dst, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 num_pixels, 
	IntPtr/* System.Byte*  */ palette);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern void sws_convertPalette8ToPacked24(
	IntPtr/* System.Byte*  */ src, 
	IntPtr/* System.Byte*  */ dst, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 num_pixels, 
	IntPtr/* System.Byte*  */ palette);

[DllImport(SWSCALE), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* AVClass*  */ sws_get_class(
);

public struct SwsVector{
	public IntPtr/* System.Double*  */ coeff;

	[MarshalAs(UnmanagedType.I4)]
	public System.Int32 length;

};

public struct SwsFilter{
	public IntPtr/* SwsVector*  */ lumH;

	public IntPtr/* SwsVector*  */ lumV;

	public IntPtr/* SwsVector*  */ chrH;

	public IntPtr/* SwsVector*  */ chrV;

};

}
}

