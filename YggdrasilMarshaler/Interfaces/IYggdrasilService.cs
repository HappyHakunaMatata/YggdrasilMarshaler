using YggdrasilMarshaler.Models;

namespace YggdrasilMarshaler.Interfaces
{
	public interface IYggdrasilService
	{
        public Tuple<int, string?> NormaliseConfing(string path = "yggdrasil.conf", bool json = true);

        public Tuple<int, string?> GetIPAddress(string path = "yggdrasil.conf");

        public Tuple<int, string?> GetPemKey(string path = "yggdrasil.conf");

        public Tuple<int, string?> GetPrivateKey(string path = "yggdrasil.conf");

        public Tuple<int, string?> GetSnet(string path = "yggdrasil.conf");

        public string Version();

        public string BuildName();

        public Tuple<int, string?> Genconf(bool json = true);

        public IYggdrasilService Logto(Logs log = Logs.custom, string path = "");

        public Tuple<int, string?> RunYggdrasilAsync(string? path);

        public Tuple<int, string?> SetLogLevel(LogLevels logLevel = LogLevels.error);

        public bool ExitYggdrasil();
        
    }
}

