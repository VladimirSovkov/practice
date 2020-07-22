using System;
using System.Collections;
using System.Collections.Generic;
using CurrencyRate.Domain.Models;

namespace CurrencyRate.Domain.Interface
{
    public interface ICurrencyRate
    {
        public CurrencyRates GetCurrencyRateData(string NameCurrencies, decimal rate);

        //void AddData(int Id, double Value, string CurrencyId, DateTime Date);
        //int GetCurrencyRateId(); //выдать id через выборку
        //double GetRate(); //через id выдавать значение курса
        //string GetCurrencyId(); // через id
        //DateTime GetDate(); //через id
    }
}
