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
        //private ListView lvItems;
        private Disposable[] disposables;

        private List<Disposable> lstDisposables;
        private ListView listView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ItemListPage); 

            btnRec = (Button)FindViewById(Resource.Id.btnRecyclable);
            btnNonRec = (Button)FindViewById(Resource.Id.btnNonRecyclable);

            listView = (ListView)FindViewById(Resource.Id.listView);

            lstDisposables = new List<Disposable>();

            lstDisposables.Add(new Disposable("Paper", "used to write things on", "", true, "", 10, ""));
            lstDisposables.Add(new Disposable("Cardboard", "used to hold things", "", true, "", 10, ""));
            lstDisposables.Add(new Disposable("milk carton", "used to hold milk", "", true, "", 10, ""));


            RecNonRecListViewAdapter adapter = new RecNonRecListViewAdapter(this, lstDisposables);

            listView.Adapter = adapter;


            btnRec.Click += btnRec_Click;
            btnNonRec.Click += btnNonRec_Click;
            //KymiraApplication.Model.ListDisposable.parseDisposable(jsonArray);
        }

        // Event handler for "Get Recyclables" button
        private void btnRec_Click(object sender, EventArgs e)
        {
            //disposables = KymiraApplication.Model.ListDisposable.requestDisposableListAsync(true);
            displayDisposablesList(disposables);

        }

        // Event handler for "Get Non-Recyclables" button
        private void btnNonRec_Click(object sender, EventArgs e)
        {
            //disposables = KymiraApplication.Model.ListDisposable.requestDisposableListAsync(false);
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