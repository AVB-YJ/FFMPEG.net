#include "StdAfx.h"
#include "AvPacket.h"

using namespace System::Runtime::InteropServices;

namespace Multimedia
{
	namespace FFmpeg
	{
		AvPacket::AvPacket()
			: NativeWrapper(new AVPacket)
		{
			av_init_packet(Handle);
			needFree = true;
		}

		AvPacket::AvPacket(array<uint8_t>^ data)
			:NativeWrapper(new AVPacket)
		{
			av_init_packet(Handle);
			this->data = data;
			this->needFree = true;
			this->dataHandle = GCHandle::Alloc(data, GCHandleType::Pinned);
			Handle->data = (uint8_t*)GCHandle::ToIntPtr(dataHandle).ToPointer();
			Handle->size = data->Length;
		}

		AvPacket::AvPacket(int dataSize)
			: NativeWrapper(new AVPacket)
		{	
			av_init_packet(Handle);
			this->needFree = true;
			data = gcnew array<uint8_t>(dataSize);
			dataHandle = GCHandle::Alloc(data, GCHandleType::Pinned);

			Handle->data = (uint8_t*)GCHandle::ToIntPtr(dataHandle).ToPointer();
			Handle->size = dataSize;
		}

		void AvPacket::Cleanup(bool disposing)
		{
			if(dataHandle.IsAllocated)
				dataHandle.Free();
			if(this->Handle)
				av_free_packet(this->Handle);
			if(needFree)
				delete Handle;			
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
