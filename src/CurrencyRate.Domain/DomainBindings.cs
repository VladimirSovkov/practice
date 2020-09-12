using CurrencyRate.Application.RateConverter;
using CurrencyRate.Domain.RateConverter.Validation.Interface;
using CurrencyRate.Domain.RateConverter.Validation.Service;
using CurrencyRate.Domain.CurrencyRateModel;
using CurrencyRate.Domain.DataRecipient.Interface;
using CurrencyRate.Domain.DataRecipient.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyRate.Domain
{
    public static class DomainBindings
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IValidationCheck, ValidationCheck>();
            services.AddScoped<IConverter, Converter>();
            services.AddScoped<IReceivingCurrency, ReceivingCurrency>();
            return services;
        }
    }
}
