using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KymiraApplication.Model;

namespace KymiraApplication
{
    public class RecNonRecListViewAdapter : BaseAdapter<Disposable>
    {

        public Disposable[] listDisposables;
        private Context cContext;

        public RecNonRecListViewAdapter(Context context, Disposable[] items)
        {
            listDisposables = items;
            cContext = context;
        }

        public override int Count
        {
            get { return listDisposables.Length; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Disposable this[int position]
        {
            get { return listDisposables[position]; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(cContext).Inflate(Resource.Layout.listviewRow, null, false);
            }

            TextView txName = row.FindViewById<TextView>(Resource.Id.tvDespName);
            txName.Text = listDisposables[position].name;
       

            ImageView ivBackup = row.FindViewById<ImageView>(Resource.Id.ivDispPic);

            ImageView ivURLImage = new ImageView(cContext);

            ivBackup.SetImageResource(Resource.Drawable.No_Image);

          
            /**
             *  Set an ImageView pointing to our placeholder. 
             *  ImageURL in the Disposable.ImageURL will be a full URL pointing to a place 
             *  on the internet. If ImageURL can find a valid image, replace our old imageView.
             *  Use a webserver to test images
             */ 



            return row;
        }
    }
}
