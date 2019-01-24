using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KymiraApplication.Models;

namespace KymiraApplication.Adapters
{
    class FAQListAdapter : BaseAdapter<FAQ>
    {
        public List<FAQ> FAQList;
        Context context;

        public FAQListAdapter(Context context, List<FAQ> FAQList)
        {
            this.context = context;
            this.FAQList = FAQList;
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
                row = LayoutInflater.From(context).Inflate(Resource.Layout.faq_row_layout, null, false);
            }

            // Set the TextView
            TextView tvFAQItemName = row.FindViewById<TextView>(Resource.Id.tvFAQItemName);

            // Set the Text of the Textview to the name of the Disposable Object
            tvFAQItemName.Text = FAQList[position].answer;
            


            return row;

            var view = convertView;
            FAQListAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as FAQListAdapterViewHolder;

            if (holder == null)
            {
                holder = new FAQListAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //replace with your item and your holder items
                //comment back in
                //view = inflater.Inflate(Resource.Layout.item, parent, false);
                //holder.Title = view.FindViewById<TextView>(Resource.Id.text);
                view.Tag = holder;
            }


            //fill in your items
            //holder.Title.Text = "new text here";

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return 0;
            }
        }

        public override FAQ this[int position] => throw new NotImplementedException();
    }

    class FAQListAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}