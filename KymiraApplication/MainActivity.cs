using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using KymiraApplication.Model;
namespace KymiraApplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText phoneField;
        EditText passField;
        Button btnlogin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            btnlogin = (Button)FindViewById(Resource.Id.loginButton);
            phoneField = (EditText)FindViewById(Resource.Id.phoneField);
            passField = (EditText)FindViewById(Resource.Id.passwordField);

            btnlogin.Click += OnLoginButtonClick;
        }

        public void OnLoginButtonClick(Object sender, EventArgs e)
        {

            SetContentView(Resource.Layout.content_main);

            String phone = phoneField.ToString();
            String password = passField.ToString();

           Credentials objCred = new Credentials { phoneNumber = phone , password = password };

            Login objLogin = new Login();
            String res = objLogin.ValidPhone(objCred);

        }

        
        

    }
}

