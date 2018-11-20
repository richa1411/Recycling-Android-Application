using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Model;
using KymiraApplication;
using System.Linq;

namespace KymiraApplicationTests
{
    [TestClass]
    public class TestBinCollectionDate
    {
        BinCollectionDate binColl;

        [TestInitialize]
        public void InitializeTest()
        {
            binColl = new BinCollectionDate { Address = "123 Test Dr", collectionDate = "11/30/2018" }; //date is just a string right now.
        }

        [TestMethod]
        public void testAddressEmpty()
        {
            binColl.Address = "";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Address cannot be an empty field", results[0].ErrorMessage);
        }

        [TestMethod]
        public void testDateEmpty()
        {
            binColl.collectionDate = "";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Date is Required", results[0].ErrorMessage);

        }
        [TestMethod]
        public void testValidAddress()
        {
            binColl.Address = "123 Test Dr";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        public void testValidDate()
        {
            binColl.collectionDate = "11/30/2018";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(0, results.Count());
          
        }

        [TestMethod]
        public void testInValidDate()
        {
            binColl.collectionDate = "This is not a valid date";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Invalid Date format", results[0].ErrorMessage);

        }

        [TestMethod]
        public void testInValidAddress()
        {
            binColl.Address = "this is not a valid address";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Invalid Address", results[0].ErrorMessage);
        }

    }
}
