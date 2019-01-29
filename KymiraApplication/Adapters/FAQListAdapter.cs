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

namespace KymiraApplication
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
            TextView tvFAQQ = row.FindViewById<TextView>(Resource.Id.tvFAQQuestion);
            TextView tvFAQA = row.FindViewById<TextView>(Resource.Id.tvFAQAnswer);

            // Set the Text of the Textview to the name of the Disposable Object
            tvFAQQ.Text = FAQList[position].question;
            tvFAQA.Text = FAQList[position].answer;
          
            return row;
        }

        //Fill in count here, currently 0
        public override int Count
        {
            get
            {
                return FAQList.Count();
            }
        }

        public override FAQ this[int position]
        {
            get
            {
                return FAQList[position];
            }
        }
    }



    class FAQListAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}