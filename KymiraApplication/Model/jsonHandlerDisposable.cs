﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace KymiraApplication.Model
{
    //This class will handle the creation, serialization, deserialzation, sending, and receiving of JSON objects in order for the
    //android application to communicate with the back end controller.
    public class jsonHandlerDisposable
    {
        // The class has a private HttpClient for POST and GET requests
        private HttpClient client;

        // Constructor for the jsonHandler accepts a Uri and creates a new HttpClient
        public jsonHandlerDisposable()
        {
            this.client = new HttpClient();
        }

        //This method handles sending a serialized Registration json object to the uri specified
        public async Task<String> sendJsonAsync(Object item, String strUri)
        {
            //Conver the given string to a URI
            Uri uri = new Uri(strUri, UriKind.Absolute);

            // Serialize the Registration item into a JSON object
            var json = JsonConvert.SerializeObject(item);

            // Convert the JSON object to be StringContent
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Create an HttpResponseMessage to hold the response of the HttpClient's POST
            HttpResponseMessage response = await client.PostAsync(uri, content);

            // If JSON was sent successfully, return that
            if(response.IsSuccessStatusCode)
            {
                return "Success";
            }
            // Else, notify user that it failed
            else
            {
                return response.StatusCode.ToString();
            }
        }

        // This method handles receiving json from the uri specified
        public async Task<String> receiveJsonAsync(String strUri)
        {

            Uri uri = new Uri(strUri, UriKind.Absolute);
            // Create an HttpResponse message to hold the response from the back end
            HttpResponseMessage response = await client.GetAsync(uri);

            // Check if the message was sent successfully
            if(response.IsSuccessStatusCode)
            {
                //Create a varialbe to contain the response of the response's GET
                var content = await response.Content.ReadAsStringAsync();

                return content;
            }
            // If there were errors receiving the JSON, let the user know
            else
            {
                return "Error receiving data";
            }

           
        }

        // This method handles receiving json from the uri specified
        public async Task<List<Disposable>> receiveSpecJsonAsync(String strUri, bool isResc)
        {
           

            strUri += isResc ? "true" : "false";

            Uri uri = new Uri(strUri, UriKind.Absolute);

            var json = JsonConvert.SerializeObject(new { isRecyclable = isResc});


            var contents = new StringContent(json, Encoding.UTF8, "application/json");
            // Create an HttpResponse message to hold the response from the back end
            HttpResponseMessage response = await client.GetAsync(uri);

            // Check if the message was sent successfully
            if (response.IsSuccessStatusCode)
            {
                //Create a varialbe to contain the response of the response's GET
                var content = await response.Content.ReadAsStringAsync();

                return  JsonConvert.DeserializeObject<List<Disposable>>(content);
            }
            // If there were errors receiving the JSON, let the user know
            else
            {
               throw new Exception("no work");
            }


        }



    }
}