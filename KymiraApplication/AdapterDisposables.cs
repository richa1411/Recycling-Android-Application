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
    class AdapterDisposables : BaseAdapter<Disposable>
    {

        public List<Disposable> disposablesList;
        private Context context;

        public AdapterDisposables(Context context, List<Disposable> disposablesList)
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

            TextView tvDisposableItemName = row.FindViewById<TextView>(Resource.Id.tvDisposableItemName);
            tvDisposableItemName.Text = disposablesList[position].name;

            ImageView ivDisposableItemName = row.FindViewById<ImageView>(Resource.Id.ivDisposableItemImage);

            // TODO: Have to set the image to the ImageURL of item's image
            ivDisposableItemName.SetImageResource(Resource.Drawable.No_Image);

            return row;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return 0;
            }
        }

        public override Disposable this[int position] => throw new NotImplementedException();
    }

    class AdapterDisposablesViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}