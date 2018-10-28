using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using KymiraApplication.Model;
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
                StartActivity(typeof(HomePage));
            }
            else 
            {
                txtError.Text = results[0].ErrorMessage;
            }
        }
    }
}

