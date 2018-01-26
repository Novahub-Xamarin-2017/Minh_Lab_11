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
using Newtonsoft.Json;

namespace Exercise04.Api.Models
{
    public class Weather
    {
        [JsonProperty("weather")]
        public List<WeatherDetail> WeatherDetail { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }
    }

    public class WeatherDetail
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}