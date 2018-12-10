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
    [Activity(Label = "ListDisposable", MainLauncher = true)]
    public class ListDisposable : Activity
    {
        string[] jsonArray;
        private Button btnRec;
        private Button btnNonRec;
        //private ListView lvItems;
        private Disposable[] disposables;
        KymiraApplication.Model.ListDisposable listDisposableHelper;

        private List<Disposable> lstDisposables;
        private ListView listView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ItemListPage); 

            btnRec = (Button)FindViewById(Resource.Id.btnRec);
            btnNonRec = (Button)FindViewById(Resource.Id.btnNonRec);

            listView = (ListView)FindViewById(Resource.Id.listView);

            disposables = new Disposable[3];
          

            //lstDisposables = new List<Disposable>();

            //lstDisposables.Add(new Disposable("Paper", "used to write things on", "", true, "", 10, ""));
            //lstDisposables.Add(new Disposable("Cardboard", "used to hold things", "", true, "", 10, ""));
            //lstDisposables.Add(new Disposable("milk carton", "used to hold milk", "", true, "", 10, ""));


            


            btnRec.Click += btnRec_Click;
            btnNonRec.Click += btnNonRec_Click;
            //KymiraApplication.Model.ListDisposable.parseDisposable(jsonArray);
        }

        // Event handler for "Get Recyclables" button
        private void btnRec_Click(object sender, EventArgs e)
        {

            disposables[0] = (new Disposable("Paper", "used to write things on", "No_Image.png", true, "", 10, ""));
            disposables[1] = (new Disposable("Cardboard", "used to hold things", "", true, "", 10, ""));
            disposables[2] = (new Disposable("milk carton", "used to hold milk", "", true, "", 10, ""));

            displayDisposablesList(disposables);

            /**
            // This calls the method that will request a list
            KymiraApplication.Model.ListDisposable.requestDisposableListAsync(true);

            // This will set the disposables array to the disposables array saved in the ListDisposable model
            disposables = KymiraApplication.Model.ListDisposable.getDisposableList();

            // This will display the list for the user
            displayDisposablesList(disposables);
            */

        }

        // Event handler for "Get Non-Recyclables" button
        private void btnNonRec_Click(object sender, EventArgs e)
        {

            disposables[0] = (new Disposable("Food", "Food", "No_Image.png", false, "", 10, ""));
            disposables[1] = (new Disposable("Pizza", "Pizza", "", false, "", 10, ""));
            disposables[2] = (new Disposable("Garbage", "Garbage", "", false, "", 10, ""));

            displayDisposablesList(disposables);

            /**
            // This calls the method that will request a list
            KymiraApplication.Model.ListDisposable.requestDisposableListAsync(false);

            // This will set the disposables array to the disposables array saved in the ListDisposable model
            disposables = KymiraApplication.Model.ListDisposable.getDisposableList();

            // This will display the list for the user
            displayDisposablesList(disposables);
            */

        }


        /**
         * This method will take in the retrieved array of Disposable Objects, and place them
         * in a ListView, which will be displayed to the user.
         */ 
        private void displayDisposablesList(Disposable[] disposables)
        {
            RecNonRecListViewAdapter adapter = new RecNonRecListViewAdapter(this, disposables);

            listView.Adapter = adapter;
        }







    }
}