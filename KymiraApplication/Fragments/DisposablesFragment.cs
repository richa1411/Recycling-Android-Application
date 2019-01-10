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

        

        private static Disposable[] disposables;

        /**
        *  This method will send a request to the backend, asking for a list of the
        *  disposables. isRecyclable is either true if the user wants a list of recyclable
        *  items or false if they want a list of non-recyclables which is determined by the
        *  they press. The backend will then return an array of JSON objects, (array of strings)
        *  to the app. The app then returns this array.
        */
        public  async void requestDisposableListAsync()
        {

            

        }



        /**
         * This method will take the array returned from requestDisposableList() and parse through it.
         * It takes each JSON object, and turns it into a Disposable Object. It then adds each object
         * to an array of Disposables. This array is returned
         */
        private static Disposable[] parseDisposable(List<Disposable> disposablesList)
        {
            return null;   
        }

        /**
         *  This method will take in an array of disposable objects, which was acqquired from parseDisposable.
         *  This method will take the disposable objects and display a list of them to the user.
         */
        public static Disposable[] getDisposableList()
        {
            // Add the items in the array to the listView
            return disposables;


        }

        /**
         * This method will take in an array of disposable objects, and add placeholder images to them if
         * any objects in the array don't have images assigned to them. It then returns the disposables array, with images.
         */
        private static Disposable[] addPlaceholders(Disposable[] disposables)
        {

            return null;
        }

        // This method handles receiving json from the uri specified
        public async Task<List<Disposable>> receiveSpecJsonAsync()
        {

            return null;

        }
    }
}