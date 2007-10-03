#include "StdAfx.h"
#include "AvFrame.h"
#include "AvCodecContext.h"

namespace Multimedia
{
	namespace FFmpeg
	{
		AvFrame::AvFrame(void)
			: NativeWrapper(avcodec_alloc_frame())
		{ }

		void AvFrame::ConvertToBitmap(AvCodecContext^ context)
		{
			AvFrame^ final = gcnew AvFrame();
			int count = avpicture_get_size(PIX_FMT_ARGB, context->Width, context->Height);
			uint8_t *buffer = new uint8_t[count];
			
			avpicture_fill((AVPicture*)final, buffer, PIX_FMT_ARGB, context->Width, context->Height);

			SwsContext* swsContext = sws_getContext(context->Width, context->Height, context->PictureFormat, 
				context->Width, context->Height, PIX_FMT_ARGB, SWS_BICUBIC, NULL, NULL, NULL);
			if(swsContext == NULL)
				throw gcnew Exception();
			sws_scale(swsContext, this->Handle->data, Handle->linesize, 0, context->Height, final->Handle->data, final->Handle->linesize);
			
			//img_convert((AVPicture*)final, PIX_FMT_ARGB, (AVPicture*)this, context->PictureFormat, context->Width, context->Height);
			delete[] buffer;
		}
	}
}
