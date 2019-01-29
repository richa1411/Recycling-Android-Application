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
using KymiraApplication.Adapters;
using KymiraApplication.Models;
using Newtonsoft.Json;

namespace KymiraApplication.Fragments
{
    public class FAQFragment : Fragment
    {
        private View view;
        private static TextView tvError;
        private static List<FAQ> faqList; //list of matching FAQ objects

        private ListView lvFAQs;

        private HttpClient client;  //client used for POST/GET requests
        private HttpResponseMessage response;



        //Will run when the app is run. It is the initial creation of the fragment
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        //This view will run when the fragment is called
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.faq_layout, container, false);

            //Instantiate the HTTP Client used to contact the API
            client = new HttpClient();
            //Have a timeout of 10 seconds if the server can't be reached
            client.Timeout = System.TimeSpan.FromSeconds(10);
            faqList = new List<FAQ>();
            tvError = (TextView)view.FindViewById(Resource.Id.tvError);
            lvFAQs = view.FindViewById<ListView>(Resource.Id.lvFAQ);

            SetFAQs();

            return view;

        }

        //Will run when an item in the listView is selected. This will bring up the next "faq_details" fragment page
        private async void Item_Select(Object sender, EventArgs e)
        {
            //Open the faq_details_layout fragment that will contain all the content from the item in the list
        }


        public async void SetFAQs()
        {
            using (client = new HttpClient())
            {
                string strAPI = Context.Resources.GetString(Resource.String.UrlAPI);
                string strFAQPath = Context.Resources.GetString(Resource.String.UrlFAQ);
                string strUri = strAPI + strFAQPath;
                client.Timeout = System.TimeSpan.FromSeconds(3);

                Uri uri = new Uri(strUri, UriKind.Absolute);

                //HttpResponseMessage response = null;

                try
                {
                    response = await client.GetAsync(uri);

                    //checks status code that API returns 
                    var success = response.StatusCode;
                    if ((int)success != 200)
                    {

                        //displays error messsage
                        tvError.Text = "Sorry, something went wrong. Try later!!";
                    }
                    else
                    {
                        //if response came back as successful, populate the view using the list returned
                        var content = await response.Content.ReadAsStringAsync();
                        faqList = JsonConvert.DeserializeObject<List<FAQ>>(content); //All of the items

                        //If the list has items in it
                        if (faqList.Count != 0)
                        {
                            PopulateList(faqList);
                        }
                        else //If the list is empty after adding the FAQs from Content (content had no content)
                        {
                            //response came back as unsuccessfull, no matching site was found in the backend
                            tvError.Text = "Sorry, something went wrong, please try again in a few minutes (Success code was not 200)";
                        }
                    }
                } catch (Exception exp)
                {
                    //response did not work - API not running
                    response = new HttpResponseMessage();
                    response.StatusCode = System.Net.HttpStatusCode.RequestTimeout;
                    tvError.Text = "Sorry, something went wrong, please try again in a few minutes";
                }
            }

            displayFAQ(faqList);

        }

        //Populate list will take the content inside of obList, and populate a list with it.
        private void PopulateList(List<FAQ> obList)
        {

        }

        private void displayFAQ(List<FAQ> faqs)
        {
            FAQListAdapter adapter = new FAQListAdapter(Context, faqs);

            lvFAQs.Adapter = adapter;
        }
    }
    
}