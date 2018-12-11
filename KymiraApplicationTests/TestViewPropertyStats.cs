using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Model;
using KymiraApplication;
using System.Linq;

namespace KymiraApplicationTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestViewPropertyStats
    {
        PropertyStats propertyStats;
        //Set up some initial data for our BinCollectionDate object
        [TestInitialize]
        public void InitializeTest()
        {
            propertyStats = new PropertyStats { Address = "123 Test Dr",}; //Address is just a string right now
        }

        //Test if the address field is Empty, will result in an error if it is empty
        [TestMethod]
        public void testAddressEmpty()
        {
            propertyStats.Address = "";
            var results = HelperTestModel.Validate(propertyStats);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Address cannot be an empty field", results[0].ErrorMessage);
        }

        //Test if the address field is a valid format as specified by our Regular Expression
        [TestMethod]
        public void testValidAddress()
        {
            propertyStats.Address = "123 Test Dr";
            var results = HelperTestModel.Validate(propertyStats);
            Assert.AreEqual(0, results.Count());
        }

        //Test if the Address is invalid (from the backend)
        [TestMethod]
        public void testInValidAddressFormat()
        {
            propertyStats.Address = "fff Test34";
            var results = HelperTestModel.Validate(propertyStats);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Invalid Address", results[0].ErrorMessage);
        }

        //Test if the Address is invalid (from the backend)
        [TestMethod]
        public void testInValidAddress()
        {
            propertyStats.Address = "AddressNotInDatabase";
            var results = HelperTestModel.Validate(propertyStats);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Invalid Address", results[0].ErrorMessage);
        }

        //Will test if the points are integers
        [TestMethod]
        public void testValidPoints()
        {
            propertyStats.PropertyPoints = 123456;
            var results = HelperTestModel.Validate(propertyStats);
            Assert.AreEqual(0, results.Count());

        }

        

    }
}
