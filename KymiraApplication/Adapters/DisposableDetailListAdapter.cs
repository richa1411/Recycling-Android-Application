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
    class DisposableDetailListAdapter : BaseExpandableListAdapter
    {
        public List<Disposable> disposableList;
        Context context;

        public DisposableDetailListAdapter(Context context, List<Disposable> disposableList)
        {
            this.context = context;
            this.disposableList = disposableList;
        }

        public override int GroupCount => disposableList.Count();

        public override bool HasStableIds => true;

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return null;
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return 1;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            //throw new NotImplementedException();

            var view = convertView;

            if (view == null)
            {
                //var inflater = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = LayoutInflater.From(context).Inflate(Resource.Layout.detail_layout, null, false);
            }

            TextView descView = view.FindViewById<TextView>(Resource.Id.description_detail);
            TextView reasonView = view.FindViewById<TextView>(Resource.Id.reason_detail);
            TextView endView = view.FindViewById<TextView>(Resource.Id.result_detail);
            TextView qtyView = view.FindViewById<TextView>(Resource.Id.qtyrecycled_detail);

            descView.Text = disposableList[childPosition].description;
            reasonView.Text = disposableList[childPosition].recycleReason;
            endView.Text = disposableList[childPosition].endResult;
            qtyView.Text = disposableList[childPosition].qtyRecycled.ToString();

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
            // throw new NotImplementedException();
            var row = convertView; // Set the Row/View
            if (row == null)
            {
                // Inflate the Row/View
                row = LayoutInflater.From(context).Inflate(Resource.Layout.disposables_row_layout, null, false);
            }

            // Set the TextView
            TextView tvDisposableItemName = row.FindViewById<TextView>(Resource.Id.tvDisposableItemName);

            // Set the Text of the Textview to the name of the Disposable Object
            tvDisposableItemName.Text = disposableList[groupPosition].name;

            // Set our ImageView
            ImageView ivDisposableItemName = row.FindViewById<ImageView>(Resource.Id.ivDisposableItemImage);

            // This grabs the "ImageURL" from the Disposable Object
            // and parses it into a URI that is then set to the 
            //imageview's imageResource.
            int id = int.Parse(disposableList[groupPosition].imageURL);
            ivDisposableItemName.SetImageResource(id);


            return row;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }
    }
}