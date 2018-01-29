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
using Android.Support.V7.Widget;
using MainApi = Exercise01.Api.Api;
using Exercise01.Adapters;

namespace Exercise01
{
    [Activity(Label = "Tweet", Theme = "@android:style/Theme.Material.Light.NoActionBar")]
    public class Tweets : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Tweet);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_tweets);
            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            var adapter = new TweetsAdapter(MainApi.api.GetTweets());
            recyclerView.SetAdapter(adapter);

            FindViewById<ImageButton>(Resource.Id.ib_logout).Click += delegate
            {
                MainApi.api.Logout();
                if (MainApi.api.messageCurrent.Equals(""))
                {
                    StartActivity(typeof(MainActivity));
                }
                else
                {
                    Toast.MakeText(this, MainApi.api.messageCurrent, ToastLength.Short).Show();
                }
            };
        }
    }
}