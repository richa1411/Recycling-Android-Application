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

namespace KymiraApplication.Fragments
{
    class FAQDetailsFragment:Fragment
    {
        //************************************************************************************//
        //Make sure there is a way to return without going to the navigation page (back button)
        // ONLY IF DOING SEPERATE FRAGMENTS


        //Define the view and the textView
        private View view;
        private TextView tvDetails;

        //Will run when the app is run. It is the initial creation of the fragment
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        //This view will run when the fragment is called
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            //will get the FAQ item selected from the backend and populate the text view with the entire content

            return view;

        }
    }
}