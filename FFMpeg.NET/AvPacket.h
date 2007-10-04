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
				array<uint8_t>^ get();
			}

			property int StreamIndex
			{
				int get() { return this->Handle->stream_index; }
			}

		protected:
			virtual void Cleanup(bool disposing) override;

		internal:
			AvPacket(AVPacket*);
			AvPacket();

		private:
			bool needFree;
			array<uint8_t>^ data;
		};
	}
}
