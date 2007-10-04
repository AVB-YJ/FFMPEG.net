#pragma once

#include "NativeWrapper.h"

using namespace System::Drawing;

namespace Multimedia
{
	namespace FFmpeg
	{
		ref class AvCodecContext; // forward declaration

		public enum class FrameFormat
		{
			None = -1,
			PlanarYUV420,
			PlanarYUVv422,
			PackedRGB24,
			PackedBGR24,
			PlanarYUV422,
			PlanarYUV444,
			PackedRGB32,
			PlanarYUV410,
			PackedYUV411,
			PackedRGB565,
			PackedRGB555,
			Grayscale8,
			MonoscaleWhite,
			MonoscaleBlack,
			PAL8,
			PlanarYUV420Jpeg,
			PlanarYUV422Jpeg,
			PlanarYUV444Jpeg,
			XVideoMotionMpeg2MC,
			XvideoMotionMpeg2IDCT,
			PackedYUV422UYVY,
			PackedYUV411UYYVYY,
			PackedBGR32,
			PackedBGR565,
			PackedBGR555,
			PackedBGR8,
			PackedBGR4,
			PackedBGR4Byte,
			PackedRGB8,
			PackedRGB4,
			PackedRGB4Byte,
			NV12,
			NV21,
			PackedRGB32_1,
			PackedBGR32_1,
			Grayscale16BigEndian,
			Grayscale16LittleEndian
		};

		public ref class AvFrame : NativeWrapper<AVFrame>
		{
		internal:
			AvFrame(int format, int width, int height);
			AvFrame(int format, Size size);
		public:
			property FrameFormat Format
			{
				FrameFormat get() { return format; }
			}

			property System::Drawing::Size Size
			{
				System::Drawing::Size get() { return size; }
			}

			property int Width
			{
				int get() { return size.Width; }
			}

			property int Height
			{
				int get() { return size.Height; }
			}

			Bitmap^ ConvertToBitmap();

			explicit operator AVPicture*() { return (AVPicture*)this->Handle; }

		protected:
			virtual void Cleanup(bool disposing) override;

		private:
			FrameFormat format;
			System::Drawing::Size size;
		};
	}
}