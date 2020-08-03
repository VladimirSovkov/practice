using Parse.Domain.Interface;
using Parse.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Parse.Infrastructure
{
    public class ParseXML : IParseXML
    {
        private string GetCorrectNumberToString(string number)
        {
            if (number.Length == 1)
            {
                number = "0" + number;
            }

            return number;
        }
        private string GetCorrectDateToString(string date)
        {
            DateTime dateTime = Convert.ToDateTime(date);
            date = GetCorrectNumberToString(dateTime.Day.ToString()) + ".";
            date += GetCorrectNumberToString(dateTime.Month.ToString()) + ".";
            date += dateTime.Year.ToString();
            return date;
        }
        private XMLModel GetDataOneCurrency(ref XmlTextReader reader)
        {
            reader.Read();
            XMLModel curency = new XMLModel();
            int count = 0;
            while (reader.Read() && reader.Name != "item")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "fullname":
                            reader.Read();//add exception 
                            curency.Name = reader.Value;
                            count++;
                            break;
                        case "title":
                            reader.Read();//add exception 
                            curency.CurrencyId = reader.Value;
                            count++;
                            break;
                        case "description":
                            reader.Read();//add exception 
                            decimal number = 0;
                            try
                            {
                                bool result = decimal.TryParse(reader.Value, out number);
                                if (!result)
                                    curency.Rate = decimal.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Сannot parse the value rate. The string contains characters!");
                            }
                            count++;
                            break;
                    }
                }
            }
            if (count != 3)
            {
                throw new FormatException("Site format changed. Instead of 3 values, we got: " + count);
            }

            return curency;
        }

        private XMLModel GetValueRuble(string URLString)
        {
            XmlTextReader reader = new XmlTextReader(URLString);
            XMLModel CurencyRub;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "item")
                {
                    XMLModel curency = GetDataOneCurrency(ref reader);
                    if (curency.CurrencyId == "RUB")
                    {
                        CurencyRub = curency;
                        return CurencyRub;
                    }
                }
            }
            throw new FormatException("could not find the rate of the ruble");
        }

        public IEnumerable<XMLModel> GetData(string dateParse)
        {
            string url = "https://www.nationalbank.kz/rss/get_rates.cfm?fdate=" + GetCorrectDateToString(dateParse);
            XMLModel CurencyRub = GetValueRuble(url);
            XmlTextReader reader = new XmlTextReader(url);
            List<XMLModel> outputData = new List<XMLModel>();
            DateTime date = new DateTime();
            while (reader.Read())
            {
                XMLModel data;
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "date")
                {
                    reader.Read();
                    try
                    {
                        date = Convert.ToDateTime(reader.Value);
                    }
                    catch (FormatException)
                    {
                        throw new FormatException("could not convert date string to type DateTime");
                    }
                }
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "item")
                {
                    data = GetDataOneCurrency(ref reader);
                    data.Date = date;
                    data.Rate = data.Rate / CurencyRub.Rate;
                    outputData.Add(data);
                    string text = data.CurrencyId + "\t" + data.Rate + "\t" + data.Name + "\n";
                }
            }
            return  outputData;
        }
    }
}
