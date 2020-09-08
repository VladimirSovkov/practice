using System.Collections.Generic;
using System;

namespace CurrencyRate.WebsiteConnector
{
    public interface IWebsiteConnector
    {
        List<string> GetSource();
        IEnumerable<dynamic> GetData(Source source, DateTime date);
    }
}
