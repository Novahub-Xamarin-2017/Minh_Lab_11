using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise05.Models.Extensions;
using Exercise05.Adapters;
using Exercise05.Api;
using System.Collections.Generic;
using Exercise05.Models;
using Android.Support.V4.Widget;
using System.Linq;

namespace Exercise05
{
    [Activity(Label = "Exercise05", Theme = "@android:style/Theme.Material.Light.DarkActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private List<TextView> textViews;

        public List<string> TextViewValues
        {
            set
            {
                var index = 0;

                value.ForEach(x =>
                {
                    textViews[index].Text = x;
                    index++;
                });
            }
        }

        private CitiesAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            adapter = new CitiesAdapter(new List<City>());
            FindViewById<RecyclerView>(Resource.Id.rrcv_city).SetRecyclerView(this, adapter);

            textViews = new List<int>()
            {
                Resource.Id.tv_title,
                Resource.Id.tv_source,
                Resource.Id.tv_time,
                Resource.Id.tv_unit
            }.Select(x => FindViewById<TextView>(x)).ToList();

            LoadGoldData();

            var refresh = FindViewById<SwipeRefreshLayout>(Resource.Id.srl_refresh);
            refresh.Refresh += delegate
            {
                LoadGoldData();
                refresh.Refreshing = false;
            };
        }

        public void LoadGoldData()
        {
            SjcService.api.LoadGoldData();

            adapter.Cities = SjcService.api.Cities;
            TextViewValues = SjcService.api.TextViewValues;
        }
    }
}

