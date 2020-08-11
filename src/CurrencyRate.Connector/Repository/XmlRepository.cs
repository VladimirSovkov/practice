﻿using CurrencyRate.Connector.Models;
using System;
using System.Collections.Generic;
using System.Xml;
using CurrencyRate.Connector.Interface;

namespace CurrencyRate.Connector.Repository
{
    class XmlRepository : IXmlRepository
    {
        private readonly string _dateToString;

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
        public XmlRepository(string date)
        {
            _dateToString = GetCorrectDateToString(date);
        }

        private XmlModel GetDataOneCurrency(ref XmlTextReader reader)
        {
            reader.Read();
            XmlModel curency = new XmlModel();
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

        public IEnumerable<XmlModel> GetData()
        {
            string url = "https://www.nationalbank.kz/rss/get_rates.cfm?fdate=" + _dateToString;
            XmlTextReader reader = new XmlTextReader(url);
            List<XmlModel> outputData = new List<XmlModel>();
            DateTime date = new DateTime();
            while (reader.Read())
            {
                XmlModel data;
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