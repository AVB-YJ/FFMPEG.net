#pragma once

using namespace System;

namespace Multimedia
{
	namespace FFmpeg
	{
		template<typename T>
		public ref class NativeWrapper
		{
		public:
			
		internal:
			NativeWrapper(T* ptr)
			{
				handle = ptr;
			}

			!NativeWrapper()
			{
				Cleanup(false);
			}

			~NativeWrapper()
			{
				Cleanup(true);
				GC::SuppressFinalize(this);
			}

			explicit operator T*()
			{
				return handle;
			}

			property T* Handle 
			{
				T* get() { return handle; }
			}

		protected:
			bool Cleaned;
			virtual void Cleanup(bool disposing) { Cleaned = true; }


		private:
			T* handle;
		};
	}
}