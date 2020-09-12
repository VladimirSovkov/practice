using CurrencyRate.ConnectorToKazakhstanBank.Parse.Models;
using CurrencyRate.ConnectorToUkrainianBank.Parse.Models;
using CurrencyRate.Domain.Toolkit.EnumOfSources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyRate.Domain.DataRecipient.Adapter
{
    public static class CurrencyRateAdapter
    {
        public static CurrencyRateModel.CurrencyRate MapToCurrencyRate(this UkrainianBankRates ukrainianRates)
        {
            if (ukrainianRates == null)
            {
                return null;
            }
            else
            {
                try
                {
                    return new CurrencyRateModel.CurrencyRate
                    {
                        CurrencyId = ukrainianRates.CurrencyId,
                        Rate = ukrainianRates.Rate,
                        Date = Convert.ToDateTime(ukrainianRates.Date),
                        Source = Sources.UkrainianBank.GetStringValue()
                    };
                }
                catch (Exception exception)
                {
                    throw new InvalidCastException($"error in converting date to CurrencyRate of UkrainianBankRates. Date = {ukrainianRates.Date}" 
                        + exception.Message);
                }
            }
        }

        public static CurrencyRateModel.CurrencyRate MapToCurrencyRate( this KazakhstanBankRates kazakhstanRates)
        {
            if ( kazakhstanRates == null)
            {
                return null;
            }
            else
            {
                try
                {
                    return new CurrencyRateModel.CurrencyRate
                    {
                        CurrencyId = kazakhstanRates.CurrencyId,
                        Rate = kazakhstanRates.Rate,
                        Date = Convert.ToDateTime(kazakhstanRates.Date),
                        Source = Sources.NationalBankKaz.GetStringValue()
                    };
                }
                catch (Exception exception)
                {
                    throw new InvalidCastException($"error in converting date to CurrencyRate of KazakhstanBankRates. Date = {kazakhstanRates.Date}" 
                        + exception.Message);
                }
            }
        }

        public static List<CurrencyRateModel.CurrencyRate> MapToCurrencyRate(this IEnumerable<UkrainianBankRates> ukrainianRates)
        {
            return ukrainianRates == null ? new List<CurrencyRateModel.CurrencyRate>() : ukrainianRates.ToList().ConvertAll(MapToCurrencyRate);
        }

        public static List<CurrencyRateModel.CurrencyRate> MapToCurrencyRate( this IEnumerable<KazakhstanBankRates> kazakhstanRates)
        {
            return kazakhstanRates == null ? new List<CurrencyRateModel.CurrencyRate>() : kazakhstanRates.ToList().ConvertAll(MapToCurrencyRate);
        }
    }
}
