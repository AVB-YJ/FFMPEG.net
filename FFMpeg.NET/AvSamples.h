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

			AvSamples(array<uint8_t>^ samples);
			AvSamples(array<int16_t>^ samples);
			AvSamples(array<int32_t>^ samples, AudioFormat format);
			AvSamples(array<float>^ samples);
			
		private:
			AudioFormat format;
			array<uint8_t>^ byteSamples;
			array<int16_t>^ shortSamples;
			array<int32_t>^ intSamples;
			array<float>^ floatSamples;
		};
	}
}
