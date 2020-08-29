using System.Collections.Generic;

namespace CurrencyRate.WebsiteConnector.Parse.WebsiteModels
{
    public interface IKazakhstanBankServices
    {
        List<KazakhstanBankModel> GetData(string url);
    }
}
