
using YggdrasilMarshaler.Imports;
using YggdrasilMarshaler.Interfaces;
using YggdrasilMarshaler.Models;

namespace YggdrasilMarshaler.Services
{
    public class YggdrasilImportService: IYggdrasilService
    {

        public YggdrasilImportService()
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
            var textptr = YggdrasilImportWrapper.NormaliseConfing(pathHandle, convertedByte);
            using var handle = textptr.SafeHandle;
            return new Tuple<int, string?>(textptr.ErrCode, handle.GetString());
        }

        
        public Tuple<int, string?> GetIPAddress(string path = "yggdrasil.conf")
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path); 
            }
            using var pathHandle = new YggdrasilSafeHandle(path);
            var textptr = YggdrasilImportWrapper.GetAddress(pathHandle);
            using var handle = textptr.SafeHandle;
            return new Tuple<int, string?>(textptr.ErrCode, handle.GetString());
        }

        public Tuple<int, string?> GetPemKey(string path = "yggdrasil.conf")
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            using var pathHandle = new YggdrasilSafeHandle(path);
            var textptr = YggdrasilImportWrapper.GetPemKey(pathHandle);
            using var handle = textptr.SafeHandle;
            return new Tuple<int, string?>(textptr.ErrCode, handle.GetString());
        }

        public Tuple<int, string?> GetPrivateKey(string path = "yggdrasil.conf")
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            using var pathHandle = new YggdrasilSafeHandle(path);
            var textptr = YggdrasilImportWrapper.GetPkey(pathHandle);
            using var handle = textptr.SafeHandle;
            return new Tuple<int, string?>(textptr.ErrCode, handle.GetString());
        }


        public Tuple<int, string?> GetSnet(string path = "yggdrasil.conf")
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            using var pathHandle = new YggdrasilSafeHandle(path);
            var textptr = YggdrasilImportWrapper.GetPkey(pathHandle);
            using var handle = textptr.SafeHandle;
            return new Tuple<int, string?>(textptr.ErrCode, handle.GetString());
        }
        
        public string Version()
        {
            string IPv6 = YggdrasilDllImporter.GetVersion();
            return IPv6;
        }
        
        public string BuildName()
        {
            string name = YggdrasilDllImporter.GetBuildName();
            return name;
        }
        
        

        public Tuple<int, string?> Genconf(bool json = true)
        {
            byte convertedByte = json ? (byte)1 : (byte)0;
            var model = YggdrasilImportWrapper.GenConfigFile(convertedByte);
            using var handle = model.SafeHandle;
            return new Tuple<int, string?>(model.ErrCode, handle.GetString());
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
            YggdrasilImportWrapper.Logto(pathHandle);
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
            var task = YggdrasilImportWrapper.Start(handle);
            using var result = task.SafeHandle;
            return new Tuple<int, string?>(task.ErrCode, result.GetString());
        }

        public Tuple<int, string?> SetLogLevel(LogLevels logLevel = LogLevels.error)
        {
            using var pathHandle = new YggdrasilSafeHandle(logLevel.ToString());
            var textptr = YggdrasilImportWrapper.SetLogLevel(pathHandle);
            using var handle = textptr.SafeHandle;
            return new Tuple<int, string?>(textptr.ErrCode, handle.GetString());
        }

        public bool ExitYggdrasil()
        {
            return YggdrasilDllImporter.Exit();
        }

        
    }
}

