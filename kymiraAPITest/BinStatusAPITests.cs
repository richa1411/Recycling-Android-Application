using kymiraAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace kymiraAPITest
{
    //This test class will validate the properties of a BinStatus and Site object.

    [TestClass]
    public class BinStatusAPITests
    {
        //valid BinStatus object to be used to validate
        BinStatus testBin = new BinStatus {
            binID = "1",
            status = 1,
            collectionDate = "2019-01-01",
            siteID = 101010
        };

        //valid Site object to be used to validate
        Site testSite = new Site {
            siteID = 10,
            address = "123 Test Street",
        };

        //list to hold ValidationResults
        public IList<ValidationResult> results;

        /*--------------------------------BinStatus validation tests--------------------------------*/

        [TestMethod]
        //testing that the status of a BinStatus object cannot be less than 1
        public void TestThatBinStatusLessThan1IsInvalid()
        {
            testBin.status = 0;
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("A status can only be the value of 1, 2, or 3", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the status of a BinStatus object cannot be greater than 3
        public void TestThatBinStatusGreaterThan3IsInvalid()
        {
            testBin.status = 4;
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("A status can only be the value of 1, 2, or 3", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the valid BinStatus object is indeed valid
        public void TestThatValidBinStatusIsValid()
        {
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the status of a BinStatus object can be between 1 and 3
        public void TestThatBinStatusOfValidNumberIsValid()
        {
            testBin.status = 2;
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the collectionDate of a BinStatus object must follow a valid format
        public void TestThatBinStatusDateBadFormatIsInvalid()
        {
            testBin.collectionDate = "20191-101-01";
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Collection date must be a valid date", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that a valid collectionDate of a BinStatus object is valid
        public void TestThatBinStatusDateGoodFormatIsValid()
        {
            testBin.collectionDate = "2019-01-01";
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the collectionDate of a BinStatus object cannot be an empty string
        public void TestThatBinStatusDateEmptyStringIsInvalid()
        {
            testBin.collectionDate = "";
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Collection date is required", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the valid binID of a BinStatus object is valid
        public void TestThatBinStatusBinIDIsValid()
        {
            testBin.binID = "W114-320-257";
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the binID of a BinStatus object cannot be an empty string
        public void TestThatBinStatusBinIDEmptyStringIsInvalid()
        {
            testBin.binID = "";
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("BinID must be between 1 and 20 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the binID of a BinStatus object cannot be in an invalid format
        public void TestThatBinStatusBinIDInvalidFormatIsInvalid()
        {
            testBin.binID = "A3/D";
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("BinID is not valid", results[0].ErrorMessage);
        }


        /*--------------------------------Site validation tests--------------------------------*/
        [TestMethod]
        //testing that the siteID of a Site object cannot be less than 1
        public void TestThatSiteIDLessThanOneIsInvalid()
        {
            testSite.siteID = 0;
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The siteID must be a valid integer", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the valid Site object is indeed valid
        public void TestThatValidSiteIsValid()
        {
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the address of a Site object cannot be an empty string
        public void TestThatSiteAddressOfEmptyStringIsInvalid()
        {
            testSite.address = "";
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the address of a Site object can be 1 character
        public void TestThatSiteAddressOfOneCharacterIsValid()
        {
            testSite.address = "a";
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the address of a Site object can be 200 characters
        public void TestThatSiteAddressOf200CharactersIsValid()
        {
            testSite.address = new string('a',200);
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }


        [TestMethod]
        //testing that the address of a Site object cannot be 201 characters
        public void TestThatSiteAddressOfLargeStringIsInvalid()
        {
            testSite.address = new string('a',201);
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

    }
}
