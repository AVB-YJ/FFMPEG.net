using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace SharpFFmpeg
{
    internal class NativeGetter<T>
    {
        private IntPtr ptr = IntPtr.Zero;

        internal NativeGetter(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        internal T Get()
        {

            T handle = default(T);
            if (ptr != IntPtr.Zero)
                handle = (T)Marshal.PtrToStructure(ptr, typeof(T));
            else
                throw new Exception("Can not get data from null pointer");
            return handle;
        }
    }

    internal class NativeSetter<T>
    {
        private IntPtr ptr = IntPtr.Zero;

        internal NativeSetter(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        internal void Set(T val)
        {
            Marshal.StructureToPtr(val, ptr, true);
        }
    }
}
