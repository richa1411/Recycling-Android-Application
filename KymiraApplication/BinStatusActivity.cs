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

namespace KymiraApplication.Resources
{
    [Activity(Label = "BinStatusActivity",MainLauncher = true)]
    public class BinStatusActivity : Activity
    {
        private TextView tvTitle;
        private TextView tvAddress;
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
            binStatusArray = new string[1];
            binStatusArray[0] = "BIN ID: 1837\tStatus: CLEAN!!!";

            base.OnCreate(savedInstanceState);
            listAdapter = new ArrayAdapter<string>(this,Resource.Layout.bin_status_list_item, binStatusArray);

            SetContentView(Resource.Layout.activity_view_statuses);

            //Assigning UI controls
            tvTitle = FindViewById<TextView>(Resource.Id.binStatusTitle);
            tvAddress = FindViewById<TextView>(Resource.Id.addressLabel);
            etAddress = FindViewById<EditText>(Resource.Id.addressEntry);
            btnSubmit = FindViewById<Button>(Resource.Id.submitAddress);
            lvBins = FindViewById<ListView>(Resource.Id.binStatusList);
            lvBins.Adapter = listAdapter;


            btnSubmit.Click += BtnSubmit_Click;
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
                
                if(sendSuccess.IsSuccessStatusCode)
                {
                    var receiveSuccess = await jsonHandler.receiveJsonAsync("https://jsonplaceholder.typicode.com/posts/1");

                    Toast.MakeText(this, receiveSuccess, ToastLength.Long).Show();
                }
            }

        }
    }
   
}