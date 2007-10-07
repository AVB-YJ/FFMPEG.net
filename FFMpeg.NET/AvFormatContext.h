#pragma once

using namespace System;

#include "AvStream.h"
#include "AvPacket.h"
#include "AvOutputFormat.h"

#include "NativeWrapper.h"
#include "Utility.h"

using namespace System::IO;
using namespace System::Runtime::InteropServices;

namespace Multimedia
{
	namespace FFmpeg
	{
		public ref class AvFormatContext : NativeWrapper<AVFormatContext>
		{
		public:
			property String^ Filename { 
				String^ get() { return gcnew String(Handle->filename); } 
			}

			property Stream^ IOStream
			{
				Stream^ get() { return Utility::FormatStreamMap[this->Filename]; }
				void set(Stream ^val) { Utility::FormatStreamMap[this->Filename] = val; }
			}
			
			property AvOutputFormat^ OutputFormat
			{
				void set(AvOutputFormat^ out)
				{
					this->Handle->oformat = (AVOutputFormat*)out;
					IntPtr x(this->Handle->oformat);
					outFormat = out;
				}

				AvOutputFormat^ get()
				{
					if(outFormat == nullptr && Handle->oformat != NULL)
						outFormat = gcnew AvOutputFormat(Handle->oformat);
					return outFormat;
				}
			}

			AvFormatContext();

			static AvFormatContext^ Open(String^ file);
			array<AvStream^>^ GetStreams();
			virtual String^ ToString() override;
			void Close();

			AvPacket^ ReadFrame(AvStream^ stream);
			AvStream^ AddVideoStream(CodecId codec);
			AvStream^ AddAudioStream(CodecId codec);

			void WritePacket(AvPacket^, AvStream^ destStream);
			
			void WriteHeader();
			void WriteTrailer();

			void SetParameters();

		protected:
			virtual void Cleanup(bool disposing) override;

		private:
			AvFormatContext(AVFormatContext*);
			AvOutputFormat^ outFormat;
			int streamId;
			bool opened;
			bool needExplicitFree;
			Guid id;
		};
	}
}