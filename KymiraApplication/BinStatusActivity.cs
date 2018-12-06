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
        private IListAdapter listAdapterPopulated;

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
            IListAdapter listAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, listPlaceholder);

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
         *  that address and sends it to the backend to compare addresses. When the method receives an object from the 
         *  backend, it displays it to the listview.
         */
        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            //gather text from the UI control
            string addressStr = etAddress.Text.Trim();

            //BinStatus object that will be sent to the backend
            binStatusSend = new BinStatus();

            //Open the backend sim to send JSON
            jsonHandler = new jsonHandler();

            //Create a BinStatus object to send to the backend with default attributes of 1 with 
            //an address of the address the user typed in
            binStatusSend.binAddress = addressStr;
            binStatusSend.binID = 1;
            binStatusSend.status = 1;

            //Check if the BinStatus object that we are sending is valid
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
               binsReceived = simBinStatusBackend.checkListOfBins(binStatusSend);

                //Toast.MakeText(this, binReceived.binID.ToString(), ToastLength.Short).Show();

                binsToDisplay = new string[binsReceived.Count];

                
                if((binsReceived[0] as BinStatus).binID == -1)
                {
                    Toast.MakeText(this, "No bins associated with that address.", ToastLength.Long).Show();
                }
                else if((binsReceived[0] as BinStatus).binID != -1)
                {
                    int counter = 0;

                    foreach (var bin in binsReceived)
                    {
                        if((bin as BinStatus).binID != -1)
                        {
                            string binStr = "Bin ID: " + (bin as BinStatus).binID + "\t" + "Status: " + convertBinStatusToString((bin as BinStatus).status);
                            binsToDisplay[counter] = binStr;
                        }

                        counter++;
                    }
                }
                else
                {
                    Toast.MakeText(this, "Something went wrong, try again in a few minutes", ToastLength.Long).Show();
                }

                //Populate the listview with the bins received from the backend that are valid
                IListAdapter listPopulatedAdapter = new ArrayAdapter<string>(this, Resource.Layout.bin_status_list_item, binsToDisplay);
                lvBins.Adapter = listPopulatedAdapter;
                /*
                if ((bin as BinStatus).binID != -1)
                    {
                        binStatusObjects.Add(bin);
                        BinStatus bs = new BinStatus();
                        bs.binID = ((BinStatus)binStatusObjects[0]).binID;        
                        bs.status = ((BinStatus)binStatusObjects[0]).status;
                        string binStr = "Bin ID: " + bs.binID + "\t" + "Status: " + convertBinStatusToString(bs.status);
                        Toast.MakeText(this, binStr, ToastLength.Short).Show();
                        binsReceived[0] = binStr;

                        //listAdapterPopulated = new ArrayAdapter<string>(this, Resource.Layout.bin_status_list_item, binsReceived);
                        IListAdapter listPopulatedAdapter = new ArrayAdapter<string>(this, Resource.Layout.bin_status_list_item, binsReceived);
                        lvBins.Adapter = listPopulatedAdapter;
                    }


                
                else if(binReceived.binID == -1)
                {
                    Toast.MakeText(this, "No bins associated with that address.", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Something went wrong, try again in a few minutes", ToastLength.Long).Show();
                }
                */
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