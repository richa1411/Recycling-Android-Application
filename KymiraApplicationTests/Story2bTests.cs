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
        List<String> recyclables;
        // List<String> nonRecyclables = new List<string> { "People", "knowledge" };
        //Test that the list is created
        public TestRecyclablesList()
        {
            recyclables = new List<string>();
            recItem = new Disposable { name = "Plastic", description = "Its Plastic", imageURL = "image1.png", isRecyclable = true, endResult = "Paper is turned into more paper",
            qtyRecycled = 10, recycleReason = "Paper can be re-used"};
            }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void testEmptyList()
        {
            recyclables = new List<string>();
            if (recyclables.Count == 0)
            {
                throw new Exception("There seems to be a problem with the items at this time");
            }
            Assert.IsTrue(recyclables.Count == 0);
        }
        [TestMethod]
        public void testNonEmptyList()
        {
            recyclables = new List<string> { "Plastic", "Paper" };

            Assert.IsTrue(recyclables.Count != 0);
            Assert.IsTrue(recyclables.Contains("Plastic"));
        }
        [TestMethod]
        public void testNoDescription()
        {
            recItem.description = "";
            Assert.IsTrue(recItem.description == "");   
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
                Assert.AreEqual("No image", results[0].ErrorMessage);

                results.Clear();
                recItem.imageURL = "placeholder";
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
            Assert.AreEqual("No item name is present", results[0].ErrorMessage);


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
            Assert.AreEqual("No item name is present", results[0].ErrorMessage);


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
