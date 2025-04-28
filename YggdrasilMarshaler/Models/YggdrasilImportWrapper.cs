using Microsoft;
using YggdrasilMarshaler.Imports;

namespace YggdrasilMarshaler.Models
{
    public static class YggdrasilImportWrapper
    {
        public static YggdrasilSafeModel NormaliseConfing(YggdrasilSafeHandle handle, byte confjson)
        {
            Requires.NotNull(handle, nameof(handle));
            return new YggdrasilSafeModel(YggdrasilDllImporter.NormaliseConfing(handle.DangerousGetHandle(), confjson));
        }

        public static YggdrasilSafeModel GetAddress(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            return new YggdrasilSafeModel(YggdrasilDllImporter.GetAddress(handle.DangerousGetHandle()));
        }

        public static YggdrasilSafeModel GetSnet(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            return new YggdrasilSafeModel(YggdrasilDllImporter.GetSnet(handle.DangerousGetHandle()));
        }

        public static YggdrasilSafeModel GetPemKey(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            return new YggdrasilSafeModel(YggdrasilDllImporter.GetPemKey(handle.DangerousGetHandle()));
        }

        public static YggdrasilSafeModel GetPkey(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            return new YggdrasilSafeModel(YggdrasilDllImporter.GetPkey(handle.DangerousGetHandle()));
        }


        public static YggdrasilSafeModel SetLogLevel(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            return new YggdrasilSafeModel(YggdrasilDllImporter.SetLogLevel(handle.DangerousGetHandle()));
        }

        public static YggdrasilSafeModel Start(YggdrasilSafeHandle? handle = null)
        {
            return new YggdrasilSafeModel(YggdrasilDllImporter.Start(handle?.DangerousGetHandle() ?? IntPtr.Zero));
        }

        public static void Logto(YggdrasilSafeHandle handle)
        {
            Requires.NotNull(handle, nameof(handle));
            YggdrasilDllImporter.Logto(handle.DangerousGetHandle());
        }

        public static YggdrasilSafeModel GenConfigFile(byte confjson)
        {
            return new YggdrasilSafeModel(YggdrasilDllImporter.GenConfigFile(confjson));
        }
    }
}

