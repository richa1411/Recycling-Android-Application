﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using KymiraApplication.Models;
using KymiraApplication;
using Newtonsoft.Json;

namespace KymiraApplication.Fragments
{
    public class BinStatusFragment : Fragment
    {
        //controls to grab from the layout
        private EditText etAddress;
        private Button btnSubmit;
        private TextView tvError;

        //textviews to be populated upon receiving matching BinStatus's
        private TextView tvCollected;
        private TextView tvContaminated;
        private TextView tvInaccessible;

        List<BinStatus> obList; //list of matching BinStatus objects

        private HttpClient client;  //client used for POST/GET requests

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.bin_status_layout, container, false);

            client = new HttpClient(); //instantiate the HTTP client once
            
            //grab the controls from the layout
            etAddress = view.FindViewById<EditText>(Resource.Id.addressEntry);
            btnSubmit = view.FindViewById<Button>(Resource.Id.btnSubmit);
            tvCollected = view.FindViewById<TextView>(Resource.Id.tvCollected);
            tvContaminated = view.FindViewById<TextView>(Resource.Id.tvContaminated);
            tvInaccessible = view.FindViewById<TextView>(Resource.Id.tvInaccessible);
            tvError = view.FindViewById<TextView>(Resource.Id.lblError);

            btnSubmit.Click += BtnSubmit_Click; //event handler for button click

            return view;
        }

        /**
         * This method is used for when the submit button is clicked. It sends the string in the etAddress field and waits for a list of BinStatus objects
         * that are associated with the sent address. 
         */
        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            string address = etAddress.Text.Trim();

            //check validation of address attempting to send using an object
            Site testSite = new Site {
                siteID = 234,
                address = address
            };

            IList<ValidationResult> validationResults = ValidationHelper.Validate(testSite);

            //if any validation results, show the proper error message
            if(validationResults.Count > 0)
            {
                tvError.Text = validationResults[0].ErrorMessage;
            }
            else
            {
                //attempt to send to backend

                tvError.Text = ""; //reset error text to be empty string

                //send address and date string to backend and response will be list of binstatuses to count
                HttpClient client = new HttpClient();
                
                string strAPI = Context.Resources.GetString(Resource.String.UrlAPI);
                string strBinPath = Context.Resources.GetString(Resource.String.UrlBinStatus);
                string strUri = strAPI + strBinPath;

                Uri uri = new Uri(strUri, UriKind.Absolute);

                //the following is for a post request
                var json = JsonConvert.SerializeObject(address);
                var send = new StringContent(json, Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync(uri, send);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        obList = JsonConvert.DeserializeObject<List<BinStatus>>(content);

                        //populate and send the obList here (response)
                        CountAndPopulateResults(obList);
                    }
                    else
                    {
                        tvError.Text = "Sorry, something went wrong. Try again later.";
                    }
                }
                catch (Exception exp)
                {

                }
                
            }
            
        }

        /**
         * This method will go through the List of matching BinStatus objects received from the backend and count
         * each type of status to be displayed to the user. It will then populate the correct TextViews on the layout with the correct information.
         * If any BinStatus in the list contains a status other than 1, 2, or 3, it will count that bin as inaccessible.
         */
        private void CountAndPopulateResults(List<BinStatus> obList)
        {
            //variables to hold the number of each bin in obList
            int countOfCollected = 0;
            int countOfContam = 0;
            int countOfInacc = 0;

            //count how many of each status is returned
            for(int i = 0; i < obList.Count; i++)
            {
                switch(obList[i].status)
                {
                    case 1:
                        countOfCollected++;
                        break;
                    case 2:
                        countOfInacc++;
                        break;
                    case 3:
                        countOfContam++;
                        break;
                    default:
                        //if a bin status contains any other status, it is defaulted to an inaccessible bin
                        countOfInacc++;
                        break;
                }
            }

            //display the correct count to the proper textviews
            tvCollected.Text = countOfCollected + "/" + obList.Count;
            tvContaminated.Text = countOfContam + "/" + obList.Count;
            tvInaccessible.Text = countOfInacc + "/" + obList.Count;
        }
        
    }
}