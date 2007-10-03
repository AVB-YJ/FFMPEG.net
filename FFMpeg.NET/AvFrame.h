#pragma once

#include "NativeWrapper.h"

using namespace System::Drawing;

namespace Multimedia
{
	namespace FFmpeg
	{
		ref class AvCodecContext; // forward declaration

		public ref class AvFrame : NativeWrapper<AVFrame>
		{
		public:
			AvFrame(void);
			Bitmap^ ConvertToBitmap(AvCodecContext^ context);

			explicit operator AVPicture*() { return (AVPicture*)this->Handle; }
		};
	}
}