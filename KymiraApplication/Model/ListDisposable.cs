using System;
using System.Collections;
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
        public static async void requestDisposableListAsync(bool isReyclable)
        {
            Disposable[] disposables;

            List<Disposable> disposablesList;
            //string stringToJson = "";
            jsonHandlerDisposable jsonHandler = new jsonHandlerDisposable();

            // Send a Request, with the isReyclable set.
            if (isReyclable == true)
            {
                disposablesList = await jsonHandler.receiveSpecJsonAsync("localhost", true);

            }
            else
            {
                disposablesList = await jsonHandler.receiveSpecJsonAsync("localhost", false);
            }

            //Check to see if the returned JSON Object has data in it

            // If it doesn't have data
            if (disposablesList.Count() == 0)
            {
                // Throw an exception -- Cannot retrieve data at this time
                throw new Exception("Error connecting to server, please try again later.");
            }

           

            // else
            // Take the array of JSON objects and call parseDisposable
            disposables = parseDisposable(disposablesList);

            

            

        }

        /**
         * This method will take the array returned from requestDisposableList() and parse through it.
         * It takes each JSON object, and turns it into a Disposable Object. It then adds each object
         * to an array of Disposables. This array is returned
         */
        private static Disposable[] parseDisposable(List<Disposable> disposablesList)
        {
            Disposable[] disposables = disposablesList.ToArray();


            int nCounter = 0;

            foreach (Disposable disposable in disposables)
            {
                disposables[nCounter] = new Disposable(disposable.name, disposable.description, disposable.imageURL,
                                                        disposable.isRecyclable, disposable.endResult, disposable.qtyRecycled, disposable.recycleReason);
            }

            // Go through the disposables array and only call addPlaceholders
            // if one of the objects is missing an ImageURL -- more efficient than
            // always calling addPlaceholders
            for(int i = 0; i < disposables.Length; i++)
            {
                if(disposables[i].imageURL == "")
                {
                    disposables = addPlaceholders(disposables);
                }
                
                
            }

            // If this statement is reached, it means that the
            // objects in the disposables array all have a valid ImageURL
            // So we can skip right to displaying the list
            return disposables;
        }

        /**
         *  This method will take in an array of disposable objects, which was acqquired from parseDisposable.
         *  This method will take the disposable objects and display a list of them to the user.
         */
        private static Disposable[] getDisposableList(Disposable[] disposables)
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
            // For each Disposable Object in the array
            for (int i = 0; i < disposables.Length; i++)
            {
                if (disposables[i].imageURL == "") // If Object has no valid image
                {
                    disposables[i].imageURL = "No_Image.png"; // Replace invalid image with our placeholder
                }

            }

            // Call this method to display our list of disposables
            return disposables;
            
        }
    }
}