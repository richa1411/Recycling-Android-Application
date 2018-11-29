using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using kymiraAPI;
using kymiraAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace kymiraAPITest
{
    [TestClass]
    public class story2gTests
    {
        string dispURL = "http://localhost:55085/api/Disposables/";

        Disposable testDbItem = new Disposable{
            ID = 1,
            name = "Glass Bottles",
            description = "These are Glass Bottles",
            pictureID = "tomatoes",
            isRecyclable = true,
            recyclableReason = "Glass Bottles Reason",
            endResult = "Glass Bottles End Result",
            qtyRecycled = 1000
        };

        Disposable sendTest = new Disposable
        {
            name = "Hey",
            description = "I'm a Potato",
            pictureID = "Potato",
            isRecyclable = true,
            recyclableReason = "Cause",
            endResult = "tomato sauce",
            qtyRecycled = 1000
        };

        //************ FUNCTIONAL TESTS ************
        /**
         * this Test will test if our POST request is succesful
         * */
        [TestMethod]
        public async Task TestSendValidJson()
        {
            jsonHandler testJSON = new jsonHandler();
            var success = await testJSON.sendJsonAsync(sendTest, dispURL);
            Assert.AreEqual("Success", success);
        }
        /**
         * This tests, tests that if given true, the api will return only recyclable objects from the db.
         * */
        [TestMethod]
        public async Task TestGetValidJsonRecyclable()
        {
            jsonHandler testJSON = new jsonHandler();

            List<Disposable> success = await testJSON.receiveSpecJsonAsync(dispURL, true);

            Assert.IsTrue(success.Count > 0);

            foreach (Disposable item in success) {
                Assert.AreEqual(true, item.isRecyclable);
            }
            
        }
        /**
         * This tests that if given false, our API will only return non-recyclable objects from the db
         * */
        [TestMethod]
        public async Task TestGetValidJsonNotRecyclable()
        {
            jsonHandler testJSON = new jsonHandler();

            List<Disposable> success = await testJSON.receiveSpecJsonAsync(dispURL, false);

            Assert.IsTrue(success.Count > 0);

            foreach (Disposable item in success)
            {
                Assert.AreEqual(false, item.isRecyclable);
            }

        }
        /**
         * Tests that invalid sent values will result in an error
         * */
         [ExpectedException(typeof(Exception))]
        [TestMethod]
        public async Task TestSendInvalidRequest()
        {
            jsonHandler testJSON = new jsonHandler();
            //see json handler for info on method call
            List<Disposable> success = await testJSON.testSendInvalidJsonHandler(dispURL, true);

        }



        /**
         * Tests that the model allows a valid object
         * */
        [TestMethod]
        public void AllRecyclableInformationIsValidTest()
        {

            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);

        }

        ////*********** ID ***********
        /**
         * Tests that the model allows a valid id.
         * */
        [TestMethod]
        public void TestThatIDIsValid()
        {

            testDbItem.ID = 1;
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);


        }



        //*********** NAME ***********
        /**
        * Test that name cannot be empty. result is invalid.
        * */
        [TestMethod]
        public void TestThatNameIsEmpty()
        {
            testDbItem.name = null;
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Name is required", results[0].ErrorMessage);
        }
        /**
        * Test that Name cannot be greater than 50 characters. result is invalid.
        * */
        [TestMethod]
        public void TestThatNameIs51CharsLong()
        {

            //ErrorMessage = "name must be 50 characters or less."
            testDbItem.name = new string('a', 51);
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("name must be 50 characters or less.", results[0].ErrorMessage);

        }

        /**
        * Test that Name is 50 charactesr long. result is valid
        * */
        [TestMethod]
        public void TestThatNameIs50CharsLong()
        {
            testDbItem.name = new string('a', 50);
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);

            //no errors

        }

        //*********** DESCRIPTION ***********
        /**
         * Test that the description is valid.
         * */
        [TestMethod]
        public void TestThatDescriptionisValid()
        {
            testDbItem.description = "PRJ2Cosmo";
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
            //NoError

        }
        /**
         * Test that Description is empty. result will be invalid.
         * */
        [TestMethod]
        public void TestThatDescriptionisEmpty()
        {
            testDbItem.description = null;
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Description is required", results[0].ErrorMessage);
            //error

        }
        /**
         * Test that the description is greater than 500 chracters. result will be invalid
         * */
        [TestMethod]
        public void TestThatDescriptionisGreaterThan500Characters()
        {
            testDbItem.description = new string('a', 501);
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Description must be 500 characters or less.", results[0].ErrorMessage);
            //error

        }
        /**
         * Tests the boundary case that the disposable description can be 500 characters.
         * */
        [TestMethod]
        public void TestThatDescriptionis500Characters()
        {
            testDbItem.description = new string('a', 500);
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
            
           

        }

        //*********** PICTURE ***********
        /**
        * Tests that pictureID cannot be empty. result is invalid.
        * */
        [TestMethod]
        public void TestThatPictureIDIsEmpty()
        {
            testDbItem.pictureID = null;
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("PictureID is required", results[0].ErrorMessage);
            //errors

        }
        /**
        * Test that pictureID is a Number. result is valid
        * */
        [TestMethod]
        public void TestThatPictureIDIsAString()
        {
            testDbItem.pictureID = "pizza";
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
            //no errors

        }

        /**
        * Test that Picture must be a number. result invalid.
        * */
        [TestMethod]
        public void TestThatPictureIDCanNotbeGreaterThan90Characters()
        {
            testDbItem.pictureID = new string('a', 91);
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("PictureID must be 90 characters or less", results[0].ErrorMessage);
            //error

        }
        /**
         * Tests that the disposable picture id is valid at 90 characters
         * */
        [TestMethod]
        public void TestThatPictureIDis90Characters()
        {
            testDbItem.pictureID = new string('a', 90);
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
            //error

        }

        //*********** isRECYCLABLE ***********
        
        /**
         * Test that the disposable item is not recyclable. IsRecyclable set to false is Valid
         * */
        [TestMethod]
        public void TestThatisRecyclableIsFalse()
        {
            testDbItem.isRecyclable = false;
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
            //NoError

        }
        /**
         * Test that the disposible item is recyclable. isRecyclable set to true is valid
         * */
        [TestMethod]
        public void TestThatisRecyclableIsTrue()
        {

            testDbItem.isRecyclable = true;
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
            //NoError

        }



        //*********** RECYCLABLEREASON ***********
        /**
        * Tests that RecyclableReason passes validation and is valid. 
        * */
        [TestMethod]
        public void TestThatRecyclableReasonIsValid()
        {
            testDbItem.recyclableReason = "Because stone cold steve austin said so";
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
            //noerror


        }

        /**
        * Tests that recycable reason cannot be greater than 500 characters. result is invalid
        * */
        [TestMethod]
        public void TestThatRecyclableReasonIsGreaterThan500Characters()
        {
            testDbItem.recyclableReason = new string('a', 501);
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Reason must be 500 characters or less.", results[0].ErrorMessage);

            //error


        }
        /**
         * Tests that the dispoable recyclable reason is valid at 500 characters.
         * */
        [TestMethod]
        public void TestThatRecyclableReasonIs500Characters()
        {
            testDbItem.recyclableReason = new string('a', 500);
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
         


        }

        /**
        * Test that Recyable Reason cannot be empty. result is invalid
        * */
        [TestMethod]
        public void TestThatRecyclableReasonIsEmpty()
        {
            testDbItem.recyclableReason = null;
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Disposable must have a recyclable reason", results[0].ErrorMessage);

            //error


        }



        //*********** ENDRESULT ***********
        /**
        * Tests that end result is valid and passes validations. 
        * */
        [TestMethod]
        public void TestThatisEndResultisValid()
        {
            testDbItem.endResult = "toilet paper for babies. this ad was sponsered by huggies";
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
            //Noerror


        }
        /**
        * Tests that the end result cannot be greater than 500 characters. Result is invalid
        * */
        [TestMethod]
        public void TestThatisEndResultIsGreaterThan500Characters()
        {

            testDbItem.endResult = new string('a', 501);
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Result must be 500 characters or less.", results[0].ErrorMessage);

            //error


        }
        /**
         * Tests that the disposable object end result is valid at 500 charactesr.
         * */
        [TestMethod]
        public void TestThatisEndResultIs500Characters()
        {

            testDbItem.endResult = new string('a', 500);
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
          


        }
        /**
         * Tests that the end result cannot be empty. Result is invalid
         * */
        [TestMethod]
        public void TestThatisEndResultIsEmpty()
        {
            testDbItem.endResult = null;
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("An end result is required", results[0].ErrorMessage);


            //error


        }


        //*********** qtyRecycled ***********
      
        /**
         * Tests that the qty Recycled is a valid input ( int). result is valid
         * */
        [TestMethod]
        public void TestThatisqtyRecycledIsValid()
        {

            testDbItem.qtyRecycled = 1234567;
            var results = HelperTestModel.Validate(testDbItem);
            Assert.AreEqual(0, results.Count);
            //Noerror


        }


    }
}

