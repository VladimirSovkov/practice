using CurrencyRate.ConnectorToKazakhstanBank.Parse.Models;
using System.Collections.Generic;

namespace CurrencyRate.ConnectorToKazakhstanBank.Parse.Interface
{
    public interface IKazakhstanBankServices
    {
        List<KazakhstanBankRates> GetData(string url);
    }
}
