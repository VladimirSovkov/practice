using System;
using System.Collections.Generic;
using System.Text;

namespace CurrancyRate.Domain.CurrencyRateModel
{
    public interface ICurrency
    {   
        void AddDataOnSpecificDate(List<Currency> arrayCurrency);
        void AddElement(Currency currency);
    }
}
