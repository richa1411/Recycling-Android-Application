using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using KymiraApplication;

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
        //tests that if an address given which is not in the database does not return any bins
        public void TestThatUnknownAddressIsInvalid()
        {
            testBinStatus.binID = -1;
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Sorry something went wrong, please try again in a few minutes", results[0].ErrorMessage);
        }

        [TestMethod]
        //tests that an address of 201 characters is invalid
        public void TestThat201CharAddressIsInvalid()
        {
            testBinStatus.binAddress = new String('a', 201);
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //tests that the BinStatus object's address is valid
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
        //tests that a bin object addressName cannot be an empty string
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
            Assert.AreEqual("Sorry something went wrong, please try again in a few minutes",results[0].ErrorMessage);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        //tests that a bin object with a null binID will throw an exception (invalid)
        public void TestThatBinsWithNoIDsAreInvalid()
        {
            testBinStatus.binID = null;
            Assert.IsNotNull(testBinStatus.binID);
        }

        [TestMethod]
        //tests that a bin object can only have an int as an id
        public void TestThatBinsWithIntIDsAreValid()
        {
            //results = HelperTestModel.Validate(testBinStatus);
            //Assert.AreEqual(0, results.Count());
            int value;
            int.TryParse(testBinStatus.binID,out value);
            Assert.AreEqual(value, testBinStatus.binID);
        }

        [TestMethod]
        //tests that a BinStatus status cannot be greater than 3 - acceptable statuses are 1, 2, and 3
        public void TestThatBinStatusOfGreaterThan3IsInvalid()
        {
            testBinStatus.status = 4;
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Sorry something went wrong, please try again in a few minutes", results[0].ErrorMessage);

        }

        [TestMethod]
        //tests that a BinStatus status cannot be less than 1 - acceptable statuses are 1, 2, and 3
        public void TestThatBinStatusOfLessThan1IsInvalid()
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
