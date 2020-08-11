using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CurrencyRate.Infrastructure.Startup;
using System;
using CurrencyRate.Infrastructure.Data;

namespace CurrencyRate.API
{
    public class Startup : IBaseStartup
    {
        private readonly IHostingEnvironment _env;  
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        public virtual void AddServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            services.AddBaseServices();
        }

        IServiceProvider IStartup.ConfigureServices(IServiceCollection services)
        {
            AddServices(services);

            return services.BuildServiceProvider();
        }

        public virtual void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDatabase<CurrencyRateContext>(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
