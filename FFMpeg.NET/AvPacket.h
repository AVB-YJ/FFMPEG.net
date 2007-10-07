#pragma once

#include "NativeWrapper.h"

using namespace System;
using namespace System::Runtime::InteropServices;

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
				void set(int value) { this->Handle->stream_index = value; }
			}

			property bool HasDestruct { bool get() { return this->Handle->destruct != NULL; } }
			property IntPtr Destruct { IntPtr get() { return IntPtr(this->Handle->destruct); } }
			property int Length { int get() { return Data->Length; } }
			property int64_t PresentationTime
			{
				int64_t get() { return Handle->pts; }
				void set(int64_t value) { Handle->pts = value; }
			}

		protected:
			virtual void Cleanup(bool disposing) override;

		internal:
			property IntPtr DataHandle { IntPtr get() { return GCHandle::ToIntPtr(dataHandle); } }

			AvPacket();
			AvPacket(array<uint8_t>^ data);
			AvPacket(int dataSize);

		private:
			bool needFree, needFreeData;
			array<uint8_t>^ data;
			GCHandle dataHandle;
		};
	}
}
