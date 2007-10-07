#include "StdAfx.h"

#include <vcclr.h>

#include "AvFormatContext.h"
#include "AvStream.h"
#include "Utility.h"

using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;

#pragma unmanaged
int Write(void* t, uint8_t* buf, int size);
#pragma managed

namespace Multimedia
{
	namespace FFmpeg
	{
		AvFormatContext::AvFormatContext(AVFormatContext* context)
			: NativeWrapper(context)
		{
			opened = true;
			needExplicitFree = false;
			id = Guid::NewGuid();
			String^ protocol = String::Format("DotNet:{0}", id);
			char* protoPtr = (char*)Marshal::StringToHGlobalAnsi(protocol).ToPointer();
			memcpy(Handle->filename, protoPtr, protocol->Length);
			Handle->filename[protocol->Length] = 0;
			Marshal::FreeHGlobal(IntPtr(protoPtr));
			Utility::FormatStreamMap[protocol] = nullptr;
		}

		AvFormatContext::AvFormatContext()
			: NativeWrapper(av_alloc_format_context())
		{
			needExplicitFree = true;
			id = Guid::NewGuid();
			String^ protocol = String::Format("DotNet:{0}", id);
			char* protoPtr = (char*)Marshal::StringToHGlobalAnsi(protocol).ToPointer();
			memcpy(Handle->filename, protoPtr, protocol->Length);
			Handle->filename[protocol->Length] = 0;
			Marshal::FreeHGlobal(IntPtr(protoPtr));		
			Utility::FormatStreamMap[protocol] = nullptr;	
		}

		AvStream^ AvFormatContext::AddAudioStream(CodecId codec)
		{
			AvStream^ str = gcnew AvStream(this, streamId++);
			str->CodecContext->Id = codec;
			str->CodecContext->Type = CodecType::Audio;
			return str;
		}

		AvStream^ AvFormatContext::AddVideoStream(CodecId codec)
		{
			AvStream^ str = gcnew AvStream(this, streamId++);
			str->CodecContext->Id = codec;
			str->CodecContext->Type = CodecType::Video;
			return str;
		}

		void AvFormatContext::Cleanup(bool disposing)
		{
			Utility::FormatStreamMap->Remove(gcnew String(Handle->filename));
			if(opened)
				av_close_input_file((AVFormatContext*)this);
			else if(needExplicitFree)
				av_free(Handle);
			Cleaned = true;
		}

		void AvFormatContext::Close()
		{
			av_close_input_file((AVFormatContext*)this);
			opened = false;
		}

		AvFormatContext^ AvFormatContext::Open(String^ file)
		{
			Utility::Initialize();
			AVFormatContext* pFormatCtx;
			char* filename = (char*)(void*)Marshal::StringToHGlobalAnsi(file);
			if(av_open_input_file(&pFormatCtx, filename, NULL, 0, NULL) != 0)
				throw gcnew System::IO::FileNotFoundException("Couldn't open file " + file);
			Marshal::FreeHGlobal(IntPtr(filename));
			return gcnew AvFormatContext(pFormatCtx);
		}

		array<AvStream^>^ AvFormatContext::GetStreams()
		{
			av_find_stream_info(Handle);

			List<AvStream^>^ streams = gcnew List<AvStream^>(20);
			for(int i = 0 ; i < MAX_STREAMS; i++)
			{
				AVStream* stream = Handle->streams[i];
				if(stream != NULL)
				{
					streamId = stream->id + 1;
					streams->Add(gcnew AvStream(stream));
				}
			}
			return streams->ToArray();
		}

		void AvFormatContext::WritePacket(AvPacket^ packet, AvStream^ destStream)
		{
			//packet->PresentationTime = av_rescale_q(destStream->CodecContext->CodedFrame->PresentationTimeStamp, 
			//	(AVRational)destStream->CodecContext->TimeBase, (AVRational)destStream->TimeBase);
			int result = av_write_frame(Handle, (AVPacket*)packet);
			if(result < 0)
				throw gcnew Exception();
		}

		AvPacket^ AvFormatContext::ReadFrame(AvStream^ stream)
		{
			AvPacket^ final = gcnew AvPacket();
			if(av_read_frame(this->Handle, (AVPacket*)final) != 0)
				return nullptr;
			return final;
		}

		String^ AvFormatContext::ToString()
		{
			dump_format(Handle, 0, Handle->filename, true);
			return "FormatContext";
		}

		void AvFormatContext::WriteHeader()
		{
			//int result = av_set_parameters((AVFormatContext*)this, NULL);
			bool x= (!(Handle->oformat->flags & AVFMT_NOFILE)) ;
			if(x)
			{
				if (url_fopen(&Handle->pb, Handle->filename, URL_WRONLY) < 0) {
					throw gcnew Exception();
				}
			}
			int result = av_write_header(Handle);
			if(result < 0)
				throw gcnew IOException();
		}

		void AvFormatContext::WriteTrailer()
		{
			av_write_trailer(Handle);
			url_fclose(&Handle->pb);
		}

		void AvFormatContext::SetParameters()
		{
			int result = av_set_parameters(Handle, NULL);
			if(result != 0)
				throw gcnew Exception();
		}
	}
}
