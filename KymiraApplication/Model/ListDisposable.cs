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

namespace KymiraApplication.Model
{
    public class ListDisposable
    {
        /**
        *  This method will send a request to the backend, asking for a list of the
        *  disposables. isRecyclable is either true if the user wants a list of recyclable
        *  items or false if they want a list of non-recyclables which is determined by the
        *  they press. The backend will then return an array of JSON objects, (array of strings)
        *  to the app. The app then returns this array.
        */
        public static string[] requestDisposableList(bool isReyclable)
        {
            return null;
        }

        /**
         * This method will take the array returned from requestDisposableList() and parse through it.
         * It takes each JSON object, and turns it into a Disposable Object. It then adds each object
         * to an array of Disposables. This array is returned
         */
        public static Disposable[] parseDisposable(string[] jsonArray)
        {
            return null;
        }

        /**
         *  This method will take in an array of disposable objects, which was acqquired from parseDisposable.
         *  This method will take the disposable objects and display a list of them to the user.
         */
        public static void displayDisposableList(Disposable[] disposables)
        {

        }
    }
}