using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Sentry.Extensibility;

namespace iChiba.Portal.ExtensionApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    var environmentName = env.EnvironmentName;

                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                          .AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .UseSentry(o =>
                {
                    o.Dsn = "https://3baa39a56c6642f08a56e15f3846b6b0@o576719.ingest.sentry.io/5732324";
                    o.TracesSampleRate = 1.0;
                    o.AttachStacktrace = true;
                    o.MaxRequestBodySize = RequestSize.Always;
                })
                .UseStartup<Startup>()
                .UseKestrel();
    }
}
