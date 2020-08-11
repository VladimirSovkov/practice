using CurrencyRate.Connector.Models;
using System.Collections.Generic;

namespace CurrencyRate.Connector.Interface
{
    public interface IJsonRepository
    {
        IEnumerable<JsonModel> GetData();
    }
}
