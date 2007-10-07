#pragma once

namespace Multimedia
{
	namespace FFmpeg
	{
		public enum class AudioFormat
		{
			None = -1,
			Unsigned8,
			Signed16,
			Signed24,
			Signed32,
			Float
		};

		public ref class AvSamples
		{
		public:			
			property int Count 
			{ 
				int get()
				{
					switch(format) 
					{
					case AudioFormat::Unsigned8:
						return this->byteSamples->Length;
					case AudioFormat::Signed16:
						return this->shortSamples->Length;
					case AudioFormat::Signed24:
					case AudioFormat::Signed32:
						return this->intSamples->Length;
					case AudioFormat::Float:
						return this->floatSamples->Length;
					}
					return 0;
				}
			}

			property AudioFormat Format
			{
				AudioFormat get() { return format; }
			}

			property array<int16_t>^ ShortSamples
			{
				array<int16_t>^ get() { return shortSamples; }
			}

			property int SampleRate { int get() { return sampleRate; } }
			property int Channels { int get() { return channels; } }

			property int BitsPerSample
			{
				int get() 
				{
					switch(format)
					{
					case AudioFormat::Unsigned8:
						return 8;
					case AudioFormat::Signed16:
						return 16;
					case AudioFormat::Signed24:
						return 24;
					case AudioFormat::Float:
					case AudioFormat::Signed32:
						return 32;
					}
					return 0;
				}
			}

			AvSamples(array<uint8_t>^ samples, int channels, int samplerate);
			AvSamples(array<int16_t>^ samples, int channels, int samplerate);
			AvSamples(array<int32_t>^ samples, int channels, int samplerate, AudioFormat format);
			AvSamples(array<float>^ samples, int channels, int samplerate);

			AvSamples^ GetSamples(int start, int length);

			static AvSamples^ operator+(AvSamples^ left, AvSamples^ right);
			//static void operator+=(AvSamples^ right);
			
		private:
			AudioFormat format;
			array<uint8_t>^ byteSamples;
			array<int16_t>^ shortSamples;
			array<int32_t>^ intSamples;
			array<float>^ floatSamples;
			int channels, sampleRate, bitsPerSample;
		};
	}
}
