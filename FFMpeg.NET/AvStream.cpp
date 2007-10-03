#include "StdAfx.h"
#include "AvStream.h"

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
			CodecID id = stream->codec->codec_id;
			Marshal::Copy(IntPtr(stream), this->rawData, 0, sizeof(AVStream));
			context = gcnew AvCodecContext(stream->codec);
		}
	}
}
