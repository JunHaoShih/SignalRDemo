using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            // 將appsettings.json讀近來，已取得Kestrel的設定
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .Build();

            var httpPort = int.Parse(config["AppSettings:KestrelSettings:HttpPort"]);
            var httpsPort = int.Parse(config["AppSettings:KestrelSettings:HttpsPort"]);

            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(serverOptions =>
                    {
                        serverOptions.ListenAnyIP(httpPort);
                        serverOptions.ListenAnyIP(httpsPort, configure => configure.UseHttps());
                    }).UseStartup<Startup>();
                });
        }
        /*public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });*/
    }
}
