using System;
using System.Collections.Generic;
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
using KymiraApplication.Adapters;
using Newtonsoft.Json;

namespace KymiraApplication.Fragments
{
    /*
     * This class handles the FAQ fragment for the app. It upon launch will try
     * to make a connection to the API to recieve a list of FAQs and then display
     * them in an expandable list view. If there is no connection it displays an
     * error message telling the user something went wrong. When the connection to
     * the API is successful and expanable list view is populated with questions. When
     * you tap the quetion in the list, the answer gets displayed under it
     */
    public class FAQFragment : Fragment
    {
        private View view; //the view we will return
        private static TextView tvError; //a textview to place a generic error
        private static List<FAQ> faqs; //list of matching FAQ objects
        private static List<FAQ> faqItems; //list of the items in the list

        private ExpandableListView lvFAQs; //where the questions will bes stored

        private HttpClient client;  //client used for POST/GET requests



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
         
            //Link the errors textview
            tvError = (TextView)view.FindViewById(Resource.Id.tvError);
            lvFAQs = view.FindViewById<ExpandableListView>(Resource.Id.lvFAQ);

            //List of FAQs
            faqs = new List<FAQ>();
            faqItems = new List<FAQ>(); 

            SetFAQs();

            return view;
        }

        /*
         * This class will grab a list of FAQs from the API and then add them to a list
         * It throws an error if there was no response from the server.
         */
        public async void SetFAQs()
        {
            LinearLayout layout = view.FindViewById<LinearLayout>(Resource.Id.FAQLayout);
            List<FAQ> faqList = await receiveFAQAsync();
            faqs = faqList;

            // If the list has items in it
            if (faqs.Count != 0)
            {
                foreach (FAQ faqItem in faqs)
                {
                    // Validate those items to make sure they are valid
                    var results = ValidationHelper.Validate(faqItem);

                    if (results.Count == 0)
                    {
                        faqItems.Add(faqItem);
                    }
                }
                //the first time the app loads in. it sets the Listview to be of only recyclable items
                displayFAQsList(faqItems);
            }
            else
            {
                tvError.Text = "Something went wrong, please try again later";
            }
        }

        /*
         * This methods will make a call to the API and grab a list of 
         * FAQs for us to use. If it fails to connect it throws the exception 
         * that there was a problem.
         */
        public async Task<List<FAQ>> receiveFAQAsync()
        {
            //list used to return FAQs
            List<FAQ> faqList = new List<FAQ>();

            //URI of API
            string strAPI = Context.Resources.GetString(Resource.String.UrlAPI);
            string strFAQPath = Context.Resources.GetString(Resource.String.UrlFAQ);
            string strUri = strAPI + strFAQPath;

            HttpResponseMessage response = null;

            try
            {
                //contacting API making a GET request for all FAQ items in the database.
                response = await client.GetAsync(strUri);

                try
                {
                    //if the GET request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Create a variable which will store the response of the GET
                        var content = await response.Content.ReadAsStringAsync();
                        // Deserialize and set this object to our FAQ List
                        faqList = JsonConvert.DeserializeObject<List<FAQ>>(content);
                    }
                    //If the request was invalid we throw an exception.
                    else
                    {
                        throw new Exception("Error reaching the server, please try again later.");
                    }
                }
                catch
                {

                }
            }
            catch (System.Threading.Tasks.TaskCanceledException)
            {

            }

            //returns FAQ List
            return faqList;         
        }

        /*
         * this method is for setting the adapter with the FAQs
         */
        private void displayFAQsList(List<FAQ> faqs)
        {
            lvFAQs.SetAdapter(new FAQDetailListAdapter(Context, faqs));
        }
    }
}