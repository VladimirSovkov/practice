using CurrencyRate.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyRate.Infrastructure.Startup
{
    public static class BaseBindings
    {
        public static IServiceCollection AddBaseServices(this IServiceCollection services)
        {
            return services.AddRepositories();
        }
    }
}
