using System;
using System.Runtime.InteropServices;
namespace Multimedia
{
    public class Native<T> 
    {
        private T handle;
        private IntPtr ptr;

        public Native()
        {
        }

        public Native(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public T Handle
        {
            get
            {
                if (ptr != IntPtr.Zero)
                {
                    try
                    {
                        handle = (T)Marshal.PtrToStructure(ptr, typeof(T));
                    }
                    catch (Exception)
                    {
                    }
                }
                return handle;
            }
            set
            {
                handle = value;
                Marshal.StructureToPtr(handle, ptr, true);
            }
        }
        public IntPtr Ptr
        {
            get{return ptr;}
            set
            {
                this.ptr = value;
            }
        }


    }
}

