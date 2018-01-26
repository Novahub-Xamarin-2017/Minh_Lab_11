using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise06.Models;
using System.Linq;

namespace Exercise06.Adapters
{
    class ExratesAdapter : RecyclerView.Adapter
    {
        private List<Exrate> exrates;

        public List<Exrate> Exrates
        {
            set
            {
                exrates = value;
                NotifyDataSetChanged();
            }
        }

        public ExratesAdapter(List<Exrate> exrates)
        {
            this.exrates = exrates;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.RateCardView;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new ExratesAdapterViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((ExratesAdapterViewHolder)viewHolder).Exrate = exrates[position];
        }

        public override int ItemCount => exrates.Count;
    }

    public class ExratesAdapterViewHolder : RecyclerView.ViewHolder
    {
        private List<TextView> textViews;

        public Exrate Exrate
        {
            set
            {
                var index = 0;

                new List<string>()
                {
                    value.CurrencyName,
                    value.CurrencyCode,
                    value.Buy,
                    value.Sell,
                    value.Transfer
                }.ForEach(x =>
                {
                    textViews[index].Text = x;
                    index++;
                });
            }
        }

        public ExratesAdapterViewHolder(View itemView) : base(itemView)
        {
            textViews = new List<int>()
            {
                Resource.Id.tv_currencyname,
                Resource.Id.tv_currencycode,
                Resource.Id.tv_buy,
                Resource.Id.tv_sell,
                Resource.Id.tv_transfer
            }.Select(x => itemView.FindViewById<TextView>(x)).ToList();
        }
    }
}