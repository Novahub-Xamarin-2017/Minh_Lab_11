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
using Exercise04.Api.Models;
using System.Net;
using Newtonsoft.Json;

namespace Exercise04.Api
{
    class WeatherApi
    {
        public static WeatherApi api = new WeatherApi();

        private string root = "http://api.openweathermap.org/data/2.5";

        private string appId = "32e86d2782c009304019c7b0526d0155";

        public List<string> GetWeather(string query)
        {
            var request = new WebClient();
            var response = request.DownloadString($"{root}/weather?q={query}&APPID={appId}&units=metric");
            var weather = JsonConvert.DeserializeObject<Weather>(response);

            var strings = new List<string>
            {
                weather.Name,
                weather.WeatherDetail[0].Description,
                weather.Main.Temp.ToString() + "°C",
                weather.Clouds.All.ToString() + "%",
                weather.Wind.Speed.ToString() + "m/s"
            };

            return strings;
        }
    }
}