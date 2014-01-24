/*
 * copyright (c) 20012 Crazyender
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
using System.Runtime.InteropServices;
using System.Security;

namespace SharpFFmpeg
{
    public partial class NativeMethods
    {
        public const string SWS = "swscale-0.dll";

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

        [DllImport(SWS), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr
            sws_getContext(int srcW, int srcH, int srcFormat,
                            int dstW, int dstH, int dstFormat,
                            int flags,
                            IntPtr srcFilter, IntPtr dstFilter, IntPtr rparam);

        [DllImport(SWS), SuppressUnmanagedCodeSecurity]
        public static extern int 
            sws_scale(IntPtr context, IntPtr[] src, int[] srcStride, int srcSliceY,
              int srcSliceH, IntPtr[] dst, int[] dstStride);
    }
}

