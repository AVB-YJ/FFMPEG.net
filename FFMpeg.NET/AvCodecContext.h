#pragma once

#include "AvCodec.h"
#include "NativeWrapper.h"

namespace Multimedia
{
	namespace FFmpeg
	{
		public enum class MotionEstimation
		{
			Zero
		};

		public enum class CodecType 
		{
			Unknown = -1,
			Video,
			Audio,
			Data,
			Subtitle,
			NB
		};

		public ref class AvCodecContext : NativeWrapper<AVCodecContext>
		{
		public:
			property int Bitrate
			{
				int get(); 
			}

			property int Channels
			{
				int get() { return Handle->channels; }
			}

			property int SampleRate
			{
				int get() { return Handle->sample_rate; }
			}

			property int BitrateTolerance
			{
				int get();
			}

			property int Flags
			{
				int get();
			}

			property int SubId
			{
				int get();
			}

			property CodecType Type
			{
				CodecType get() { return (CodecType)this->Handle->codec_type; }
			}

			property MotionEstimation MotionEstimationMethod
			{
				MotionEstimation get();
			}

			property int CodecId
			{
				int get();
			}

			property int Width
			{
				int get() { return this->Handle->width; }
			}

			property int Height
			{
				int get() { return this->Handle->height; }
			}

			property int PictureFormat
			{
				int get() { return this->Handle->pix_fmt; }
			}

			AvCodec^ GetCodec();
		internal:
			AvCodecContext(AVCodecContext*);
		private:
			array<uint8_t>^ rawData;
		};
	}
}