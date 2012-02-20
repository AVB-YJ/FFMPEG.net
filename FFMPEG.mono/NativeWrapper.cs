using System;
using System.Runtime.InteropServices;
namespace Multimedia
{
    public class NativeWrapper<T> 
    {
        private T handle;
        private IntPtr ptr;
        internal NativeWrapper (IntPtr ptr)
        {
            this.ptr = ptr;
            if( ptr != IntPtr.Zero )    
                handle = (T)Marshal.PtrToStructure( ptr, typeof(T));

        }
        internal T Handle
        {
            get
            {
                return handle;
            }
        }
        internal IntPtr Ptr
        {
            get{return ptr;}
        }
    }
}

