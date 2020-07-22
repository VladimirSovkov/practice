using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    interface ICurrencyRate
    {
        IEnumerable<CurrencyRate> GetAllCurrencyRate();
        CurrencyRate GetObjCurrencyRate(string id);
    }
}
