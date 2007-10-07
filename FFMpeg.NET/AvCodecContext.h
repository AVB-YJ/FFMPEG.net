#pragma once

#include "AvCodec.h"
#include "NativeWrapper.h"
#include "AvOutputFormat.h"
#include "AvRational.h"
#include "AvFrame.h"

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
				void set(int value) { Handle->bit_rate = value; }
			}

			property int Channels
			{
				int get() { return Handle->channels; }
				void set(int value) { Handle->channels = value; }
			}

			property int SampleRate
			{
				int get() { return Handle->sample_rate; }
				void set(int value) { Handle->sample_rate = value; }
			}

			property int BitrateTolerance
			{
				int get();
			}

			property int FrameSize
			{
				int get() { return Handle->frame_size; }
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
			internal: void set(CodecType value) { this->Handle->codec_type = (::CodecType)value; }
			}

			property MotionEstimation MotionEstimationMethod
			{
				MotionEstimation get();
			}

			property CodecId Id
			{
				CodecId get() { return (CodecId)(Handle->codec_id); }
			internal: void set(CodecId value) { this->Handle->codec_id = (CodecID)value; }
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

			property AvRational^ TimeBase
			{
				AvRational^ get() { return gcnew AvRational(&Handle->time_base); }
			}

			property AvFrame^ CodedFrame { AvFrame^ get() { return gcnew AvFrame(Handle->coded_frame); } } 

			AvCodecContext();

			AvCodec^ GetDecoder();
			AvCodec^ GetEncoder();

		protected:
			virtual void Cleanup(bool disposing) override;

		internal:
			AvCodecContext(AVCodecContext*);

		private:
			bool needFree;
		};
	}
}