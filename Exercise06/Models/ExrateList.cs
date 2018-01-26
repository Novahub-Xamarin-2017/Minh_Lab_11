using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Xml.Serialization;

namespace Exercise06.Models
{
    [XmlRoot(ElementName = "Exrate")]
    public class Exrate
    {
        [XmlAttribute(AttributeName = "CurrencyCode")]
        public string CurrencyCode { get; set; }

        [XmlAttribute(AttributeName = "CurrencyName")]
        public string CurrencyName { get; set; }

        [XmlAttribute(AttributeName = "Buy")]
        public string Buy { get; set; }

        [XmlAttribute(AttributeName = "Transfer")]
        public string Transfer { get; set; }

        [XmlAttribute(AttributeName = "Sell")]
        public string Sell { get; set; }
    }

    [XmlRoot(ElementName = "ExrateList")]
    public class ExrateList
    {
        [XmlElement(ElementName = "DateTime")]
        public string DateTime { get; set; }

        [XmlElement(ElementName = "Exrate")]
        public List<Exrate> Exrates { get; set; }

        [XmlElement(ElementName = "Source")]
        public string Source { get; set; }
    }
}