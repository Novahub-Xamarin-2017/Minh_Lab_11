using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise02.Models;
using Square.Picasso;

namespace Exercise02.Adapters
{
    public class UserAdapter : RecyclerView.Adapter
    {
        public event EventHandler ItemClick;

        private List<User> users;

        public List<User> Users
        {
            set
            {
                users = value;
                NotifyDataSetChanged();
            }

            get => users;
        }

        public UserAdapter(List<User> users)
        {
            this.users = users;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.CardViewUser;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            var userAdapterViewHolder = new UserAdapterViewHolder(itemView);

            userAdapterViewHolder.ClickHandler += ItemClick;

            return userAdapterViewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((UserAdapterViewHolder)viewHolder).User = users[position];
        }

        public override int ItemCount => users.Count;
    }
}