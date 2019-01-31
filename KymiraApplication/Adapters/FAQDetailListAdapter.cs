using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using KymiraApplication.Models;

namespace KymiraApplication.Adapters
{
    class FAQDetailListAdapter : BaseExpandableListAdapter
    {
        public List<FAQ> FAQList;
        Context context;

        public FAQDetailListAdapter(Context context, List<FAQ> FAQList)
        {
            this.context = context;
            this.FAQList = FAQList;
        }

        public override int GroupCount => FAQList.Count();

        public override bool HasStableIds => true;

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return null;
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return groupPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return 1;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.faq_answer_layout, null, false);
            }

            TextView answerView = view.FindViewById<TextView>(Resource.Id.tvFAQAnswer);

            answerView.Text = FAQList[groupPosition].answer;

            return view;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return null;
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            var row = convertView; // Set the Row/View
            if (row == null)
            {
                // Inflate the Row/View
                row = LayoutInflater.From(context).Inflate(Resource.Layout.faq_question_layout, null, false);
            }

            // Set the TextView
            TextView tvFAQQ = row.FindViewById<TextView>(Resource.Id.tvFAQQuestion);

            // Set the Text of the Textview to the name of the Disposable Object
            tvFAQQ.Text = FAQList[groupPosition].question;

            return row;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }
    }
}