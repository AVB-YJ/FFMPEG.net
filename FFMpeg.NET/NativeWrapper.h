#pragma once

using namespace System;

namespace Multimedia
{
	namespace FFmpeg
	{
		template<typename T>
		public ref class NativeWrapper
		{
		internal:
			NativeWrapper(T* ptr)
			{
				handle = ptr;
			}

			explicit operator T*()
			{
				return handle;
			}

			property T* Handle 
			{
				T* get() { return handle; }
			}

		private:
			T* handle;
		};
	}
}