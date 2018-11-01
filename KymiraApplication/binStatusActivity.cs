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
    [Activity(Label = "binStatusActivity")]
    public class binStatusActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }




        /**
         * This method will send a json Object of the resident to the backend api requesting the users bin/s to check the contamination status of said bins
         * 
         * */
        private void requestBinStatus()
        {
        }
        /**
         * this method will take the status and dislay the bin on the Layout
         * */
        private void displayBinStatus()
        { }

       
    }
}