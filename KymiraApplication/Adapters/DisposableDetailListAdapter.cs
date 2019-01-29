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
    class DisposableDetailListAdapter : Java.Lang.Object, IExpandableListAdapter
    {
        public List<Disposable> disposableList;
        Context context;

        public DisposableDetailListAdapter(Context context, List<Disposable> disposableList)
        {
            this.context = context;
            this.disposableList = disposableList;
        }


        //public  Java.Lang.Object GetItem(int position)
        //{
        //    return position;
        //}

        //public override long GetItemId(int position)
        //{
        //    return position;
        //}

        //public override View GetView(int position, View convertView, ViewGroup parent)
        //{
        //    var view = convertView;
        //    DisposableDetailListAdapterViewHolder holder = null;

        //    if (view != null)
        //        holder = view.Tag as DisposableDetailListAdapterViewHolder;

        //    if (holder == null)
        //    {
        //        holder = new DisposableDetailListAdapterViewHolder();
        //        var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
        //        //replace with your item and your holder items
        //        //comment back in
        //        //view = inflater.Inflate(Resource.Layout.item, parent, false);
        //        //holder.Title = view.FindViewById<TextView>(Resource.Id.text);
        //        view.Tag = holder;
        //    }


        //    //fill in your items
        //    //holder.Title.Text = "new text here";

        //    return view;
        //}

        public bool AreAllItemsEnabled()
        {
            throw new NotImplementedException();
        }

        public Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            throw new NotImplementedException();
        }

        public long GetChildId(int groupPosition, int childPosition)
        {
            throw new NotImplementedException();
        }

        public int GetChildrenCount(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            //throw new NotImplementedException();

            var view = convertView;

            if (view == null)
            {
                var inflater = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                view = inflater.Inflate(Resource.Layout.detail_layout, null);
            }


            return view;
        }

        public long GetCombinedChildId(long groupId, long childId)
        {
            throw new NotImplementedException();
        }

        public long GetCombinedGroupId(long groupId)
        {
            throw new NotImplementedException();
        }

        public Java.Lang.Object GetGroup(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public long GetGroupId(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
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

        public bool IsChildSelectable(int groupPosition, int childPosition)
        {
            throw new NotImplementedException();
        }

        public void OnGroupCollapsed(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public void OnGroupExpanded(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public void RegisterDataSetObserver(DataSetObserver observer)
        {
            throw new NotImplementedException();
        }

        public void UnregisterDataSetObserver(DataSetObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
        public int GroupCount => throw new NotImplementedException();

        public bool HasStableIds => throw new NotImplementedException();

        public bool IsEmpty => throw new NotImplementedException();

        public IntPtr Handle => throw new NotImplementedException();
    }

    class DisposableDetailListAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}