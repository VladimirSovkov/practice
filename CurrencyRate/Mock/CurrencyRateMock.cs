using CurrencyRate.Domain.Interface;
using CurrencyRate.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Parse.Domain.Interface;
using Parse.Domain.Model;

namespace CurrencyRate.Domain.Mock
{
    public class CurrencyRateMock : ICurrencyRate
    {
        private readonly IParseJSON _parseJSON;
        public CurrencyRateMock(IParseJSON parseJSON)
        {
            _parseJSON = parseJSON;
        }
        public CurrencyRates GetCurrencyRateData(string NameCurrencies, decimal rate)
        {
            List<JSONModel> AllDataJSON = _parseJSON.GetData("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=20190320&json").ToList();
            JSONModel answer = new JSONModel { };
            double rateInDouble = Convert.ToDouble(rate);
            bool IsAnswer = false;
            foreach (var currencyRate in AllDataJSON)
            {
                if (NameCurrencies == currencyRate.cc)
                {
                    answer = currencyRate;
                    IsAnswer = true;
                }
            }
            if (IsAnswer)
            {
                answer.Rate *= Convert.ToDouble(rate);
                CurrencyRates outData = new CurrencyRates { };
                outData.Rate = answer.Rate;
                outData.CurrencyId = answer.cc;
                outData.Date = Convert.ToDateTime(answer.exchangedate);
                return outData;
            }

            return new CurrencyRates { };
        }

    }
}
