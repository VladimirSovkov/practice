using CurrencyRate.WebsiteConnector.Parse.WebsiteModels;
using System;
using System.Collections.Generic;
using System.Xml;

namespace CurrencyRate.WebsiteConnector.Parse.Service
{
    public class KazakhstanBankService : IKazakhstanBankServices
    {
        private KazakhstanBankModel GetDataOneCurrency(ref XmlTextReader reader)
        {
            reader.Read();
            KazakhstanBankModel curency = new KazakhstanBankModel();
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
                            decimal number;
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

        public List<KazakhstanBankModel> GetData(string url)
        {
            XmlTextReader reader = new XmlTextReader(url);
            List<KazakhstanBankModel> outputData = new List<KazakhstanBankModel>();
            DateTime date = new DateTime();
            while (reader.Read())
            {
                KazakhstanBankModel data;
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
                    outputData.Add(data);
                }
            }
            return outputData;
        }
    }
}
