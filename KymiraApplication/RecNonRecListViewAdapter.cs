﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KymiraApplication.Model;

namespace KymiraApplication
{
    public class RecNonRecListViewAdapter : BaseAdapter<Disposable>
    {

        public List<Disposable> listDisposables;
        private Context cContext;

        public RecNonRecListViewAdapter(Context context, List<Disposable> items)
        {
            listDisposables = items;
            cContext = context;
        }

        public override int Count
        {
            get { return listDisposables.Count; }
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

            TextView txName = row.FindViewById<TextView>(Resource.Id.tvName);
            txName.Text = listDisposables[position].name;


            TextView txDesc = row.FindViewById<TextView>(Resource.Id.tvDesc);
            txDesc.Text = listDisposables[position].description;


            return row;
        }
    }
}
