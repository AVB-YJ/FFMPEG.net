using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;

namespace ASoundLIb
{
	public class Asound
	{
	
		public const string ASOUND = "asound";

		/** Output type. */
		public enum snd_pcm_stream_t
		{
			/** Playback stream */
			SND_PCM_STREAM_PLAYBACK = 0,
			/** Capture stream */
			SND_PCM_STREAM_CAPTURE,
			SND_PCM_STREAM_LAST = SND_PCM_STREAM_CAPTURE
}

		public enum snd_pcm_access_t {
	/** mmap access with simple interleaved channels */
	SND_PCM_ACCESS_MMAP_INTERLEAVED = 0,
	/** mmap access with simple non interleaved channels */
	SND_PCM_ACCESS_MMAP_NONINTERLEAVED,
	/** mmap access with complex placement */
	SND_PCM_ACCESS_MMAP_COMPLEX,
	/** snd_pcm_readi/snd_pcm_writei access */
	SND_PCM_ACCESS_RW_INTERLEAVED,
	/** snd_pcm_readn/snd_pcm_writen access */
	SND_PCM_ACCESS_RW_NONINTERLEAVED,
	SND_PCM_ACCESS_LAST = SND_PCM_ACCESS_RW_NONINTERLEAVED
} ;

		/** PCM sample format */
public enum snd_pcm_format_t {
	/** Unknown */
	SND_PCM_FORMAT_UNKNOWN = -1,
	/** Signed 8 bit */
	SND_PCM_FORMAT_S8 = 0,
	/** Unsigned 8 bit */
	SND_PCM_FORMAT_U8,
	/** Signed 16 bit Little Endian */
	SND_PCM_FORMAT_S16_LE,
	/** Signed 16 bit Big Endian */
	SND_PCM_FORMAT_S16_BE,
	/** Unsigned 16 bit Little Endian */
	SND_PCM_FORMAT_U16_LE,
	/** Unsigned 16 bit Big Endian */
	SND_PCM_FORMAT_U16_BE,
	/** Signed 24 bit Little Endian */
	SND_PCM_FORMAT_S24_LE,
	/** Signed 24 bit Big Endian */
	SND_PCM_FORMAT_S24_BE,
	/** Unsigned 24 bit Little Endian */
	SND_PCM_FORMAT_U24_LE,
	/** Unsigned 24 bit Big Endian */
	SND_PCM_FORMAT_U24_BE,
	/** Signed 32 bit Little Endian */
	SND_PCM_FORMAT_S32_LE,
	/** Signed 32 bit Big Endian */
	SND_PCM_FORMAT_S32_BE,
	/** Unsigned 32 bit Little Endian */
	SND_PCM_FORMAT_U32_LE,
	/** Unsigned 32 bit Big Endian */
	SND_PCM_FORMAT_U32_BE,
	/** Float 32 bit Little Endian, Range -1.0 to 1.0 */
	SND_PCM_FORMAT_FLOAT_LE,
	/** Float 32 bit Big Endian, Range -1.0 to 1.0 */
	SND_PCM_FORMAT_FLOAT_BE,
	/** Float 64 bit Little Endian, Range -1.0 to 1.0 */
	SND_PCM_FORMAT_FLOAT64_LE,
	/** Float 64 bit Big Endian, Range -1.0 to 1.0 */
	SND_PCM_FORMAT_FLOAT64_BE,
	/** IEC-958 Little Endian */
	SND_PCM_FORMAT_IEC958_SUBFRAME_LE,
	/** IEC-958 Big Endian */
	SND_PCM_FORMAT_IEC958_SUBFRAME_BE,
	/** Mu-Law */
	SND_PCM_FORMAT_MU_LAW,
	/** A-Law */
	SND_PCM_FORMAT_A_LAW,
	/** Ima-ADPCM */
	SND_PCM_FORMAT_IMA_ADPCM,
	/** MPEG */
	SND_PCM_FORMAT_MPEG,
	/** GSM */
	SND_PCM_FORMAT_GSM,
	/** Special */
	SND_PCM_FORMAT_SPECIAL = 31,
	/** Signed 24bit Little Endian in 3bytes format */
	SND_PCM_FORMAT_S24_3LE = 32,
	/** Signed 24bit Big Endian in 3bytes format */
	SND_PCM_FORMAT_S24_3BE,
	/** Unsigned 24bit Little Endian in 3bytes format */
	SND_PCM_FORMAT_U24_3LE,
	/** Unsigned 24bit Big Endian in 3bytes format */
	SND_PCM_FORMAT_U24_3BE,
	/** Signed 20bit Little Endian in 3bytes format */
	SND_PCM_FORMAT_S20_3LE,
	/** Signed 20bit Big Endian in 3bytes format */
	SND_PCM_FORMAT_S20_3BE,
	/** Unsigned 20bit Little Endian in 3bytes format */
	SND_PCM_FORMAT_U20_3LE,
	/** Unsigned 20bit Big Endian in 3bytes format */
	SND_PCM_FORMAT_U20_3BE,
	/** Signed 18bit Little Endian in 3bytes format */
	SND_PCM_FORMAT_S18_3LE,
	/** Signed 18bit Big Endian in 3bytes format */
	SND_PCM_FORMAT_S18_3BE,
	/** Unsigned 18bit Little Endian in 3bytes format */
	SND_PCM_FORMAT_U18_3LE,
	/** Unsigned 18bit Big Endian in 3bytes format */
	SND_PCM_FORMAT_U18_3BE,
	SND_PCM_FORMAT_LAST = SND_PCM_FORMAT_U18_3BE,


