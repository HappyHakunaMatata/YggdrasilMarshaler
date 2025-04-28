using System.Runtime.InteropServices;
using System.Reflection;

namespace YggdrasilMarshaler.Models
{
	public static class DllImportResolver
	{
        public static void SetDllImportResolver()
		{
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), Resolve);
        }

        private static IntPtr Resolve(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (!string.IsNullOrEmpty(libraryName)) 
            {
                string basePath = Path.Combine(GetRootDirectory(), "wwwroot", "Library");
                string fileName = GetPlatformSpecificLibraryName(libraryName);
                string fullPath = Path.Combine(basePath, fileName);

                if (File.Exists(fullPath))
                {
                    return NativeLibrary.Load(fullPath);
                }
            }
            return IntPtr.Zero;
        }

        private static string GetPlatformSpecificLibraryName(string libraryName)
        {
            if (OperatingSystem.IsWindows())
                return libraryName + ".dll";
            else if (OperatingSystem.IsLinux())
                return libraryName + ".so";
            else if (OperatingSystem.IsMacOS())
                return libraryName + ".dylib";
            else
                throw new PlatformNotSupportedException();
        }

        private static string GetRootDirectory()
        {
            var currentPath = Directory.GetCurrentDirectory();
            while (true)
            {
                var currentDir = new DirectoryInfo(currentPath);
                if (AppDomain.CurrentDomain.FriendlyName == currentDir.Name)
                {
                    return currentPath;
                }
                var parent = currentDir.Parent;
                if (parent == null)
                {
                    return currentPath;
                }
                currentPath = parent.FullName;
            }
        }
    }
}

