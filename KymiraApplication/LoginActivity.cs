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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class LoginActivity : AppCompatActivity
    {
        private EditText phoneField;
        private EditText passField;
        private Button btnlogin;
        private TextView txtError;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginPage);
            btnlogin = (Button)FindViewById(Resource.Id.btnLogin);
            phoneField = (EditText)FindViewById(Resource.Id.etxtPhone);
            passField = (EditText)FindViewById(Resource.Id.etxtPassword);
            txtError = (TextView)FindViewById(Resource.Id.tvError);

            btnlogin.Click += btnlogin_Click;

        }

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
                        // Create a new post  
                        var novoPost = new Credentials
                        {
                            
                            phoneNumber = phone,
                            password = password
                        };

                        // create the request content and define Json  
                        var json = JsonConvert.SerializeObject(novoPost);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        //  send a POST request  
                        var uri = "Server=(localdb)\\mssqllocaldb;Database=kymiraAPIContext-bdae60b3-966d-4816-abfe-4aa9d23e2424;Trusted_Connection=True;MultipleActiveResultSets=true";
                        var result = await client.PostAsync(uri, content);

                        // on error throw a exception  
                        result.EnsureSuccessStatusCode();

                        // handling the answer  
                        var resultString = await result.Content.ReadAsStringAsync();
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

