using CurrencyRate.ConnectorToUkrainianBank.Parse.Models;
using System;
using System.Collections.Generic;

namespace CurrencyRate.ConnectorToUkrainianBank.Interface
{
    public interface IConnectorToUkrainianBank
    {
        List<UkrainianBankRates> LoadData(DateTime date);
    }
}
