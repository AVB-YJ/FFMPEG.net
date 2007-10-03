#pragma once

#include "NativeWrapper.h"

using namespace System;

namespace Multimedia
{
	namespace FFmpeg
	{
		public ref class AvPacket : NativeWrapper<AVPacket>
		{
		public:
			property array<uint8_t>^ Data
			{
				array<uint8_t>^ get() { return data; }
			}

			property int StreamIndex
			{
				int get() { return this->Handle->stream_index; }
			}

			!AvPacket() 
			{ 
				delete this->Handle; 
			}

			~AvPacket();

		internal:
			AvPacket(AVPacket*);

		private:
			array<uint8_t>^ data;
		};
	}
}
