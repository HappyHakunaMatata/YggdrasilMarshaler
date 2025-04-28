using System.Runtime.InteropServices;
using YggdrasilMarshaler.Models;

namespace YggdrasilMarshaler.Imports
{
	public class YggdrasilDllImporter
    {
        [DllImport("yggdrasillib")]
        public static extern YggdrasilUnsafeReturnStruct Start(IntPtr useconffile = default(IntPtr));

        [DllImport("yggdrasillib")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool Exit();

        [DllImport("yggdrasillib")]
        public static extern YggdrasilUnsafeReturnStruct GetPkey(IntPtr useconffile);

        [DllImport("yggdrasillib")]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static extern string GetBuildName();

        [DllImport("yggdrasillib")]
        [return: MarshalAs(UnmanagedType.LPUTF8Str)]
        public static extern string GetVersion();

        [DllImport("yggdrasillib")]
        public static extern YggdrasilUnsafeReturnStruct GetAddress(IntPtr ptr);

        [DllImport("yggdrasillib")]
        public static extern YggdrasilUnsafeReturnStruct GetSnet(IntPtr ptr);

        [DllImport("yggdrasillib")]
        public static extern YggdrasilUnsafeReturnStruct GetPemKey(IntPtr ptr);

        [DllImport("yggdrasillib")]
        public static extern YggdrasilUnsafeReturnStruct GenConfigFile(byte confjson);

        [DllImport("yggdrasillib")]
        public static extern YggdrasilUnsafeReturnStruct NormaliseConfing(IntPtr ptr, byte confjson);

        [DllImport("yggdrasillib")]
        public static extern void Logto(IntPtr ptr);

        [DllImport("yggdrasillib")]
        public static extern YggdrasilUnsafeReturnStruct SetLogLevel(IntPtr ptr);
    }
}

