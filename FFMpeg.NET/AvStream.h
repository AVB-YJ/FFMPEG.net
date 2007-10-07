#pragma once
#include "AvCodecContext.h"
#include "NativeWrapper.h"
#include "AvRational.h"

namespace Multimedia
{
	namespace FFmpeg
	{
		ref class AvFormatContext; // forward

		public ref class AvStream : NativeWrapper<AVStream>
		{
		public:
			property AvCodecContext^ CodecContext
			{
				AvCodecContext^ get() 
				{
					if(context == nullptr && Handle->codec)
						context = gcnew AvCodecContext(Handle->codec);
					return context; 
				}
			}

			property int Index { int get() { return this->Handle->index; } }
			property int Id { int get() { return this->Handle->id; } }
			property int64_t StartTime { int64_t get() { return this->Handle->start_time; } }
			property int64_t Duration { int64_t get() { return this->Handle->duration; } }
			property AvRational^ TimeBase { AvRational^ get() { return gcnew AvRational(&Handle->time_base); } }

			AvStream(AvFormatContext^ context, int id);

		internal:
			AvStream(AVStream*);

		protected:
			virtual void Cleanup(bool disposing) override;

		private:
			bool needFree;
			array<uint8_t>^ rawData;
			AvCodecContext^ context;
		};
	}
}