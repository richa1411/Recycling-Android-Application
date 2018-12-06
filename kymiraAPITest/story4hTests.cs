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

        BinStatus testStatus = new BinStatus //bin status object that is good for validation but not good to send.
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


        /**
 * Tests that the model allows a valid object
 * */


        ////*********** ID ***********
        /**
         * Tests that the model allows a valid id.
         * */
        [TestMethod]
        public void TestThatIDIsValid()
        {

            testStatus.binID = 1;
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(0, results.Count);


        }

        ////*********** ID ***********
        /**
         * Tests that the model does not allow an invalid id.
         * */
        [TestMethod]
        public void TestThatIDIsInvalid()
        {

            testStatus.binID = -1;
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Sorry something went wrong, please try again in a few minutes", results[0].ErrorMessage);
           

        }

    
  

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
         public async Task testThatAPISendsBinStatusSuccessfully()
        {

            jsonHandler testJson = new jsonHandler();

            var success = await testJson.sendJsonAsync( sendTest,dispURL);
            Assert.AreEqual("Success", success);

        }
        /**
         * Test that the API can return a list of bin/s with a matching address of the sent binstatus object
         * */
        [TestMethod]
        public async Task testThatAPIGetsBinStatusSuccessfully()
        {

            jsonHandler testJson = new jsonHandler();

            List<BinStatus> Success = await testJson.receiveSpecBinStatusJsonAsync(dispURL, sendTest);

          
            Assert.IsTrue(Success.Count > 0);

            foreach (BinStatus item in Success)
            {
                Assert.AreEqual(sendTest.binAddress, item.binAddress);
            }

        }
        /**
         * Tests that the API does not return any objects if the binstatus address does not exist in the system
         * */
        [TestMethod]
        public async Task testThatAPIGetsBinStatusUnsuccessfully()
        {

            jsonHandler testJson = new jsonHandler();

            List<BinStatus> Success = await testJson.receiveSpecBinStatusJsonAsync(dispURL, badStatus);

            Assert.IsTrue(Success.Count == 0);

          

        }
        /**Tests that the Bins status is valid at 1 == good
         * 
         * */
        [TestMethod]
        public void TestThatBinStatusIsValidAt1()
        {
            testStatus.status = 1;
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(0, results.Count);
          
        }
        /**
        * tests that the bin status is valid at 2 == blocked
        * */
        [TestMethod]
        public void TestThatBinStatusIsValidAt2()
        {
            testStatus.status = 2;
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(0, results.Count);
          
        }
        /**
        * test that the bin status is valid at 3 == contaminated.
        * */
        [TestMethod]
        public void TestThatBinStatusIsValidAt3()
        {
            testStatus.status = 3;
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(0, results.Count);
         
        }
        /**
        * test that the bin status is NOT valid at 4
        * */
        [TestMethod]
        public void TestThatBinStatusIsInvalidAt4()
        {
            testStatus.status = 4;
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Sorry something went wrong, please try again in a few minutes", results[0].ErrorMessage);
        }

    }
}
