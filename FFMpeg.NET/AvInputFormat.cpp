#include "StdAfx.h"

#include <memory.h>

#include "AvInputFormat.h"
#include "Utility.h"

using namespace System::IO;
using namespace System::Runtime::InteropServices;

namespace Multimedia
{
	namespace FFmpeg
	{
		AvInputFormat::AvInputFormat(AVInputFormat* format)
			: NativeWrapper(format)
		{
		}

		AvInputFormat^ AvInputFormat::GuessInputFormat(String ^fname)
		{
			Utility::Initialize();
			AVProbeData data, *dataPtr = &data;
			ByteIOContext pb, *pbPtr = &pb;
			AVInputFormat* format;
			String^ formatted = String::Format("DotNet:{0}", fname);
			char* ptr = (char*)Marshal::StringToHGlobalAnsi(formatted).ToPointer();

			url_fopen(pbPtr, ptr, URL_RDONLY);

			int probemin = 2048, probemax = 1 << 20;
			dataPtr->buf = (uint8_t*)av_malloc(probemin);
			for(int probe = probemin; probe < probemax; probe <<= 1)
			{
				dataPtr->buf = (uint8_t*)av_realloc(dataPtr->buf, probe + AVPROBE_SCORE_MAX);
				dataPtr->buf_size = get_buffer(pbPtr, dataPtr->buf, probe);
				memset(dataPtr->buf + dataPtr->buf_size, 0, AVPROBE_PADDING_SIZE);
				if(url_fseek(pbPtr, 0, SEEK_SET) < 0)
				{
					url_fclose(pbPtr);
					if(url_fopen(pbPtr, ptr, URL_RDONLY) < 0)
						return nullptr;
				}
				format = av_probe_input_format(dataPtr, 1);
				if(format != NULL) break;
			}

			Marshal::FreeHGlobal(IntPtr(ptr));
			return gcnew AvInputFormat(format);
		}
	}
}
