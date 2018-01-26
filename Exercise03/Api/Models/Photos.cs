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

namespace Exercise03.Api.Models
{
    public class Photos
    {
        [JsonProperty("images")]
        public List<Image> Images { get; set; }
    }

    public class Image
    {
        [JsonProperty("display_sizes")]
        public List<DisplaySize> DisplaySizes { get; set; }
    }

    public class DisplaySize
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}