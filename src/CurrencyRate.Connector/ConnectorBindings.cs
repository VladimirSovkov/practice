using Microsoft.Extensions.DependencyInjection;
using CurrencyRate.Connector.Interface;
using CurrencyRate.Connector.Repository;

namespace CurrencyRate.Connector
{
    public static class ConnectorBindings
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IJsonRepository, JsonRepository>();
            services.AddTransient<IXmlRepository, XmlRepository>();
            return services;
        }
    }
}
