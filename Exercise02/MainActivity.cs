using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise02.Api;
using Exercise02.Adapters;
using Exercise02.Models;
using System.Collections.Generic;
using Android.Content;

namespace Exercise02
{
    [Activity(Label = "Exercise02", Theme = "@android:style/Theme.Material.Light.DarkActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_user);
            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            var adapter = new UserAdapter(new List<User>());
            recyclerView.SetAdapter(adapter);

            var searchView = FindViewById<SearchView>(Resource.Id.sv_user);

            searchView.QueryTextSubmit += delegate
            {
                adapter.Users = GitHub.gitHub.GetUsers(searchView.Query);
            };

            adapter.ItemClick += (object sender, UserAdapterClickEventArgs e) =>
            {
                var intent = new Intent(this, typeof(Details));
                intent.PutExtra("url", e.RepositoryUrl);
                Detail.DetailCurrent = e.Detail;
                StartActivity(intent);
            };
        }
    }
}

