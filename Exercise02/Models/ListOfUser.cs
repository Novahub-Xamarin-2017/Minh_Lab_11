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
    public class ListOfUser
    {
        [JsonProperty("items")]
        public List<User> Users { get; set; }
    }
}