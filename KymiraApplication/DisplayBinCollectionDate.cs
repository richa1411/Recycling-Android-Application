﻿using System;
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
using Org.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;


namespace KymiraApplication
{
    [Activity(Label = "DisplayBinCollectionDate")]
    public class DisplayBinCollectionDate : Activity
    {
        private TextView tvCollectionDate1;
        private TextView tvCollectionDate2;
        private jsonHandler jsonHandler;

        List<ValidationResult> validationResult;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CollectionDate);
            tvCollectionDate1 = FindViewById<EditText>(Resource.Id.tvCollectionDate1);
            tvCollectionDate2 = FindViewById<EditText>(Resource.Id.tvCollectionDate2);

            var receivedObject = JsonConvert.DeserializeObject<BinCollectionDate>(Intent.GetStringExtra("ReceivedJSON"));

            tvCollectionDate1.Text += receivedObject.collectionDate1;
            tvCollectionDate2.Text += receivedObject.collectionDate2;





        }

        
    }
}