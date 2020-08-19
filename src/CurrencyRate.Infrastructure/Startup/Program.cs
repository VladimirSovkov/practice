using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace CurrencyRate.Infrastructure.Startup
{
    public class Program<TStartup> where TStartup : IBaseStartup 
    {
        public void Run(string[] args)
        {
            BuildWebHost(args).Run();
        }

        private IWebHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            IWebHostBuilder builder = WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddNLog();
                })
                .UseStartup(typeof(TStartup));
            string argUrls = config["urls"];
            if (argUrls != null)
            {
                builder.UseUrls(argUrls);
            }

            return builder.Build();
        }
    }
}
