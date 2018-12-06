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

        string dispURL = "http://localhost:55085/api/BinStatus/";

        BinStatus testStatus = new BinStatus
        {
            binID = 1,
            status = 1,
            binAddress = "123 fake Street"
        };
        BinStatus sendTest = new BinStatus
        {
            
            status = 1,
            binAddress = "123 fake Street"
        };


        /**
 * Tests that the model allows a valid object
 * */
        [TestMethod]
        public void AllBinStatusInformationIsValidTest()
        {

            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(0, results.Count);

        }

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
         * Tests that the model allows a valid id;
         * */
        [TestMethod]
        public void TestThatAddressIsValid()
        {

            testStatus.binAddress = "123 fake street sk";
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(0, results.Count);
           


        }
        [TestMethod]
        public void TestThatAddressIsInValid()
        {

            testStatus.binAddress = "";
            var results = HelperTestModel.Validate(testStatus);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);


        }

        //-------------------functional----------------
        /**
         * 
         * */
         [TestMethod]
         public async Task testThatAPISendsBinStatusSuccessfully()
        {

            jsonHandler testJson = new jsonHandler();

            var success = await testJson.sendJsonAsync( sendTest,dispURL);
            Assert.AreEqual("Success", success);

        }
        [TestMethod]
        public async Task testThatAPIGetsBinStatusSuccessfully()
        {

            jsonHandler testJson = new jsonHandler();

            List<BinStatus> Success = await testJson.receiveSpecBinStatusJsonAsync(dispURL, sendTest);

            var success = await testJson.sendJsonAsync(sendTest, dispURL);
            Assert.IsTrue(Success.Count > 0);

            foreach (BinStatus item in Success)
            {
                Assert.AreEqual(sendTest.binAddress, item.binAddress);
            }

        }

    }
}
