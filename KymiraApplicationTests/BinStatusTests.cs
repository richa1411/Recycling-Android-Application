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
     *  This test class is used for testing valid BinStatus objects that are received from the backend and
     *  for testing Site objects (used for validating the address a user types in)
     */
    [TestClass()]
    public class BinStatusTests
    {
        //a valid BinStatus object
        BinStatus testBinStatus = new BinStatus
        {
            binID = "1",
            collectionDate = "2019-01-01",
            siteID = 30,
            status = BinStatus.CollectionStatus.Inaccessible
        };

        List<ValidationResult> results; //to hold a list of validation results

        //a valid site
        Site testSite = new Site
        {
            siteID = 20,
            address = "123 Test Street",
            sitePickupDays = Site.PickupDays.Monday,
            frequency = Site.PickupFrequency.Weekly
        };


        //************* ADDRESS TESTS *************
        [TestMethod]
        //tests that an address of 201 characters is invalid
        public void TestThat201CharAddressIsInvalid()
        {
            testSite.address = new String('a', 201);
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //tests that the Site object's address is valid
        public void TestThatBasicAddressIsValid()
        {
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        //tests that an address can be 200 chars long
        public void TestThatAddressMaximumSizeIsValid()
        {
            testSite.address = new String('a', 200);
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        //tests that an address cannot be an empty string
        public void TestThatBinsWithEmptyAddressNameAreInvalid()
        {
            testSite.address = "";
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        //************* BIN TESTS *************

        [TestMethod]
        //testing that the valid binID of a BinStatus object is valid
        public void TestThatBinStatusBinIDIsValid()
        {
            testBinStatus.binID = "W114-320-257";
            results = TestValidationHelper.Validate(testBinStatus);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the binID of a BinStatus object cannot be an empty string
        public void TestThatBinStatusBinIDEmptyStringIsInvalid()
        {
            testBinStatus.binID = "";
            results = TestValidationHelper.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("BinID must be between 1 and 20 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the binID of a BinStatus object cannot be in an invalid format
        public void TestThatBinStatusBinIDInvalidFormatIsInvalid()
        {
            testBinStatus.binID = "A3/D";
            results = TestValidationHelper.Validate(testBinStatus);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("BinID is not valid", results[0].ErrorMessage);
        }



        

        //[TestMethod]
        ////tests that a BinStatus status cannot be greater than 3 - acceptable statuses are 1, 2, and 3
        //public void TestThatBinStatusOfGreaterThan3IsInvalid()
        //{
        //    testBinStatus.status = 4;
        //    results = TestValidationHelper.Validate(testBinStatus);
        //    Assert.AreEqual(1, results.Count());
        //    Assert.AreEqual("A status can only be the value of 1, 2, or 3", results[0].ErrorMessage);

        //}

        //[TestMethod]
        ////tests that a BinStatus status cannot be less than 1 - acceptable statuses are 1, 2, and 3
        //public void TestThatBinStatusOfLessThan1IsInvalid()
        //{
        //    testBinStatus.status = 0;
        //    results = TestValidationHelper.Validate(testBinStatus);
        //    Assert.AreEqual(1, results.Count());
        //    Assert.AreEqual("A status can only be the value of 1, 2, or 3", results[0].ErrorMessage);

        //}

        [TestMethod]
        //tests that a bin object BinStatus of one of the valid numbers is valid (1, 2, or 3)
        public void TestThatBinsWithProperBinStatusAreValid()
        {
            testBinStatus.status = BinStatus.CollectionStatus.Inaccessible;
            results = TestValidationHelper.Validate(testBinStatus);
            Assert.AreEqual(0, results.Count());
        }


    }
}