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
using Exercise03.Api.Models;
using Refit;
using System.Net;
using Newtonsoft.Json;

namespace Exercise03.Api
{
    class FindPhotos
    {
        public static FindPhotos api = new FindPhotos();

        private string apiKey = "n97gpt7n4nvj77gmwx583zjg";

        private string root = "https://api.gettyimages.com/v3";

        public List<string> GetPhotos(string query)
        {
            var request = new WebClient();
            request.Headers["Api-Key"] = apiKey;

            var response = request.DownloadString($"{root}/search/images?fields=id,title,thumb,referral_destinations&sort_order=best&phrase={query}");

            return JsonConvert.DeserializeObject<Photos>(response).Images.Select(x => x.DisplaySizes[0].Uri).ToList();
        }
    }
}