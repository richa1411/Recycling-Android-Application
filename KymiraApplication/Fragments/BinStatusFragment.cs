using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using KymiraApplication.Models;

namespace KymiraApplication.Fragments
{
    public class BinStatusFragment : Fragment
    {

        private EditText etAddress;
        private Button btnSubmit;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            var view = inflater.Inflate(Resource.Layout.bin_status_layout, container, false);

            //grab the controls from the layout
            etAddress = view.FindViewById<EditText>(Resource.Id.addressEntry);
            btnSubmit = view.FindViewById<Button>(Resource.Id.submitAddress);

            return view;
        }

        //method to handle button click 
    }
}