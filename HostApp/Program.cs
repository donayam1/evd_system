using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace HostApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>()
                   .ConfigureAppConfiguration((context, config) => {
                       config.SetBasePath(Directory.GetCurrentDirectory())
                              .AddEnvironmentVariables()
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                              .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                              .AddJsonFile($"InitialSystemAccounts.{context.HostingEnvironment.EnvironmentName}.json", optional: false, reloadOnChange: true);
                   });
                   //.UseSerilog((context, config) =>
                   //{
                   //    config
                   //        .MinimumLevel.Debug()
                   //        .MinimumLevel.Override("Microsoft", LogEventLevel.Verbose)
                   //        .MinimumLevel.Override("System", LogEventLevel.Verbose)
                   //        .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Verbose)
                   //        .Enrich.FromLogContext()
                   //        .WriteTo.File($"logs/AppLog_{DateTime.Now.ToString("MM_dd_yyyy")}_log.txt")
                   //        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate);
                   //});

            return host;



            //WebHost.CreateDefaultBuilder(args)
            //    .UseStartup<Startup>();
        }
    }
}
