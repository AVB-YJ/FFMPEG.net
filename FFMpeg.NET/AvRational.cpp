#include "StdAfx.h"
#include "AvRational.h"

namespace Multimedia
{
	namespace FFmpeg 
	{
		AvRational::AvRational(AVRational *ptr)
			: NativeWrapper(ptr)
		{}
	}
}
