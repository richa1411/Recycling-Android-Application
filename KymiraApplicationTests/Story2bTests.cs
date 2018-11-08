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
    {
        Disposable recItem;
        List<Disposable> recyclables;
        // List<String> nonRecyclables = new List<string> { "People", "knowledge" };
        //Test that the list is created
        public TestRecyclablesList()
        {
            recyclables = new List<Disposable>();
            recItem = new Disposable { name = "Plastic", description = null, imageURL = "image1.png", isRecyclable = true, endResult = "Paper is turned into more paper",
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
            recyclables = new List<Disposable> { recItem };
            Assert.IsTrue(recyclables.Count > 0);
            Assert.IsTrue(recyclables.Contains(recItem));
        }

        //Test that an item has no description
        //Input: a recItem with no description.
        //Expectation: recItem's description is empty 
        [TestMethod]
        public void testNoDescription()
        {
            Assert.IsNull(recItem.description);
        }

        [TestMethod]
        public void testDescription()
        {         
            recItem.description = "It is Paper";
            Assert.IsTrue(recItem.description == "It is Paper");
        }
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

        [TestMethod]
        public void testImage()
        {
            recItem.imageURL = "image1.png";
            Assert.IsTrue(recItem.imageURL == "image1.png");

            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        public void testNoName()
        {
            recItem.name = "";
            Assert.IsTrue(recItem.name == "");
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("No name is present", results[0].ErrorMessage);
        }

        [TestMethod]
        public void testReyclableStatusExists()
        {
            Assert.IsTrue(recItem.isRecyclable == true);
            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        public void testRecyclableStatusDoesNotExist()
        {
            recItem.name = "";
            Assert.IsTrue(recItem.name == "");

            var results = HelperTestModel.Validate(recItem);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("No name is present", results[0].ErrorMessage);
        }

        [TestMethod]
        public void testName()
        {
            recItem.name = "Paper";
            Assert.IsTrue(recItem.name == "Paper");
        }

        [TestMethod]
        public void testNoTurnedInto()
        {
            recItem.endResult = "";
            Assert.IsTrue(recItem.endResult == "");
        }

        [TestMethod]
        public void testTurnedInto()
        {
            recItem.endResult = "Paper is turned into more paper";
            Assert.IsTrue(recItem.endResult == "Paper is turned into more paper");
        }

        [TestMethod]
        public void testNoitemQuantity()
        {
            recItem.qtyRecycled = 0;
            Assert.IsTrue(recItem.qtyRecycled == 0);
        }

        [TestMethod]
        public void testitemQuanity()
        {
            recItem.qtyRecycled = 10;
            Assert.IsTrue(recItem.qtyRecycled == 10);
        }

        [TestMethod]
        public void testNoRecyclableReason()
        {
            recItem.recycleReason = "";
            Assert.IsTrue(recItem.recycleReason == "");
        }

        [TestMethod]
        public void testRecyclableReason()
        {
            recItem.recycleReason = "Paper can be re-used";
            Assert.IsTrue(recItem.recycleReason == "Paper can be re-used");
        }
    }
}
