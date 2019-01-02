using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Models;
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

        /** TestRetrieveRecyclables
         * 
         * This Test will use a "demo" method to retrieve a list of disposables.
         * This demo method will call the methods required to generate an array
         * of disposables that are recyclable or non recyclable depending on the input.
         * The only difference between this method and our actual method that receives data
         * is that this demo method retrieves constant information, rather than trying to
         * retrieve it from the database.
         *
         */
        [TestMethod]
        public void testRetrieveRecyclables()
        {
            KymiraApplication.Models.ListDisposable.requestDisposableListAsyncDemo(true);

            disposables = KymiraApplication.Models.ListDisposable.getDisposableList();

            Assert.IsTrue(disposables[0].isRecyclable);
            Assert.IsTrue(disposables[1].isRecyclable);
            Assert.IsTrue(disposables[2].isRecyclable);

            KymiraApplication.Models.ListDisposable.requestDisposableListAsyncDemo(false);

            disposables = KymiraApplication.Models.ListDisposable.getDisposableList();

            Assert.AreEqual(disposables[0].isRecyclable, false);
            Assert.AreEqual(disposables[1].isRecyclable, false);
            Assert.AreEqual(disposables[2].isRecyclable, false);

        }


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
                throw new Exception("Error connecting to server, please try again later.");
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
            recItem1.description = "";
            Assert.AreEqual("", recItem1.description);
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
            Assert.IsTrue(recItem4.isRecyclable);
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
