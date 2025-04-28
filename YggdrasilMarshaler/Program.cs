
using Microsoft.Extensions.DependencyInjection;
using YggdrasilMarshaler.Interfaces;
using YggdrasilMarshaler.Models;
using YggdrasilMarshaler.Services;

namespace YggdrasilMarshaler;

class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection()
            .AddTransient<IYggdrasilService>(provider =>
            {
                #if NET7_0_OR_GREATER
                    return new YggdrasilService();
                #else
                    return new YggdrasilImportService();
                #endif
            });
        using var serviceProvider = services.BuildServiceProvider();
        var ygd = serviceProvider.GetService<IYggdrasilService>();
        if (ygd == null)
        {
            return;
        }
        var t = ygd.GetIPAddress("/Users/user/Desktop/yggdrasil.conf");
        Console.WriteLine($"{t.Item1},{t.Item2}");
        t = ygd.GetSnet("/Users/user/Desktop/yggdrasil.conf");
        Console.WriteLine($"{t.Item1},{t.Item2}");
        t = ygd.GetPemKey("/Users/user/Desktop/yggdrasil.conf");
        Console.WriteLine($"{t.Item1},{t.Item2}");
        t = ygd.GetPrivateKey("/Users/user/Desktop/yggdrasil.conf");
        Console.WriteLine($"{t.Item1},{t.Item2}");
        var s = ygd.Version();
        Console.WriteLine(s);
        s = ygd.BuildName();
        Console.WriteLine(s);
        t = ygd.Genconf(false);
        Console.WriteLine($"{t.Item1},{t.Item2}");
        t = ygd.NormaliseConfing("/Users/user/Documents/GitHub/LittleMozzarellaNode/Node/Node/bin/Debug/net8.0/yggdrasil.conf");
        Console.WriteLine($"{t.Item1},{t.Item2}");
        t = ygd.SetLogLevel(LogLevels.error);
        Console.WriteLine($"{t.Item1},{t.Item2}");
        ygd.Logto(path: "/Users/user/Documents/GitHub/LittleMozzarellaNode/Node/Node/bin/Debug/net8.0/yggdrasil.log");
        t = ygd.SetLogLevel(LogLevels.error);
        Console.WriteLine($"{t.Item1},{t.Item2}");
        var task = Task.Run(() => ygd.RunYggdrasilAsync("/Users/user/Desktop/yggdrasil.conf"));
        bool r = ygd.ExitYggdrasil();
        Console.WriteLine(r);
        task.Wait();
    }
}

