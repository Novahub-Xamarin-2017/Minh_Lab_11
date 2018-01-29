using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise02.Api;
using Exercise02.Adapters;
using Exercise02.Models;
using System.Collections.Generic;
using Android.Content;
using Exercise02.Models.Extension;
using System;
using System.Net;
using Android.Util;
using System.Linq;
using Android.Views;

namespace Exercise02
{
    [Activity(Label = "Exercise02", Theme = "@android:style/Theme.Material.Light.DarkActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private UserAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            adapter = new UserAdapter(new List<User>());
            var recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_user);
            recyclerView.SetRecyclerView(this, adapter);

            adapter.ItemClick += (object sender, EventArgs e) =>
            {
                var intent = new Intent(this, typeof(DetailsActivity));
                int position = recyclerView.GetChildAdapterPosition((View)sender);
                intent.PutExtra("url", adapter.Users[position].Url);
                StartActivity(intent);
            };

            var searchView = FindViewById<SearchView>(Resource.Id.sv_user);
            searchView.QueryTextSubmit += delegate
            {
                try
                {
                    var users = GitHub.Instance.GetUsers(searchView.Query);

                    if (!users.Any())
                    {
                        Toast.MakeText(this, "Result empty", ToastLength.Short).Show();
                    }

                    adapter.Users = users;
                }
                catch (WebException e)
                {
                    Log.Debug("ApiError", $"Exception: {e.Message}");
                }
            };
        }
    }
}

