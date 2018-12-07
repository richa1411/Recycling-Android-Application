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
        private TextView tvCollectionDate1;
        private TextView tvCollectionDate2;
        private TextView tvError;
        //private jsonHandler jsonHandler;

       // List<ValidationResult> validationResult;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CollectionDate);
            tvCollectionDate1 = FindViewById<TextView>(Resource.Id.tvCollectionDate1);
            tvCollectionDate2 = FindViewById<TextView>(Resource.Id.tvCollectionDate2);
            tvError = FindViewById<TextView>(Resource.Id.tvError);

            //var receivedObject = JsonConvert.DeserializeObject<BinCollectionDate>(Intent.GetStringExtra("ReceivedJSON"));
            //tvCollectionDate.Text += receivedObject.collectionDate1;
           
            //receives dates from intent 
            string receivedObject1 = Intent.GetStringExtra("ReceivedJSON1");
            string receivedObject2 = Intent.GetStringExtra("ReceivedJSON2");
            //if string got from intent is nonempty then shows dates otherwise displays error
            if (receivedObject1.Equals("") && receivedObject2.Equals(""))
            {
                tvError.Text += "Sorry!!!No dates are assigned for this address yet!! Try later";
            }
            else
            {
                Toast.MakeText(this, receivedObject1, ToastLength.Long).Show();

                tvCollectionDate1.Text += receivedObject1;
                tvCollectionDate2.Text += receivedObject2;
            }
            
            





        }

        
    }
}