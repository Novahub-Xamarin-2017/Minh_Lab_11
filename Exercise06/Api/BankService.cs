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
using Exercise06.Models;
using System.Net;
using System.IO;
using System.Xml.Serialization;

namespace Exercise06.Api
{
    class BankService
    {
        public static BankService api = new BankService();

        private string root = "https://www.vietcombank.com.vn/exchangerates/ExrateXML.aspx";

        public List<Exrate> Exrates { get; private set; }

        public List<string> TextViewValues { get; private set; }

        public void LoadExratesData()
        {
            var request = new WebClient();

            var respone = request.DownloadString(root);

            using (var stringReader = new StringReader(respone))
            {
                var exrateList = (ExrateList)(new XmlSerializer(typeof(ExrateList))).Deserialize(stringReader);

                exrateList.Exrates.ForEach(x =>
                {
                    x.CurrencyName = "CurrencyName: " + x.CurrencyName;
                    x.CurrencyCode = "CurrencyCode: " + x.CurrencyCode;
                    x.Buy = "Buy: " + x.Buy;
                    x.Sell = "Sell: " + x.Sell;
                    x.Transfer = "Transfer: " + x.Transfer;
                });

                Exrates = exrateList.Exrates;

                TextViewValues = new List<string>()
                {
                    "Source: " + exrateList.Source,
                    "Updated: " + exrateList.DateTime
                };
            }
        }
    }
}