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
        //an object for mainactivity just to pass token created at login time
        MainActivity mainAct = new MainActivity();
        private HttpClient client;
        //input fields and butoon that we have on out layout page
        private View view;
        private EditText phoneField;
        private EditText passField;
        private Button btnlogin;
        private TextView txtError;
        HttpResponseMessage result;

        //Will run when the app is run. It is the initial creation of the fragment
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        //This view will run when the fragment is called
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.login_layout, container, false);

            //assigning each input to the layout generated input ids
            //Resource.id will access all the ids from layout
            btnlogin = (Button)view.FindViewById(Resource.Id.btnLogin);
            phoneField = (EditText)view.FindViewById(Resource.Id.etxtPhone);
            passField = (EditText)view.FindViewById(Resource.Id.etxtPassword);
            txtError = (TextView)view.FindViewById(Resource.Id.tvError);
            

            //calls a method on click of button
            btnlogin.Click += btnLogin_Click;

            return view;

          

        }
        //Will be called once the login button is tapped

        //Will first check the client side validation. If the client side validation passes (Format validation)
        //It will further then check the backend validation for the correct credentials (Registered Validation)
        private async void btnLogin_Click(Object sender, EventArgs e)
        {
            String phone = phoneField.Text;
            String password = passField.Text;

            //an instance of credentials class that will get values from user
            Credentials objCred = new Credentials { phoneNumber = phone, password = password };
            //checks user entered credentials against validation helper class for validating them
            var results = ValidationHelper.Validate(objCred);
            //if credentials are valid then connects with backend
            if (results.Count == 0)
            {
                //calls delegate
                btnlogin.Click += async delegate
                {
                    //makes response with HTtpClient that bwill try to connect with URL
                    using (client = new HttpClient())
                    {

                        //create the request content and define Json  
                        //converting object of credentials into json notation
                        var json = JsonConvert.SerializeObject(objCred);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        client.Timeout = System.TimeSpan.FromSeconds(3);

                        //  send a POST request  to backend API
                        var uri = "http://10.0.2.2:55085/api/Credentials";
                        //result variable gets output from API
                        
                        try
                        {
                            result = await client.PostAsync(uri, content);
                        
                        //checks status code that API returns 
                        var success = result.StatusCode;
                            //if status code is not 200 that is OK it means worked well, no not found or bad request or so on
                            if ((int)success != 200)
                            {

                                //displays error messsage
                                txtError.Text = "Incorrect phone number or password";
                            }
                            else
                            {
                                //handling the answer  
                                var resultString = await result.Content.ReadAsStringAsync();
                                //on successful login front end receives token from backend that will be checked against token model class 

                                //trim out the extra quotes
                                resultString = resultString.Trim("\"".ToCharArray());
                                Token objToken = new Token
                                {
                                    token = resultString
                            };
                       

                                var validationResult = ValidationHelper.Validate(objToken);
                                //if token is not in proper GUID format then displays an error message
                                if (validationResult.Count == 0)
                                {
                                    //sets token to mainactivity make it global so that other fragments can use it
                                    mainAct.setToken(objToken.token);
                                    //on successful authentication takes user to a new home screen 
                                    FragmentManager.BeginTransaction().Replace(Resource.Id.frameContent, new HomeFragment()).Commit();
                                
                                }
                                else
                                {

                                    txtError.Text = "Sorry, something went wrong. Try later!!";

                                }
                            }
                        }
                        catch (Exception exc)
                        {
                            result = new HttpResponseMessage();

                            result.StatusCode = System.Net.HttpStatusCode.RequestTimeout;

                            txtError.Text = "Sorry, something went wrong. Try later!!";
                        }
                    }
                };
                
            }
            //displays an error on invalid credentials entries
            else
            {
                txtError.Text = results[0].ErrorMessage;
            }
        }
    }
}