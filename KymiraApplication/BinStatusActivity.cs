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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            listAdapter = new ArrayAdapter<string>(this,Resource.Layout.bin_status_list_item); 

            

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

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Hello",ToastLength.Short).Show();
        }
    }
   
}