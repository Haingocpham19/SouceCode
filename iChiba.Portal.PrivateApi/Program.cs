using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sentry.Extensibility;
using Serilog;

namespace iChiba.Portal.PrivateApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(builder =>
                {
                    builder.ClearProviders();
                    builder.AddSerilog();
                })
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
                    o.Dsn = "https://d5612c9064954b9a8c62d1659f538266@o576719.ingest.sentry.io/5730679";
                    o.TracesSampleRate = 1.0;
                    o.AttachStacktrace = true;
                    o.MaxRequestBodySize = RequestSize.Always;
                })
                .UseStartup<Startup>()
                .UseKestrel();
    }
}
