using CurrencyRate.WebsiteConnector.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using CurrencyRate.WebsiteConnector.Service;
using CurrencyRate.WebsiteConnector.Parse.WebsiteModels;
using CurrencyRate.WebsiteConnector.Parse.Service;

namespace CurrencyRate.WebsiteConnector
{
    public static class WebSiteConnectionBindings
    {
        public static IServiceCollection AddWebsiteConnector(this IServiceCollection services)
        {
            services.AddTransient<IKazakhstanBankServices, KazakhstanBankService>();
            services.AddTransient<IUkrainianBankServices, UkrainianBankService>();
            return services;
        }

        public static IServiceCollection AddWebsiteConnector (
            this IServiceCollection services,
            string urlKazakhstanBank,
            string urlUkrainianBank)
        {
            services.AddSingleton<IConnectorToKazakhstanBank>(x =>
                new ConnectorToKazakhstanBank(urlKazakhstanBank));
            services.AddSingleton<IConnectorToUkrainianBank, ConnectorToUkrainianBank>(x =>
                new ConnectorToUkrainianBank(urlUkrainianBank));
            services.AddScoped<IWebsiteConnector, WebsiteConnector>();
            return services;
        }
    }
}
