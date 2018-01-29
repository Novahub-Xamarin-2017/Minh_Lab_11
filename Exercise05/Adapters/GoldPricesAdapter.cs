using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise05.Models;
using System.Linq;

namespace Exercise05.Adapters
{
    class GoldPricesAdapter : RecyclerView.Adapter
    {
        private List<GoldPrice> goldPrices;

        public List<GoldPrice> GoldPrices
        {
            set
            {
                goldPrices = value;
                NotifyDataSetChanged();
            }
        }

        public GoldPricesAdapter(List<GoldPrice> goldPrices)
        {
            this.goldPrices = goldPrices;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.GoldPriceItem;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new GoldPricesAdapterViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((GoldPricesAdapterViewHolder)viewHolder).GoldPrice = goldPrices[position];
        }

        public override int ItemCount => goldPrices.Count;
    }

    public class GoldPricesAdapterViewHolder : RecyclerView.ViewHolder
    {
        private List<TextView> textViews;

        public GoldPrice GoldPrice
        {
            set
            {
                var index = 0;

                new List<string>()
                {
                    value.Buy,
                    value.Sell,
                    value.Type
                }.ForEach(x =>
                {
                    textViews[index].Text = x;
                    index++;
                });
            }
        }

        public GoldPricesAdapterViewHolder(View itemView) : base(itemView)
        {
            textViews = new List<int>()
            {
                Resource.Id.tv_buy,
                Resource.Id.tv_sell,
                Resource.Id.tv_type
            }.Select(x => itemView.FindViewById<TextView>(x)).ToList();
        }
    }
}