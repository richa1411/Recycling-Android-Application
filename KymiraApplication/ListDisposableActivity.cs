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
using KymiraApplication.Model;

namespace KymiraApplication
{
    [Activity(Label = "ListDisposable")]
    public class ListDisposable : Activity
    {
        string[] jsonArray;
        private Button btnRec;
        private Button btnNonRec;
        private ListView lvItems;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ItemListPage); 
            btnRec = (Button)FindViewById(Resource.Id.btnRecyclable);
            btnNonRec = (Button)FindViewById(Resource.Id.btnNonRecyclable);
            lvItems = (ListView)FindViewById(Resource.Id.lvItemList);


            //KymiraApplication.Model.ListDisposable.parseDisposable(jsonArray);

        }

       



    }
}