#include "StdAfx.h"
#include "AvCodec.h"
#include "AvCodecContext.h"

using namespace System::Runtime::InteropServices;

namespace Multimedia
{
	namespace FFmpeg
	{
		AvCodec::AvCodec(AVCodec* codec)
		: NativeWrapper(codec)
		{
			RawData = gcnew array<uint8_t>(sizeof(AVCodec));
			Marshal::Copy(IntPtr((void*)codec), RawData, 0, sizeof(AVCodec));
		}

		String^ AvCodec::Name::get()
		{
			pin_ptr<uint8_t> ptr = &RawData[0];
			AVCodec* codec = (AVCodec*)ptr;
			return gcnew String(codec->name);
		}

		AvCodecContext^ AvCodec::Context::get()
		{
			return this->context;
		}

		void AvCodec::Open(AvCodecContext^ context)
		{
			if(this->context != nullptr)
				throw gcnew InvalidOperationException("This codec is already open in another context.");
			avcodec_open((AVCodecContext*)context, (AVCodec*)this);
			this->context = context;
		}

		array<int16_t>^ AvCodec::DecodeAudio(AvPacket^ packet)
		{
			if(this->context == nullptr)
				throw gcnew InvalidOperationException("This is not open yet.");
			array<int16_t>^ outputBuffer = gcnew array<int16_t>((AVCODEC_MAX_AUDIO_FRAME_SIZE * 3) / 2);

			pin_ptr<int16_t> samplePtr = &outputBuffer[0];
			int length = outputBuffer->Length * sizeof(int16_t);
			uint8_t* rawData = NULL;

			pin_ptr<uint8_t> inputPtr = &packet->Data[0];

			int decoded = avcodec_decode_audio2((AVCodecContext*)context, samplePtr, &length, inputPtr, packet->Data->Length);
			array<int16_t>^ final = gcnew array<int16_t>(length / sizeof(int16_t));
			Array::Copy(outputBuffer, final, final->Length);
			return final;
		}

		AvFrame^ AvCodec::DecodeVideo(AvPacket^ packet)
		{
			int frame_finished;
			AvFrame^ finishedFrame = gcnew AvFrame();
			pin_ptr<uint8_t> dataPtr = &packet->Data[0];

			int result = avcodec_decode_video((AVCodecContext*)context, (AVFrame*)finishedFrame, &frame_finished, dataPtr, packet->Data->Length);
			if(result < 0)
				Console::WriteLine("Error");
			//	throw gcnew Exception("An error occured.");

			if(frame_finished == 0)
				return nullptr;
			return finishedFrame;
		}

		int AvCodec::DecodeSubtitle()
		{
			return 0;
		}

		void AvCodec::Close()
		{
			avcodec_close((AVCodecContext*)context);
			this->context = nullptr;
		}
	}
}