using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise02.Models;
using Square.Picasso;

namespace Exercise02.Adapters
{
    class UserAdapter : RecyclerView.Adapter
    {
        public event EventHandler<UserAdapterClickEventArgs> ItemClick;

        private List<User> users;

        public List<User> Users
        {
            set
            {
                users = value;
                NotifyDataSetChanged();
            }
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

            return new UserAdapterViewHolder(itemView, OnClick);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((UserAdapterViewHolder)viewHolder).User = users[position];
        }

        public override int ItemCount => users.Count;

        void OnClick(UserAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
    }

    public class UserAdapterViewHolder : RecyclerView.ViewHolder
    {
        private TextView textViewName;

        private ImageView imageViewAvatar;

        private TextView textViewEmail;

        private string url;

        private Detail detail;

        public User User
        {
            set
            {
                textViewName.Text = value.Login;
                textViewEmail.Text = value.Detail.Email?.ToString() ?? "";
                detail = value.Detail;
                url = value.Url;
                Picasso.With(ItemView.Context).Load(value.AvatarUrl).Resize(50, 50).Into(imageViewAvatar);
            }
        }

        public UserAdapterViewHolder(View itemView, Action<UserAdapterClickEventArgs> clickListener) : base(itemView)
        {
            textViewName = itemView.FindViewById<TextView>(Resource.Id.tv_user);
            textViewEmail = itemView.FindViewById<TextView>(Resource.Id.tv_email);
            imageViewAvatar = itemView.FindViewById<ImageView>(Resource.Id.iv_avatar);

            itemView.Click += (sender, e) => clickListener(new UserAdapterClickEventArgs
            {
                View = itemView,
                Url = url,
                Detail = detail
            });
        }
    }

    public class UserAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }

        public string Url { get; set; }

        public Detail Detail { get; set; }
    }
}