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
        private Disposable[] disposables;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ItemListPage); 
            btnRec = (Button)FindViewById(Resource.Id.btnRecyclable);
            btnNonRec = (Button)FindViewById(Resource.Id.btnNonRecyclable);
            lvItems = (ListView)FindViewById(Resource.Id.lvItemList);

            btnRec.Click += btnRec_Click;

            btnNonRec.Click += btnNonRec_Click;



            //KymiraApplication.Model.ListDisposable.parseDisposable(jsonArray);


        }

        // Event handler for "Get Recyclables" button
        private void btnRec_Click(object sender, EventArgs e)
        {
            disposables = KymiraApplication.Model.ListDisposable.requestDisposableListAsync(true);
            displayDisposablesList(disposables);

        }

        // Event handler for "Get Non-Recyclables" button
        private void btnNonRec_Click(object sender, EventArgs e)
        {
            disposables = KymiraApplication.Model.ListDisposable.requestDisposableListAsync(false);
            displayDisposablesList(disposables);

        }


        /**
         * This method will take in the retrieved array of Disposable Objects, and place them
         * in a ListView, which will be displayed to the user.
         */ 
        private void displayDisposablesList(Disposable[] disposables)
        {

        }







    }
}