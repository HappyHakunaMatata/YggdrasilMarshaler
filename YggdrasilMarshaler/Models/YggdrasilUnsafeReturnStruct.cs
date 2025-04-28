using System.Runtime.InteropServices;

namespace YggdrasilMarshaler.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct YggdrasilUnsafeReturnStruct
	{
        public int errCode;
        public IntPtr safeHandle;
    }
}

