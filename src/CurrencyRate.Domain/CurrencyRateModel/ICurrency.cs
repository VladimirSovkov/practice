﻿using System.Collections.Generic;

namespace CurrencyRate.Domain.CurrencyRateModel
{
    public interface ICurrency
    {   
        void AddDataOnSpecificDate(List<Currency> arrayCurrency);
        void AddElement(Currency currency);
    }
}
