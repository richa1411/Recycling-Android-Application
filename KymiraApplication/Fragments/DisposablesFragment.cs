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

using Android.Support.V4.View;
using KymiraApplication.Adapters;

namespace KymiraApplication.Fragments
{
    /**
     * Fragment used to display disposable information on the screen.
     * */
    public class DisposablesFragment : Fragment
    {
        //Declaration of Views
        private View view;
        private static List<Disposable> disposables; // This will store all of the disposable items
        private static List<Disposable> recItems; // This will store all of the recyclable Items
        private static List<Disposable> nonRecItems; // This will store all of the non-recycable Items

        private Button btnViewRecyclables; // Button that will display the recyclable items
        private Button btnViewNonRecyclables; // Button that will display the non-recyclable items
        private ExpandableListView lvDisposables; // Our list view that will display the Disposable items

        private HttpClient client; // This client is used for GET and POST requests


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            view = inflater.Inflate(Resource.Layout.disposables_layout, container, false);



            // Instantiate the HTTP Client used to contact the API
            client = new HttpClient();
            client.Timeout = System.TimeSpan.FromSeconds(10);

            //List of recyclable items
            recItems = new List<Disposable>();
            //List of non recyclable items
            nonRecItems = new List<Disposable>();
            //assiging the button views
            btnViewRecyclables = view.FindViewById<Button>(Resource.Id.btnViewRecyclableItems);
            btnViewNonRecyclables = view.FindViewById<Button>(Resource.Id.btnViewNonRecyclableItems);

            btnViewRecyclables.SetBackgroundColor(new Android.Graphics.Color(192, 192, 192));
            btnViewNonRecyclables.SetBackgroundColor(new Android.Graphics.Color(192, 192, 192));

            lvDisposables = view.FindViewById<ExpandableListView>(Resource.Id.lvDisposables);

            // Event Handlers for the buttons
            btnViewRecyclables.Click += btnViewRecyclables_Click;
            btnViewNonRecyclables.Click += btnViewNonRecyclables_Click;

            disposables = new List<Disposable>();

            // Calling the function setDisposables that will contact the API requesting disposable information.
            setDisposables();

       

           
            
            return view;


        }

        // Event handler for the View Recyclables Button.
        // This simply calls displayDisposablesList and passes
        // in our list of RECYCLABLE items.
        private void btnViewRecyclables_Click(object sender, EventArgs e)
        {
            displayDisposablesList(recItems);
            highlightButton(btnViewRecyclables, btnViewNonRecyclables);
        }

        // Event handler for the View Non-Recyclables Button.
        // This simply calls displayDisposablesList and passes
        // in our list of NON-RECYCLABLE items.
        private void btnViewNonRecyclables_Click(object sender, EventArgs e)
        {
            displayDisposablesList(nonRecItems);
            highlightButton( btnViewNonRecyclables, btnViewRecyclables);
        }


        // This method creates a new DisposablesAdapter and sets 
        // the listview to use it.
        private void displayDisposablesList(List<Disposable> disposables)
        {
            //DisposablesAdapter adapter = new DisposablesAdapter(Context, disposables);
            
            lvDisposables.SetAdapter(new DisposableDetailListAdapter(Context, disposables));
            //lvDisposables.GroupClick += (sender, e) => lvDisposables.ChildClick(sender, new ExpandableListView.ChildClickEventArgs(true, e.Parent, e.ClickedView, e.GroupPosition, (int)e.Id, 0));
        }

        private void highlightButton(Button set,Button revert)
        {

            set.SetBackgroundColor(new Android.Graphics.Color(173, 216, 230));
            revert.SetBackgroundColor(new Android.Graphics.Color(192, 192, 192));
        }


        /**
         * This method handles receiving json from the uri specified 
         * returns a Task<list<Disposable> of all recyclable items from the database
         */
        public async Task<List<Disposable>> receiveDisposablesAsync()
        {
            //list used to return disposables
            List<Disposable> rList = new List<Disposable>();

            //URI of API
            String sUri = Context.Resources.GetString(Resource.String.UrlAPI);
            sUri += Context.Resources.GetString(Resource.String.UrlDisposables);
            Uri uri = new Uri(sUri, UriKind.Absolute);

            HttpResponseMessage response = null;

           
            try
            {
                //contacting API making a GET request for all recylcable items in the database.
                 response = await client.GetAsync(uri);

                try
                {
                    //if the GET request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Create a variable which will store the response of the GET
                        var content = await response.Content.ReadAsStringAsync();

                        // Deserialize and set this object to our Disposables List
                        rList = JsonConvert.DeserializeObject<List<Disposable>>(content);

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
            catch(System.Threading.Tasks.TaskCanceledException)
            {

            }

            //returns Dipsoables List
            return rList;

        }

        public  async void setDisposables()
        {
            //Assigning the layout
            LinearLayout layout = view.FindViewById<LinearLayout>(Resource.Id.masterLayout); 
            //Makes the request to t    
            List<Disposable> displist = await receiveDisposablesAsync();
            disposables = displist;

            // If the list has items in it
            if (disposables.Count != 0)
            {
                foreach (Disposable disposableItem in disposables)
                {
                    //declaration
                    var resourceId = 0;
                    var var1 = disposableItem.imageURL;
                    try
                    {
                        //sets resourceID to Drawable id of the current disposable items imageURL
                        //it is set to 0 if it does not exist and will have a placeholder inserted below
                        resourceId = (int)typeof(Resource.Drawable).GetField(var1).GetValue(null);
                    }
                    catch (Exception e)
                    {

                    }
                    //if the imageURL does not have a matching image in the Drawable folder, is null or is empty a place holder will be inserted.
                    if (disposableItem.imageURL == null || disposableItem.imageURL == "" || resourceId == 0)
                    {

                        //Place holder image is inserted.
                        disposableItem.imageURL = Resource.Drawable.logoBlue.ToString();
                    }
                    else
                    {
                        //will change the image url to the Drawable resource number. ex: "2010102991"
                        disposableItem.imageURL = resourceId.ToString();
                    }

                    // Validate those items to make sure they are valid
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

                    
                }
                //the first time the app loads in. it sets the Listview to be of only recyclable items
                displayDisposablesList(recItems);
                highlightButton(btnViewRecyclables, btnViewNonRecyclables);
            }
            else
            {
            
                //If the list is empty and no responce was recieved from the server. we create a TextView to show an error.
                var error = view.FindViewById<TextView>(Resource.Id.errorLabel);
                error.Text = "Something went wrong, please try again later";
                error.SetTextSize(ComplexUnitType.Px, 69);
                
                error.SetTextColor(new Android.Graphics.Color(255, 0, 0));

                
            }



        }
    }

}