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
using KymiraApplication.Model;

namespace KymiraApplication
{
    [Activity(Label = "ListDisposable")]
    public class ListDisposable : Activity
    {
        string[] jsonArray;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            //KymiraApplication.Model.ListDisposable.parseDisposable(jsonArray);
            
        }

       



    }
}