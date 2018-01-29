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
using Exercise02.Models;
using Square.Picasso;

namespace Exercise02.Adapters
{
    public class UserAdapterViewHolder : RecyclerView.ViewHolder
    {
        private TextView textViewName;

        private ImageView imageViewAvatar;

        private TextView textViewEmail;

        private string url;

        private Detail detail;

        public event EventHandler ClickHandler;

        public User User
        {
            set
            {
                textViewName.Text = value.Login;
                textViewEmail.Text = value.Detail.Email;
                detail = value.Detail;
                url = value.Url;
                Picasso.With(ItemView.Context).Load(value.AvatarUrl).Resize(50, 50).Into(imageViewAvatar);
            }
        }

        public UserAdapterViewHolder(View itemView) : base(itemView)
        {
            textViewName = itemView.FindViewById<TextView>(Resource.Id.tv_user);
            textViewEmail = itemView.FindViewById<TextView>(Resource.Id.tv_email);
            imageViewAvatar = itemView.FindViewById<ImageView>(Resource.Id.iv_avatar);

            itemView.Click += (s, e) =>
            {
                ClickHandler.Invoke(itemView, e);
            };
        }
    }
}