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
            recItem = new RecyclablesList { name = "Plastic", description = "Its Plastic" };
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


    }
}
