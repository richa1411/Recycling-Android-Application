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
        private EditText addressField;
       
        private Button btnLogin;
        private TextView txtDate;
        private TextView txtError;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //We have two activities

            //The first activity (addressForCollection) is for non-logged in users which will have a textview for an address field to fill in
            //and also a button that will submit the address provided. 
            //Then the application will check the given address with the backend to verify that address exists in the database.
            //If the address exists, and it is valid a collection date for that address will be displayed in another activity 
            //(CollectionDate) for the user.

            //The Second Activity (CollectionDate) will have no inputs, but instead will just automatically
            //check the given address linked to the users account or specified by a non-logged in user with the backend to verify 
            //that address exists in the database. If the address exists, a collection date for that address will be displayed to the user.

            //Logged in users will automatically be shown the second activity and will never see the first activity unless they log out.




            /*

                //activity displays textview for address
                //activity displays button to submit entered address
                //a method for onsubmit button that checks valid address(non empty, format) using BinCollectionDate Model Class
               //calls json from backend 
              //checks validatation(Non empty, format) on received date using BinCollectionDate Model class
              //and displays date with textview 

            }

            private void btnAddress_Click(object sender, EventArgs e)
            {
               
            }
            */

        }


    }
}
 
 