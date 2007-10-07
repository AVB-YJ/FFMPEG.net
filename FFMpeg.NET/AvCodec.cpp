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
		{ }

		AvCodec::AvCodec(AVCodec* codec, AvCodecContext^ context)
			: NativeWrapper(codec)
		{
			this->context = context;
		}

		void AvCodec::Cleanup(bool disposing)
		{
			if(!Cleaned) 
			{
				if(disposing && context != nullptr)
				{
					delete context;
					context = nullptr;
				}
				Cleaned = true;
			}
		}

		String^ AvCodec::Name::get()
		{
			return gcnew String(Handle->name);
		}

		AvCodecContext^ AvCodec::Context::get()
		{
			return this->context;
		}

		void AvCodec::Open()
		{
			if(this->context == nullptr)
				throw gcnew InvalidOperationException("Invalid context.");
			if(avcodec_open((AVCodecContext*)context, (AVCodec*)this) < 0)
				throw gcnew Exception("Could not open codec.");
			opened = true;
		}

		AvSamples^ AvCodec::DecodeAudio(AvPacket^ packet)
		{
			if(!opened)
				throw gcnew InvalidOperationException("This codec is not open yet.");
			array<int16_t>^ outputBuffer = gcnew array<int16_t>((AVCODEC_MAX_AUDIO_FRAME_SIZE * 3) / 2);

			pin_ptr<int16_t> samplePtr = &outputBuffer[0];
			int length = outputBuffer->Length * sizeof(int16_t);
			uint8_t* rawData = NULL;

			pin_ptr<uint8_t> inputPtr = &packet->Data[0];

			int decoded = avcodec_decode_audio2((AVCodecContext*)context, samplePtr, &length, inputPtr, packet->Data->Length);
			array<int16_t>^ final = gcnew array<int16_t>(length / sizeof(int16_t));
			Array::Copy(outputBuffer, final, final->Length);

			if(context->Handle->sample_fmt != SAMPLE_FMT_S16)
				throw gcnew Exception("Sample type mismatch.");

			return gcnew AvSamples(final, context->Channels, context->SampleRate);
		}

		AvFrame^ AvCodec::DecodeVideo(AvPacket^ packet)
		{
			if(!opened)
				throw gcnew InvalidOperationException("This codec is not open yet.");

			int frame_finished;
			AvFrame^ finishedFrame = gcnew AvFrame(context->PictureFormat, context->Width, context->Height);
			pin_ptr<uint8_t> dataPtr = &packet->Data[0];

			int result = avcodec_decode_video((AVCodecContext*)context, (AVFrame*)finishedFrame, &frame_finished, dataPtr, packet->Data->Length);
			if(result < 0)
				Console::WriteLine("Error");
			if(frame_finished == 0)
				return nullptr;
			return finishedFrame;
		}

		int AvCodec::DecodeSubtitle()
		{
			if(!opened)
				throw gcnew InvalidOperationException("This codec is not open yet.");
			return 0;
		}

		AvPacket^ AvCodec::EncodeAudio(AvSamples^ samples)
		{
			array<uint8_t>^ buffer = gcnew array<uint8_t>(FF_MIN_BUFFER_SIZE);

			pin_ptr<uint8_t> bufferPtr = &buffer[0];
			pin_ptr<int16_t> samplePtr = &samples->ShortSamples[0];

			int nBytes = avcodec_encode_audio((AVCodecContext*)context, 
				bufferPtr, buffer->Length, samplePtr);

			if(nBytes < 0)
				throw gcnew Exception();

			Array::Resize<uint8_t>(buffer, nBytes);
			return gcnew AvPacket(buffer);
		}

		void AvCodec::Close()
		{
			if(!opened)
				throw gcnew InvalidOperationException("This codec is not open yet.");
			avcodec_close((AVCodecContext*)context);
		}

		AvCodec^ AvCodec::FindEncoder(CodecId id)
		{
			AVCodec* codec = avcodec_find_encoder((::CodecID)id);
			if(codec == NULL)
				return nullptr;
			AvCodec^ codecManaged = gcnew AvCodec(codec);
			AvCodecContext^ context = gcnew AvCodecContext();
			codecManaged->context = context;
			return codecManaged;
		}

		AvCodec^ AvCodec::FindEncoder(String^ name)
		{
			return nullptr;
		}
	}
}