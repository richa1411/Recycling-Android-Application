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

            recItems = new List<Disposable>();
            nonRecItems = new List<Disposable>();

            btnViewNonRecyclables = ()

            // When the view loads, retrieve the disposables list from the database
            receiveDisposablesAsync(); 

            if (disposables.Count != 0)
            {

                // If the list has items in it
                // Validate those items to make sure they work
                // Create two new lists, one to store recyclables,
                // one to store non-recyclables.
                
                foreach(Disposable disposableItem in disposables)
                {
                    if(disposableItem.isRecyclable)
                    {
                        recItems.Add(disposableItem);
                    }
                    else
                    {
                        nonRecItems.Add(disposableItem);
                    }
                }


            }
            else
            {
                // If the disposables list is empty
                // Notify the user that server can't be reached.
            }

            return base.OnCreateView(inflater, container, savedInstanceState);



        }


        /**
         *  This method will use the Listview and adapter to display the information on dispoables
         */
        private void displayDisposablesList(List<Disposable> disposables)
        {

        }



        // This method handles receiving json from the uri specified
        public async void receiveDisposablesAsync()
        {
            // populate dispsoables list with stuff from api.

            // Instantiate the HTTP Client
            client = new HttpClient();

            // Grab the Root API URL and the Disposables URL from the Resources.Strings File
            String urlAPI = Context.Resources.GetString(Resource.String.UrlAPI);
            String urlDisposables = Context.Resources.GetString(Resource.String.UrlDisposables);

            // Add them together to form the full URI String
            String uriString = urlAPI + urlDisposables;

            // Create a URI
            Uri uri = new Uri(uriString, UriKind.Absolute);

            // Make an HTTPResponseMessage
            HttpResponseMessage response = await client.GetAsync(uri);

            // Check if the message was sent successfully
            if(response.IsSuccessStatusCode)
            {
                // Create a variable which will store the response of the GET
                var content = await response.Content.ReadAsStringAsync();

                // Deserialize and set this object to our Disposables List
                disposables = JsonConvert.DeserializeObject<List<Disposable>>(content);
            }
            else
            {
                throw new Exception("Error reaching the server, please try again later.");
            }




        }
    }

}