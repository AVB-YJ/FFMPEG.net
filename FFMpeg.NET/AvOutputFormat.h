#pragma once
#include "NativeWrapper.h"
#include "AvCodec.h"

using namespace System;

namespace Multimedia
{
	namespace FFmpeg
	{
		public ref class AvOutputFormat : NativeWrapper<AVOutputFormat>
		{
		internal:
			AvOutputFormat(AVOutputFormat* context);

		public:
			property String^ Name
			{
				String^ get() { return gcnew String(Handle->name); }
			}

			property CodecId AudioCodec
			{
				CodecId get() { return (CodecId)Handle->audio_codec; }
			}

			property CodecId VideoCodec
			{
				CodecId get() { return (CodecId)Handle->video_codec; }
			}

			property String^ LongName
			{
				String^ get() { return gcnew String(Handle->long_name); }
			}

			property String^ MimeType
			{
				String^ get() { return gcnew String(Handle->mime_type); }
			}

			property array<String^>^ FileTypes
			{
				array<String^>^ get();
			}

			static AvOutputFormat^ GuessOutputFormat(String^ name, String^ filename, String^ mime);

			AvCodec^ CreateAudioEncoder();
			AvCodec^ CreateVideoEncoder();
		};
	}
}