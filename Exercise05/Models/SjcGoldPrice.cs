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

namespace Exercise05.Models
{
    [XmlRoot(ElementName = "item")]
    public class GoldPrice
    {
        [XmlAttribute(AttributeName = "buy")]
        public string Buy { get; set; }

        [XmlAttribute(AttributeName = "sell")]
        public string Sell { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "city")]
    public class City
    {
        [XmlElement(ElementName = "item")]
        public List<GoldPrice> GoldPrice { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "ratelist")]
    public class Ratelist
    {
        [XmlElement(ElementName = "city")]
        public List<City> City { get; set; }

        [XmlAttribute(AttributeName = "updated")]
        public string Updated { get; set; }

        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
    }

    [XmlRoot(ElementName = "root")]
    public class SjcGoldPrice
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "url")]
        public string Url { get; set; }

        [XmlElement(ElementName = "ratelist")]
        public Ratelist Ratelist { get; set; }
    }

}