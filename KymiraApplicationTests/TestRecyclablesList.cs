using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Model;

namespace KymiraApplicationTests
{
    /// <summary>
    /// Summary description for TestRecyclables
    /// </summary>
    [TestClass]
    public class TestRecyclablesList
    {
        RecyclablesList recItem;
        List<String> recyclables;
        // List<String> nonRecyclables = new List<string> { "People", "knowledge" };
        //Test that the list is created
        public TestRecyclablesList()
        {
            recyclables = new List<string>();
            recItem = new RecyclablesList { name = "Plastic", description = "Its Plastic", imageURL = "image1.png", turnedInto = "Paper is turned into more paper",
            itemQuantity = "10", recycleReason = "Paper can be re-used"};
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
            Assert.IsTrue(recItem.imageURL == "");
        }

        [TestMethod]
        public void testImage()
        {

            recItem.imageURL = "image1.png";
            Assert.IsTrue(recItem.imageURL == "image1.png");
        }

        

        [TestMethod]
        public void testNoName()
        {


            recItem.name = "";
            Assert.IsTrue(recItem.name == "");


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


            recItem.turnedInto = "";
            Assert.IsTrue(recItem.turnedInto == "");


        }

        [TestMethod]
        public void testTurnedInto()
        {

            recItem.turnedInto = "Paper is turned into more paper";
            Assert.IsTrue(recItem.turnedInto == "Paper is turned into more paper");
        }


        [TestMethod]
        public void testNoitemQuantity()
        {


            recItem.itemQuantity = "";
            Assert.IsTrue(recItem.itemQuantity == "");


        }

        [TestMethod]
        public void testitemQuanity()
        {

            recItem.itemQuantity = "10 pieces of paper have been recycled";
            Assert.IsTrue(recItem.itemQuantity == "10 pieces of paper have been recycled");
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
