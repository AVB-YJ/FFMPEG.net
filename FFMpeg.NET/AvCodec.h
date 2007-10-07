#pragma once

#include "NativeWrapper.h"
#include "AvPacket.h"
#include "AvFrame.h"
#include "AvSamples.h"

using namespace System::IO;
using namespace System;

namespace Multimedia
{
	namespace FFmpeg
	{
		ref class AvCodecContext; // forward declaration

		public enum class CodecId
		{
			None,
			Mpeg1Video,
			Mpeg2Video, /* preferred ID for MPEG-1/2 video decoding */
			Mpeg2VideoXVMC,
			H261,
			H263,
			RealVideo10,
			RealVideo20,
			MotionJPEG,
			MotionJpegB,
			LJpeg,
			Sp5X,
			JpegLS,
			Mpeg4,
			RawVideo,
			MicrosoftMpeg4V1,
			MicrosoftMpeg4V2,
			MicrosoftMpeg4V3,
			WindowMediaVideo1,
			WindowMediaVideo2,
			H263Proogressive,
			H263Interlaced,
			FlashVideoEncoderV1,
			SVQ1,
			SVQ3,
			DVVideo,
			HuffYUV,
			CreativeYUV,
			H264,
			Indeo3,
			VP3,
			Theora,
			ASV1,
			ASV2,
			FFV1,
			FourXM,
			VCR1,
			CLJR,
			MDEC,
			ROQ,
			InterplayVideo,
			XanWC3,
			XanWC4,
			RPZA,
			Cinepak,
			WsVQA,
			MSRLE,
			MicrosoftVideo1,
			IDCIN,
			EightBPS,
			SMC,
			FLIC,
			TrueMotion1,
			VMDVideo,
			MSZH,
			ZLIB,
			QTRLE,
			SNOW,
			TSCC,
			ULTI,
			QDRAW,
			VIXL,
			QPEG,
			XviD,
			Png,
			Ppm,
			PBM,
			PGM,
			PGMYUV,
			PAM,
			FFVHUFF,
			RV30,
			RV40,
			VC1,
			WMV3,
			LOCO,
			WNV1,
			AASC,
			Indeo2,
			FRAPS,
			TrueMotion2,
			BMP,
			CSCD,
			MMVideo,
			ZMBV,
			AVS,
			SmackVideo,
			NUV,
			KMVC,
			FlashSV,
			CAVS,
			Jpeg2000,
			VMNC,
			VP5,
			VP6,
			VP6F,
			TARGA,
			DSICINVideo,
			TIERTEXSEQVideo,
			TIFF,
			GIF,
			FFH264,
			DXA,
			DNXHD,
			THP,
			SGI,
			C93,
			BETHSOFTVID,
			PTX,
			TXD,

			/* various PCM "codecs" */
			PCM_S16LE= 0x10000,
			PCM_S16BE,
			PCM_U16LE,
			PCM_U16BE,
			PCM_S8,
			PCM_U8,
			PCM_MULAW,
			PCM_ALAW,
			PCM_S32LE,
			PCM_S32BE,
			PCM_U32LE,
			PCM_U32BE,
			PCM_S24LE,
			PCM_S24BE,
			PCM_U24LE,
			PCM_U24BE,
			PCM_S24DAUD,

			/* various ADPCM codecs */
			ADPCM_IMA_QT= 0x11000,
			ADPCM_IMA_WAV,
			ADPCM_IMA_DK3,
			ADPCM_IMA_DK4,
			ADPCM_IMA_WS,
			ADPCM_IMA_SMJPEG,
			ADPCM_MS,
			ADPCM_4XM,
			ADPCM_XA,
			ADPCM_ADX,
			ADPCM_EA,
			ADPCM_G726,
			ADPCM_CT,
			ADPCM_SWF,
			ADPCM_YAMAHA,
			ADPCM_SBPRO_4,
			ADPCM_SBPRO_3,
			ADPCM_SBPRO_2,
			ADPCM_THP,

			/* AMR */
			AMR_NB= 0x12000,
			AMR_WB,

			/* RealAudio codecs*/
			RA_144= 0x13000,
			RA_288,

			/* various DPCM codecs */
			ROQ_DPCM= 0x14000,
			INTERPLAY_DPCM,
			XAN_DPCM,
			SOL_DPCM,

			Mp2= 0x15000,
			Mp3, /* preferred ID for decoding MPEG audio layer 1, 2 or 3 */
			Aac,
			Mpeg4Aac,
			Ac3,
			Dts,
			OggVorbis,
			DvAudio,
			WMAV1,
			WMAV2,
			Mace3,
			Mace6,
			VMDAudio,
			Sonic,
			SonicLs,
			Flac,
			Mp3ADU,
			Mp3ON4,
			Shorten,
			AppleLossless,
			WestwoodSnd1,
			GSM, /* as in Berlin toast format */
			QDM2,
			CookCodec,
			TrueSpeech,
			TTA,
			SmackAudio,
			QCELP,
			WAVPACK,
			DSICINAUDIO,
			IMC,
			MUSEPACK7,
			MLP,
			GSM_MS, /* as found in WAV */
			Atrac3,

			/* subtitle codecs */
			DvdSubtitle= 0x17000,
			DvbSubtitle,

			Mpeg2TS = 0x20000, /* _FAKE_ codec to indicate a raw MPEG-2 TS
										* stream (only used by libavformat) */
		};

		public ref class AvCodec : NativeWrapper<AVCodec>
		{
		public:
			property String^ Name
			{
				String^ get();
			}

			property AvCodecContext^ Context
			{
				AvCodecContext^ get();
			}

			void Open();
			void Close();

			AvSamples^ DecodeAudio(AvPacket^ packet);
			AvFrame^ DecodeVideo(AvPacket^ packet);
			int DecodeSubtitle();

			AvPacket^ EncodeAudio(AvSamples^ samples);

			static AvCodec^ FindEncoder(CodecId id);
			static AvCodec^ FindEncoder(String^ name);

		protected:
			virtual void Cleanup(bool disposing) override;

		internal:
			AvCodec(AVCodec*);
			AvCodec(AVCodec*, AvCodecContext^ context);

		private:
			bool freeNeeded;
			bool opened;
			AvCodecContext^ context;
		};
	}
}