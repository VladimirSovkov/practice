using CurrencyRate.WebsiteConnector.Parse.WebsiteModels;
using System;
using System.Collections.Generic;

namespace CurrencyRate.WebsiteConnector.Interface
{
    public interface IConnectorToKazakhstanBank
    {
        List<KazakhstanBankModel> LoadData(DateTime date);
    }
}
