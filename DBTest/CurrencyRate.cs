using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTest
{
    public class CurrencyRate
    {
        public int CurrencyRateId { get; set; }
        public double Rate { get; set; }
        public string CurrencyId { get; set; }
        public DateTime Date { get; set; }

        public virtual Currency Currencies { get; set; }
    }
}
