using DataBase.Domain.Model;
using System.Collections.Generic;

namespace DataBase.Domain.Interface
{
    public interface ICurrencyRepository
    {
        void AddDataOnSpecificDate(List<Currency> arrayCurrency);
        void AddElement(Currency currency);
    }
}
