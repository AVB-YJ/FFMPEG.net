#include "StdAfx.h"
#include "AvSamples.h"

namespace Multimedia
{
	namespace FFmpeg
	{
		AvSamples::AvSamples(array<int16_t>^ samples)
		{
			format = AudioFormat::Signed16;
			shortSamples = samples;
		}

		AvSamples::AvSamples(array<uint8_t>^ samples)
		{
			format = AudioFormat::Unsigned8;
		}

		AvSamples::AvSamples(array<float>^ samples)
		{
			format = AudioFormat::Float;
		}

		AvSamples::AvSamples(array<int32_t>^ samples, AudioFormat format)
		{
			this->format = format;
		}
	}
}
