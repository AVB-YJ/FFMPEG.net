using System;
using System.Runtime.InteropServices;
namespace Multimedia
{
    internal class NativeWrapper<T> 
    {
        private T handle;
        private IntPtr ptr;

        internal NativeWrapper()
        {
        }

        internal NativeWrapper (IntPtr ptr)
        {
            this.ptr = ptr;
        }

        internal T Handle
        {
            get
            {
                if (ptr != IntPtr.Zero)
                    handle = (T)Marshal.PtrToStructure(ptr, typeof(T));
                return handle;
            }
            set
            {
                handle = value;
                Marshal.StructureToPtr(handle, ptr, true);
            }
        }
        internal IntPtr Ptr
        {
            get{return ptr;}
            set
            {
                this.ptr = value;
            }
        }


    }
}

