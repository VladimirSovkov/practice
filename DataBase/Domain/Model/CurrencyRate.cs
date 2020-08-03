using System;
using System.Collections.Generic;

namespace DataBase.Domain.Model
{
    public partial class CurrencyRate
    {
        public int CurrencyRateId { get; set; }
        public decimal Rate { get; set; }
        public string CurrencyId { get; set; }
        public string Source { get; set; }
        public DateTime Date { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
