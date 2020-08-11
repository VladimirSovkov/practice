using CurrencyRate.Connector.Models;
using System.Collections.Generic;

namespace CurrencyRate.Connector.Interface
{
    public interface IXmlRepository
    {
        IEnumerable<XmlModel> GetData();
    }
}
