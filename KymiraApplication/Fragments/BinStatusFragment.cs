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
        //controls to grab from the layout
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

            btnSubmit.Click += BtnSubmit_Click;

            return view;
        }

        /**
         * This method is used for when the submit button is clicked. It sends the string in the etAddress field and waits for a list of BinStatus objects
         * that are associated with the sent address. 
         */
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            //send the address string
            string address = etAddress.Text;

            //TODO: also populate the proper labels with the information and do a count

        }
    }
}