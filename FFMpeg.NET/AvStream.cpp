#include "StdAfx.h"
#include "AvStream.h"
#include "AvFormatContext.h"

using namespace System;
using namespace System::Runtime::InteropServices;

namespace Multimedia
{
	namespace FFmpeg
	{
		AvStream::AvStream(AVStream* stream)
			: NativeWrapper(stream)
		{
			this->rawData = gcnew array<uint8_t>(sizeof(AVStream));
			CodecID id = (CodecID)stream->codec->codec_id;
			Marshal::Copy(IntPtr(stream), this->rawData, 0, sizeof(AVStream));
			context = gcnew AvCodecContext(stream->codec);
		}

		AvStream::AvStream(AvFormatContext^ context, int streamid)
			: NativeWrapper(av_new_stream((AVFormatContext*)context, streamid)), needFree(true)
		{ }

		void AvStream::Cleanup(bool disposing)
		{
			if(needFree)
				av_freep(Handle);
		}
	}
}
