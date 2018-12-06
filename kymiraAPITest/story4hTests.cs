using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using kymiraAPI;
using kymiraAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace kymiraAPITest
{
    [TestClass]
    public class story4hTests
    {
        //setup
        string dispURL = "http://localhost:55085/api/BinStatus/";

        BinStatus testStatus = new BinStatus //bin status object that is good for validation .
        {
            binID = 1,
            status = 1,
            binAddress = "123 fake Street"
        };
        BinStatus sendTest = new BinStatus // binstatus object that is good to send over the internet
        {
            
            status = 1,
            binAddress = "123 fake Street"
        };
        BinStatus badStatus = new BinStatus // bin status with an address not in the database
        {

            status = 1,
            binAddress = "a"
        };

        string address1 = "123 fake Street";
        string address2 = "321 fake Street";
        string address3 = "456 fake Street";


        /**
 * Tests that the model allows a valid object
 * */




        ////*********** address ***********
        /**
         * Tests that the model does not allow an invalid address;
         * */
        [TestMethod]
        public void TestThatAddressIsValid()
        {

            testStatus.binAddress = "123 fake street sk";
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(0, results.Count);
           


        }

        [TestMethod]
        public void TestThatAddressIsValidAt200Characters()
        {

            testStatus.binAddress = new string('a', 200);
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(0, results.Count);



        }

        /**
         * test that the model allows a valid address
         * */
        [TestMethod]
        public void TestThatAddressCanNotBeEmpty()
        {

            testStatus.binAddress = "";
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);


        }
        /**
      * test that the model allows a valid address
      * */
        [TestMethod]
        public void TestThatAddressIsInvalidAt201Characters()
        {

            testStatus.binAddress = new string('a',201);
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);


        }
    
        //-------------------functional----------------
        /**
         * Test that API can receive a Binstatus to put in DB, ( mainly used for testing)
         * */
        [TestMethod]
         public async Task testThatAPISendsBinStatusSuccessfullyWithNoID()
        {

            jsonHandler testJson = new jsonHandler();

            var success = await testJson.sendJsonAsync( sendTest,dispURL);
            Assert.AreEqual("Success", success);

        }
        /**
         * Test that the API can return a list of bin/s with a matching address of the sent binstatus object
         * */
        [TestMethod]
        public async Task testThatAPIGetsBinStatusSuccessfullyAndContains1BinStatus()
        {

            jsonHandler testJson = new jsonHandler();

            List<BinStatus> Success = await testJson.receiveSpecBinStatusJsonAsync(dispURL, address1);

          
            Assert.IsTrue(Success.Count ==1);

            foreach (BinStatus item in Success)
            {
                Assert.AreEqual(sendTest.binAddress, item.binAddress);
            }

        }
        /**
     * Test that the API can return a list of bin/s with a matching address of the sent binstatus object
     * */
        [TestMethod]
        public async Task testThatAPIGetsBinStatusSuccessfullyAndContains2BinStatus()
        {

            jsonHandler testJson = new jsonHandler();

            List<BinStatus> Success = await testJson.receiveSpecBinStatusJsonAsync(dispURL, address1);


            Assert.IsTrue(Success.Count == 2);

            foreach (BinStatus item in Success)
            {
                Assert.AreEqual(sendTest.binAddress, item.binAddress);
            }

        }
        /**
     * Test that the API can return a list of bin/s with a matching address of the sent binstatus object
     * */
        [TestMethod]
        public async Task testThatAPIGetsBinStatusSuccessfullyAndContains3BinStatus()
        {

            jsonHandler testJson = new jsonHandler();

            List<BinStatus> Success = await testJson.receiveSpecBinStatusJsonAsync(dispURL, address1);


            Assert.IsTrue(Success.Count == 3);

            foreach (BinStatus item in Success)
            {
                Assert.AreEqual(sendTest.binAddress, item.binAddress);
            }

        }
        /**
         * Tests that the API does not return any objects if the binstatus address does not exist in the system
         * */
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public async Task testThatAPIGetsBinStatusWithAddressNotFoundInSystem()
        {

            jsonHandler testJson = new jsonHandler();

            List<BinStatus> Success = await testJson.receiveSpecBinStatusJsonAsync(dispURL, address1);

            

          

        }
        /**
 * Tests that the API can send a Json object with an ID, as long as Address is valid.
 * */
       
        [TestMethod]
        public async Task testThatAPIGetsBinStatus()
        {

            jsonHandler testJson = new jsonHandler();

            List<BinStatus> Success = await testJson.receiveSpecBinStatusJsonAsync(dispURL, address1);

            Assert.IsTrue(Success.Count > 0);

            foreach (BinStatus item in Success)
            {
                Assert.AreEqual(sendTest.binAddress, item.binAddress);
            }

        }

    }
}
