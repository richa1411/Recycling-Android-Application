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
using KymiraApplication.Models;

namespace KymiraApplication
{
    class DisposablesAdapter : BaseAdapter<Disposable>
    {

        public List<Disposable> disposablesList;
        private Context context;

        public DisposablesAdapter(Context context, List<Disposable> disposablesList)
        {
            this.context = context;
            this.disposablesList = disposablesList;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var row = convertView; // Set the Row/View

            if (row == null)
            {
                // Inflate the Row/View
                row = LayoutInflater.From(context).Inflate(Resource.Layout.disposables_row_layout, null, false);
            }

            // Set the TextView
            TextView tvDisposableItemName = row.FindViewById<TextView>(Resource.Id.tvDisposableItemName);

            // Set the Text of the Textview to the name of the Disposable Object
            tvDisposableItemName.Text = disposablesList[position].name;

            // Set our ImageView
            ImageView ivDisposableItemName = row.FindViewById<ImageView>(Resource.Id.ivDisposableItemImage);

            // This grabs the "ImageURL" from the Disposable Object
            // and parses it into a URI that is then set to the 
            // Imageview's ImageURI
            Android.Net.Uri url = Android.Net.Uri.Parse(disposablesList[position].imageURL);
            ivDisposableItemName.SetImageURI(url);

            // This is the backup image, we won't need this here if we are
            // adding our placeholder image to Disposables in the fragment
            ivDisposableItemName.SetImageResource(Resource.Drawable.No_Image);

            return row;
        }

        
        public override int Count
        {
           get
            {
               return disposablesList.Count();
            }
        }

        public override Disposable this[int position]
        {
            get
            {
                return disposablesList[position];
            }
        }
    }

    class AdapterDisposablesViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}