using System;
using System.Net.Http;
using System.Text;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using KymiraApplication.Model;
using Newtonsoft.Json;

namespace KymiraApplication
{
    //LoginActivity Page
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class LoginActivity : AppCompatActivity
    {
        //private Fields / Properties 2 textfields for phonenumber and password one textview for error and button for login
        private EditText phoneField;
        private EditText passField;
        private Button btnlogin;
        private TextView txtError;

       //OnCreate method that starts an app (Launching)
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginPage); //content view is got from Resource that contains layout for our login page
            btnlogin = (Button)FindViewById(Resource.Id.btnLogin);
            phoneField = (EditText)FindViewById(Resource.Id.etxtPhone);
            passField = (EditText)FindViewById(Resource.Id.etxtPassword);
            txtError = (TextView)FindViewById(Resource.Id.tvError);

            btnlogin.Click += btnlogin_Click; //Onclick listener for button
        }

        /*
         * This method waits for the user to click the log in button
         * It then takes in the two values from the edit text field and 
         * creates a new credentials object that is used to validate.
         * if there are no validation violations detected then the app 
         * will start the home screen activity and send the jsonized 
         * file to server for server side validation
         * 
         * If there is a violation then a text message pops up
         * with the appropriate error message. 
         */
        private void btnlogin_Click(object sender, EventArgs e)
        {
            String phone = phoneField.Text; 
            String password = passField.Text;

            Credentials objCred = new Credentials { phoneNumber = phone, password = password };
            var results = ValidationHelper.Validate(objCred);

            if (results.Count == 0)
            {
                btnlogin.Click += async delegate
                {
                    using (var client = new HttpClient())
                    {


                        // create the request content and define Json  
                        var json = JsonConvert.SerializeObject(objCred);
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

                StartActivity(typeof(HomePage));
            }
            else 
            {
                txtError.Text = results[0].ErrorMessage;
            }
        }
    }
}

