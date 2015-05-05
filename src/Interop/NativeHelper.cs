using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpFFmpeg
{
    public class Native<T> : IDisposable
    {
        private IntPtr ptr = IntPtr.Zero;
        private T obj = default(T);

        public Native(T obj)
        {
            ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(obj));
            Marshal.StructureToPtr(obj, ptr, true);
        }

        public Native(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public IntPtr P
        {
            get { return ptr; }
            set { ptr = value; }
        }

        public T O
        {
            get
            {
                return (T)Marshal.PtrToStructure(ptr, obj.GetType());
            }
            set
            {
                obj = value;
                if (ptr != IntPtr.Zero)
                    Marshal.StructureToPtr(obj, ptr, false);
            }
        }

        public void Dispose()
        {
            if (ptr != IntPtr.Zero)
                Marshal.FreeCoTaskMem(ptr);
        }
    }
}
