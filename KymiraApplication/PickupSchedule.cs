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

namespace KymiraApplication
{
    [Activity(Label = "PickupSchedule")]
    public class PickupSchedule : Activity
    {
        //Declare jsonHandler

        //Declare UI controls

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            
            //Assign UI Control

            //Call method to populate text view's with collection information
        }

        //Function that handles generating the text for the collection date text views
        private async void setCollectionDateText()
        {
            //Request collection dates from the API/backend

            //Update text views with collection date information
        }
    }
}