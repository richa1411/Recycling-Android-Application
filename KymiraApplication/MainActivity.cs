using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace KymiraApplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Widget.Button login = FindViewById<Android.Widget.Button>(Resource.Id.log)
        }

        public void OnLoginButtonClick(Object sender, EventArgs e)
        {
            Model.Credentials cred = new Model.Credentials();
            
        }

    }
}

