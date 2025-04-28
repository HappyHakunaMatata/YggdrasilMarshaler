#if NET7_0_OR_GREATER
using Microsoft;
using YggdrasilMarshaler.Imports;

namespace YggdrasilMarshaler.Models
{
    public static class YggdrasilWrapper
    {
        public static YggdrasilSafeReturnModel NormaliseConfing(YggdrasilSafeHandle handle, byte confjson)
        {
            Requires.NotNull(handle, nameof(handle));
            return YggdrasilLibraryImporter.NormaliseConfing(handle.DangerousGetHandle(), confjson);
        }

        public static YggdrasilSafeReturnModel GetAddress(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            return YggdrasilLibraryImporter.GetAddress(handle.DangerousGetHandle());
        }

        public static YggdrasilSafeReturnModel GetSnet(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            return YggdrasilLibraryImporter.GetSnet(handle.DangerousGetHandle());
        }

        public static YggdrasilSafeReturnModel GetPemKey(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            return YggdrasilLibraryImporter.GetPemKey(handle.DangerousGetHandle());
        }

        public static YggdrasilSafeReturnModel GetPkey(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            return YggdrasilLibraryImporter.GetPkey(handle.DangerousGetHandle());
        }


        public static YggdrasilSafeReturnModel SetLogLevel(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            return YggdrasilLibraryImporter.SetLogLevel(handle.DangerousGetHandle());
        }

        public static YggdrasilSafeReturnModel Start(YggdrasilSafeHandle? handle = null)
        {
            return YggdrasilLibraryImporter.Start(handle?.DangerousGetHandle() ?? IntPtr.Zero);
        }

        public static void Logto(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            YggdrasilLibraryImporter.Logto(handle.DangerousGetHandle());
        }
    }
}

#endif