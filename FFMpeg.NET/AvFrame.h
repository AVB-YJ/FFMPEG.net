#pragma once

#include "NativeWrapper.h"

namespace Multimedia
{
	namespace FFmpeg
	{
		ref class AvCodecContext; // forward declaration

		public ref class AvFrame : NativeWrapper<AVFrame>
		{
		public:
			AvFrame(void);
			void ConvertToBitmap(AvCodecContext^ context);

			explicit operator AVPicture*() { return (AVPicture*)this->Handle; }
		};
	}
}