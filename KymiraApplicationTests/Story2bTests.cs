using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KymiraApplication;

namespace KymiraApplicationTests
{
    /// <summary>
    /// Summary description for TestRecyclables
    /// </summary>
    [TestClass]
    public class TestRecyclablesList
    { //TODO: Make sure the methods used in ListDisposable are called in the tests, finish adding Objects and arrays for them to work
        

        string[] jsonArray; // This is the JSON Array that we receive from the backend

        string jsonObject1; // This is a JSON Object in the JSON Array
        string jsonObject2; // This is a JSON Object in the JSON Array
        string jsonObject3; // This is a JSON Object in the JSON Array
        string jsonObject4; // This is a JSON Object in the JSON Array

        Disposable[] disposables; // This is an array of disposables, that is returned from the parseDisposable() method

        Disposable recItem1; // This is a Disposable Object in the Disposables Array
        Disposable recItem2; // This is a Disposable Object in the Disposables Array
        Disposable recItem3; // This is a Disposable Object in the Disposables Array
        Disposable recItem4; // This is a Disposable Object in the Disposables Array

        [TestInitialize]
        public void TestInitialize()
        {
            // Define the JSON Array
            jsonArray = new string[4]; 

            // Create JSON Objects based off of disposable items, i.e. items that could be pulled from the DB
             jsonObject1 = "{ 'name' : 'Paper', 'description' : 'itemDesc', 'imageURL' : 'paper'," +
            " 'isReyclable' : 'true', 'endResult' : 'Paper is turned into more paper', 'qtyRecycled' : '10', 'recycleReason' : 'Paper can be re-used'}";

             jsonObject2 = "{ 'name' : 'Plastic', 'description' : 'itemDesc', 'imageURL' : 'plastic'," +
                " 'isReyclable' : 'true', 'endResult' : 'plastic is turned into more plastic', 'qtyRecycled' : '10', 'recycleReason' : 'plastic can be re-used'}";

             jsonObject3 = "{ 'name' : 'Food', 'description' : 'itemDesc', 'imageURL' : 'food'," +
                " 'isReyclable' : 'false', 'endResult' : 'food is not recyclable', 'qtyRecycled' : '10', 'recycleReason' : 'food cannot be re-used'}";

             jsonObject4 = "{ 'name' : 'Pizza', 'description' : 'itemDesc', 'imageURL' : 'plastic'," +
                " 'isReyclable' : 'false', 'endResult' : 'pizza is not recyclable', 'qtyRecycled' : '10', 'recycleReason' : 'pizza cannot be re-used'}";

        }

        /**SendRequestToBackendForRecyclablesTest
         * 
         * This test will send a request to the backend
         * for a list of recyclable items.
         * The backend will then query the DB for a list
         * of recyclable materials. These materials will
         * be returned as an array of JSON Objects. 
         * 
         * This test will pass if it receives items in an Array,
         * and if those items are recyclable.
         * 
         * *Note: This Test needs to be done in a way, that will
         *        check if every object is recyclable rather then
         *        if objects are equal to pre-defined ones.
         */
        [TestMethod]
        public void SendRequestToBackendForRecyclablesTest()
        {
            Assert.IsTrue(jsonArray.Length == 0); // Test that nothing is in the array

            jsonArray = requestDisposableList(true); // Call the method to request a list of recyclable items

            Assert.AreEqual(jsonArray[0], jsonObject1); // Test if the Object in the Array, is equal to the premade Object
            Assert.AreEqual(jsonArray[1], jsonObject2); // May need to be changed, Size of the array, and need to ensure every item is recyclable

            Assert.IsTrue(jsonArray.Length == 2); // Ensure the JSON Array has only the necessary objects in it
        }


        /**SendRequestToBackendForNonRecyclablesTest
         * 
         * This test will send a request to the backend
         * for a list of recyclable items.
         * The backend will then query the DB for a list
         * of recyclable materials. These materials will
         * be returned as an array of JSON Objects. 
         * 
         * This test will pass if it receives items in an Array,
         * and if those items are recyclable.
         * 
         * *Note: This Test needs to be done in a way, that will
         *        check if every object is recyclable rather then
         *        if objects are equal to pre-defined ones.
         */
        [TestMethod]
        public void SendRequestToBackendForNonRecyclablesTest()
        {
            Assert.IsTrue(jsonArray.Length == 0); // Test that nothing is in the array

            jsonArray = requestDisposableList(false); // Call the method to request a list of non-recyclable items

            Assert.AreEqual(jsonArray[0], jsonObject3); // Test if the Object in the Array, is equal to the premade Object
            Assert.AreEqual(jsonArray[1], jsonObject4); // May need to be changed, Size of the array, and need to ensure every item is recyclable

            Assert.IsTrue(jsonArray.Length == 2); // Ensure the JSON Array has only the necessary objects in it
        }


        /** ConvertJsonArrayToDisposablesArrayTest
         * 
         * This test will test to see if the array of JSON Objects 
         * acquired from requestDisposables() can be successfully
         * converted into an array of Disposable Objects.
         * 
         * This test will pass if it is able to receive an array
         * of Disposable Objects that has the same data from the JSON
         * Array that was sent in the praseDisposable() Method.
         *
         */
        [TestMethod]
        public void ConvertJsonArrayToDisposablesArrayTest()
        {
            jsonArray = requestDisposables(true); // Call requestDisposables() to acquire the data for the JSON array

            Assert.IsTrue(disposables.Length == 0); // Ensure the disposable array is empty
            Assert.IsTrue(jsonArray.Length != 0); // Ensure JSON Array has data in it

            disposables = parseDisposable(jsonArray); // Call the parseDisposable() Method to generate an Array of Disposable Objects

        }

