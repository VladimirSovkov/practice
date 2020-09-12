using CurrencyRate.ConnectorToKazakhstanBank.Interface;
using CurrencyRate.ConnectorToKazakhstanBank.Parse.Interface;
using CurrencyRate.ConnectorToKazakhstanBank.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyRate.ConnectorToKazakhstanBank
{
    public static class ConnectorToKazakhstanBankBindings
    {
        public static IServiceCollection AddConnectorToKazakhstanBank(
            this IServiceCollection services,
            string url)
        {
            services.AddTransient<IKazakhstanBankServices, KazakhstanBankService>();
            services.AddSingleton<IConnectorToKazakhstanBank>(x =>
                new KazakhstanBankConnector(url));
            return services;
        }
    }
}
