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

namespace FFMPEG.mono
{
    public delegate void DestructCallback(ref AVPacket AvPacket);
	[StructLayout(LayoutKind.Sequential)]
	public struct AVPacket
	{

	    public Int64 dts;                  //int64_t dts; ///< decompression time stamp in time_base units
	    private IntPtr _data;       //uint8_t *data;
        public byte[] data
        {
            get
            {
                byte[] _data_ = new byte[size];
                Marshal.Copy(_data, _data_, 0, size);
                return _data_;
            }
        }
        public Int32 size;                 //int   size;
        public Int32 stream_index;         //int   stream_index;
        public Int32 flags;                //int   flags;
        public Int32 duration;             //int   duration; ///< presentation duration in time_base units (0 if not available)
        private IntPtr _destruct;   //void  (*destruct)(struct AVPacket *);
        public DestructCallback destruct
        {
            get
            {
                if (_destruct == IntPtr.Zero)
                    return null;
                return Marshal.GetDelegateForFunctionPointer(_destruct, typeof(DestructCallback)) as DestructCallback;
            }
        }
        public IntPtr priv;                //void  *priv;
        public Int64 pos;                  //int64_t pos;   
	}
	
	public class AVCodec
	{
	}
}

