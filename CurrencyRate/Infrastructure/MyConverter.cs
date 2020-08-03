using DataBase.Domain.Model;
using Parse.Domain.Model;
using Parse.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure
{
    public class MyConverter
    {
        static public IEnumerable<Currency> ToCurrency(List<XMLModel> xmlModelsList)
        {
            List<Currency> currencies = new List<Currency>();
            foreach (var item in xmlModelsList)
            {
                currencies.Add( new Currency { CurrencyId = item.CurrencyId, Code = 0, Name = item.Name});
            }
            return currencies;
        }

        static public List<DataBase.Domain.Model.CurrencyRate> ToCurrencyRate(List<XMLModel>xmlModelsList)
        {
            List<DataBase.Domain.Model.CurrencyRate> currencyRates = new List<DataBase.Domain.Model.CurrencyRate>();
            foreach (var item in xmlModelsList)
            {
                currencyRates.Add(new DataBase.Domain.Model.CurrencyRate {Rate = item.Rate, CurrencyId = item.CurrencyId, Source = "National Bank KAZ", Date = item.Date });
            }

            return currencyRates;
        }

        static public List<Currency> ToCurrency(List<JSONModel> jsonModelsList)
        {
            List<Currency> currencies = new List<Currency>();
            foreach (var item in jsonModelsList)
            {
                currencies.Add(new Currency { CurrencyId = item.cc, Code = item.r030, Name = item.txt});
            }
            return currencies;
        }

        static public List<DataBase.Domain.Model.CurrencyRate> ToCurrencyRate(List<JSONModel> jsonModelsList)
        {
            List<DataBase.Domain.Model.CurrencyRate> currencyRates = new List<DataBase.Domain.Model.CurrencyRate>();
            DateTime date = new DateTime();
            foreach (var item in jsonModelsList)
            {
                try
                {
                    date = Convert.ToDateTime(item.exchangedate);
                }
                catch (Exception)
                {
                    currencyRates.Clear();
                    break;
                }
                currencyRates.Add(new DataBase.Domain.Model.CurrencyRate { Rate = item.Rate, CurrencyId = item.cc, Source = "Ukrainian bank", Date = date });
            }
            return currencyRates;
        }
    }
}
