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

namespace Exercise05.Models.Extensions
{
    public static class RecyclerViewExtension
    {
        public static void SetRecyclerView(this RecyclerView recyclerView, Context context, RecyclerView.Adapter adapter)
        {
            recyclerView.SetLayoutManager(new LinearLayoutManager(context));
            recyclerView.SetAdapter(adapter);
        }
    }
}