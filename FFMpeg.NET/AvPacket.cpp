#include "StdAfx.h"
#include "AvPacket.h"

using namespace System::Runtime::InteropServices;

namespace Multimedia
{
	namespace FFmpeg
	{
		AvPacket::AvPacket(AVPacket* packet)
			: NativeWrapper(packet)
		{ 
			needFree = false;
		}

		AvPacket::AvPacket()
			: NativeWrapper(new AVPacket)
		{
			needFree = true;
		}

		void AvPacket::Cleanup(bool disposing)
		{
			if(needFree)
				av_free_packet(this->Handle);
			Cleaned = true;
		}

		array<uint8_t>^ AvPacket::Data::get()
		{
			if(data == nullptr)
			{
				data = gcnew array<uint8_t>(Handle->size);
				Marshal::Copy(IntPtr(Handle->data), data, 0, data->Length);
			}
			return data;
		}
	}
}
