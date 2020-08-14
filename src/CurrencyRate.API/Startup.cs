using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CurrencyRate.Infrastructure.Startup;
using System;
using CurrencyRate.Infrastructure.Data;
using CurrencyRate.Application;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.FeatureManagement;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyRate.API
{
    public class Startup : IBaseStartup
    {
        private readonly IWebHostEnvironment _env;  
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public virtual void Configure(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();
        }
        
        IServiceProvider IStartup.ConfigureServices(IServiceCollection services)
        {
            AddServices(services);

            return services.BuildServiceProvider();
        }

        public virtual void AddServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            services.AddFeatureManagement();
            services.AddControllers();
            services.AddApiVersioning(
                options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                });
            services
                .AddBaseServices()
                .AddApplication()
                .AddMvcCore(options => options.EnableEndpointRouting = false)

                .AddNewtonsoftJson(
                options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                     options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });


            


        }

        public virtual void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDatabase<CurrencyRateContext>(Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
