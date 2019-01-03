using kymiraAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace kymiraAPITest.Fixtures
{
    /**
     * This class is used to add and then delete data from the database in order for tests to pass.
     */
    public class fixture_bin_status
    {
        /**
         * This method adds hard-coded data into the database.
         */
            

        public void load()
        {
            //BinStatus objects to add into the database
            BinStatus testStatus = new BinStatus //bin status object that is good for validation
            {
                status = 1,
                binAddress = "123 fake Street"
            };
            BinStatus testStatus2 = new BinStatus //bin status object that is good for validation
            {
                status = 1,
                binAddress = "321 fake Street"
            };
            BinStatus testStatus3 = new BinStatus //bin status object that is good for validation
            {
                status = 1,
                binAddress = "456 fake Street"
            };
            BinStatus badStatus = new BinStatus // bin status with an address not in the database
            {
                status = 1,
                binAddress = ""
            };

            //string dispURL = "http://localhost:55085/api/BinStatus/";
            private HttpClient client;
            Uri uri;

        
        
            //add 1 testStatus object
            //var json = JsonConvert.SerializeObject(testStatus);
            //var contents = new StringContent(json, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync(uri, contents);
            
            //add 2 testStatus2 objects

            //add 3 testStatus3 objects

        }

        /**
         * This method deletes the hard-coded data from the database that was previously added.
         */
        public void delete()
        {

        }
    }
}
