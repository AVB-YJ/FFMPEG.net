#pragma once

using namespace System;
using namespace System::IO;
using namespace System::Collections::Generic;

namespace Multimedia
{
	namespace FFmpeg
	{
		ref class AvFormatContext; // forward

		ref class Utility
		{
		public:
			static void Initialize();

		internal:
			static property Dictionary<String^, Stream^>^ FormatStreamMap
			{
				Dictionary<String^, Stream^>^ get() { return fmtMap; }
			}

		private:
			static Dictionary<String^, Stream^>^ fmtMap;
			static bool Initialized;
		};
	}
}
