﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using kymiraAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using kymiraAPI.Fixtures;

namespace kymiraAPITest
{
    [TestClass]
    public class BinStatusAPITests
    {
        //setup
        //string dispURL = "http://localhost:55085/api/BinStatus/";
        //string dispURL = KymiraApplication.Resource.String.UrlBinStatus;
            //Application.Context.Resources.GetString();
            //KymiraApplication.Resource.String.UrlBinStatus.ToString();
            //KymiraApplication.Resources.values.strings.xml;
        private HttpClient client;
        Uri uri;
        
        BinStatus testStatus = new BinStatus //bin status object that is good for validation .
        {
           
            status = 1,
            binAddress = "123 fake Street"
        };
        
        /*
        BinStatus testStatus2 = new BinStatus //bin status object that is good for validation .
        {

            status = 1,
            binAddress = "321 fake Street"
        };
        BinStatus testStatus3 = new BinStatus //bin status object that is good for validation .
        {

            status = 1,
            binAddress = "456 fake Street"
        };
      
        BinStatus badStatus = new BinStatus // bin status with an address not in the database
        {

            status = 1,
            binAddress = ""
        };
        */

        //defined addresses to use for altering the BinStatus object above to
        // check if a BinStatus object is valid or invalid
        string address1 = "123 fake Street";
        string address2 = "321 fake Street";
        string address3 = "456 fake Street";
        string badAddress = "";

        /*
         *  This method runs before the tests to set up the database for 
         *  the tests in this class. It calls the fixture class to load the database.
         */
        [TestInitialize]
        public  void Setup()
        {
            //client = new HttpClient();
            //uri = new Uri(dispURL, UriKind.Absolute);

            //create an instance of the fixture class and load the proper objects into the database 
            //to be used for testing
            fixture_bin_status fixtureBinStatus = new fixture_bin_status();
            //fixtureBinStatus.Load(_context);
        }

        /**
         * Tests that the model does not allow an invalid address;
        */
        [TestMethod]
        public void TestThatAddressIsInvalidAt201Characters()
        {
            testStatus.binAddress = new string('a', 201);
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        /**
        * test that the model allows a valid address
         * */
        [TestMethod]
        public void TestThatAddressIsValid()
        {
            testStatus.binAddress = "123 fake street sk";
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(0, results.Count);
        }

        /**
         * Tests that a binstatus object is valid with an address of 200 characters.
         */
        [TestMethod]
        public void TestThatAddressIsValidAt200Characters()
        {
    
            testStatus.binAddress = new string('a', 200);
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(0, results.Count);
        }

        /*
         * Tests that the API does not return any objects if the binstatus address does not exist in the system
         */
        [TestMethod]
        public async Task testThatAPIGetsBinStatusWithAddressNotFoundInSystem()
        {
            // sends address string 3
            var json = JsonConvert.SerializeObject(badAddress);
            var contents = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri, contents);
            Assert.AreEqual("Bad Request", response.ReasonPhrase);
        }

        /*
         * test that the model with an empty binAddress is invalid
         */
        [TestMethod]
        public void TestThatAddressCanNotBeEmpty()
        {
            testStatus.binAddress = "";
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        /*
         * Test that the API can return a list of bin/s with a matching address of the sent binstatus object
         */
        [TestMethod]
        public async Task testThatAPIGetsBinStatusSuccessfullyAndContains1BinStatus()
        {
            // sends address string 1
            var json = JsonConvert.SerializeObject(address1);
            var contents = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(uri, contents);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                List<BinStatus> binList = JsonConvert.DeserializeObject<List<BinStatus>>(content);
                Assert.IsTrue(binList.Count == 1);

                foreach (BinStatus item in binList)
                {
                    Assert.AreEqual(address1, item.binAddress);
                }
            }
        }

        /*
         * Test that the API can return a list of bin/s with a matching address of the sent binstatus object
         */
        [TestMethod]
        public async Task testThatAPIGetsBinStatusSuccessfullyAndContains2BinStatus()
        {
            // sends address string 2
            var json = JsonConvert.SerializeObject(address2);
            var contents = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri, contents);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                List<BinStatus> binList = JsonConvert.DeserializeObject<List<BinStatus>>(content);


                Assert.IsTrue(binList.Count == 2);

                foreach (BinStatus item in binList)
                {
                    Assert.AreEqual(address2, item.binAddress);
                }


            }
        }
        /*
         * Test that the API can return a list of bin/s with a matching address of the sent binstatus object
         */
        [TestMethod]
        public async Task testThatAPIGetsBinStatusSuccessfullyAndContains3BinStatus()
        {
            // sends address string 3
            var json = JsonConvert.SerializeObject(address3);
            var contents = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri, contents);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                List<BinStatus> binList = JsonConvert.DeserializeObject<List<BinStatus>>(content);
                Assert.IsTrue(binList.Count == 3);

                foreach (BinStatus item in binList)
                {
                    Assert.AreEqual(address3, item.binAddress);
                }
            }
        }

        [TestMethod]
        public async Task testThatIsLastestCollection()
        {
            //search for certain address that contains many dates for pickups
            //ensure that the BinStatuses brought back/selected were the latest date

            //the latest entry of the database is "2019-02-02" for site 2.



        }

        /**
 * Tests that the API can send a Json object with an ID, as long as Address is valid.
 * */
       
        [TestMethod]
        public async Task testThatAPIGetsBinStatus()
        {
            var json = JsonConvert.SerializeObject(address1);
            var contents = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri, contents);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                List<BinStatus> binList = JsonConvert.DeserializeObject<List<BinStatus>>(content);

                foreach (BinStatus item in binList)
                {
                    Assert.AreEqual(address1, item.binAddress);
                }


            }


        }

     

    }
}
