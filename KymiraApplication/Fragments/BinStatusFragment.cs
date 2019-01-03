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
        //UI controls for this fragment
        private TextView tvTitle;
        private TextView tvAddress;
        private TextView tvAddressLabel;
        private EditText etAddress;
        private Button btnSubmit;
        private ListView lvBins;

        //adapter for the list view of bin objects to display
        private IListAdapter listAdapter;
        private IListAdapter listPopulatedAdapter;

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

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}