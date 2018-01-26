using Android.App;
using Android.Widget;
using Android.OS;
using Exercise04.Api;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace Exercise04
{
    [Activity(Label = "Exercise04", Theme = "@android:style/Theme.Material.Light.DarkActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<int> ids = new List<int>()
        {
            Resource.Id.tv_cityname,
            Resource.Id.tv_weather,
            Resource.Id.tv_temperature,
            Resource.Id.tv_cloud,
            Resource.Id.tv_wind
        };

        public List<string> TextViews
        {
            set
            {
                var index = 0;

                value.ForEach(x =>
                {
                    FindViewById<TextView>(ids[index]).Text = x;
                    index++;
                });
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var searchView = FindViewById<SearchView>(Resource.Id.sv_city);
            searchView.QueryTextSubmit += delegate
            {
                TextViews = WeatherApi.api.GetWeather(searchView.Query);
            };
        }
    }
}

