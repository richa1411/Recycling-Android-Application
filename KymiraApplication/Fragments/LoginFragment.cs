using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace KymiraApplication.Fragments
{
    public class LoginFragment : Fragment
    {
        //Will run when the app is run. It is the initial creation of the fragment
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        //This view will run when the fragment is called
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            return inflater.Inflate(Resource.Layout.login_layout, container, false);
            

        }
        //Will be called once the login button is tapped

            //Will first check the client side validation. If the client side validation passes (Format validation)
            //It will further then check the backend validation for the correct credentials (Registered Validation)
        private async void BtnLogin_Click(Object sender, EventArgs e)
        {

        }
    }
}