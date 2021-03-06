using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CurrencyRate.Infrastructure.Startup;
using System;
using System.Reflection;
using CurrencyRate.Infrastructure.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using CurrencyRate.Domain;
using CurrencyRate.ConnectorToKazakhstanBank;
using CurrencyRate.ConnectorToUkrainianBank;

namespace CurrencyRate.API
{
    public class Startup : IBaseStartup
    {
        private readonly IWebHostEnvironment _env;  
        public IConfiguration Configuration { get; }
        public Startup( IConfiguration configuration, IWebHostEnvironment env )
        {
            _env = env;
            Configuration = configuration;
        }

        public virtual void Configure( IApplicationBuilder app)
        {
            app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvcWithDefaultRoute();
        }
        
        IServiceProvider IStartup.ConfigureServices( IServiceCollection services )
        {
            AddServices(services);

            return services.BuildServiceProvider();
        }

        public virtual void AddServices(IServiceCollection services)
        {
            ConfigureDatabase( services );
            services.AddControllers();
            services
                .AddDomain()
                .AddBaseServices()
                .AddConnectorToKazakhstanBank(Configuration["UrlToLoadData:NationalBankKaz"])
                .AddConnectorToUkrainianBank(Configuration["UrlToLoadData:UkrainianBank"])
                .AddMvcCore(options => options.EnableEndpointRouting = false)
                .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                        options.SerializerSettings.Converters.Add(new StringEnumConverter());
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;   
                    })
            .AddApplicationPart( Assembly.Load( new AssemblyName( "CurrencyRate.API" )) );
             services.AddCors();
        }

        public virtual void ConfigureDatabase( IServiceCollection services )
        {
            services.AddDatabase<CurrencyRateContext>( Configuration.GetConnectionString("DefaultConnection") );
        }
    }
}
