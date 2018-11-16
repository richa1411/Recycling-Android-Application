using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace KymiraApplication
{
    [Activity(Label = "BinCollection")]
    public class BinCollection : Activity
    {
        private EditText addressField;
       
        private Button btnlogin;
        private TextView txtDate;
        private TextView txtError;
        protected override void OnCreate(Bundle savedInstanceState)
        {


            /*if(user is logged in)
         {
              //calls json from backend 
              //checks validatation(Non empty, format) on received date using BinCollectionDate Model class
              //and displays date with textview 
               StartActivity(typeof(CollectionDate));
          }
          else
            {
             base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addressForCollectionPage); //content view is got from Resource that contains layout for our login page
            btnAddress = (Button)FindViewById(Resource.Id.btnAddress);
        addressField = (EditText)FindViewById(Resource.Id.etxtAddress);
            txtDate = (TextView)FindViewById(Resource.Id.tvDate);
             txtError = (TextView)FindViewById(Resource.Id.tvError);

            btnAddress.Click += btnAddress_Click; //Onclick listener for button
                //activity displays textview for address
                //activity displays button to submit entered address
                //a method for onsubmit button that checks valid address(non empty, format) using BinCollectionDate Model Class
               //calls json from backend 
              //checks validatation(Non empty, format) on received date using BinCollectionDate Model class
              //and displays date with textview 

            }

            private void btnAddress_Click(object sender, EventArgs e)
            {
                String address = addressField.Text;
               

                BinCollectionDate objDate = new Credentials { Address = address, collectionDate = ""};
                var results = ValidationHelper.Validate(objDate);

                if (results.Count == 0)
                {
                    btnAddress.Click += async delegate
                    {
                        using (var client = new HttpClient())
                        {


                            // create the request content and define Json  
                            var json = JsonConvert.SerializeObject(objDate);
                            var content = new StringContent(json, Encoding.UTF8, "application/json");
                            //TODO: Add proper url 
                            //  send a POST request  
                            var uri = "Server=(localdb)\\mssqllocaldb;Database=kymiraAPIContext-bdae60b3-966d-4816-abfe-4aa9d23e2424;Trusted_Connection=True;MultipleActiveResultSets=true";
                            var result = await client.PostAsync(uri, content);

                            // on error throw a exception  
                            result.EnsureSuccessStatusCode();

                            // handling the answer  
                            var resultString = await result.Content.ReadAsStringAsync();
                            //TODO get back resident object or authentication token
                            var post = JsonConvert.DeserializeObject<Credentials>(resultString);
                        }
                    };

                    StartActivity(typeof(CollectionDate));
                }
                else
                {
                    txtError.Text = results[0].ErrorMessage;
                }
            }
            */
         
        }


    }
}
 
 