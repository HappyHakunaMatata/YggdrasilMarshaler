#if NET7_0_OR_GREATER
using YggdrasilMarshaler.Imports;
using YggdrasilMarshaler.Interfaces;
using YggdrasilMarshaler.Models;

namespace YggdrasilMarshaler.Services
{
    public class YggdrasilService: IYggdrasilService
    {

        public YggdrasilService()
        {
            DllImportResolver.SetDllImportResolver();
        }

        public Tuple<int, string?> NormaliseConfing(string path = "yggdrasil.conf", bool json = true)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            byte convertedByte = json ? (byte)1 : (byte)0;
            using var pathHandle = new YggdrasilSafeHandle(path);
            YggdrasilSafeReturnModel textptr = YggdrasilWrapper.NormaliseConfing(pathHandle, convertedByte);
            using var handle = textptr.safeHandle;
            return new Tuple<int, string?>(textptr.err_code, handle.GetString());
        }

        
        public Tuple<int, string?> GetIPAddress(string path = "yggdrasil.conf")
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path); 
            }
            using var pathHandle = new YggdrasilSafeHandle(path);
            YggdrasilSafeReturnModel textptr = YggdrasilWrapper.GetAddress(pathHandle);
            using var handle = textptr.safeHandle;
            return new Tuple<int, string?>(textptr.err_code, handle.GetString());
        }

        public Tuple<int, string?> GetPemKey(string path = "yggdrasil.conf")
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            using var pathHandle = new YggdrasilSafeHandle(path);
            YggdrasilSafeReturnModel textptr = YggdrasilWrapper.GetPemKey(pathHandle);
            using var handle = textptr.safeHandle;
            return new Tuple<int, string?>(textptr.err_code, handle.GetString());
        }

        public Tuple<int, string?> GetPrivateKey(string path = "yggdrasil.conf")
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            using var pathHandle = new YggdrasilSafeHandle(path);
            YggdrasilSafeReturnModel textptr = YggdrasilWrapper.GetPkey(pathHandle);
            using var handle = textptr.safeHandle;
            return new Tuple<int, string?>(textptr.err_code, handle.GetString());
        }


        public Tuple<int, string?> GetSnet(string path = "yggdrasil.conf")
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            using var pathHandle = new YggdrasilSafeHandle(path);
            YggdrasilSafeReturnModel textptr = YggdrasilWrapper.GetPkey(pathHandle);
            using var handle = textptr.safeHandle;
            return new Tuple<int, string?>(textptr.err_code, handle.GetString());
        }
        
        public string Version()
        {
            string IPv6 = YggdrasilLibraryImporter.GetVersion();
            return IPv6;
        }
        
        public string BuildName()
        {
            string name = YggdrasilLibraryImporter.GetBuildName();
            return name;
        }
        
        

        public Tuple<int, string?> Genconf(bool json = true)
        {
            byte convertedByte = json ? (byte)1 : (byte)0;
            var model = YggdrasilLibraryImporter.GenConfigFile(convertedByte);
            using var handle = model.safeHandle;
            return new Tuple<int, string?>(model.err_code, handle.GetString());
        }
        
        public IYggdrasilService Logto(Logs log = Logs.custom, string path = "")
        {
            string _path = "";
            if (log == Logs.custom)
            {
                _path = path;
            }
            else
            {
                _path = log.ToString();
            }
            using var pathHandle = new YggdrasilSafeHandle(_path);
            YggdrasilWrapper.Logto(pathHandle);
            return this;
        }

        
        
        public Tuple<int, string?> RunYggdrasilAsync(string? path)
        {
            YggdrasilSafeHandle? handle = null;
            if (path != null && File.Exists(path))
            {
                handle = new YggdrasilSafeHandle(path);
            }
            else
            {
                handle = new YggdrasilSafeHandle();
            }
            var task = YggdrasilWrapper.Start(handle);
            using var result = task.safeHandle;
            return new Tuple<int, string?>(task.err_code, result.GetString());
        }

        public Tuple<int, string?> SetLogLevel(LogLevels logLevel = LogLevels.error)
        {
            using var pathHandle = new YggdrasilSafeHandle(logLevel.ToString());
            YggdrasilSafeReturnModel textptr = YggdrasilWrapper.SetLogLevel(pathHandle);
            using var handle = textptr.safeHandle;
            return new Tuple<int, string?>(textptr.err_code, handle.GetString());
        }

        public bool ExitYggdrasil()
        {
            return YggdrasilLibraryImporter.Exit();
        }

        
    }
}

#endif