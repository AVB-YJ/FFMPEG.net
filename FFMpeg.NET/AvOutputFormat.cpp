#include "StdAfx.h"
#include "AvOutputFormat.h"
#include "Utility.h"

using namespace System::Runtime::InteropServices;

namespace Multimedia
{
	namespace FFmpeg
	{
		AvOutputFormat::AvOutputFormat(AVOutputFormat* ptr)
			: NativeWrapper(ptr)
		{
		}

		array<String^>^ AvOutputFormat::FileTypes::get()
		{
			String^ str = gcnew String(Handle->extensions);
			return str->Split(',');
		}

		AvCodec^ AvOutputFormat::CreateAudioEncoder()
		{
			if(this->AudioCodec == CodecId::None)
				return nullptr;
			AvCodec^ codec = AvCodec::FindEncoder(AudioCodec);
			return codec;
		}

		AvCodec^ AvOutputFormat::CreateVideoEncoder()
		{
			if(this->VideoCodec == CodecId::None)
				return nullptr;
			AvCodec^ codec = AvCodec::FindEncoder(VideoCodec);
			return codec;
		}

		AvOutputFormat^ AvOutputFormat::GuessOutputFormat(String^ name, String^ filename, String^ mime)
		{
			Utility::Initialize();
			char *namePtr = NULL, *filenamePtr = NULL, *mimePtr = NULL;
			if(!String::IsNullOrEmpty(name))
				namePtr = (char*)(void*)Marshal::StringToHGlobalAnsi(name);
			if(!String::IsNullOrEmpty(filename))
				filenamePtr = (char*)(void*)Marshal::StringToHGlobalAnsi(filename);
			if(!String::IsNullOrEmpty(mime))
				mimePtr = (char*)(void*)Marshal::StringToHGlobalAnsi(mime);

			AVOutputFormat* format = guess_format(namePtr, filenamePtr, mimePtr);
			
			if(namePtr != NULL)
				Marshal::FreeHGlobal(IntPtr((void*)namePtr));
			if(filenamePtr != NULL)
				Marshal::FreeHGlobal(IntPtr((void*)filenamePtr));
			if(mimePtr != NULL)
				Marshal::FreeHGlobal(IntPtr((void*)mimePtr));

			if(format != NULL)
				return gcnew AvOutputFormat(format);
			return nullptr;
		}
	}
}
