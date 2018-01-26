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
using Exercise05.Models;
using System.Net;
using System.Xml.Serialization;
using System.IO;

namespace Exercise05.Api
{
    class SjcService
    {
        public static SjcService api = new SjcService();

        private string root = "http://www.sjc.com.vn/xml/tygiavang.xml";

        private List<City> cities;

        public List<City> Cities
        {
            get => cities;
        }

        private List<string> strings;

        public List<string> Strings
        {
            get => strings;
        }

        public void ReloadSjcGoldPrice()
        {
            var request = new WebClient();

            var respone = request.DownloadString(root);

            using(var stringReader = new StringReader(respone))
            {
                var sjcGoldPrice = (SjcGoldPrice)(new XmlSerializer(typeof(SjcGoldPrice))).Deserialize(stringReader);

                sjcGoldPrice.Ratelist.City.ForEach(x=>x.GoldPrice.ForEach(y=> 
                {
                    y.Buy = "Buy: " + y.Buy;
                    y.Sell = "Sell: " + y.Sell;
                    y.Type = "Type: " + y.Type;
                }));

                cities = sjcGoldPrice.Ratelist.City;

                strings = new List<string>()
                {
                    sjcGoldPrice.Title,
                    "Source: " + sjcGoldPrice.Url,
                    "Updated: " + sjcGoldPrice.Ratelist.Updated,
                    "Unit: " + sjcGoldPrice.Ratelist.Unit
                };
            }
        }
    }
}