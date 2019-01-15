using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using KymiraApplication.Models;
using Newtonsoft.Json;
using Mono;

namespace KymiraApplication.Fragments
{
    public class DisposablesFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        

        private static List<Disposable> disposables;


        /**
         *  This method will use the Listview and adapter to display the information on dispoables
         */ 
        private void displayDisposablesList(List<Disposable> disposables)
        {

        }



        /**
         * This method will take in an array of disposable objects, and add placeholder images to them if
         * any objects in the array don't have images assigned to them. It then returns the disposables array, with images.
         */
        private static List<Disposable> addPlaceholders(List<Disposable> disposables)
        {

            return null;
        }


 

        // This method handles receiving json from the uri specified
        public async Task<List<Disposable>> receiveSpecJsonAsync()
        {

            return null;

        }

}