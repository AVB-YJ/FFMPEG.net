#include "StdAfx.h"
#include "AvSamples.h"

using namespace System;

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

		AvSamples^ AvSamples::operator +(AvSamples ^left, AvSamples ^right)
		{
			if(left->Format != right->Format || left->Channels != right->Channels || left->SampleRate != right->SampleRate)
				throw gcnew ArgumentException();
			switch(left->Format)
			{
			case AudioFormat::Signed16:
				array<int16_t>^ newArray = gcnew array<int16_t>(left->Count + right->Count);
				Array::Copy(left->ShortSamples, newArray, left->Count);
				Array::Copy(right->ShortSamples, 0, newArray, left->Count, right->Count);
				return gcnew AvSamples(newArray, left->Channels, left->SampleRate);
			}
			throw gcnew ArgumentException();
		}

		AvSamples^ AvSamples::GetSamples(int start, int length)
		{
			array<int16_t>^ output = gcnew array<int16_t>(length);
			Array::Copy(this->ShortSamples, start, output, 0, length);
			return gcnew AvSamples(output, this->Channels, this->SampleRate);
		}
	}
}
