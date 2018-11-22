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
         
        string jsonObject1; // This is a JSON Object in the JSON Array that represents a recycable object with valid information
        string jsonObject2; // This is a JSON Object in the JSON Array that represents a recycable object with valid information
        string jsonObject3; // This is a JSON Object in the JSON Array that represents a non-recycable object with valid information
        string jsonObject4; // This is a JSON Object in the JSON Array that represents a non-recycable object with valid information
        string jsonObject5; // This is a JSON Object in the JSON Array that represents a non-recycable with a missing name attribute
        string jsonObject6; // This is a JSON Object in the JSON Array that represents a non-recycable with a missing description attribute
        string jsonObject7; // This is a JSON Object in the JSON Array that represents a recyclable with no ImageURL property

        Disposable[] disposables; // This is an array of disposables, that is returned from the parseDisposable() method

        Disposable recItem1; // This is a Disposable Object in the Disposables Array
        Disposable recItem2; // This is a Disposable Object in the Disposables Array
        Disposable recItem3; // This is a Disposable Object in the Disposables Array
        Disposable recItem4; // This is a Disposable Object in the Disposables Array

        [TestInitialize]
        public void TestInitialize()
        {
            // Define the JSON Array
            jsonArray = new string[6]; 

            // Create JSON Objects based off of disposable items, i.e. items that could be pulled from the DB
             jsonObject1 = "{ 'name' : 'Paper', 'description' : 'itemDesc', 'imageURL' : 'paper'," +
            " 'isReyclable' : 'true', 'endResult' : 'Paper is turned into more paper', 'qtyRecycled' : '10', 'recycleReason' : 'Paper can be re-used'}";

             jsonObject2 = "{ 'name' : 'Plastic', 'description' : 'itemDesc', 'imageURL' : 'plastic'," +
                " 'isReyclable' : 'true', 'endResult' : 'plastic is turned into more plastic', 'qtyRecycled' : '10', 'recycleReason' : 'plastic can be re-used'}";

             jsonObject3 = "{ 'name' : 'Food', 'description' : 'itemDesc', 'imageURL' : 'food'," +
                " 'isReyclable' : 'false', 'endResult' : 'food is not recyclable', 'qtyRecycled' : '10', 'recycleReason' : 'food cannot be re-used'}";

             jsonObject4 = "{ 'name' : 'Pizza', 'description' : 'itemDesc', 'imageURL' : 'Pizza'," +
                " 'isReyclable' : 'false', 'endResult' : 'pizza is not recyclable', 'qtyRecycled' : '0', 'recycleReason' : 'pizza cannot be re-used'}";

            jsonObject5 = "{ 'name' : '', 'description' : 'itemDesc', 'imageURL' : 'plastic'," +
                 " 'isReyclable' : 'false', 'endResult' : 'pizza is not recyclable', 'qtyRecycled' : '10', 'recycleReason' : 'pizza cannot be re-used'}";

            jsonObject6 = "{ 'name' : 'Pop tarts', 'description' : '', 'imageURL' : 'plastic'," +
                " 'isReyclable' : 'false', 'endResult' : 'pizza is not recyclable', 'qtyRecycled' : '10', 'recycleReason' : 'pizza cannot be re-used'}";

            jsonObject7 = "{ 'name' : 'Cardboard', 'description' : 'itemDesc', 'imageURL' : ''," +
                " 'isReyclable' : 'true', 'endResult' : 'cardboard is turned into more cardboard', 'qtyRecycled' : '20', 'recycleReason' : 'cardboard can be re-used'}";


            recItem1 = new Disposable("Food", "itemDesc", "food", false, "food is not recyclable", 10, "food cannot be re-used");
            recItem2 = new Disposable("Pizza", "itemDesc", "Pizza", false, "pizza is not recyclable", 0, "pizza cannot be re-used");
            recItem3 = new Disposable("Pop tarts", "", "plastic", false, "pizza is not recyclable", 10, "pizza cannot be re-used");
            recItem4 = new Disposable("Cardboard", "itemDesc", "No_Image", true, "cardboard is turned into more cardboard", 20, "cardboard can be re-used");

        }

        #region ListDisposable Method Tests


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

            jsonArray = KymiraApplication.Model.ListDisposable.requestDisposableList(true); // Call the method to request a list of recyclable items

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

            jsonArray = KymiraApplication.Model.ListDisposable.requestDisposableList(false); // Call the method to request a list of non-recyclable items

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
            jsonArray = KymiraApplication.Model.ListDisposable.requestDisposableList(true); // Call requestDisposables() to acquire the data for the JSON array

            Assert.IsTrue(disposables.Length == 0); // Ensure the disposable array is empty
            Assert.IsTrue(jsonArray.Length != 0); // Ensure JSON Array has data in it

            disposables = KymiraApplication.Model.ListDisposable.parseDisposable(jsonArray); // Call the parseDisposable() Method to generate an Array of Disposable Objects

        }




        /* missingRequiredAttributesTest
         * 
         * This test will test to see if a passed in array of JSON objects is successfully
         * parsed and turned into an array of Disposable Objects. This test will call
         * parseDisposables() taking in an array with invalid information. One of the objects
         * jsonObject5, is missing a name attribute, which is required.
         * 
         * This test will pass if the newly created disposables array does not have any objects with
         * invalid information in it.
         */
        public void missingRequiredAttributesTest()
        {

            // Add dummy objects to an array - for testing purposes
            jsonArray[0] = jsonObject3;
            jsonArray[1] = jsonObject4;
            jsonArray[2] = jsonObject5;

            // Call parse disposables
            disposables = KymiraApplication.Model.ListDisposable.parseDisposable(jsonArray);

            // Assert that the disposables array only has 2 objects in it
            Assert.AreEqual(2, disposables.Length);

            // Assert that the objects in the disposables array match our test objects 
            Assert.AreEqual(disposables[0], recItem1);
            Assert.AreEqual(disposables[1], recItem2);


        }

        /* missingNonReqiredAttributesTest
         * 
        *  This test will test to see if a passed in array of JSON objects is successfully
        * parsed and turned into an array of Disposable Objects. This test will call
        * parseDisposables() taking in an array with missing information. One of the objects
        * jsonObject6, is missing a description attribute. However, since this attribute is not required
        * it will still be able to add that object to the disposables Array.
        * 
        * This test will pass if the newly created disposables array only has
        * JSON objects in it that either have all the information, or are only missing
        * non-mandatory information; like the description.
        */
        public void missingNonReqiredAttributesTest()
        {

            // Add dummy objects to an array - for testing purposes
            jsonArray[0] = jsonObject3;
            jsonArray[1] = jsonObject4;
            jsonArray[2] = jsonObject6;

            // Call parse disposables
            disposables = KymiraApplication.Model.ListDisposable.parseDisposable(jsonArray);

            // Assert that the disposables array only has 2 objects in it
            Assert.AreEqual(3, disposables.Length);

            // Assert that the objects in the disposables array match our test objects 
            Assert.AreEqual(disposables[0], recItem1);
            Assert.AreEqual(disposables[1], recItem2);
            Assert.AreEqual(disposables[3], recItem3);
        }


        /* missingImageAttributeTest
         * 
        *  This test will test to see if a passed in array of JSON objects is successfully
        * parsed and turned into an array of Disposable Objects. This test will call
        * parseDisposables() taking in an array with missing information. One of the objects
        * jsonObject7, is missing an image attribute. If the image attribute is missing, it will
        * be replaced with a placeholder image. 
        * 
        * This test will pass if the newly created disposables array has valid objects
        * in it, no objects have an empty string or a non-existant image as their ImageUrl property,
        * and any invalid ImageURL properties are set to a placeholder image.
        */
        public void missingImageAttributeTest()
        {

            // Add dummy objects to an array - for testing purposes
            jsonArray[0] = jsonObject1;
            jsonArray[1] = jsonObject2;
            jsonArray[2] = jsonObject7;

            // Call parse disposables
            disposables = KymiraApplication.Model.ListDisposable.parseDisposable(jsonArray);

            // Assert that the disposables array only has 2 objects in it
            Assert.AreEqual(3, disposables.Length);

            // Assert that the objects in the disposables array match our test objects 
            Assert.AreEqual(disposables[0], recItem1);
            Assert.AreEqual(disposables[1], recItem2);
            Assert.AreEqual(disposables[2], recItem3);

        }

        #endregion ListDisposable Method Tests


        #region Validation Tests


        /** TestEmptyList
         * 
         * This test will test to see if an exception occurs if no information can be retrieved
         * for the list of Recyclables.
         * 
         * This test will throw an Exception stating there is a problem retrieving the items.
         *
         */
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void testEmptyList()
        {
            disposables = new Disposable[0];
            if (disposables.Length < 1)
            {
                throw new Exception("There seems to be a problem with the items at this time");
            }
            Assert.IsTrue(disposables.Length < 1);
        }


        /** TestNoDescription
         * 
         * This test will test to make sure no errors are thrown if the description
         * field is left blank.
         * 
         * This test will pass if a blank description is added, and if
         * no errors are thrown when validation is performed on that description.
         *
         */
        [TestMethod]
        public void testNoDescription()
        {
            Assert.IsNull(recItem1.description);
            var results = HelperTestModel.Validate(recItem1);
            Assert.AreEqual(0, results.Count);

        }

        /** TestDescription
         * 
         * This test will test to see that no errors are thrown if the
         * description field exists.
         * 
         * This test will pass if an item has a description and no errors
         * occur. 
         *
         */
        [TestMethod]
        public void testDescription()
        {         
            recItem1.description = "It is Paper";
            Assert.IsTrue(recItem1.description == "It is Paper");
            var results = HelperTestModel.Validate(recItem1);
            Assert.AreEqual(0, results.Count);
        }

        /** TestNoImage
         * 
         * This test will test to make sure an error is thrown if an object
         * has no image. This test will make use of addPlaceholders() to
         * add in our placeholder image to the necessary objects.
         * 
         * This test will pass if a Disposable Object without an image
         * is given an image after calling addPlaceholders()
         *
         */
        [TestMethod]
        public void testNoImage()
        {
            disposables[0].imageURL = "";
            var results = HelperTestModel.Validate(disposables[0]);
            Assert.AreEqual(1, results.Count());

            KymiraApplication.Model.ListDisposable.addPlaceholders(disposables);

            Assert.AreEqual(disposables[0].imageURL, "No_Image.png");
        }

        /** TestImage
         * 
         * This test will test to see if no errors are thrown
         * when a disposable object has a valid image.
         * 
         * This test will pass if no errors occur when a disposable object
         * has a valid image.
         *
         */
        [TestMethod]
        public void testImage()
        {
            disposables[0].imageURL = "Paper.png";
            Assert.IsTrue(disposables[0].imageURL == "Paper.png");

            var results = HelperTestModel.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count());

            KymiraApplication.Model.ListDisposable.addPlaceholders(disposables);

            Assert.AreEqual(disposables[0].imageURL, "Paper.png");
        }

        /** TestNoName()
         * 
         * This test will test to see if an error is thrown properly when
         * a disposable object has no name.
         * 
         * This test will pass if it is able to throw an error when
         * an object with no name is found.
         *
         */
        [TestMethod]
        public void testNoName()
        {
            recItem1.name = "";
            Assert.IsTrue(recItem1.name == "");
            var results = HelperTestModel.Validate(recItem1);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("No name is present", results[0].ErrorMessage);
        }

        /** TestReyclableStatusExists()
         * 
         * This test will test to see if no errors are thrown
         * when an item has a valid isRecyclable status
         * 
         * This test will pass if no errors occur when an object with an isRecyclable 
         * status is found.
         *
         */
        [TestMethod]
        public void testReyclableStatusExists()
        {
            Assert.IsTrue(recItem1.isRecyclable == true);
            var results = HelperTestModel.Validate(recItem1);
            Assert.AreEqual(0, results.Count());
        }


        /** TestName()
         * 
         * This test will test to see if no errors are thrown
         * when an item has a valid name
         * 
         * This test will pass if no errors occur when an object with a name is found. 
         *
         */
        [TestMethod]
        public void testName()
        {
            recItem1.name = "Paper";
            Assert.IsTrue(recItem1.name == "Paper");
            var results = HelperTestModel.Validate(recItem1);
            Assert.AreEqual(0, results.Count);
        }

        /** TestNoTurnedInto()
         * 
         * This test will test to see if no errors are thrown
         * when an item has a no endResult field
         * 
         * This test will pass if no errors occur when an object with no endResult is found. 
         *
         */
        [TestMethod]
        public void testNoTurnedInto()
        {
            recItem1.endResult = "";
            Assert.IsTrue(recItem1.endResult == "");
            var results = HelperTestModel.Validate(recItem1);
            Assert.AreEqual(0, results.Count);
        }

        /** TestTurnedInto
         * 
         * This test will test to see if no errors are thrown
         * when an item has a valid endResult field
         * 
         * This test will pass if no errors occur when an object with an endResult is found. 
         *
         */
        [TestMethod]
        public void testTurnedInto()
        {
            recItem1.endResult = "Paper is turned into more paper";
            Assert.IsTrue(recItem1.endResult == "Paper is turned into more paper");
            var results = HelperTestModel.Validate(recItem1);
            Assert.AreEqual(0, results.Count);
        }

        /** TestNoItemQuantity
         * 
         * This test will test to see if no errors are thrown
         * when an item has no qtyRecycled field.
         * 
         * This test will pass if no errors occur when an object with an empty qtyRecycled is found
         *
         */
        [TestMethod]
        public void testNoitemQuantity()
        {
            recItem1.qtyRecycled = 0;
            Assert.IsTrue(recItem1.qtyRecycled == 0);
            var results = HelperTestModel.Validate(recItem1);
            Assert.AreEqual(0, results.Count);
        }

        /** TestItemQuantity
         * 
         * This test will test to see if no errors are thrown
         * when an item has a valid qtyRecycled
         * 
         * This test will pass if no errors occur when an object with a valid qtyRecycled is found. 
         *
         */
        [TestMethod]
        public void testitemQuanity()
        {
            recItem1.qtyRecycled = 10;
            Assert.IsTrue(recItem1.qtyRecycled == 10);
            var results = HelperTestModel.Validate(recItem1);
            Assert.AreEqual(0, results.Count);
        }

        /** TestNoRecyclableReason
         * 
         * This test will test to see if no errors are thrown
         * when an item has an empty recycleReason
         * 
         * This test will pass if no errors occur when an object with an empty recycleReason is found. 
         *
         */
        [TestMethod]
        public void testNoRecyclableReason()
        {
            recItem1.recycleReason = "";
            Assert.IsTrue(recItem1.recycleReason == "");
            var results = HelperTestModel.Validate(recItem1);
            Assert.AreEqual(0, results.Count);
        }

        /** TestRecyclable
         * 
         * This test will test to see if no errors are thrown
         * when an item has a valid RecycleReason
         * 
         * This test will pass if no errors occur when an object with a valid RecycleReason is found. 
         *
         */
        [TestMethod]
        public void testRecyclableReason()
        {
            recItem1.recycleReason = "Paper can be re-used";
            Assert.IsTrue(recItem1.recycleReason == "Paper can be re-used");
            var results = HelperTestModel.Validate(recItem1);
            Assert.AreEqual(0, results.Count);
        }
        #endregion Validation Tests
    }
}
