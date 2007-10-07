#pragma once
#include "NativeWrapper.h"

namespace Multimedia
{
	namespace FFmpeg 
	{
		public ref class AvRational : NativeWrapper<AVRational>
		{
		public:
			AvRational(AVRational*);

			property int Numerator 
			{
				int get() { return Handle->num; } 
				void set(int num) { Handle->num = num; }
			}

			property int Denominator 
			{
				int get() { return Handle->den; } 
				void set(int den) { Handle->den = den; }
			}

			property int Milliseconds
			{
				int get() { return (int)(Numerator / (float)Denominator * 1000); }
			}

			explicit operator  AVRational()
			{
				AVRational ret;
				ret.num = Numerator;
				ret.den = Denominator;
				return ret;
			}
		};
	}
}
