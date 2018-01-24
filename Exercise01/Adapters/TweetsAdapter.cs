using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Exercise01.Api.Models;
using Android.Net;
using Android.Graphics;
using System.Net;

namespace Exercise01.Adapters
{
    class TweetsAdapter : RecyclerView.Adapter
    {
        private List<Tweet> tweets;

        private List<string> images;

        private bool isImage;

        public TweetsAdapter(List<Tweet> tweetsOrImages)
        {
            tweets = tweetsOrImages;
            this.isImage = false;
        }

        public TweetsAdapter(List<string> tweetsOrImages)
        {
            images = tweetsOrImages;
            this.isImage = true;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (isImage)
            {
                var id = Resource.Layout.CardViewImage;
                var itemView = LayoutInflater.From(parent.Context).
                       Inflate(id, parent, false);

                return new ImagesAdapterViewHolder(itemView);
            }
            else
            {
                var id = Resource.Layout.CardViewTweet;
                var itemView = LayoutInflater.From(parent.Context).
                       Inflate(id, parent, false);

                return new TweetsAdapterViewHolder(itemView);
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            if (isImage)
            {
                ((ImagesAdapterViewHolder)viewHolder).Image = images[position];
            }
            else
            {
                ((TweetsAdapterViewHolder)viewHolder).Tweet = tweets[position];
            }
        }

        public override int ItemCount => isImage ? images?.Count ?? 0 : tweets?.Count ?? 0;
    }

    public class TweetsAdapterViewHolder : RecyclerView.ViewHolder
    {
        private TextView textViewName;

        private TextView textViewContent;

        private RecyclerView recyclerView;

        public Tweet Tweet
        {
            set
            {
                textViewName.Text = value.Author;
                textViewContent.Text = value.Content;

                var layoutManager = new LinearLayoutManager(ItemView.Context);
                recyclerView.SetLayoutManager(layoutManager);
                var adapter = new TweetsAdapter(value.Images);
                recyclerView.SetAdapter(adapter);
            }
        }

        public TweetsAdapterViewHolder(View itemView) : base(itemView)
        {
            textViewName = itemView.FindViewById<TextView>(Resource.Id.tv_name);
            textViewContent = itemView.FindViewById<TextView>(Resource.Id.tv_content);
            recyclerView = itemView.FindViewById<RecyclerView>(Resource.Id.rv_tweet);
        }
    }

    public class ImagesAdapterViewHolder : RecyclerView.ViewHolder
    {
        private ImageView imageView;

        public string Image
        {
            set
            {
                imageView.SetImageBitmap(GetImageBitmapFromUrl(value));
            }
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            if (!string.IsNullOrEmpty(url))
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);

                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }
            }
                
            return imageBitmap;
        }

        public ImagesAdapterViewHolder(View itemView) : base(itemView)
        {
            imageView = itemView.FindViewById<ImageView>(Resource.Id.iv_image);
        }
    }
}