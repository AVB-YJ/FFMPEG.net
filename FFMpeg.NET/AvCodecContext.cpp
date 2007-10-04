#include "StdAfx.h"
#include "AvCodecContext.h"

using namespace System;
using namespace System::Runtime::InteropServices;

namespace Multimedia
{
	namespace FFmpeg
	{
		AvCodecContext::AvCodecContext()
			: NativeWrapper(avcodec_alloc_context())
		{ 
			needFree = true;
		}

		AvCodecContext::AvCodecContext(AVCodecContext* ptr)
			: NativeWrapper(ptr)
		{ 
			needFree = false;
		}

		int AvCodecContext::BitrateTolerance::get()
		{
			return 0;
		}

		int AvCodecContext::Flags::get()
		{
			return 0;
		}

		void AvCodecContext::Cleanup(bool disposing)
		{
			if(!Cleaned) 
			{
				if(needFree && Handle != NULL) 
					av_free(Handle);
				Cleaned = true;
			}
		}

		MotionEstimation AvCodecContext::MotionEstimationMethod::get()
		{
			return MotionEstimation::Zero;
		}

		int AvCodecContext::SubId::get()
		{
			return 0;
		}

		AvCodec^ AvCodecContext::GetCodec()
		{
			AVCodec* codecInstance = avcodec_find_decoder((::CodecID)Id);
			return gcnew AvCodec(codecInstance, this);
		}
	};
};