using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface ICurrency
    {
        IEnumerable<Currency> GetAllCurrency();
        Currency GetObjCurrency(string id);

    }
}
