#pragma once
using namespace System;

#include "NativeWrapper.h"
#include "AvPacket.h"
#include "AvFrame.h"

namespace Multimedia
{
	namespace FFmpeg
	{
		ref class AvCodecContext; // forward declaration

		public ref class AvCodec : NativeWrapper<AVCodec>
		{
		public:
			property String^ Name
			{
				String^ get();
			}

			property AvCodecContext^ Context
			{
				AvCodecContext^ get();
			}

			void Open(AvCodecContext^ context);
			void Close();

			array<int16_t>^ DecodeAudio(AvPacket^ packet);
			AvFrame^ DecodeVideo(AvPacket^ packet);
			int DecodeSubtitle();

		internal:
			AvCodec(AVCodec*);

		private:
			array<uint8_t>^ RawData;
			AvCodecContext^ context;
		};
	}
}