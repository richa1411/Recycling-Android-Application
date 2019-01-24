using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using KymiraApplication.Adapters;
using KymiraApplication.Models;
using Newtonsoft.Json;

namespace KymiraApplication.Fragments
{
    public class FAQFragment : Fragment
    {

        //Define the view and the List
        private View view;
        private static List<FAQ> FAQList; // This will store all of the FAQ items
        private ListView lvFAQs;

        private HttpClient client; // This client is used for GET and POST requests

        private ExpandableListView expListView;
        private IExpandableListAdapter expListAdapter;


        //Will run when the app is run. It is the initial creation of the fragment
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        //This view will run when the fragment is called
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {


            
            //Will create a listview adapter that will populate the list
            //will get the FAQ items from the backend and populate the list view

            //Instantiate the HTTP Client used to contact the API
            client = new HttpClient();
            //Have a timeout of 10 seconds if the server can't be reached
            client.Timeout = System.TimeSpan.FromSeconds(10);

            var view = inflater.Inflate(Resource.Layout.faq_layout, container, false);


            expListAdapter = new ArrayAdapter<String>(Resource.Layout.faq_details_layout);

            expListView = view.FindViewById<ExpandableListView>(Resource.Id.lvFAQ);

            





            //FAQList = new List<FAQ>();
            //lvFAQs = view.FindViewById<ListView>(Resource.Id.lvFAQ); ////////////
            //setFAQs();

            return view;

        }

        // This method creates a new DisposablesAdapter and sets 
        // the listview to use it.
        private void dsiplayFAQList(List<FAQ> faq)
        {
            FAQListAdapter adapter = new FAQListAdapter(Context, faq);

            lvFAQs.Adapter = adapter;
        }

        //Will run when an item in the listView is selected. This will bring up the next "faq_details" fragment page
        private async void Item_Select(Object sender, EventArgs e)
        {
            //Open the faq_details_layout fragment that will contain all the content from the item in the list
        }


        public async void setFAQs()
        {
            ////Assigning the layout
            //LinearLayout layout = view.FindViewById<LinearLayout>(Resource.Id.masterLayout);
            ////Makes the request to t    
            //List<FAQ> FAQlist = await receiveDisposablesAsync();
            //disposables = displist;

            //// If the list has items in it
            //if (disposables.Count != 0)
            //{

            //    foreach (Disposable disposableItem in disposables)
            //    {
            //        //declaration
            //        var resourceId = 0;
            //        var var1 = disposableItem.imageURL;
            //        try
            //        {
            //            //sets resourceID to Drawable id of the current disposable items imageURL
            //            //it is set to 0 if it does not exist and will have a placeholder inserted below
            //            resourceId = (int)typeof(Resource.Drawable).GetField(var1).GetValue(null);
            //        }
            //        catch (Exception e)
            //        {

            //        }
            //        //if the imageURL does not exist, is null or empty a place holder will be inserted.
            //        if (disposableItem.imageURL == null || disposableItem.imageURL == "" || resourceId == 0)
            //        {

            //            //Place holder image is inserted.
            //            disposableItem.imageURL = Resource.Drawable.logoBlue.ToString();
            //        }
            //        else
            //        {
            //            //will change the image url to the Drawable resource number. ex: "2010102991"
            //            disposableItem.imageURL = resourceId.ToString();
            //        }

            //        // Validate those items to make sure they are valid
            //        var results = ValidationHelper.Validate(disposableItem);

            //        if (results.Count == 0)
            //        {
            //            if (disposableItem.isRecyclable)
            //            {
            //                recItems.Add(disposableItem);
            //            }
            //            else
            //            {
            //                nonRecItems.Add(disposableItem);
            //            }
            //        }


            //    }
            //    //the first time the app loads in. it sets the Listview to be of only recyclable items.
            //    displayDisposablesList(recItems);
            //}
            //else
            //{

            //    //If the list is empty and no responce was recieved from the server. we create a TextView to show an error.
            //    var error = view.FindViewById<TextView>(Resource.Id.errorLabel);
            //    error.Text = "Something went wrong, please try again later";
            //    error.SetTextSize(ComplexUnitType.Px, 120);


            //}



        }
    }
    
}