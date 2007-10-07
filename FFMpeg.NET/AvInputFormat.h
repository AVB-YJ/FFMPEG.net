#pragma once
#include "NativeWrapper.h"

namespace Multimedia
{
	namespace FFmpeg
	{
		public ref class AvInputFormat : NativeWrapper<AVInputFormat>
		{
		public:
			AvInputFormat(AVInputFormat* format);

			static AvInputFormat^ GuessInputFormat(String^ fname);
		};
	}
}

