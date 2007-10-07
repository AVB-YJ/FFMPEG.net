#include "StdAfx.h"

#define __STDC_CONSTANT_MACROS

#include <avcodec.h>
#include <avformat.h>

#include <msclr\auto_gcroot.h>

#include "Utility.h"
#include "AvFormatContext.h"

URLProtocol protocol;

using namespace System;
using namespace System::IO;
using namespace System::Runtime::InteropServices;

using namespace msclr;

namespace Multimedia
{
	namespace FFmpeg
	{
		// DotNet Streams FFMpeg URL protocol
		int OpenFile(URLContext* context, const char* filename, int mode);
		int WriteStream(URLContext* context, unsigned char*, int);
		offset_t SeekStream(URLContext* context, offset_t, int);
		int CloseStream(URLContext*);
		int ReadStream(URLContext*, uint8_t*, int);

		void Utility::Initialize(void)
		{
			if(Initialized) return;
			av_register_all();

			protocol.name = "DotNet";
			protocol.url_open = &OpenFile;
			protocol.url_write = &WriteStream;
			protocol.url_seek = &SeekStream;
			protocol.url_read = &ReadStream;
			protocol.url_close = &CloseStream;
			register_protocol(&protocol);

			fmtMap = gcnew Dictionary<String^, Stream^>();
			Initialized = true;
		}

		Stream^ GetStream(const char* filename)
		{
			String^ str = gcnew String(filename);
			array<String^>^ strArr = str->Split(':');
			Guid guid(strArr[1]);
			if(!Utility::FormatStreamMap->ContainsKey(str))
				throw gcnew IOException("Internal Error.");
			return Utility::FormatStreamMap[str];
		}

		int OpenFile(URLContext* context, const char* filename, int mode)
		{
			Stream^ stream = nullptr;
			String^ str = gcnew String(filename);
			array<String^>^ fargs = str->Split(gcnew array<wchar_t>{ ':' }, 2);
			if(fargs[1]->Contains("\\") || fargs[1]->Contains(":")) // windows file
			{
				switch(mode)
				{
				case URL_RDONLY:
					stream = File::OpenRead(fargs[1]);
					break;
				case URL_WRONLY:
					stream = File::OpenWrite(fargs[1]);
					break;
				case URL_RDWR:
					stream = File::Open(fargs[1], FileMode::OpenOrCreate);
					break;
				}
				Utility::FormatStreamMap[gcnew String(filename)] = stream;
			}
			else //guid
			{
				stream = Utility::FormatStreamMap[gcnew String(filename)];
			}

			context->is_streamed = !stream->CanSeek;
			//Stream^ x = GetStream(filename);
			if(stream == nullptr)
				throw gcnew IOException("No stream is associated with this context!");
			return 0;
		}

		int ReadStream(URLContext* context, uint8_t* buffer, int size)
		{
			String^ fname = gcnew String(context->filename);
			Stream^ stream = Utility::FormatStreamMap[fname];
			
			array<uint8_t>^ bufferPtr = gcnew array<uint8_t>(size);			
			int read = stream->Read(bufferPtr, 0, size);
			Marshal::Copy(bufferPtr, 0, IntPtr(buffer), read);
			return read;
		}

		int WriteStream(URLContext* context, unsigned char* buffer, int size)
		{
			String^ fname = gcnew String(context->filename);
			Stream^ stream = Utility::FormatStreamMap[fname];
			array<unsigned char>^ data = gcnew array<unsigned char>(size);
			Marshal::Copy(IntPtr(buffer), data, 0, size);
			stream->Write(data, 0, size);
			return size;
		}

		offset_t SeekStream(URLContext* context, offset_t offset, int mode)
		{
			String^ fname = gcnew String(context->filename);
			Stream^ stream = Utility::FormatStreamMap[fname];
			
			if(!stream->CanSeek)
				throw gcnew InvalidOperationException();

			offset_t ret;
			switch(mode)
			{
			case SEEK_SET:
				ret = stream->Seek(offset, SeekOrigin::Begin);
				break;
			case SEEK_CUR:
				ret = stream->Seek(offset, SeekOrigin::Begin);
				break;
			case SEEK_END:
				ret = stream->Seek(offset, SeekOrigin::End);
				break;
			}

			return ret;
		}

		int CloseStream(URLContext* context)
		{ 
			Stream^ stream = GetStream(context->filename);
			stream->Close();
			return 0;
		}
	}
}