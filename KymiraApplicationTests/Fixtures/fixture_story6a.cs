using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KymiraApplicationTests.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace KymiraApplicationTests.Fixtures
{
    public class fixture_story6a
    {
        private HttpClient client;
        Uri uri;

        //valid
        Credentials objCred1 = new Credentials
        {
            ID = 1,
            phoneNumber = "1234557892",
            password = "Pa$$w0rd"


        };

        //valid
        Credentials objCred2 = new Credentials
        {
            ID = 1,
            phoneNumber = "1234557890",
            password = "Pa$$w0"


        };

        //valid
        Credentials objCred3 = new Credentials
        {
            ID = 1,
            phoneNumber = "1234557895",
            password = "Pa$$w0rrd"


        };






        /**
                 * This method adds hard-coded data into the database.
                 */
        public async Task load()
        {
            string dispURL = "http://localhost:55085/api/Residents/";

            //add 1 objCred object
            var json = JsonConvert.SerializeObject(objCred1);
            var contents = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.GetAsync(uri);


            json = JsonConvert.SerializeObject(objCred2);
            contents = new StringContent(json, Encoding.UTF8, "application/json");
            response = await client.PostAsync(uri, contents);




            json = JsonConvert.SerializeObject(objCred3);
            contents = new StringContent(json, Encoding.UTF8, "application/json");
            response = await client.PostAsync(uri, contents);


        }



        /**
         * This method deletes the hard-coded data from the database that was previously added.
         */
        public void delete()
        {

        }
    }
}

