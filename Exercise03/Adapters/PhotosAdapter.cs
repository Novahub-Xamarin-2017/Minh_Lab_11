using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Square.Picasso;

namespace Exercise03.Adapters
{
    class PhotosAdapter : RecyclerView.Adapter
    {
        private List<string> photos;

        public List<string> Photos
        {
            set
            {
                photos = value;
                NotifyDataSetChanged();
            }
        }

        public PhotosAdapter(List<string> photos)
        {
            this.photos = photos;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var id = Resource.Layout.CardViewPhoto;
            var itemView = LayoutInflater.From(parent.Context).
                   Inflate(id, parent, false);

            return new PhotosAdapterViewHolder(itemView);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            ((PhotosAdapterViewHolder)viewHolder).Photo = photos[position];
        }

        public override int ItemCount => photos.Count;
    }

    public class PhotosAdapterViewHolder : RecyclerView.ViewHolder
    {
        private ImageView imageView;

        public string Photo
        {
            set
            {
                Picasso.With(ItemView.Context).Load(value).Fit().CenterInside().Into(imageView);
            }
        }

        public PhotosAdapterViewHolder(View itemView) : base(itemView)
        {
            imageView = itemView.FindViewById<ImageView>(Resource.Id.iv_photo);
        }
    }
}