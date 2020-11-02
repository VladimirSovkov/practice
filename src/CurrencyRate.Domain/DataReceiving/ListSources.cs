using CurrencyRate.Domain.Toolkit.EnumOfSources;

namespace CurrencyRate.Domain.DataRecipient
{
    public enum Sources
    {
        [StringValue("Ukrainian bank")]
        UkrainianBank = 0,

        [StringValue("National Bank KAZ")]
        NationalBankKaz = 1
    }
}
