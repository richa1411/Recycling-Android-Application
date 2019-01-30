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
    public class FAQFragment : Fragment
    {
        private View view;
        private static TextView tvError;
        private static List<FAQ> faqs; //list of matching FAQ objects
        private static List<FAQ> faqItems;

        private ExpandableListView lvFAQs;

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
            lvFAQs = view.FindViewById<ExpandableListView>(Resource.Id.lvFAQ);

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
                
                tvError.Text = "Something went wrong, please try again later";
                tvError.SetTextSize(ComplexUnitType.Px, 69);

                tvError.SetTextColor(new Android.Graphics.Color(255, 0, 0));
            }
        }

        private void displayFAQsList(List<FAQ> faqs)
        {

            //DisposablesAdapter adapter = new DisposablesAdapter(Context, disposables);

            lvFAQs.SetAdapter(new FAQDetailListAdapter(Context, faqs));
            //lvDisposables.GroupClick += (sender, e) => lvDisposables.ChildClick(sender, new ExpandableListView.ChildClickEventArgs(true, e.Parent, e.ClickedView, e.GroupPosition, (int)e.Id, 0));


            //FAQDetailListAdapter adapter = new FAQDetailListAdapter(Context, faqs);
            //lvFAQs.Adapter = adapter;
        }
    }
}