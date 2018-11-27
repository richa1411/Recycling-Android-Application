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

namespace KymiraApplication
{
    [Activity(Label = "BinCollection")]
    public class BinCollectionAddress : Activity
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
        //a method for onsubmit button that checks valid address(non empty, format) using BinCollectionDate Model Class
        //calls json from backend 
        //checks validatation(Non empty, format) on received date using BinCollectionDate Model class
        //and displays date with textview 

        private EditText addressField;
       
        private Button btnSubmitAddress;
        private TextView tvDisplayDate;
       
        private TextView tvError;
        private jsonHandler jsonHandler;
        List<ValidationResult> validationResult;
        DisplayBinCollectionDate displayBinCollectionDate;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            BinCollectionDate objCollection = new BinCollectionDate();
            objCollection.Address = "123 test";


            
            //assign values to private properties of the class
            //activity displays textview for address
            //activity displays button to submit entered address
            base.OnCreate(savedInstanceState);
           // listAdapter = new ArrayAdapter<string>(this, Resource.Layout.bin_status_list_item, binStatusArray);

            SetContentView(Resource.Layout.addressForCollection);

            //Assigning UI controls
           
          
            addressField = FindViewById<EditText>(Resource.Id.etAddress);
            tvError = FindViewById<EditText>(Resource.Id.tvError);
            btnSubmitAddress = FindViewById<Button>(Resource.Id.btnSubmit);





            //click events
            btnSubmitAddress.Click += BtnAddress_Click;

        }
        private async void BtnAddress_Click(object sender, EventArgs e)
        {
            string addressStr = addressField.Text;

            BinCollectionDate binCollectionDate = new BinCollectionDate();
            jsonHandler = new jsonHandler();

            binCollectionDate.Address = addressStr;
            validationResult = ValidationHelper.Validate(binCollectionDate);
            if (validationResult.Count > 0)
            {
                Toast.MakeText(this, validationResult[0].ErrorMessage, ToastLength.Short).Show();
            }
            else
            {
                var sendSuccess = await jsonHandler.sendJsonAsync(binCollectionDate, "https://jsonplaceholder.typicode.com/posts");

                checkReceivedObject(sendSuccess);
                
            }

        }
        private async void checkReceivedObject(HttpResponseMessage sendSuccess)
        {
            if (sendSuccess.IsSuccessStatusCode)
            {
                var receivedObject = await jsonHandler.receiveJsonAsync("https://jsonplaceholder.typicode.com/posts/1");

                //Toast.MakeText(this, receiveSuccess, ToastLength.Long).Show();
                if (receivedObject.IsSuccessStatusCode)
                {
                    string binCollectionJSON = await receivedObject.Content.ReadAsStringAsync();

                    //Deserialization takes a string and puts it back into an object
                    BinCollectionAddress binCollectionDateReceived = JsonConvert.DeserializeObject<BinCollectionAddress>(binCollectionJSON);

                    validationResult = ValidationHelper.Validate(binCollectionDateReceived);

                    if (validationResult.Count > 0)
                    {
                        Toast.MakeText(this, validationResult[0].ErrorMessage, ToastLength.Long).Show();
                    }
                    else
                    {
                        Intent intent = new Intent(this, typeof(DisplayBinCollectionDate));

                        //Serializing takes an object and turns it into a string
                        intent.PutExtra("ReceivedJSON", JsonConvert.SerializeObject(receivedObject));

                        this.StartActivity(intent);

                    }
                }
                else
                {
                    //status code is bad for some reason
                    Toast.MakeText(this, "Sorry something went wrong, please try again in a few minutes", ToastLength.Long).Show();
                }
            }
        }
        //checks the address string.

        //checks whether the field is empty

        //checks whether the field is a valid format for the address

        /*
        if(Invalid address)
        {

        //if anything is invalid (empty or invalid format) then the button will trigger an error message
        //with a textView saying "Invalid date"

        //will check the format of, and if the field is empty by referencing the ValidationHelper class.

        }
        else{
                send JSON object to the backend
                navigate to a new activity (second activity)

                if(address is in the database)
                {
                    display the next two pickup dates
                }
                else
                {
                    will display an error message "No dates available".
                }

            }
            */
    }



    
}
 
 