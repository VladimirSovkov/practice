using CurrencyRate.Connector.Model;
using System;
using System.Collections.Generic;

namespace CurrencyRate.Connector.UnitTests.ObjectMother
{
    public static class ConnectionObj
    {
        public static readonly List<ConnectorModel> GetJsonObj = new List<ConnectorModel>
        {
            new ConnectorModel{ CurrencyId = "AUD", Code = 36, Rate = 19.29768m, Date = new DateTime(2019, 03, 20), Name = "Австралійський долар", Source = "Ukrainian bank"},
            new ConnectorModel{ CurrencyId = "CAD", Code = 124, Rate = 20.484244m, Date = new DateTime(2019, 03, 20), Name = "Канадський долар", Source = "Ukrainian bank"},
            new ConnectorModel{ CurrencyId = "CNY", Code = 156, Rate = 4.046496m, Date = new DateTime(2019, 03, 20), Name = "Юань Женьмiньбi", Source = "Ukrainian bank"},
            new ConnectorModel{ CurrencyId = "HRK", Code = 191, Rate = 4.159377m, Date = new DateTime(2019, 03, 20), Name = "Куна", Source = "Ukrainian bank"},
            new ConnectorModel{ CurrencyId = "CZK", Code = 203, Rate = 1.204861m, Date = new DateTime(2019, 03, 20), Name = "Чеська крона", Source = "Ukrainian bank"}
        };

        public static readonly List<ConnectorModel> GetXmlObj = new List<ConnectorModel>
        {
            new ConnectorModel { CurrencyId = "AUD", Code = 0, Rate = 267.13m, Date = new DateTime(), Name = "АВСТРАЛИЙСКИЙ ДОЛЛАР", Source = "National Bank KAZ"},
            new ConnectorModel { CurrencyId = "AZN", Code = 0, Rate = 222.33m, Date = new DateTime(), Name = "АЗЕРБАЙДЖАНСКИЙ МАНАТ", Source = "National Bank KAZ"},
            new ConnectorModel { CurrencyId = "AMD", Code = 0, Rate = 7.76m, Date = new DateTime(), Name = "АРМЯНСКИЙ ДРАМ", Source = "National Bank KAZ"},
            new ConnectorModel { CurrencyId = "BYN", Code = 0, Rate = 178.91m, Date = new DateTime(), Name = "БЕЛОРУССКИЙ РУБЛЬ", Source = "National Bank KAZ"},
            new ConnectorModel { CurrencyId = "BRL", Code = 0, Rate = 99.27m, Date = new DateTime(), Name = "БРАЗИЛЬСКИЙ РЕАЛ", Source = "National Bank KAZ"},
        };
    }
}
