using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using KymiraApplication.Models;
using Newtonsoft.Json;

namespace KymiraApplication.Fragments
{
    public class FAQFragment : Fragment
    {
        private HttpClient client;

        //searchBox input field
        private View view;
        private EditText searchBox;
        private TextView txtError;
        private List<string> FAQList;

        //Will run when the app is run. It is the initial creation of the fragment
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        //This view will run when the fragment is called
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.faq_layout, container, false);

            searchBox = (EditText)view.FindViewById(Resource.Id.etxtPhone);
            
            txtError = (TextView)view.FindViewById(Resource.Id.tvError);

            

            return view;



        }
    }
}