using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise05.Models;
using Exercise05.Models.Extensions;

namespace Exercise05.Adapters
{
    class CitiesAdapter : RecyclerView.Adapter
    {
        private List<City> cities;

        public List<City> Cities
        {
            set
            {
                cities = value;
                NotifyDataSetChanged();
            }
        }

        public CitiesAdapter(List<City> cities)
        {
            this.cities = cities;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.CityCardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new CitiesAdapterViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((CitiesAdapterViewHolder)viewHolder).City = cities[position];
        }

        public override int ItemCount => cities.Count;
    }

    public class CitiesAdapterViewHolder : RecyclerView.ViewHolder
    {
        private TextView textViewCityName;

        private RecyclerView recyclerViewGoldPrice;

        private GoldPricesAdapter adapter;

        public City City
        {
            set
            {
                textViewCityName.Text = value.Name;
                adapter.GoldPrices = value.GoldPrices;
            }
        }

        public CitiesAdapterViewHolder(View itemView) : base(itemView)
        {
            textViewCityName = itemView.FindViewById<TextView>(Resource.Id.tv_cityname);

            recyclerViewGoldPrice = itemView.FindViewById<RecyclerView>(Resource.Id.rccv_goldprice);
            adapter = new GoldPricesAdapter(new List<GoldPrice>());
            recyclerViewGoldPrice.SetRecyclerView(ItemView.Context, adapter);
        }
    }
}