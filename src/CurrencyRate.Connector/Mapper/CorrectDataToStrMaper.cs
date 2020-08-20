using System;

namespace CurrencyRate.Connector.Mapper
{
    public static class CorrectDataToStrMaper
    {
        private static string GetCorrectNumberToString(string number)
        {
            if (number.Length == 1)
            {
                number = "0" + number;
            }

            return number;
        }
        public static string GetCorrectDataToXml(DateTime date)
        {
            string day = GetCorrectNumberToString(date.Day.ToString()) + ".";
            string month = GetCorrectNumberToString(date.Month.ToString()) + ".";
            string year = date.Year.ToString();
            return day + month + year;
        }

        public static string GetCorrectDataToJson(DateTime date)
        {
            string year = date.Year.ToString();
            string month = GetCorrectNumberToString(date.Month.ToString());
            string day = GetCorrectNumberToString(date.Day.ToString());
            return year + month + day;
        }
    }
}
