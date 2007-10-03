#include "StdAfx.h"

#include "AvFormatContext.h"
#include "AvStream.h"
#include "Utility.h"

using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

namespace Multimedia
{
	namespace FFmpeg
	{
		AvFormatContext::AvFormatContext(AVFormatContext* context)
			: NativeWrapper(context)
		{
			rawData = gcnew array<uint8_t>(sizeof(AVFormatContext));
			Marshal::Copy(IntPtr((void*)context), rawData, 0, sizeof(AVFormatContext));
		}

		AvFormatContext^ AvFormatContext::Open(String^ file)
		{
			Utility::Initialize();
			AVCodec* codec = avcodec_find_decoder(CodecID::CODEC_ID_FLAC);
			AVFormatContext* pFormatCtx;
			char* filename = (char*)(void*)Marshal::StringToHGlobalAnsi(file);
			if(av_open_input_file(&pFormatCtx, filename, NULL, 0, NULL) != 0)
				throw gcnew System::IO::FileNotFoundException("Couldn't open file " + file);
			Marshal::FreeHGlobal(IntPtr(filename));
			return gcnew AvFormatContext(pFormatCtx);
		}

		array<AvStream^>^ AvFormatContext::GetStreams()
		{
			pin_ptr<uint8_t> ptr = &this->rawData[0];
			AVFormatContext* pFormat = (AVFormatContext*)ptr;
			av_find_stream_info(pFormat);

			List<AvStream^>^ streams = gcnew List<AvStream^>(20);
			for(int i = 0 ; i < MAX_STREAMS; i++)
			{
				AVStream* stream = pFormat->streams[i];
				if(stream != NULL)
				{
					streams->Add(gcnew AvStream(stream));
				}
			}
			return streams->ToArray();
		}

		AvPacket^ AvFormatContext::ReadFrame(AvStream^ stream)
		{
			AVPacket packet;
			if(av_read_frame(this->Handle, &packet) != 0)
				throw gcnew IO::IOException();
			AVPacket* final = new AVPacket;
			memcpy(final, &packet, sizeof(AVPacket));
			
			return gcnew AvPacket(final);
		}

		String^ AvFormatContext::ToString()
		{
			IntPtr value = Marshal::StringToHGlobalAnsi(Filename);
			dump_format((AVFormatContext*)this, 0, (char*)(void*)value, false);
			Marshal::FreeHGlobal(value);
			return "FormatContext";
		}
	}
}