using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using KymiraApplication.Models;


namespace KymiraApplicationTests
{
    /**
     *  This test class is used for testing valid BinStatus objects 
     *  (BinStatus objects that are received from the backend upon a match with the address)
     */
    [TestClass()]
    public class BinStatusTests
    {
        BinStatus testBinStatus;    //a valid BinStatus object
        BinStatus testBinStatusBad; //an invalid BinStatus object
        public List<ValidationResult> results; //to hold a list of validation results
        public List<ValidationResult> moreResults; //to hold a second list of validation results
        BinStatus[] binArray = new BinStatus[2]; //array of one valid and one invalid BinStatus object


        Site testSite;

        [TestInitialize()]
        //this setup method runs for each test and creates a valid BinStatus and an invalid object to be tested against (also an array of both)
        public void setup()
        {
            //a valid BinStatus
            testBinStatus = new BinStatus();
            testBinStatus.binID = 1;
            testBinStatus.collectionDate = "2019-01-01";
            testBinStatus.siteID = 30;
            testBinStatus.status = 2;

            //a valid Site
            testSite = new Site {
                siteID = 20,
                address = "123 Test Street"
            };

            //an invalid BinStatus
            testBinStatusBad = new BinStatus();
            testBinStatusBad.binID = -1;
            testBinStatus.collectionDate = "2019-01-01";
            testBinStatus.siteID = 30;
            testBinStatusBad.status = 2;

            binArray[0] = testBinStatus;
            binArray[1] = testBinStatusBad;

        }

        //************* ADDRESS TESTS *************
        [TestMethod]
        //tests that an address of 201 characters is invalid
        public void TestThat201CharAddressIsInvalid()
        {
            testSite.address = new String('a', 201);
            results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //tests that the Site object's address is valid
        public void TestThatBasicAddressIsValid()
        {
            results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        //tests that an address can be 200 chars long
        public void TestThatAddressMaximumSizeIsValid()
        {
            testSite.address = new String('a', 200);
            results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        //tests that an address cannot be an empty string
        public void TestThatBinsWithEmptyAddressNameAreInvalid()
        {
            testSite.address = "";
            results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        //************* BIN TESTS *************

        [TestMethod]
        //tests that the bin object ID is valid
        public void TestThatBinWithPosIDIsValid()
        {
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
            Assert.AreEqual("BinID must be a valid number", results[0].ErrorMessage);
        }

        [TestMethod]
        //tests that a BinStatus status cannot be greater than 3 - acceptable statuses are 1, 2, and 3
        public void TestThatBinStatusOfGreaterThan3IsInvalid()
        {
            testBinStatus.status = 4;
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A status can only be the value of 1, 2, or 3", results[0].ErrorMessage);

        }

        [TestMethod]
        //tests that a BinStatus status cannot be less than 1 - acceptable statuses are 1, 2, and 3
        public void TestThatBinStatusOfLessThan1IsInvalid()
        {
            testBinStatus.status = 0;
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A status can only be the value of 1, 2, or 3", results[0].ErrorMessage);

        }

        [TestMethod]
        //tests that a bin object BinStatus of one of the valid numbers is valid (1, 2, or 3)
        public void TestThatBinsWithProperBinStatusAreValid()
        {
            testBinStatus.status = 2;
            results = HelperTestModel.Validate(testBinStatus);
            Assert.AreEqual(0, results.Count());
        }


    }
}