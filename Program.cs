using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace PakketService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.Configure<KestrelServerOptions>(
                        context.Configuration.GetSection("Kestrel"));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Limits.MaxConcurrentConnections = 100;
                        serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;
                        serverOptions.Limits.MaxRequestBodySize = 10 * 1024;
                        serverOptions.Limits.MinRequestBodyDataRate =
                            new MinDataRate(bytesPerSecond: 100,
                                gracePeriod: TimeSpan.FromSeconds(10));
                        serverOptions.Limits.MinResponseDataRate =
                            new MinDataRate(bytesPerSecond: 100,
                                gracePeriod: TimeSpan.FromSeconds(10));
                        serverOptions.Limits.KeepAliveTimeout =
                            TimeSpan.FromDays(30);
                        serverOptions.Limits.RequestHeadersTimeout =
                            TimeSpan.FromDays(30);
                    })
                    .UseStartup<Startup>()
                    .UseUrls("http://*:5001"); //Add this line
                });
    }
}
