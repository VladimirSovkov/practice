using System;
using System.Collections.Generic;
using CurrencyRate.Connector.Parser.Models;
using CurrencyRate.Connector.Model;

namespace CurrencyRate.Connector
{
    public interface IConnector
    {
        List<ConnectorModel> Load(DateTime date, Source source);
    }
}
