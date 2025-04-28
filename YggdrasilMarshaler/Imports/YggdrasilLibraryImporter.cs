#if NET7_0_OR_GREATER
using System.Runtime.InteropServices;
using YggdrasilMarshaler.Models;

namespace YggdrasilMarshaler.Imports
{

    public static partial class YggdrasilLibraryImporter
    {
        
        [LibraryImport("yggdrasillib")]
        public static partial YggdrasilSafeReturnModel Start(IntPtr useconffile = default(IntPtr));

        [LibraryImport("yggdrasillib")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool Exit();

        [LibraryImport("yggdrasillib")]
        public static partial YggdrasilSafeReturnModel GetPkey(IntPtr useconffile);

        [LibraryImport("yggdrasillib")]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string GetBuildName();

        [LibraryImport("yggdrasillib")]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static partial string GetVersion();

        [LibraryImport("yggdrasillib")]
        public static partial YggdrasilSafeReturnModel GetAddress(IntPtr ptr);

        [LibraryImport("yggdrasillib")]
        public static partial YggdrasilSafeReturnModel GetSnet(IntPtr ptr);

        [LibraryImport("yggdrasillib")]
        public static partial YggdrasilSafeReturnModel GetPemKey(IntPtr ptr);

        [LibraryImport("yggdrasillib")]
        public static partial YggdrasilSafeReturnModel GenConfigFile(byte confjson);

        [LibraryImport("yggdrasillib")]
        public static partial YggdrasilSafeReturnModel NormaliseConfing(IntPtr ptr, byte confjson);

        [LibraryImport("yggdrasillib")]
        public static partial void Logto(IntPtr ptr);

        [LibraryImport("yggdrasillib")]
        public static partial YggdrasilSafeReturnModel SetLogLevel(IntPtr ptr);
    }
}

#endif