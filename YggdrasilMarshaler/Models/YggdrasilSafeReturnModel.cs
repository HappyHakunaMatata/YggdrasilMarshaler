#if NET7_0_OR_GREATER
using System.Runtime.InteropServices.Marshalling;
using Microsoft;

namespace YggdrasilMarshaler.Models
{
    [NativeMarshalling(typeof(YggdrasilMarshaller))]
    public sealed class YggdrasilSafeReturnModel
    {
        public int err_code;
        public YggdrasilSafeHandle safeHandle;

        public YggdrasilSafeReturnModel(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            safeHandle = handle;
        }

        public YggdrasilSafeReturnModel() : this(new YggdrasilSafeHandle()) { }
    };
}

#endif
