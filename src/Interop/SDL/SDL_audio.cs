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
namespace SDLLib
{
    public partial class SDLNative
    {
        public const string SDL_AUDIO = "SDL2.dll";


        public static readonly uint SDL_AUDIO_MASK_BITSIZE = (0xFF);
        public static readonly uint SDL_AUDIO_MASK_DATATYPE = (1 << 8);
        public static readonly uint SDL_AUDIO_MASK_ENDIAN = (1 << 12);
        public static readonly uint SDL_AUDIO_MASK_SIGNED = (1 << 15);
        public static readonly uint AUDIO_U8 = 0x0008;
        public static readonly uint AUDIO_S8 = 0x8008;
        public static readonly uint AUDIO_U16LSB = 0x0010;
        public static readonly uint AUDIO_S16LSB = 0x8010;
        public static readonly uint AUDIO_U16MSB = 0x1010;
        public static readonly uint AUDIO_S16MSB = 0x9010;
        public static readonly uint AUDIO_U16 = AUDIO_U16LSB;
        public static readonly uint AUDIO_S16 = AUDIO_S16LSB;
        public static readonly uint AUDIO_S32LSB = 0x8020;
        public static readonly uint AUDIO_S32MSB = 0x9020;
        public static readonly uint AUDIO_S32 = AUDIO_S32LSB;
        public static readonly uint AUDIO_F32LSB = 0x8120;
        public static readonly uint AUDIO_F32MSB = 0x9120;
        public static readonly uint AUDIO_F32 = AUDIO_F32LSB;
        public static readonly uint AUDIO_U16SYS = AUDIO_U16LSB;
        public static readonly uint AUDIO_S16SYS = AUDIO_S16LSB;
        public static readonly uint AUDIO_S32SYS = AUDIO_S32LSB;
        public static readonly uint AUDIO_F32SYS = AUDIO_F32LSB;
        public static readonly uint SDL_AUDIO_ALLOW_FREQUENCY_CHANGE = 0x00000001;
        public static readonly uint SDL_AUDIO_ALLOW_FORMAT_CHANGE = 0x00000002;
        public static readonly uint SDL_AUDIO_ALLOW_CHANNELS_CHANGE = 0x00000004;
        public static readonly uint SDL_AUDIO_ALLOW_ANY_CHANGE = (SDL_AUDIO_ALLOW_FREQUENCY_CHANGE | SDL_AUDIO_ALLOW_FORMAT_CHANGE | SDL_AUDIO_ALLOW_CHANNELS_CHANGE);
        public static readonly uint SDL_MIX_MAXVOLUME = 128;
        public enum SDL_AudioStatus
        {
            SDL_AUDIO_STOPPED = 0,
            SDL_AUDIO_PLAYING = 1,
            SDL_AUDIO_PAUSED = 2,
        }

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 SDL_GetNumAudioDrivers(
        );

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern string SDL_GetAudioDriver(
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 index);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 SDL_AudioInit(
            [MarshalAs(UnmanagedType.LPStr)]
	string driver_name);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_AudioQuit(
        );

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern string SDL_GetCurrentAudioDriver(
        );

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 SDL_OpenAudio(
            IntPtr/* SDL_AudioSpec*  */ desired,
            IntPtr/* SDL_AudioSpec*  */ obtained);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 SDL_GetNumAudioDevices(
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 iscapture);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern string SDL_GetAudioDeviceName(
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 index,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 iscapture);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern System.UInt32 SDL_OpenAudioDevice(
            [MarshalAs(UnmanagedType.LPStr)]
	string device,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 iscapture,
            IntPtr/* SDL_AudioSpec*  */ desired,
            IntPtr/* SDL_AudioSpec*  */ obtained,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 allowed_changes);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern SDL_AudioStatus SDL_GetAudioStatus(
        );

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern SDL_AudioStatus SDL_GetAudioDeviceStatus(
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 dev);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_PauseAudio(
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 pause_on);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_PauseAudioDevice(
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 dev,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 pause_on);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr/* SDL_AudioSpec*  */ SDL_LoadWAV_RW(
            IntPtr/* SDL_RWops*  */ src,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 freesrc,
            IntPtr/* SDL_AudioSpec*  */ spec,
            IntPtr/* IntPtr*  */ audio_buf,
            IntPtr/* System.UInt32*  */ audio_len);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_FreeWAV(
            IntPtr/* System.Byte*  */ audio_buf);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 SDL_BuildAudioCVT(
            IntPtr/* SDL_AudioCVT*  */ cvt,
            [MarshalAs(UnmanagedType.I2)]
	System.UInt16 src_format,
            [MarshalAs(UnmanagedType.I1)]
	System.Byte src_channels,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 src_rate,
            [MarshalAs(UnmanagedType.I2)]
	System.UInt16 dst_format,
            [MarshalAs(UnmanagedType.I1)]
	System.Byte dst_channels,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 dst_rate);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern System.Int32 SDL_ConvertAudio(
            IntPtr/* SDL_AudioCVT*  */ cvt);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_MixAudio(
            IntPtr/* System.Byte*  */ dst,
            IntPtr/* System.Byte*  */ src,
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 len,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 volume);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_MixAudioFormat(
            IntPtr/* System.Byte*  */ dst,
            IntPtr/* System.Byte*  */ src,
            [MarshalAs(UnmanagedType.I2)]
	System.UInt16 format,
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 len,
            [MarshalAs(UnmanagedType.I4)]
	System.Int32 volume);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_LockAudio(
        );

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_LockAudioDevice(
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 dev);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_UnlockAudio(
        );

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_UnlockAudioDevice(
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 dev);

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_CloseAudio(
        );

        [DllImport(SDL_AUDIO), SuppressUnmanagedCodeSecurity]
        public static extern void SDL_CloseAudioDevice(
            [MarshalAs(UnmanagedType.I4)]
	System.UInt32 dev);

        public struct SDL_AudioSpec
        {
            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 freq;

            [MarshalAs(UnmanagedType.I2)]
            public System.UInt16 format;

            [MarshalAs(UnmanagedType.I1)]
            public System.Byte channels;

            [MarshalAs(UnmanagedType.I1)]
            public System.Byte silence;

            [MarshalAs(UnmanagedType.I2)]
            public System.UInt16 samples;

            [MarshalAs(UnmanagedType.I2)]
            public System.UInt16 padding;

            [MarshalAs(UnmanagedType.I4)]
            public System.UInt32 size;

            [MarshalAs(UnmanagedType.FunctionPtr)]
            public SDL_AudioCallback callback;

            public IntPtr/* void*  */ userdata;

        };

        public struct SDL_AudioCVT
        {
            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 needed;

            [MarshalAs(UnmanagedType.I2)]
            public System.UInt16 src_format;

            [MarshalAs(UnmanagedType.I2)]
            public System.UInt16 dst_format;

            [MarshalAs(UnmanagedType.R8)]
            public System.Double rate_incr;

            public IntPtr/* System.Byte*  */ buf;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 len;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 len_cvt;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 len_mult;

            [MarshalAs(UnmanagedType.R8)]
            public System.Double len_ratio;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public IntPtr[] filters;

            [MarshalAs(UnmanagedType.I4)]
            public System.Int32 filter_index;

        };

        //typedef void (SDLCALL * SDL_AudioCallback) (void *userdata, Uint8 * stream,  int len);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)] 
        public delegate void SDL_AudioCallback(IntPtr userdata, IntPtr stream, int len);
    }
}

