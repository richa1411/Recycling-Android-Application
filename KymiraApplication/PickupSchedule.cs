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
    [Activity(Label = "PickupSchedule")]
    public class PickupSchedule : Activity
    {
        //Declare jsonHandler
        private jsonHandler jsonHandler;

        //Declare UI controls

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Assign UI Controls
        }

        //Function that handles generating the text for the collection date text views
        private async void sendAddress(string address)
        {
            //Request collection dates from the API/backend based on address

            //Update layout with bin collection information
        }
    }
}