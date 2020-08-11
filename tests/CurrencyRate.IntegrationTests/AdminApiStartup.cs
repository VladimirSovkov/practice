using CurrencyRate.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using CurrencyRate.IntegrationTests.TestKit;

namespace CurrencyRate.IntegrationTests
{
    public class ApiStartup : API.Startup
    {
        public ApiStartup(IConfiguration configuration, IHostingEnvironment env) : base(configuration, env)
        {
        }

        public override void ConfigureDatabase(IServiceCollection services)
        {
            string dbName = Guid.NewGuid().ToString();
            services.AddDbContext<CurrencyRateContext>(
                options => options
                    .UseInMemoryDatabase(dbName)
                    .ConfigureWarnings(x => x.Throw(RelationalEventId.QueryClientEvaluationWarning)));
        }

        public override void AddServices(IServiceCollection services)
        {
            base.AddServices(services);

            services.AddSingleton<IDbSeeder, DatabaseSeeder>();
        }
    }
}
