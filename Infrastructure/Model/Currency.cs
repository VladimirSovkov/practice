using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Model
{
    public class Currency
    {
        public string CurrencyId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CurrencyRate> CurrencyRate { get; set; }    
    }
}
