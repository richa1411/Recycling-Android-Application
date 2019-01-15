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

using KymiraApplication.Models;
using Newtonsoft.Json;

namespace KymiraApplication.Fragments
{
    public class LoginFragment : Fragment
    {
        

        private View view;
        private EditText phoneField;
        private EditText passField;
        private Button btnlogin;
        private TextView txtError;

        //Will run when the app is run. It is the initial creation of the fragment
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        //This view will run when the fragment is called
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.login_layout, container, false);

            btnlogin = (Button)view.FindViewById(Resource.Id.btnLogin);
            phoneField = (EditText)view.FindViewById(Resource.Id.etxtPhone);
            passField = (EditText)view.FindViewById(Resource.Id.etxtPassword);
            txtError = (TextView)view.FindViewById(Resource.Id.tvError);

            btnlogin.Click += btnLogin_Click;

            return view;

            //Can Delete probably
            //return inflater.Inflate(Resource.Layout.login_layout, container, false); 




        }
        //Will be called once the login button is tapped

        //Will first check the client side validation. If the client side validation passes (Format validation)
        //It will further then check the backend validation for the correct credentials (Registered Validation)
        private void btnLogin_Click(Object sender, EventArgs e)
        {
            //*******************************************************************************//
            // THIS CURRENTLY USES A JSON OBJECT... WE NEED IT TO USE AN AUTHENTICATION TOKEN //
            //*******************************************************************************//
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
                        var uri = "";
                        var result = await client.PostAsync(uri, content);

                        // on error throw a exception  
                        result.EnsureSuccessStatusCode();

                        // handling the answer  
                        var resultString = await result.Content.ReadAsStringAsync();
                        //TODO get back resident object or authentication token
                        var post = JsonConvert.DeserializeObject<Credentials>(resultString);
                    }
                };

            }
            else
            {
                txtError.Text = results[0].ErrorMessage;
            }
        }
    }
}