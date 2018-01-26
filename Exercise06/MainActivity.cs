using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise06.Adapters;
using Exercise06.Models;
using System.Collections.Generic;
using Exercise06.Api;
using Android.Support.V4.Widget;
using System.Linq;

namespace Exercise06
{
    [Activity(Label = "Exercise06", Theme = "@android:style/Theme.Material.Light.DarkActionBar", MainLauncher = true)]
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
        private ExratesAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.rccv_exrate);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            adapter = new ExratesAdapter(new List<Exrate>());
            recyclerView.SetAdapter(adapter);

            textViews = new List<int>()
            {
                Resource.Id.tv_source,
                Resource.Id.tv_time
            }.Select(x => FindViewById<TextView>(x)).ToList();

            LoadExrateData();

            var refresh = FindViewById<SwipeRefreshLayout>(Resource.Id.srl_refresh);
            refresh.Refresh += delegate
            {
                LoadExrateData();
                refresh.Refreshing = false;
            };
        }

        public void LoadExrateData()
        {
            BankService.api.LoadExratesData();

            adapter.Exrates = BankService.api.Exrates;
            TextViewValues = BankService.api.TextViewValues;
        }
    }
}

