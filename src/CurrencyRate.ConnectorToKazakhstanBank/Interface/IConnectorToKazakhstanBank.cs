using CurrencyRate.ConnectorToKazakhstanBank.Parse.Models;
using System;
using System.Collections.Generic;

namespace CurrencyRate.ConnectorToKazakhstanBank.Interface
{
    public interface IConnectorToKazakhstanBank
    {
        List<KazakhstanBankRates> LoadData(DateTime date);
    }
}
