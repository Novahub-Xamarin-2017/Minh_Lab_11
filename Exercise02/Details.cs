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
using Exercise02.Api;
using Exercise02.Models;

namespace Exercise02
{
    [Activity(Label = "Details", Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class Details : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Details);

            var detail = Detail.DetailCurrent;
            FindViewById<TextView>(Resource.Id.tv_blog).Text = "Blog: " + detail.Blog;
            FindViewById<TextView>(Resource.Id.tv_company).Text = "Company: " + detail.Company;
            FindViewById<TextView>(Resource.Id.tv_email).Text = "Email: " + detail.Email?.ToString() ?? "";
            FindViewById<TextView>(Resource.Id.tv_location).Text = "Location: " + detail.Location;
            FindViewById<TextView>(Resource.Id.tv_name).Text = "Name: " + detail.Name;

            var listView = FindViewById<ListView>(Resource.Id.lv_repository);
            var url = Intent.GetStringExtra("url");
            var adapter = new ArrayAdapter<string>(this, Resource.Layout.Repository, GitHub.gitHub.GetRepositories(url));
            listView.Adapter = adapter;
        }
    }
}