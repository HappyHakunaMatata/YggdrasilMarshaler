using System.Runtime.InteropServices;
using System.Text;

namespace YggdrasilMarshaler.Models
{
    public class YggdrasilSafeHandle : SafeHandle
    {

       

        public YggdrasilSafeHandle(string path) : base(IntPtr.Zero, true)
        {
            byte[] stringBytes = Encoding.ASCII.GetBytes(path + '\0');
            IntPtr memory = Marshal.AllocHGlobal(stringBytes.Length);
            Marshal.Copy(stringBytes, 0, memory, stringBytes.Length);
            SetHandle(memory);
        }

        public YggdrasilSafeHandle(IntPtr handle, bool ownsHandle) : this(ownsHandle)
        {
            SetHandle(handle);
        }

        public YggdrasilSafeHandle() : this(true)
        { }


        private YggdrasilSafeHandle(bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        { }

        override protected bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(handle);
            return true;
        }

        public static YggdrasilSafeHandle InvalidHandle => new(false);

        public override bool IsInvalid => handle == IntPtr.Zero;

        public string? GetString()
        {
            if (IsInvalid)
            {
                throw new InvalidOperationException("Invalid handle");
            }
            return Marshal.PtrToStringUTF8(handle);
        }
    }
}

