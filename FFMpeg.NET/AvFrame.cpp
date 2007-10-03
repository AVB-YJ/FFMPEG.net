#include "StdAfx.h"
#include "AvFrame.h"
#include "AvCodecContext.h"

using namespace System;
using namespace System::IO;
using namespace System::Text;

namespace Multimedia
{
	namespace FFmpeg
	{
		AvFrame::AvFrame(int format, int width, int height)
			: NativeWrapper(avcodec_alloc_frame())
		{ 
			this->format = (FrameFormat)format;
			this->size = System::Drawing::Size(width, height);
		}

		AvFrame::AvFrame(int format, System::Drawing::Size size)
			: NativeWrapper(avcodec_alloc_frame())
		{ 
			this->format = (FrameFormat)format;
			this->size = size;
		}

		AvFrame::~AvFrame()
		{
			av_free(this->Handle);
		}

		Bitmap^ AvFrame::ConvertToBitmap()
		{
			AvFrame^ final = gcnew AvFrame(PIX_FMT_BGR24, this->size);
			int dst_fmt = (int)final->Format;
			int count = avpicture_get_size(dst_fmt, this->Width, this->Height);

			array<uint8_t>^ bufferArr = gcnew array<uint8_t>(count);
			pin_ptr<uint8_t> buffer = &bufferArr[0];
			
			avpicture_fill((AVPicture*)final, buffer, dst_fmt, Width, Height);

			SwsContext* swsContext = sws_getContext(Width, Height, (int)Format, 
				Width, Height, dst_fmt, SWS_BICUBIC, NULL, NULL, NULL);
			if(swsContext == NULL)
				throw gcnew Exception();
			sws_scale(swsContext, this->Handle->data, Handle->linesize, 0, Height, final->Handle->data, final->Handle->linesize);

			Stream^ str = gcnew MemoryStream();
			BinaryWriter^ writer = gcnew BinaryWriter(str);
			// LITTLE ENDIAN!!
			writer->Write(gcnew array<uint8_t> { 0x42, 0x4D });
			writer->Write((int32_t)(count + 0x36));
			writer->Write((int32_t)0);
			writer->Write((int32_t)0x36);
			writer->Write((int32_t)40);
			writer->Write((int32_t)Width);
			writer->Write((int32_t)Height);
			writer->Write((int16_t)1);
			writer->Write((int16_t)24);
			writer->Write((int32_t)0);
			writer->Write((int32_t)count);
			writer->Write((int32_t)3780);
			writer->Write((int32_t)3780);
			writer->Write((int32_t)0);
			writer->Write((int32_t)0);
			// Array::Reverse(bufferArr);
			for(int y = Height - 1; y >= 0; y--)
				writer->Write(bufferArr, y * final->Handle->linesize[0], Width * 3);
			writer->Flush();
			writer->Seek(0, SeekOrigin::Begin);

			Bitmap^ bitmap = gcnew Bitmap(str);
			return bitmap;
		}
	}
}