        /*
         * We require tests that:
         * 
         * -- Check each of the validation rules, and ensure:
         * 1. Objects cannot be created if they're missing a required attribute
         * 2. Missing - but not required - attributes are given the correct placeholder information
         *  These tests will involve using the parseDisposable() method.
         *  The validation itself, i.e. calling the Validate method, will likely happen in parseDisposable()
         *  
         * -- cont.
         */



        #region Old Tests -- TODO
        // List<String> nonRecyclables = new List<string> { "People", "knowledge" };
        //Test that the list is created
        public TestRecyclablesList()
        {
            recyclables = new List<Disposable>();
            recItem = new Disposable { name = "Paper", description = null, imageURL = "image1.png", isRecyclable = true, endResult = "Paper is turned into more paper",
            qtyRecycled = 10, recycleReason = "Paper can be re-used"};
        }

        //Test for empty list
        //Input: an empty list
        //Expectation: an exception that tells the user there was a problem 
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void testEmptyList()
        {
            recyclables = new List<Disposable>();
            if (recyclables.Count == 0)
            {
                throw new Exception("There seems to be a problem with the items at this time");
            }
            Assert.IsTrue(recyclables.Count == 0);
        }

        //Test that a list is not empty
        //Input: a list with a disposable item
        //Expectation: The recycables list has a count greater than 0
        [TestMethod]
        public void testNonEmptyList()
        {
            requestDisposable()
        }

        //Test that an item has no description
        //Input: a recItem with no description.
        //Expectation: recItem's description is empty and should still pass validation
        [TestMethod]
        public void testNoDescription()
        {
            Assert.IsNull(recItem.description);
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count);

        }

        //Test that an item with a description is valid
        //Input: A recycable item with a desription
        //Expectation: The item is valid 
        [TestMethod]
        public void testDescription()
        {         
            recItem.description = "It is Paper";
            Assert.IsTrue(recItem.description == "It is Paper");
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count);
        }

        //Test that an entry with no item will be replaced with a placeholder 
        //Input: an item with no image url
        //Expectation: if the item has no image url, set it to the default
        [TestMethod]
        public void testNoImage()
        {
            recItem.imageURL = "";
            var results = HelperTestModel.Validate(recItem);
            if (results.Count() == 1)
            {
                Assert.AreEqual("The imageURL field is required.", results[0].ErrorMessage);
                results.Clear();
                recItem.imageURL = "/prj2.cosmo/KymiraApplication/Resources/drawable/No_Image.png";
                results = HelperTestModel.Validate(recItem);
                Assert.AreEqual(0, results.Count);
            }
        }

        //Test that an item with an image is valid
        //Input: an item with an image
        //Expectation: The item passes validation 
        [TestMethod]
        public void testImage()
        {
            recItem.imageURL = "image1.png";
            Assert.IsTrue(recItem.imageURL == "image1.png");

            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count());
        }

        //Test if an entry has no name
        //Input: an item with no name
        //Expectation: The item fails validation with the error "no name is present" 
        [TestMethod]
        public void testNoName()
        {
            recItem.name = "";
            Assert.IsTrue(recItem.name == "");
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("No name is present", results[0].ErrorMessage);
        }

        //Test that a recycalbe status exists
        //Input: an item with a status
        //Expectation: item passes validation
        [TestMethod]
        public void testReyclableStatusExists()
        {
            Assert.IsTrue(recItem.isRecyclable == true);
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count());
        }

        //Test that a status does 
        [TestMethod]
        public void testRecyclableStatusDoesNotExist()
        {
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(1, results.Count());
           // Assert.AreEqual("No name is present", results[0].ErrorMessage);
        }

        //Test an item with a name
        //Input: an item with a name of Paper
        //Expectation: The item passes validation 
        [TestMethod]
        public void testName()
        {
            recItem.name = "Paper";
            Assert.IsTrue(recItem.name == "Paper");
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count);
        }

        //Test an item with no record for turned into
        //Expectation: still passes validation 
        [TestMethod]
        public void testNoTurnedInto()
        {
            recItem.endResult = "";
            Assert.IsTrue(recItem.endResult == "");
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count);
        }

        //Test that item has something to turn into
        //Expectation: passes validation 
        [TestMethod]
        public void testTurnedInto()
        {
            recItem.endResult = "Paper is turned into more paper";
            Assert.IsTrue(recItem.endResult == "Paper is turned into more paper");
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count);
        }

        //Test that item doesnt have a quantity
        //Expectation: still passes validation 
        [TestMethod]
        public void testNoitemQuantity()
        {
            recItem.qtyRecycled = 0;
            Assert.IsTrue(recItem.qtyRecycled == 0);
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void testitemQuanity()
        {
            recItem.qtyRecycled = 10;
            Assert.IsTrue(recItem.qtyRecycled == 10);
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void testNoRecyclableReason()
        {
            recItem.recycleReason = "";
            Assert.IsTrue(recItem.recycleReason == "");
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void testRecyclableReason()
        {
            recItem.recycleReason = "Paper can be re-used";
            Assert.IsTrue(recItem.recycleReason == "Paper can be re-used");
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count);
        }
        #endregion Old Tests
    }
}