	/** Signed 16 bit CPU endian */
	SND_PCM_FORMAT_S16 = SND_PCM_FORMAT_S16_LE,
	/** Unsigned 16 bit CPU endian */
	SND_PCM_FORMAT_U16 = SND_PCM_FORMAT_U16_LE,
	/** Signed 24 bit CPU endian */
	SND_PCM_FORMAT_S24 = SND_PCM_FORMAT_S24_LE,
	/** Unsigned 24 bit CPU endian */
	SND_PCM_FORMAT_U24 = SND_PCM_FORMAT_U24_LE,
	/** Signed 32 bit CPU endian */
	SND_PCM_FORMAT_S32 = SND_PCM_FORMAT_S32_LE,
	/** Unsigned 32 bit CPU endian */
	SND_PCM_FORMAT_U32 = SND_PCM_FORMAT_U32_LE,
	/** Float 32 bit CPU endian */
	SND_PCM_FORMAT_FLOAT = SND_PCM_FORMAT_FLOAT_LE,
	/** Float 64 bit CPU endian */
	SND_PCM_FORMAT_FLOAT64 = SND_PCM_FORMAT_FLOAT64_LE,
	/** IEC-958 CPU Endian */
	SND_PCM_FORMAT_IEC958_SUBFRAME = SND_PCM_FORMAT_IEC958_SUBFRAME_LE
} ;


		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		public static extern 
        int snd_pcm_open (out IntPtr /* snd_pcm_t ** */pcm, 
			                 [MarshalAs(UnmanagedType.LPStr)]
			                 string name, 
		 snd_pcm_stream_t stream, int mode);

		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		public static extern 
		int snd_pcm_hw_params_sizeof ();

		public static IntPtr snd_pcm_hw_params_alloca ()
		{
			IntPtr ptr = Marshal.AllocHGlobal (snd_pcm_hw_params_sizeof ());
			return ptr;
		}

		public static void snd_pcm_params_free(IntPtr param)
		{
			Marshal.FreeHGlobal(param);
		}

		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		public static extern 
		int snd_pcm_hw_params_any(IntPtr /*snd_pcm_t* */pcm, IntPtr /*snd_pcm_hw_params_t * */@params);

		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		public static extern 
		int snd_pcm_hw_params_set_access(IntPtr /*snd_pcm_t* */pcm,
			                                 IntPtr /*snd_pcm_hw_params_t * */@params,
			                                 snd_pcm_access_t access);
		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		public static extern 
		int snd_pcm_hw_params_set_format(IntPtr /*snd_pcm_t* */pcm,
			                                 IntPtr /*snd_pcm_hw_params_t * */@params, 
			                                 snd_pcm_format_t val);
		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		public static extern 
		int snd_pcm_hw_params_set_channels(IntPtr /*snd_pcm_t* */pcm,
			                                 IntPtr /*snd_pcm_hw_params_t * */@params, 
			                                int val);

		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		public static extern 
		int snd_pcm_hw_params_set_rate_near(IntPtr /*snd_pcm_t* */pcm,
			                                 IntPtr /*snd_pcm_hw_params_t * */@params, 
			                                 ref int val, out int dir);

		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		public static extern 
		int snd_pcm_hw_params_set_period_size_near(IntPtr /*snd_pcm_t* */pcm,
			                                 IntPtr /*snd_pcm_hw_params_t * */@params, 
			                                           ref ulong val, 
			                                           out int dir);

		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		public static extern 
		int snd_pcm_hw_params(IntPtr /*snd_pcm_t* */pcm,
			                                 IntPtr /*snd_pcm_hw_params_t * */@params);

		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		public static extern 
		long snd_pcm_writei(IntPtr /*snd_pcm_t* */pcm,
			                    IntPtr buffer, uint size);

		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		public static extern 
		int snd_pcm_close(IntPtr /*snd_pcm_t* */pcm);

		[DllImport(ASOUND), SuppressUnmanagedCodeSecurity]
		private static extern
		IntPtr snd_strerror(int errnum);
	
		public static string _snd_strerror(int errnum)
		{
			IntPtr ret = snd_strerror(errnum);
			string name = Marshal.PtrToStringAnsi(ret);
			return name;
		}
	}
}

