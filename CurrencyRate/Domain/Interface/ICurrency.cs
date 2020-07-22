using CurrencyRate.Domain.Models;
using System;
using System.Collections.Generic;

namespace CurrencyRate.Domain.Interface
{
    public interface ICurrency
    {
        IEnumerable<Currency> GetAllCurrency();


        //void AddData(string CurencyId, int Code, string Name);
        //string GetToString();
        //string GetId();
        //int GetCode();
        //string GetName();
    }
}
