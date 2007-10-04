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
				int get() { return Handle->bit_rate; }
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

			property CodecId Id
			{
				CodecId get() { return (CodecId)(Handle->codec_id); }
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

			AvCodecContext();

			AvCodec^ GetCodec();

		protected:
			virtual void Cleanup(bool disposing) override;

		internal:
			AvCodecContext(AVCodecContext*);

		private:
			bool needFree;
		};
	}
}