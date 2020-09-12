using System.Collections.Generic;
using CurrencyRate.ConnectorToUkrainianBank.Parse.Models;

namespace CurrencyRate.ConnectorToUkrainianBank.Parse.Interface
{
    public interface IUkrainianBankServices
    {
        List<UkrainianBankRates> GetData(string url);
    }
}
