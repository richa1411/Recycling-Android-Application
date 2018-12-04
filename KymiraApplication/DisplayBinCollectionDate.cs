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
using Org.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;


namespace KymiraApplication
{
    [Activity(Label = "DisplayBinCollectionDate")]
    public class DisplayBinCollectionDate : Activity
    {
        private TextView tvCollectionDate;
        private TextView tvError;
        //private jsonHandler jsonHandler;

       // List<ValidationResult> validationResult;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CollectionDate);
            tvCollectionDate = FindViewById<TextView>(Resource.Id.tvCollectionDate);
            tvError = FindViewById<TextView>(Resource.Id.tvError);

            // var receivedObject = JsonConvert.DeserializeObject<BinCollectionDate>(Intent.GetStringExtra("ReceivedJSON"));
            //tvCollectionDate.Text += receivedObject.collectionDate1;
           
            string receivedObject = Intent.GetStringExtra("ReceivedJSON");
            if (receivedObject.Equals(""))
            {
                tvError.Text += "Sorry!!!No dates are assigned for this address yet!! Try later";
            }
            else
            {
                Toast.MakeText(this, receivedObject, ToastLength.Long).Show();

                tvCollectionDate.Text += receivedObject;
            }
            
            





        }

        
    }
}