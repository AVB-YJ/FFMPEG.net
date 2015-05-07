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
    public partial class SDL 
{
public const string SDL_STDINC = "SDL2.dll";


public static readonly double M_PI = 3.14159265358979323846264338327950288;
//public static readonly uint SDL_ICONV_ERROR = (size_t)-1;
//public static readonly uint SDL_ICONV_E2BIG = (size_t)-2;
//public static readonly uint SDL_ICONV_EILSEQ = (size_t)-3;
//public static readonly uint SDL_ICONV_EINVAL = (size_t)-4;
public enum SDL_bool
{
	SDL_FALSE = 0,
	SDL_TRUE = 1,
}

public enum SDL_DUMMY_ENUM
{
	DUMMY_ENUM_VALUE = 0,
}

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_malloc(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_calloc(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 nmemb, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_realloc(
	IntPtr/* void*  */ mem, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern void SDL_free(
	IntPtr/* void*  */ mem);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_getenv(
	[MarshalAs(UnmanagedType.LPStr)]
	string name);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_setenv(
	[MarshalAs(UnmanagedType.LPStr)]
	string name, 
	[MarshalAs(UnmanagedType.LPStr)]
	string value, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 overwrite);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern void SDL_qsort(
	IntPtr/* void*  */ _base, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 nmemb, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 size, 
	[MarshalAs(UnmanagedType.FunctionPtr)]
	SDL_stdinc_func_0 compare);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_abs(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_isdigit(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_isspace(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_toupper(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_tolower(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_memset(
	IntPtr/* void*  */ dst, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 c, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 len);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern void SDL_memset4(
	IntPtr/* void*  */ dst, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 val, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 dwords);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_memcpy(
	IntPtr/* void*  */ dst, 
	IntPtr/* void*  */ src, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 len);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_memcpy4(
	IntPtr/* void*  */ dst, 
	IntPtr/* void*  */ src, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 dwords);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr/* void*  */ SDL_memmove(
	IntPtr/* void*  */ dst, 
	IntPtr/* void*  */ src, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 len);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_memcmp(
	IntPtr/* void*  */ s1, 
	IntPtr/* void*  */ s2, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 len);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_wcslen(
	IntPtr/* System.UInt16*  */ wstr);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_wcslcpy(
	IntPtr/* System.UInt16*  */ dst, 
	IntPtr/* System.UInt16*  */ src, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 maxlen);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_wcslcat(
	IntPtr/* System.UInt16*  */ dst, 
	IntPtr/* System.UInt16*  */ src, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 maxlen);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_strlen(
	[MarshalAs(UnmanagedType.LPStr)]
	string str);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_strlcpy(
	[MarshalAs(UnmanagedType.LPStr)]
	string dst, 
	[MarshalAs(UnmanagedType.LPStr)]
	string src, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 maxlen);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_utf8strlcpy(
	[MarshalAs(UnmanagedType.LPStr)]
	string dst, 
	[MarshalAs(UnmanagedType.LPStr)]
	string src, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 dst_bytes);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_strlcat(
	[MarshalAs(UnmanagedType.LPStr)]
	string dst, 
	[MarshalAs(UnmanagedType.LPStr)]
	string src, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 maxlen);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_strdup(
	[MarshalAs(UnmanagedType.LPStr)]
	string str);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_strrev(
	[MarshalAs(UnmanagedType.LPStr)]
	string str);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_strupr(
	[MarshalAs(UnmanagedType.LPStr)]
	string str);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_strlwr(
	[MarshalAs(UnmanagedType.LPStr)]
	string str);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_strchr(
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 c);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_strrchr(
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 c);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_strstr(
	[MarshalAs(UnmanagedType.LPStr)]
	string haystack, 
	[MarshalAs(UnmanagedType.LPStr)]
	string needle);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_itoa(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 value, 
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 radix);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_uitoa(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 value, 
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 radix);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_ltoa(
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 value, 
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 radix);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_ultoa(
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 value, 
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 radix);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_lltoa(
	[MarshalAs(UnmanagedType.I8)]
	System.Int64 value, 
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 radix);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_ulltoa(
	[MarshalAs(UnmanagedType.I8)]
	System.UInt64 value, 
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 radix);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_atoi(
	[MarshalAs(UnmanagedType.LPStr)]
	string str);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_atof(
	[MarshalAs(UnmanagedType.LPStr)]
	string str);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_strtol(
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	IntPtr/* string*  */ endp, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 _base);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_strtoul(
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	IntPtr/* string*  */ endp, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 _base);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int64 SDL_strtoll(
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	IntPtr/* string*  */ endp, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 _base);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.UInt64 SDL_strtoull(
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	IntPtr/* string*  */ endp, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 _base);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_strtod(
	[MarshalAs(UnmanagedType.LPStr)]
	string str, 
	IntPtr/* string*  */ endp);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_strcmp(
	[MarshalAs(UnmanagedType.LPStr)]
	string str1, 
	[MarshalAs(UnmanagedType.LPStr)]
	string str2);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_strncmp(
	[MarshalAs(UnmanagedType.LPStr)]
	string str1, 
	[MarshalAs(UnmanagedType.LPStr)]
	string str2, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 maxlen);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_strcasecmp(
	[MarshalAs(UnmanagedType.LPStr)]
	string str1, 
	[MarshalAs(UnmanagedType.LPStr)]
	string str2);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_strncasecmp(
	[MarshalAs(UnmanagedType.LPStr)]
	string str1, 
	[MarshalAs(UnmanagedType.LPStr)]
	string str2, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 len);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_sscanf(
	[MarshalAs(UnmanagedType.LPStr)]
	string text, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_vsscanf(
	[MarshalAs(UnmanagedType.LPStr)]
	string text, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt, 
	[MarshalAs(UnmanagedType.LPStr)]
	string ap);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_snprintf(
	[MarshalAs(UnmanagedType.LPStr)]
	string text, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 maxlen, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_vsnprintf(
	[MarshalAs(UnmanagedType.LPStr)]
	string text, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 maxlen, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fmt, 
	[MarshalAs(UnmanagedType.LPStr)]
	string ap);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_acos(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_asin(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_atan(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_atan2(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x, 
	[MarshalAs(UnmanagedType.R8)]
	System.Double y);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_ceil(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_copysign(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x, 
	[MarshalAs(UnmanagedType.R8)]
	System.Double y);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_cos(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern float SDL_cosf(
	[MarshalAs(UnmanagedType.R4)]
	float x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_fabs(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_floor(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_log(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_pow(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x, 
	[MarshalAs(UnmanagedType.R8)]
	System.Double y);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_scalbn(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x, 
	[MarshalAs(UnmanagedType.I4)]
	System.Int32 n);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_sin(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern float SDL_sinf(
	[MarshalAs(UnmanagedType.R4)]
	float x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Double SDL_sqrt(
	[MarshalAs(UnmanagedType.R8)]
	System.Double x);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern IntPtr SDL_iconv_open(
	[MarshalAs(UnmanagedType.LPStr)]
	string tocode, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fromcode);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.Int32 SDL_iconv_close(
	IntPtr cd);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern System.UInt32 SDL_iconv(
	IntPtr cd, 
	IntPtr/* string*  */ inbuf, 
	IntPtr/* System.UInt32*  */ inbytesleft, 
	IntPtr/* string*  */ outbuf, 
	IntPtr/* System.UInt32*  */ outbytesleft);

[DllImport(SDL_STDINC), SuppressUnmanagedCodeSecurity]
public static extern string SDL_iconv_string(
	[MarshalAs(UnmanagedType.LPStr)]
	string tocode, 
	[MarshalAs(UnmanagedType.LPStr)]
	string fromcode, 
	[MarshalAs(UnmanagedType.LPStr)]
	string inbuf, 
	[MarshalAs(UnmanagedType.I4)]
	System.UInt32 inbytesleft);

public delegate System.Int32 SDL_stdinc_func_0(
	IntPtr/* void*  */ __arg0, 
	IntPtr/* void*  */ __arg1);

}
}

