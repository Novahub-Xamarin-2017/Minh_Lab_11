using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Exercise03.Adapters;
using System.Collections.Generic;
using Exercise03.Api;

namespace Exercise03
{
    [Activity(Label = "Exercise03", Theme = "@android:style/Theme.Material.Light.DarkActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_photo);
            var layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            var adapter = new PhotosAdapter(new List<string>());
            recyclerView.SetAdapter(adapter);

            var searchView = FindViewById<SearchView>(Resource.Id.sv_photo);
            searchView.QueryTextSubmit += delegate
            {
                adapter.Photos = FindPhotos.api.GetPhotos(searchView.Query);
            };
        }
    }
}

