using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
namespace Valute
{
    class Class1
    {
        static void Main(string[] args)
        {
            List<Valute> valutes = new List<Valute>();
            valutes = ValuteParser.Parse("http://www.cbr.ru/scripts/XML_daily.asp");
            double min = Int32.MaxValue;
            double max = 0;
            if (valutes.Count > 0) {
                Valute maxValute = valutes[0];
                Valute minValute = valutes[0];
                foreach (Valute valute in valutes)
                {
                    double v = valute.Value / valute.Nominal;
                    if (v < min)
                    {
                        min = v;
                        minValute = valute;
                    }
                    if (v > max)
                    {
                        max = v;
                        maxValute = valute;
                    }
                }
                Console.WriteLine("Самая дорогая валюта: " + maxValute.CharCode + " " + maxValute.Name + " Cтоимость: " + max);
                Console.WriteLine("Самая дешевая валюта: " + minValute.CharCode + " " + minValute.Name + " Cтоимость: " + min);
                Console.ReadKey();
            }
        }
    }
}