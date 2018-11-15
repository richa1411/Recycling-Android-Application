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
    [Activity(Label = "BinCollection")]
    public class BinCollection : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {

            /*if(user is logged in)
         {
              //calls json from backend 
              //checks validatation(Non empty, format) on received date using BinCollectionDate Model class
              //and displays date with textview 
          }
          else
            {
                //activity displays textview for address
                //activity displays button to submit entered address
                //a method for onsubmit button that checks valid address(non empty, format) using BinCollectionDate Model Class
               //calls json from backend 
              //checks validatation(Non empty, format) on received date using BinCollectionDate Model class
              //and displays date with textview 

            }*/
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}
 
 