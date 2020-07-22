using Parse.Domain.Interface;
using Parse.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Parse.Infrastructure
{
    class ParseXML : IParseXML
    {
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
                            double number = 0;
                            try
                            {
                                //если дробная часть разделяется запятой то выполняется  условие
                                //иначе 2
                                bool result = double.TryParse(reader.Value, out number);
                                if (!result)
                                    curency.Rate = double.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Сannot parse the value rate. The string contains characters!");
                            }

                            curency.Rate = double.Parse(reader.Value, System.Globalization.CultureInfo.InvariantCulture);
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

        public IEnumerable<XMLModel> GetData(string url)
        {
            XMLModel CurencyRub = GetValueRuble(url);
            XmlTextReader reader = new XmlTextReader(url);
            List<XMLModel> outputData = new List<XMLModel> { new XMLModel { } };
            while (reader.Read())
            {
                XMLModel data;
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "item")
                {
                    //нашли блок с информацией!
                    data = GetDataOneCurrency(ref reader);
                    data.Rate = data.Rate / CurencyRub.Rate;
                    outputData.Add(data);
                    string text = data.CurrencyId + "\t" + data.Rate + "\t" + data.Name + "\n";
                    Console.WriteLine(text);
                }
            }
            return  outputData;
        }
    }
}
