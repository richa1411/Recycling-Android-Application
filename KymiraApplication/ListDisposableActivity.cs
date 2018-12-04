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
    public class ListDisposable : ListActivity
    {
        string[] jsonArray;
        private Button btnRec;
        private Button btnNonRec;
        private ListView lvItems;
        private Disposable[] disposables;
        KymiraApplication.Model.ListDisposable listDisposableHelper;

        static readonly string[] countries = new String[] {
    "Afghanistan","Albania","Algeria","American Samoa","Andorra",
    "Angola","Anguilla","Antarctica","Antigua and Barbuda","Argentina",
    "Armenia","Aruba","Australia","Austria","Azerbaijan",
    "Bahrain","Bangladesh","Barbados","Belarus","Belgium",
    "Belize","Benin","Bermuda","Bhutan","Bolivia",
    "Bosnia and Herzegovina","Botswana","Bouvet Island","Brazil","British Indian Ocean Territory",
    "British Virgin Islands","Brunei","Bulgaria","Burkina Faso","Burundi",
    "Cote d'Ivoire","Cambodia","Cameroon","Canada","Cape Verde"

  };


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ItemListPage); 

            string[] items;
            items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);


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
            // This calls the method that will request a list
            KymiraApplication.Model.ListDisposable.requestDisposableListAsync(true);

            // This will set the disposables array to the disposables array saved in the ListDisposable model
            disposables = KymiraApplication.Model.ListDisposable.getDisposableList();

            // This will display the list for the user
            displayDisposablesList(disposables);

        }

        // Event handler for "Get Non-Recyclables" button
        private void btnNonRec_Click(object sender, EventArgs e)
        {
            // This calls the method that will request a list
            KymiraApplication.Model.ListDisposable.requestDisposableListAsync(false);

            // This will set the disposables array to the disposables array saved in the ListDisposable model
            disposables = KymiraApplication.Model.ListDisposable.getDisposableList();

            // This will display the list for the user
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