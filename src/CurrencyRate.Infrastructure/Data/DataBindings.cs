using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using CurrancyRate.Domain.CurrencyRateModel;
using CurrencyRate.Infrastructure.Data.CurrencyRateModel;

namespace CurrencyRate.Infrastructure.Data
{
    public static class DataBindings
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICurrency, CurrencyRepository>();
            services.AddScoped<ICurrencyRate, CurrencyRateRepository>();

            return services;
        }

        public static IServiceCollection AddDatabase<T>(this IServiceCollection services, string connectionString)
            where T : DbContext
        {
            return services.AddDbContext<T>(c =>
            {
                try
                {
                    c.UseLazyLoadingProxies().UseSqlServer(connectionString);
                }
                catch (Exception)
                {
                    //TODO: logger
                }
            });
        }
    }
}
