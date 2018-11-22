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
using Android.Views;
using Android.Widget;
using KymiraApplication.Model;
using Newtonsoft.Json;

namespace KymiraApplication.Resources
{
    [Activity(Label = "BinStatusActivity",MainLauncher = true)]
    public class BinStatusActivity : Activity
    {
        private TextView tvTitle;
        private TextView tvAddress;
        private TextView tvAddressLabel;
        private EditText etAddress;
        private Button btnSubmit;
        private ListView lvBins;

        private IListAdapter listAdapter;

        private ArrayList binStatusObjects;
        private string[] binStatusArray;

        List<ValidationResult> validationResults;

        private jsonHandler jsonHandler;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            binStatusObjects= new ArrayList();

            BinStatus a = new BinStatus();
            BinStatus b = new BinStatus();
            BinStatus c = new BinStatus();

            a.binID = 1;
            a.status = 1;
            a.binAddress = "123 Test St.";

            b.binID = 2;
            b.status = 3;

            c.status = 2;
            c.binID = 3;

            binStatusObjects.Add(a);
            binStatusObjects.Add(b);
            binStatusObjects.Add(c);

            binStatusArray = new string[binStatusObjects.Count];

            for (int i=0;i<binStatusObjects.Count;i++)
            {
                BinStatus bs = (BinStatus)binStatusObjects[i];
                string binStr = "Bin ID: " + bs.binID + "\t" + "Status: " + convertBinStatusToString(bs.status);
                binStatusArray[i] = binStr;
                
            }


          
           // binStatusArray[0] = "BIN ID: 1837\tStatus: CLEAN!!!";

            base.OnCreate(savedInstanceState);
            listAdapter = new ArrayAdapter<string>(this,Resource.Layout.bin_status_list_item, binStatusArray);

            SetContentView(Resource.Layout.activity_view_statuses);

            //Assigning UI controls
            tvTitle = FindViewById<TextView>(Resource.Id.binStatusTitle);
            tvAddress = FindViewById<TextView>(Resource.Id.addressLabel);
            tvAddressLabel = FindViewById<TextView>(Resource.Id.binAddressLabel);
            etAddress = FindViewById<EditText>(Resource.Id.addressEntry);
            btnSubmit = FindViewById<Button>(Resource.Id.submitAddress);
            lvBins = FindViewById<ListView>(Resource.Id.binStatusList);
            lvBins.Adapter = listAdapter;

            tvAddressLabel.Text = "Bins found at: " + a.binAddress;

            //click events
            btnSubmit.Click += BtnSubmit_Click;
        }

        /**
         * This method converts an int bin status to a string.
         * Input: int status - the status of the BinStatus object (1, 2, or 3)
         * Returns: string - the corresponding value of the status passed in (2 -> blocked, 3 -> Contaminated, default (1) -> good)
         **/
        private string convertBinStatusToString(int status)
        {
            switch(status)
            {
                case 2:
                    return "Blocked";
                case 3:
                    return "Contaminated";
                default:
                    return "Good";
            }
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            string addressStr = etAddress.Text;

            BinStatus binStatusSend = new BinStatus();
            jsonHandler = new jsonHandler();

            binStatusSend.binAddress = addressStr;
            binStatusSend.binID = 1;
            binStatusSend.status = 1;

            validationResults = ValidationHelper.Validate(binStatusSend);

            if(validationResults.Count > 0)
            {
                Toast.MakeText(this, validationResults[0].ErrorMessage, ToastLength.Short).Show();
            }
            else
            {
                var sendSuccess = await jsonHandler.sendJsonAsync(binStatusSend, "https://jsonplaceholder.typicode.com/posts");

                checkReceivedObject(sendSuccess);
                
            }

        }

        private async void checkReceivedObject(HttpResponseMessage sendSuccess)
        {
            if(sendSuccess.IsSuccessStatusCode)
            {
                var receivedObject = await jsonHandler.receiveJsonAsync("https://jsonplaceholder.typicode.com/posts/1");

                //Toast.MakeText(this, receiveSuccess, ToastLength.Long).Show();
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