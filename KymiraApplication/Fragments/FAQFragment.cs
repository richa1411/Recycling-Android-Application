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
using Newtonsoft.Json;

namespace KymiraApplication.Fragments
{
    public class FAQFragment : Fragment
    {
        private View view;
        private static TextView tvError;
        private static List<FAQ> faqs; //list of matching FAQ objects
        private static List<FAQ> faqItems;

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

            

            //Link the errors textview
            tvError = (TextView)view.FindViewById(Resource.Id.tvError);
            lvFAQs = view.FindViewById<ListView>(Resource.Id.lvFAQ);

            //List of FAQs
            faqs = new List<FAQ>();
            faqItems = new List<FAQ>();

            SetFAQs();

            return view;

        }

        public async Task<List<FAQ>> receiveFAQAsync()
        {
            //list used to return disposables
            List<FAQ> rList = new List<FAQ>();

            //URI of API
            string strAPI = Context.Resources.GetString(Resource.String.UrlAPI);
            string strFAQPath = Context.Resources.GetString(Resource.String.UrlFAQ);
            string strUri = strAPI + strFAQPath;

            HttpResponseMessage response = null;


            try
            {
                //contacting API making a GET request for all recylcable items in the database.
                response = await client.GetAsync(strUri);

                try
                {
                    //if the GET request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Create a variable which will store the response of the GET
                        var content = await response.Content.ReadAsStringAsync();

                        // Deserialize and set this object to our Disposables List
                        rList = JsonConvert.DeserializeObject<List<FAQ>>(content);

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

            //returns Dipsoables List
            return rList;



            

        }

        //Will run when an item in the listView is selected. This will bring up the next "faq_details" fragment page
        private async void Item_Select(Object sender, EventArgs e)
        {
            //Open the faq_details_layout fragment that will contain all the content from the item in the list
        }


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

                //If the list is empty and no responce was recieved from the server. we create a TextView to show an error.
                var error = view.FindViewById<TextView>(Resource.Id.errorLabel);
                error.Text = "Something went wrong, please try again later";
                error.SetTextSize(ComplexUnitType.Px, 69);

                error.SetTextColor(new Android.Graphics.Color(255, 0, 0));


            }


            //using (client = new HttpClient())
            //{
            //    string strAPI = Context.Resources.GetString(Resource.String.UrlAPI);
            //    string strFAQPath = Context.Resources.GetString(Resource.String.UrlFAQ);
            //    string strUri = strAPI + strFAQPath;

            //    Uri uri = new Uri(strUri, UriKind.Absolute);

            //    //HttpResponseMessage response = null;


            //    try
            //    {
            //        response = await client.GetAsync(uri);
            //        //checks status code that API returns 
            //        var success = response.StatusCode;
            //        if ((int)success != 200)
            //        {

            //            //displays error messsage
            //            tvError.Text = "Sorry, something went wrong. Try later!!";
            //        }
            //        else
            //        {
            //            //if response came back as successful, populate the view using the list returned
            //            var content = await response.Content.ReadAsStringAsync();
            //            faqList = JsonConvert.DeserializeObject<List<FAQ>>(content); //All of the items

            //            //If the list has items in it
            //            if (faqList.Count != 0)
            //            {
            //                PopulateList(faqList);
            //            }
            //            else //If the list is empty after adding the FAQs from Content (content had no content)
            //            {
            //                //response came back as unsuccessfull, no matching site was found in the backend
            //                tvError.Text = "Sorry, something went wrong, please try again in a few minutes (Success code was not 200)";
            //            }
            //        }
            //    } catch (Exception exp)
            //    {
            //        //response did not work - API not running
            //        response = new HttpResponseMessage();
            //        response.StatusCode = System.Net.HttpStatusCode.RequestTimeout;
            //        tvError.Text = "Sorry, something went wrong, please try again in a few minutes";
            //    }
            //}

            //displayFAQsList(faqList);

        }

        //Populate list will take the content inside of obList, and populate a list with it.
        private void PopulateList(List<FAQ> obList)
        {

        }

        private void displayFAQsList(List<FAQ> faqs)
        {
            FAQListAdapter adapter = new FAQListAdapter(Context, faqs);

            lvFAQs.Adapter = adapter;
        }
    }
    
}