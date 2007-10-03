#include "StdAfx.h"
#include "AvSamples.h"

namespace Multimedia
{
	namespace FFmpeg
	{
		AvSamples::AvSamples(array<int16_t>^ samples, int channel, int samplerate)
		{
			format = AudioFormat::Signed16;
			shortSamples = samples;
			this->channels = channel;
			this->sampleRate = samplerate;
		}

		AvSamples::AvSamples(array<uint8_t>^ samples, int channel, int samplerate)
		{
			format = AudioFormat::Unsigned8;
			this->channels = channel;
			this->sampleRate = samplerate;
		}

		AvSamples::AvSamples(array<float>^ samples, int channel, int samplerate)
		{
			format = AudioFormat::Float;
			this->channels = channel;
			this->sampleRate = samplerate;
		}

		AvSamples::AvSamples(array<int32_t>^ samples, int channels, int samplerate, AudioFormat format)
		{
			this->format = format;
			this->sampleRate = samplerate;
			this->channels = channels;
		}
	}
}
