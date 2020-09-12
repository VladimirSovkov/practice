using CurrencyRate.ConnectorToUkrainianBank.Interface;
using CurrencyRate.ConnectorToUkrainianBank.Parse.Interface;
using CurrencyRate.ConnectorToUkrainianBank.Parse.Service;
using Microsoft.Extensions.DependencyInjection;
using CurrencyRate.ConnectorToUkrainianBank.Service;

namespace CurrencyRate.ConnectorToUkrainianBank
{
    public static class ConnectorToUkrainianBankBindings
    {
        public static IServiceCollection AddConnectorToUkrainianBank(
            this IServiceCollection services,
            string urlUkrainianBank)
        {
            services.AddTransient<IUkrainianBankServices, UkrainianBankService>();
            services.AddSingleton<IConnectorToUkrainianBank>(x =>
                new UkrainianBankConnector(urlUkrainianBank));
            return services;
        }
    }
}
