#pragma once
#include "AvCodecContext.h"
#include "NativeWrapper.h"

namespace Multimedia
{
	namespace FFmpeg
	{
		public ref class AvStream : NativeWrapper<AVStream>
		{
		public:
			property AvCodecContext^ CodecContext
			{
				AvCodecContext^ get() { return context; }
			}

			property int Index { int get() { return this->Handle->index; } }
			property int Id { int get() { return this->Handle->id; } }
			property int64_t StartTime { int64_t get() { return this->Handle->start_time; } }
			property int64_t Duration { int64_t get() { return this->Handle->duration; } }

		internal:	
			AvStream(AVStream*);
		private:
			array<uint8_t>^ rawData;
			AvCodecContext^ context;
		};
	}
}