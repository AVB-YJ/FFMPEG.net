#include "StdAfx.h"
#include "AvCodecContext.h"

using namespace System;
using namespace System::Runtime::InteropServices;

namespace Multimedia
{
	namespace FFmpeg
	{
		AvCodecContext::AvCodecContext(AVCodecContext* ptr)
		: NativeWrapper(ptr)
		{
			rawData = gcnew array<uint8_t>(sizeof(AVCodecContext));
			Marshal::Copy(IntPtr(ptr), rawData, 0, sizeof(AVCodecContext));
		}

		int AvCodecContext::Bitrate::get()
		{
			pin_ptr<uint8_t> ptr = &rawData[0];
			AVCodecContext* codec = (AVCodecContext*)ptr;
			return codec->bit_rate;
		}

		int AvCodecContext::BitrateTolerance::get()
		{
			return 0;
		}

		int AvCodecContext::Flags::get()
		{
			return 0;
		}

		MotionEstimation AvCodecContext::MotionEstimationMethod::get()
		{
			return MotionEstimation::Zero;
		}

		int AvCodecContext::SubId::get()
		{
			return 0;
		}

		int AvCodecContext::CodecId::get()
		{
			pin_ptr<uint8_t> ptr = &rawData[0];
			AVCodecContext* codec = (AVCodecContext*)ptr;
			return codec->codec_id;
		}

		AvCodec^ AvCodecContext::GetCodec()
		{
			pin_ptr<uint8_t> ptr = &rawData[0];
			AVCodecContext* codec = (AVCodecContext*)ptr;
			AVCodec* codecInstance = avcodec_find_decoder((CodecID)CodecId);

			return gcnew AvCodec(codecInstance);
		}
	};
};