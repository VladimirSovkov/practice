using System;
using System.Collections.Generic;

namespace DataBase.Domain.Model
{
    public partial class Currency
    {
        public Currency()
        {
            CurrencyRate = new HashSet<CurrencyRate>();
        }
        public string CurrencyId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CurrencyRate> CurrencyRate { get; set; }
    }
}
