using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;


namespace KymiraApplication.Fragments
{
    public class LoginFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }




        private RecyclerView recycleView;

        public View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            //return inflater.Inflate(Resource.Layout.Login_Layout, container, false);

            var view = inflater.Inflate(Resource.Layout.Login_Layout, null);
            recycleView = view.FindViewById<RecyclerView>(Resource.Id.LoginRecyclerView);

            return view;

            // return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}