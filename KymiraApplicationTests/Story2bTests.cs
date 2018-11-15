using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace KymiraApplicationTests
{
    /// <summary>
    /// Summary description for TestRecyclables
    /// </summary>
    [TestClass]
    public class TestRecyclablesList
    { //TODO: Make usre the methods used in ListDisposable are called in the tests, finish adding Objects and arrays for them to work
        Disposable recItem1;
        Disposable recItem2;
        string[] jsonArray;
        string jsonObject1 = "{ 'name' : 'Paper', 'description' : 'itemDesc', 'imageURL' : 'paper'," +
            " 'isReyclable' : 'true', 'endResult' : 'Paper is turned into more paper', 'qtyRecycled' : '10', 'recycleReason' : 'Paper can be re-used'}";
        string jsonObject2 = "{ 'name' : 'Plastic', 'description' : 'itemDesc', 'imageURL' : 'plastic'," +
            " 'isReyclable' : 'true', 'endResult' : 'plastic is turned into more plastic', 'qtyRecycled' : '10', 'recycleReason' : 'plastic can be re-used'}";

        string jsonObject3 = "{ 'name' : 'Food', 'description' : 'itemDesc', 'imageURL' : 'food'," +
            " 'isReyclable' : 'false', 'endResult' : 'food is not recyclable', 'qtyRecycled' : '10', 'recycleReason' : 'food cannot be re-used'}";
        string jsonObject4 = "{ 'name' : 'Pizza', 'description' : 'itemDesc', 'imageURL' : 'plastic'," +
            " 'isReyclable' : 'true', 'endResult' : 'plastic is turned into more plastic', 'qtyRecycled' : '10', 'recycleReason' : 'plastic can be re-used'}";
        Disposable[] disposables;
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
    }
}
