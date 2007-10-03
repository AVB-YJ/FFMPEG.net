#include "StdAfx.h"
#include "AvPacket.h"

namespace Multimedia
{
	namespace FFmpeg
	{
		AvPacket::AvPacket(AVPacket* packet)
			: NativeWrapper(packet)
		{
			data = gcnew array<uint8_t>(packet->size);
			System::Runtime::InteropServices::Marshal::Copy(IntPtr(packet->data), data, 0, packet->size);
		}
	}
}
