using System;
using System.Collections.Generic;
using System.Xml;
using System.Collections;


namespace Valute
{
    class Valute
    {
        private String id;
        private String numCode;
        private String charCode;
        private int nominal;
        private String name;
        private Double value;

        public Valute(string id, string numCode, string charCode, int nominal, string name, double value)
        {
            this.id = id;
            this.numCode = numCode;
            this.charCode = charCode;
            this.nominal = nominal;
            this.name = name;
            this.value = value;
        }
        public Valute(){}

        public int Nominal { get => Nominal1; set => Nominal1 = value; }
        public string Id { get => id; set => id = value; }
        public string NumCode { get => numCode; set => numCode = value; }
        public string CharCode { get => charCode; set => charCode = value; }
        public int Nominal1 { get => nominal; set => nominal = value; }
        public string Name { get => name; set => name = value; }
        public double Value { get => value; set => this.value = value; }
    }
    class ValuteParser
    {
        public static List<Valute> Parse(String url)
        {
            List<Valute> valutes = new List<Valute>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(url);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                Valute valute = new Valute();
                XmlNode attr = xnode.Attributes.GetNamedItem("ID");
                if (attr != null)
                    valute.Id = attr.Value;

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "Value")
                        valute.Value = Convert.ToDouble(childnode.InnerText);

                    if (childnode.Name == "Name")
                        valute.Name = childnode.InnerText;

                    if (childnode.Name == "Nominal")
                        valute.Nominal = Int32.Parse(childnode.InnerText);

                    if (childnode.Name == "CharCode")
                        valute.CharCode = childnode.InnerText;

                    if (childnode.Name == "NumCode")
                        valute.NumCode = childnode.InnerText;
                }
                valutes.Add(valute);
            }            
            return valutes;
        }
    }
}
