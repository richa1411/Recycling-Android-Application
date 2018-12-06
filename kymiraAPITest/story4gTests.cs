using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using kymiraAPI;
using kymiraAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace kymiraAPITest
{
    [TestClass]
    public class storyg4gTests
    {
        //SETUP
        string dispURL = "http://localhost:55085/api/PickupDate/";

        PickupDate testDbItem = new PickupDate
        {
            binID = 1,
            binAddress = "426 Spadina Cres W",
            collectionDate = "12/06/2018"
        };

        //************ FUNCTIONAL TESTS ************
        /**
          * this Test will test if our POST request is succesful
          * */
        [TestMethod]
        public async Task TestSendValidJson()
        {
            jsonHandler testJSON = new jsonHandler();
            var success = await testJSON.sendJsonAsync(testDbItem, dispURL);
            Assert.AreEqual("Success", success);
        }
        /**
         * This tests, tests that if given true, the api will return only bins from the given address
         * */
        [TestMethod]
        public async Task TestGetValidJsonRecyclable()
        {
            jsonHandler testJSON = new jsonHandler();

            List<PickupDate> success = await testJSON.receiveSpecJsonAsyncPickup(dispURL, "426 Spadina Cres W");

            Assert.IsTrue(success.Count > 0);

            foreach (PickupDate item in success)
            {
                Assert.AreEqual("426 Spadina Cres W", item.binAddress);
            }

        }

        //Model Tests

        ////*********** ID ***********
        /**
         * Tests that the model allows a valid id.
         * */
        [TestMethod]
        public void TestThatIDIsValid()
        {
            testDbItem.binID = 1;
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
        }

        ////*********** Address ***********

        /**
        * Tests that an empty address will be rejected
        * 
        * */
        [TestMethod]
        public void TestInvalidEmptyAddress()
        {
            testDbItem.binAddress = "";
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address cannot be an empty field", results[0].ErrorMessage);
        }

        /**
        * Tests that an address with invalid characters will be rejected
        * 
        * */
        [TestMethod]
        public void TestInvalidCharacterAddress()
        {
            testDbItem.binAddress = "Wilson @@!!??";
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Invalid Address", results[0].ErrorMessage);
        }

        /**
        * Tests that an address that is too long will be rejected
        * 
        * */
        [TestMethod]
        public void TestInvalid301CharacterAddress()
        {
            testDbItem.binAddress = new string('a', 301);
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 300 characters or less", results[0].ErrorMessage);
        }

        /**
         * Tests that a valid address will be accepted
         * 
         * */
        [TestMethod]
        public void TestValidAddress()
        {
            testDbItem.binAddress = "426 Spadina Cres W";
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
        }        

        ////*********** Collection Date ***********

         /**
         * Tests that an invalid collection date will be rejected
         * 
         * */
        [TestMethod]
        public void TestInvalidEmptyCollectionDate()
        {
            testDbItem.collectionDate = "";
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Collection Date cannot be an empty field", results[0].ErrorMessage);
        }

        /**
         * Tests that an invalid collection date will be rejected
         * 
         * */
        [TestMethod]
        public void TestInvalidCollectionDate()
        {
            testDbItem.collectionDate = "2344/68/1990";
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Invalid Date format", results[0].ErrorMessage);
        }

        /**
         * Tests that a valid collection date will be accepted
         * 
         * */
        [TestMethod]
        public void TestValidCollectionDate()
        {
            testDbItem.collectionDate = "12/06/2018";
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
        }

    }
}

