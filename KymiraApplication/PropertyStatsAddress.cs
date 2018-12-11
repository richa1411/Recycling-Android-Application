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
using Newtonsoft.Json;
using KymiraApplication.Model;

using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Android.Support.V7.App;

namespace KymiraApplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class PropertyStatsAddress : AppCompatActivity
    {
        //We have two activities

        //The first activity (ViewPropertyStatsAddress) is for non-logged in users which will have a textview for an address field to fill in
        //and also a button that will submit the address provided. 
        //Then the application will check the given address with the backend to verify that address exists in the database.
        //If the address exists, and it is valid a collection date for that address will be displayed in another activity 
        //(ViewPropertyStats) for the user.

        //The Second Activity (ViewPropertyStats) will have no inputs, but instead will just automatically
        //check the given address linked to the users account or specified by a non-logged in user with the backend to verify 
        //that address exists in the database. If the address exists, stats for that address will be displayed to the user.
        //The user will also be able to see stats for the top other properties and be able to notice how their property is doing in comparison to the users

        //Logged in users will automatically be shown the second activity and will never see the first activity unless they log out.
        //a method for onsubmit button that checks valid address(non empty, format) using the PropertyStats Model Class
        //calls json from backend 
        //checks validatation(Non empty, format) on received date using PropertyStats Model Class
        //and will show the stats in a text view

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //assign values to the private properties of the class
            //activity displays a textview for the property address
            //activity displays a button to submit entered address

            //Assigning UI controls (FindViewById)
            base.OnCreate(savedInstanceState);
            //need a click event for the button

            SetContentView(Resource.Layout.AddressForPropertyStats);


        }
        private void BtnAddress_Click(object sender, EventArgs e)
        {
            //Will need the button to call the validation helper to verify that the address is a valid address

        }
    }
}