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
		AvFrame::AvFrame(void)
			: NativeWrapper(avcodec_alloc_frame())
		{ }

		Bitmap^ AvFrame::ConvertToBitmap(AvCodecContext^ context)
		{
			AvFrame^ final = gcnew AvFrame();
			int dst_fmt = PIX_FMT_RGB24;
			/*
			avpicture_layout((AVPicture*)this, context->PictureFormat, context->Width, context->Height, buffer, count);

			Stream^ str = File::OpenWrite("C:\\out.bmp");
			str->Write(bufferArr, 0, count);
			str->Close();
			return nullptr;
			*/
			int count = avpicture_get_size(dst_fmt, context->Width, context->Height);

			array<uint8_t>^ bufferArr = gcnew array<uint8_t>(count);
			pin_ptr<uint8_t> buffer = &bufferArr[0];
			
			avpicture_fill((AVPicture*)final, buffer, dst_fmt, context->Width, context->Height);

			SwsContext* swsContext = sws_getContext(context->Width, context->Height, context->PictureFormat, 
				context->Width, context->Height, dst_fmt, SWS_BICUBIC, NULL, NULL, NULL);
			if(swsContext == NULL)
				throw gcnew Exception();
			sws_scale(swsContext, this->Handle->data, Handle->linesize, 0, context->Height, final->Handle->data, final->Handle->linesize);
			
			/*
			Stream^ str2 = File::OpenWrite("C:\\out.ppm");

			String^ header = String::Format("P6\n{0} {1}\n255\n", context->Width, context->Height);
			str2->Write(Encoding::ASCII->GetBytes(header), 0, Encoding::ASCII->GetByteCount(header));
			str2->Write(bufferArr, 0, count);
			for(int y = 0; y < context->Height; y++)
			{
				for(int x = 0; x < context->Width * 3; x++)
				{
					str2->WriteByte(buffer[0 + y * final->Handle->linesize[0] + x]);
				}
			}
			str2->Close();
			*/

			Stream^ str = gcnew MemoryStream();
			BinaryWriter^ writer = gcnew BinaryWriter(str);
			// LITTLE ENDIAN!!
			writer->Write(gcnew array<uint8_t> { 0x42, 0x4D });
			writer->Write((int32_t)(count + 0x36));
			writer->Write((int32_t)0);
			writer->Write((int32_t)0x36);
			writer->Write((int32_t)40);
			writer->Write((int32_t)context->Width);
			writer->Write((int32_t)context->Height);
			writer->Write((int16_t)1);
			writer->Write((int16_t)24);
			writer->Write((int32_t)0);
			writer->Write((int32_t)count);
			writer->Write((int32_t)3780);
			writer->Write((int32_t)3780);
			writer->Write((int32_t)0);
			writer->Write((int32_t)0);
			Array::Reverse(bufferArr);
			writer->Write(bufferArr);
			writer->Flush();
			writer->Seek(0, SeekOrigin::Begin);

			// Stream^ str = gcnew MemoryStream(bufferArr);
			Bitmap^ bitmap = gcnew Bitmap(str);
			return bitmap;
			// final->Free();
		}
	}
}
