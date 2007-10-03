#pragma once

using namespace System;

#include "AvStream.h"
#include "AvPacket.h"

#include "NativeWrapper.h"

namespace Multimedia
{
	namespace FFmpeg
	{
		public ref class AvFormatContext : NativeWrapper<AVFormatContext>
		{
		public:
			property String^ Filename { String^ get() { return filename; } }

			static AvFormatContext^ Open(String^ file);
			array<AvStream^>^ GetStreams();
			virtual String^ ToString() override;

			AvPacket^ ReadFrame(AvStream^ stream);

		private:
			AvFormatContext(AVFormatContext*);
			String^ filename;
			array<uint8_t>^ rawData;
		};
	}
}