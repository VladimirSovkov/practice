using CurrencyRate.Application.Converter;
using Microsoft.Extensions.DependencyInjection;

namespace CurrancyRate.Domain
{
    public static class DomainBindings
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IConverter, Converter>();
            return services;
        }
    }
}
