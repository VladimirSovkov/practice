using CurrencyRate.Application.Converter;
using Microsoft.Extensions.DependencyInjection; 

namespace CurrencyRate.Application
{
    public static class ApplicationBindings
    {
        public static IServiceCollection AddApplication(this IServiceCollection services )
        {
            services.AddScoped<IConverter, Converter.Converter>();
            return services;
        }
    }
}
