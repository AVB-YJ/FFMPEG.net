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
        public const string AVIO = "avformat-55.dll";


        public static readonly uint AVIO_SEEKABLE_NORMAL = 0x0001;
        public static readonly uint AVSEEK_SIZE = 0x10000;
        public static readonly uint AVSEEK_FORCE = 0x20000;
        public static readonly uint AVIO_FLAG_READ = 1;
        public static readonly uint AVIO_FLAG_WRITE = 2;
        public static readonly uint AVIO_FLAG_READ_WRITE = (AVIO_FLAG_READ | AVIO_FLAG_WRITE);
        public static readonly uint AVIO_FLAG_NONBLOCK = 8;
        public static readonly uint AVIO_FLAG_DIRECT = 0x8000;
        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_check(
            [MarshalAs(UnmanagedType.LPStr)]
	string url,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr/* AVIOContext*  */ avio_alloc_context(
            [MarshalAs(UnmanagedType.LPStr)]
	string buffer,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 buffer_size,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 write_flag,
            IntPtr/* void*  */ opaque,
            [MarshalAs(UnmanagedType.FunctionPtr)]
	avio_func_0 read_packet,
            [MarshalAs(UnmanagedType.FunctionPtr)]
	avio_func_0 write_packet,
            [MarshalAs(UnmanagedType.FunctionPtr)]
	avio_func_1 seek);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern void avio_w8(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 b);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern void avio_write(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.LPStr)]
	string buf,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern void avio_wl64(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.I8)]
	System.UInt64 val);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern void avio_wb64(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.I8)]
	System.UInt64 val);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern void avio_wl32(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 val);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern void avio_wb32(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 val);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern void avio_wl24(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 val);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern void avio_wb24(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 val);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern void avio_wl16(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 val);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern void avio_wb16(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 val);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_put_str(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.LPStr)]
	string str);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_put_str16le(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.LPStr)]
	string str);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int64 avio_seek(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.I8)]
	System.Int64 offset,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 whence);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int64 avio_skip(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.I8)]
	System.Int64 offset);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int64 avio_tell(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int64 avio_size(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 url_feof(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_printf(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.LPStr)]
	string fmt);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern void avio_flush(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_read(
            IntPtr/* AVIOContext*  */ s,
            [MarshalAs(UnmanagedType.LPStr)]
	string buf,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 size);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_r8(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.UInt32 avio_rl16(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.UInt32 avio_rl24(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.UInt32 avio_rl32(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.UInt64 avio_rl64(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.UInt32 avio_rb16(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.UInt32 avio_rb24(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.UInt32 avio_rb32(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.UInt64 avio_rb64(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_get_str(
            IntPtr/* AVIOContext*  */ pb,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 maxlen,
            [MarshalAs(UnmanagedType.LPStr)]
	string buf,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 buflen);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_get_str16le(
            IntPtr/* AVIOContext*  */ pb,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 maxlen,
            [MarshalAs(UnmanagedType.LPStr)]
	string buf,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 buflen);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_get_str16be(
            IntPtr/* AVIOContext*  */ pb,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 maxlen,
            [MarshalAs(UnmanagedType.LPStr)]
	string buf,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 buflen);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_open(
            IntPtr/* IntPtr*  */ s,
            [MarshalAs(UnmanagedType.LPStr)]
	string url,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_open2(
            IntPtr/* IntPtr*  */ s,
            [MarshalAs(UnmanagedType.LPStr)]
	string url,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 flags,
            IntPtr/* AVIOInterruptCB*  */ int_cb,
            IntPtr/* IntPtr*  */ options);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_close(
            IntPtr/* AVIOContext*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_closep(
            IntPtr/* IntPtr*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_open_dyn_buf(
            IntPtr/* IntPtr*  */ s);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_close_dyn_buf(
            IntPtr/* AVIOContext*  */ s,
            IntPtr/* IntPtr*  */ pbuffer);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern string avio_enum_protocols(
            IntPtr/* IntPtr*  */ opaque,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 output);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 avio_pause(
            IntPtr/* AVIOContext*  */ h,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 pause);

        [DllImport(AVIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int64 avio_seek_time(
            IntPtr/* AVIOContext*  */ h,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 stream_index,
            [MarshalAs(UnmanagedType.I8)]
	System.Int64 timestamp,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 flags);

        public struct AVIOInterruptCB
        {
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public avio_func_2 callback;

            public IntPtr/* void*  */ opaque;

        };

        public struct AVIOContext
        {
            public IntPtr/* AVClass*  */ av_class;

            [MarshalAs(UnmanagedType.LPStr)]
            public string buffer;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 buffer_size;

            [MarshalAs(UnmanagedType.LPStr)]
            public string buf_ptr;

            [MarshalAs(UnmanagedType.LPStr)]
            public string buf_end;

            public IntPtr/* void*  */ opaque;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public avio_func_0 read_packet;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public avio_func_0 write_packet;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public avio_func_1 seek;

            [MarshalAs(UnmanagedType.I8)]
            public System.Int64 pos;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 must_flush;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 eof_reached;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 write_flag;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 max_packet_size;

            [MarshalAs(UnmanagedType.I4)]
            public System.UInt32 checksum;

            [MarshalAs(UnmanagedType.LPStr)]
            public string checksum_ptr;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public avio_func_3 update_checksum;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 error;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public avio_func_4 read_pause;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public avio_func_5 read_seek;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 seekable;

            [MarshalAs(UnmanagedType.I8)]
            public System.Int64 maxsize;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 direct;

            [MarshalAs(UnmanagedType.I8)]
            public System.Int64 bytes_read;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 seek_count;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 writeout_count;

        };

    }
}

