using CurrencyRate.Domain.CurrencyRateModel;
using System;
using System.Collections.Generic;

namespace CurrencyRate.Domain.DataRecipient.Interface
{
    public interface IReceivingCurrency
    {
        List<string> GetSourcesList();
        List<Currency> GetCurrencies(string sources, DateTime date);
        List<CurrencyRateModel.CurrencyRate> GetCurrencyRates(string sources, DateTime date);
    }
}
