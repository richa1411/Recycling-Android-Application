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

using KymiraApplication.Models;
using Newtonsoft.Json;

namespace KymiraApplication.Fragments
{
    public class FAQFragment : Fragment
    {

        //Define the view and the List
        private View view;
        private List<string> faqList;

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

            return view;

        }

        //Will run when an item in the listView is selected. This will bring up the next "faq_details" fragment page
        private async void Item_Select(Object sender, EventArgs e)
        {
            //Open the faq_details_layout fragment that will contain all the content from the item in the list
        }
    }
}