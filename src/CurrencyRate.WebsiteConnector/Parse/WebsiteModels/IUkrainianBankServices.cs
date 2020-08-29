using System.Collections.Generic;

namespace CurrencyRate.WebsiteConnector.Parse.WebsiteModels
{
    public interface IUkrainianBankServices
    {
        List<UkrainianBankModel> GetData(string url);
    }
}
