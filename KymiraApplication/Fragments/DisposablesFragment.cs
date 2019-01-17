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
using Mono;

namespace KymiraApplication.Fragments
{
    public class DisposablesFragment : Fragment
    {

        private View view;
        private static List<Disposable> disposables; // This will store all of the disposable items
        private static List<Disposable> recItems; // This will store all of the recyclable Items
        private static List<Disposable> nonRecItems; // This will store all of the non-recycable Items

        private Button btnViewRecyclables; // Button that will display the recyclable items
        private Button btnViewNonRecyclables; // Button that will display the non-recyclable items
        private ListView lvDisposables; // Our list view that will display the Disposable items

        private HttpClient client; // This client is used for GET and POST requests


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            view = inflater.Inflate(Resource.Layout.disposables_layout, container, false);

            // Instantiate the HTTP Client
            client = new HttpClient();
            client.Timeout = System.TimeSpan.FromSeconds(10);


            recItems = new List<Disposable>();
            nonRecItems = new List<Disposable>();

            btnViewRecyclables = view.FindViewById<Button>(Resource.Id.btnViewRecyclableItems);
            btnViewNonRecyclables = view.FindViewById<Button>(Resource.Id.btnViewNonRecyclableItems);

            lvDisposables = view.FindViewById<ListView>(Resource.Id.lvDisposables);

            // Event Handlers for the buttons
            btnViewRecyclables.Click += btnViewRecyclables_Click;
            btnViewNonRecyclables.Click += btnViewNonRecyclables_Click;

            disposables = new List<Disposable>();


            setDisposables();

            // When the view loads, retrieve the disposables list from the database


           

            //return base.OnCreateView(inflater, container, savedInstanceState);
            return view;


        }

        // Event handler for the View Recyclables Button.
        // This simply calls displayDisposablesList and passes
        // in our list of RECYCLABLE items.
        private void btnViewRecyclables_Click(object sender, EventArgs e)
        {
            displayDisposablesList(recItems);
        }

        // Event handler for the View Non-Recyclables Button.
        // This simply calls displayDisposablesList and passes
        // in our list of NON-RECYCLABLE items.
        private void btnViewNonRecyclables_Click(object sender, EventArgs e)
        {
            displayDisposablesList(nonRecItems);
        }


        // This method creates a new DisposablesAdapter and sets 
        // the listview to use it.
        private void displayDisposablesList(List<Disposable> disposables)
        {
            DisposablesAdapter adapter = new DisposablesAdapter(Context, disposables);

            lvDisposables.Adapter = adapter;
        }



        // This method handles receiving json from the uri specified
        public async Task<List<Disposable>> receiveDisposablesAsync()
        {

            List<Disposable> rList = new List<Disposable>();

            String uriString = "http://10.0.2.2:55085/api/Disposables";

   
            Uri uri = new Uri(uriString, UriKind.Absolute);

        

           
            HttpResponseMessage response = null;

            try
            {

                 response = await client.GetAsync(uri);

                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        // Create a variable which will store the response of the GET
                        var content = await response.Content.ReadAsStringAsync();

                        // Deserialize and set this object to our Disposables List

                        rList = JsonConvert.DeserializeObject<List<Disposable>>(content);

                    }
                    else
                    {
                        throw new Exception("Error reaching the server, please try again later.");
                    }
                }
                catch
                {

                }

            }
            catch(System.Threading.Tasks.TaskCanceledException)
            {

            }

            return rList;

            
            
            
            // Check if the message was sent successfully
           
            



        }

        public  async void setDisposables()
        {

                List<Disposable> displist = await receiveDisposablesAsync();
                disposables = displist;

            if (disposables.Count != 0)
            {

                // If the list has items in it


                // Validate those items to make sure they work

                /** TODO:
                 *  This loop handles validation.
                 *  We have to set our placeholder image before doing the validation
                 *  That way if an item doesn't have an image, it isn't removed from the list
                 *  The URL has to be set to where our image is gonna be located (So G:/ThisImage.png)
                 *  The URL itself is parsed in the adapter, so we don't have to worry about any of that
                 *  the URL is simply a String that points to an image.
                 *  
                 */
                foreach (Disposable disposableItem in disposables)
                {
                    if (disposableItem.imageURL == null || disposableItem.imageURL == "")
                    {
                        disposableItem.imageURL = "/Resources/Drawable/no_image.png";
                    }



                    var results = ValidationHelper.Validate(disposableItem);

                    if (results.Count == 0)
                    {
                        if (disposableItem.isRecyclable)
                        {
                            recItems.Add(disposableItem);
                        }
                        else
                        {
                            nonRecItems.Add(disposableItem);
                        }
                    }

                    // We have to Validate the object
                    // var results = HelperTestModel.Validate(disposableItem);
                }


                // Create two new lists, one to store recyclables,
                // one to store non-recyclables.

                /**
                 *  This loop makes the lists for recyclable and non-recyclable items.
                 *  It looks at the IsRecyclable property, (which is a boolean)
                 *  and puts it into list A if true and list B if false.
                 */



            }
            else
            {

                // TODO:

                // If the disposables list is empty
                // Notify the user that server can't be reached.
            }



        }
    }

}