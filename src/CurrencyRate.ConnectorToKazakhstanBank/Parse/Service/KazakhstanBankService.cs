using CurrencyRate.ConnectorToKazakhstanBank.Parse.Interface;
using CurrencyRate.ConnectorToKazakhstanBank.Parse.Models;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace CurrencyRate.ConnectorToKazakhstanBank.Service
{
    public class KazakhstanBankService : IKazakhstanBankServices
    {
        public List<KazakhstanBankRates> GetData(string url)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(url);
                XmlSerializer serializer = new XmlSerializer(typeof(KazakhstanBankModel));
                KazakhstanBankModel KazakhstanBankData = (KazakhstanBankModel)serializer.Deserialize(reader);
                foreach (var currencyRate in KazakhstanBankData.CurrenciesList)
                {
                    currencyRate.Date = KazakhstanBankData.Date;
                }
                return KazakhstanBankData.CurrenciesList;
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(exception.Message);
            }
        }

    }
}
