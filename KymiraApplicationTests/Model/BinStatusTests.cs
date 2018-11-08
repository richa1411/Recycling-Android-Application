using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Model;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace KymiraApplicationTests
{
    [TestClass]
    public class BinStatusTests
    {

        BinStatus testBinStatus;
        public List<ValidationResult> results;

        [TestInitialize()]
        public void setup()
        {
            testBinStatus = new BinStatus();
            testBinStatus.binID = 1;
            testBinStatus.binAddress = "123 Test Street";
            testBinStatus.status = 2;
        }

        //************* ADDRESS TESTS *************
        [TestMethod]
        //tests that if an address given which is not in the database throws an error and does not return any bins
        public void TestThatUnknownAddressIsInvalid()
        {
            testBinStatus.binID = -1;
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Sorry something went wrong, please try again in a few minutes", results[0].ErrorMessage);
        }

        [TestMethod]
        //tests that an address given which is over 200 characters throws an error
        public void TestThat201CharAddressIsInvalid()
        {
            testBinStatus.binAddress = new String('a', 201);
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //tests that an address given which is in the database returns bins
        public void TestThatKnownAddressIsValid()
        {
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(0, results.Count());

        }

        [TestMethod]
        //tests that a bin object addressName can be 200 chars long
        public void TestThatAddressMaximumSizeIsValid()
        {
            testBinStatus.binAddress = new String('a', 200);
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        //tests that a bin object addressName cannot be empty
        public void TestThatBinsWithEmptyAddressNameAreInvalid()
        {
            testBinStatus.binAddress = "";
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Address is required", results[0].ErrorMessage);
        }

        //************* BIN TESTS *************
        //ID

        [TestMethod]
        //tests that a bin object can only have an int as an id
        public void TestThatBinsWithNonIntIDsAreInvalid()
        {
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Sorry something went wrong, please try again in a few minutes");

        }

        [TestMethod]
        //tests that a bin object can only have an int as an id and must have one
        public void TestThatBinsWithNoIDsAreInvalid()
        {
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Sorry something went wrong, please try again in a few minutes", results[0].ErrorMessage);

        }

        [TestMethod]
        //tests that a bin object can only have an int as an id
        public void TestThatBinsWithIntIDsAreValid()
        {          
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        //tests that a bin object BinStatus cannot be empty
        public void TestThatBinsWithEmptyBinStatusAreInvalid()
        {
            testBinStatus.status = 0;
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Sorry something went wrong, please try again in a few minutes", results[0].ErrorMessage);

        }

        [TestMethod]
        //tests that a bin object BinStatus of one of the valid numbers is valid
        public void TestThatBinsWithProperBinStatusAreValid()
        {
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(0, results.Count());
        }
    }
}
