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

namespace Exercise02.Models
{
    public class User
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("repos_url")]
        public string ReposUrl { get; set; }

        [JsonProperty("type")]
        public string PurpleType { get; set; }

        public Detail Detail { get; set; }
    }
}