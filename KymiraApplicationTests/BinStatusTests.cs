/*
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KymiraApplication.Models.Tests
{
    [TestClass()]
    public class BinStatusTests
    {
        BinStatus testBinStatus;
        BinStatus testBinStatusBad;
        public List<ValidationResult> results;
        public List<ValidationResult> moreResults;
        BinStatus[] binArray = new BinStatus[2];

        [TestInitialize()]
        //this setup method runs for each test and creates a valid BinStatus and an invalid object to be tested against (also an array of both)
        public void setup()
        {
            testBinStatus = new BinStatus();
            testBinStatus.binID = 1;
            testBinStatus.binAddress = "123 Test Street";
            testBinStatus.status = 2;

            testBinStatusBad = new BinStatus();
            testBinStatusBad.binID = -1;
            testBinStatusBad.binAddress = "123 Example Street";
            testBinStatusBad.status = 2;

            binArray[0] = testBinStatus;
            binArray[1] = testBinStatusBad;

        }

        //************* ADDRESS TESTS *************
        [TestMethod]
        //tests that if an address given which is not in the database does not return any bins
        public void TestThatUnknownAddressIsInvalid()
        {
            //backend will return a BinStatus object with a binID of -1 if the address does not have any bins associated with it
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
        public void TestThatBasicAddressIsValid()
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
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        //************* BIN TESTS *************

        [TestMethod]
        //tests that the bin object ID is valid
        public void TestThatBinWithPosIDIsValid()
        {
            //backend will return a BinStatus object with a binID of 1 if the address has a match in the database
            testBinStatus.binID = 1;
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        //tests that a bin object with a negative int is invalid
        public void TestThatBinsWithNegIDAreInvalid()
        {
            testBinStatus.binID = -1;
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Sorry something went wrong, please try again in a few minutes", results[0].ErrorMessage);
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
        //tests that a bin object BinStatus of one of the valid numbers is valid (1, 2, or 3)
        public void TestThatBinsWithProperBinStatusAreValid()
        {
            testBinStatus.status = 2;
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        //Tests that one invalid bin in an array of received bins will display an error message
        public void TestThatInvalidBinInArrayIsInvalid()
        {
            results = HelperTestModel.Validate(binArray[0]);
            moreResults = HelperTestModel.Validate(binArray[1]);

            Assert.AreEqual(0, results.Count());
            Assert.AreEqual(1, moreResults.Count());
            Assert.AreEqual("Sorry something went wrong, please try again in a few minutes", moreResults[0].ErrorMessage);
        }

        [TestMethod]
        //Tests that an array containing all valid bins is valid
        public void TestThatValidBinArrayIsValid()
        {
            testBinStatusBad.binID = 2;

            binArray[0] = testBinStatus;
            binArray[1] = testBinStatusBad;

            results = HelperTestModel.Validate(binArray[0]);
            moreResults = HelperTestModel.Validate(binArray[1]);

            Assert.AreEqual(0, results.Count());
            Assert.AreEqual(0, moreResults.Count());
        }


    }
}*/