using CurrencyRate.WebsiteConnector.Parse.WebsiteModels;
using System;
using System.Collections.Generic;

namespace CurrencyRate.WebsiteConnector.Interface
{
    public interface IConnectorToUkrainianBank
    {
        List<UkrainianBankModel> LoadData(DateTime date);
    }
}
