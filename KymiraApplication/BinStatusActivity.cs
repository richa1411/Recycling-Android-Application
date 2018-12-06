using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using KymiraApplication.Model;
using Newtonsoft.Json;

namespace KymiraApplication.Resources
{
    [Activity(Label = "BinStatusActivity",MainLauncher = true)]
    public class BinStatusActivity : Activity
    {
        //UI controls for this activity
        private TextView tvTitle;
        private TextView tvAddress;
        private TextView tvAddressLabel;
        private EditText etAddress;
        private Button btnSubmit;
        private ListView lvBins;

        //adapter for the list view of bin objects to display
        private IListAdapter listAdapter;
        private IListAdapter listPopulatedAdapter;

        private string[] listPlaceholder;

        //the BinStatus object created by user's entered data to send to the backend
        private BinStatus binStatusSend;

        //list to hold results when validating BinStatus objects
        private List<ValidationResult> validationResults;

        private jsonHandler jsonHandler;

        //class to simulate the backend (contains objects to compare)
        private SimBinStatusBackend simBinStatusBackend;

        //the BinStatus objects received from the simulated backend (results)
        private ArrayList binsReceived;

        //The actual array list that will be used to store the returned BinStatus objects
        private ArrayList binStatusObjects;

        //The primitive array of binStatuses received to display to the application's ListView
        private string[] binsToDisplay;

        protected override void OnCreate(Bundle savedInstanceState)
        {   
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_view_statuses);

            //placeholders for the listview upon activity start
            listPlaceholder = new string[1];
            listPlaceholder[0] = "Discovered bins will be displayed here";

            
            //setting the correct listview
            listAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, listPlaceholder);

            //Assigning UI controls
            tvTitle = FindViewById<TextView>(Resource.Id.binStatusTitle);
            tvAddress = FindViewById<TextView>(Resource.Id.addressLabel);
            tvAddressLabel = FindViewById<TextView>(Resource.Id.binAddressLabel);
            etAddress = FindViewById<EditText>(Resource.Id.addressEntry);
            btnSubmit = FindViewById<Button>(Resource.Id.submitAddress);
            lvBins = FindViewById<ListView>(Resource.Id.binStatusList);
            lvBins.Adapter = listAdapter;
            
            //Object used to simulate the backend
            simBinStatusBackend = new SimBinStatusBackend();

            //click events
            btnSubmit.Click += BtnSubmit_Click;
        }



        /**
         *  This method executes when the user clicks the Submit button. It creates a BinStatus object with
         *  that address (used to validate what the user entered) and sends only the address string to the backend to compare addresses. 
         *  It then receives an Arraylist from the backend, checks those results and then displays it to the listview accordingly.
         */
        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            //gather text from the UI control
            string addressStr = etAddress.Text.Trim();

            //BinStatus object that will be sent to the backend
            binStatusSend = new BinStatus();

            //Open the backend sim to send JSON
            jsonHandler = new jsonHandler();

            //Create a BinStatus object with default attributes -- used for validating what the user entered
            binStatusSend.binAddress = addressStr;
            binStatusSend.binID = 1;
            binStatusSend.status = 1;

            //Check if the BinStatus object created is valid
            validationResults = ValidationHelper.Validate(binStatusSend);

            if(validationResults.Count > 0)
            {
                //If there are validation errors with the object, display the certain messages to the user
                Toast.MakeText(this, validationResults[0].ErrorMessage, ToastLength.Short).Show();
            }
            else
            {
                //var sendSuccess = await jsonHandler.sendJsonAsync(binStatusSend, "https://jsonplaceholder.typicode.com/posts");
                //checkReceivedObject(sendSuccess);

                //Simulated call to the back end
                binsReceived = simBinStatusBackend.checkListOfBins(binStatusSend.binAddress);
                
                //Check the results of the call to the backend -- if there were no matches, an empty arraylist is sent back
                if(binsReceived.Count == 0)
                {
                    binsToDisplay = new string[1];
                }
                else
                {
                    binsToDisplay = new string[binsReceived.Count];
                }

                //If no bins were returned by the simulated back end, display appropriate message
                if(binsReceived.Count == 0)
                {
                    binsToDisplay[0] = "No bins associated with that address.";
                }
                //Else if there was a match with the address the user sent to bins in the back end
                else if(binsReceived.Count > 0)
                {
                    //Variable to track the index of the array to insert into
                    int counter = 0;

                    //Loop for each bin found 
                    foreach (var bin in binsReceived)
                    {
                        //Create a display string and add it to a display array
                         string binStr = "Bin ID: " + (bin as BinStatus).binID + "\t" + "Status: " + convertBinStatusToString((bin as BinStatus).status);
                         binsToDisplay[counter] = binStr;
                         counter++; //increase the index by 1
                    }
                }
                //If something else went wrong, let the user know (catch all case)
                else
                {
                    //Toast.MakeText(this, "Something went wrong, try again in a few minutes", ToastLength.Long).Show();
                    binsToDisplay[0] = "Something went wrong, try again in a few minutes";
                }

                //Populate the listview with the bins received from the backend that are valid
                listPopulatedAdapter = new ArrayAdapter<string>(this, Resource.Layout.bin_status_list_item, binsToDisplay);
                lvBins.Adapter = listPopulatedAdapter;
            }
        }

        /**
        * This method converts an int bin status to a string.
        * Input: int status - the status of the BinStatus object (1, 2, or 3)
        * Returns: string - the corresponding value of the status passed in (2 -> blocked, 3 -> Contaminated, default (1) -> good)
        **/
        private string convertBinStatusToString(int status)
        {
            switch (status)
            {
                case 2:
                    return "Blocked";
                case 3:
                    return "Contaminated";
                default:
                    return "Good";
            }
        }

        /**
         * This method will be used for checking the response from the backend after a BinStatus
         * object is sent.
         */
        private async void checkReceivedObject(HttpResponseMessage sendSuccess)
        {
            if(sendSuccess.IsSuccessStatusCode)
            {
                var receivedObject = await jsonHandler.receiveJsonAsync("https://jsonplaceholder.typicode.com/posts/1");
                
                if(receivedObject.IsSuccessStatusCode)
                {
                    string binStatusJson = await receivedObject.Content.ReadAsStringAsync();
                    BinStatus binStatusReceived = JsonConvert.DeserializeObject<BinStatus>(binStatusJson);
                    validationResults = ValidationHelper.Validate(binStatusReceived);

                    if(validationResults.Count > 0)
                    {
                        Toast.MakeText(this, validationResults[0].ErrorMessage, ToastLength.Long).Show();
                    }
                    else
                    {
                        //add valid bin status object to arraylist 
                        binStatusObjects.Add(binStatusReceived);
                    }
                }
                else
                {
                    //status code is bad for some reason
                    Toast.MakeText(this, "Sorry something went wrong, please try again in a few minutes", ToastLength.Long).Show();
                }
            }
        }
    }
   
}