using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraAdmin.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KymiraAdminTests
{
    /**
     * This test class will test validation of a BinStatus object. 
     */
    [TestClass]
    public class BinStatusAdminTests
    {
        
        //valid BinStatus object to be used to validate
        BinStatus testBin = new BinStatus
        {
            binID = "1",
            status = 1,
            collectionDate = "2019-01-01",
            siteID = 101010
        };
        List<ValidationResult> results; //to hold a list of validation results
        StatusList objStatus = new StatusList
        {

        };
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
        public void TestThatdBinStatusIsValidWithMinimumEntry()
        {
            testBin.status = 1;
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the status of a BinStatus object can be between 1 and 3
        public void TestThatBinStatusIsValidWithMaximumEntry()
        {
            testBin.status = 3;
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

        [TestMethod]
        //testing that the binID of a BinStatus object cannot be in an invalid format
        public void TestThatBinStatusSiteIDLessThanOneIsInvalid()
        {
            testBin.siteID = 0;
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The siteID must be a valid integer", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the siteID of a valid BinStatus object is indeed valid
        public void TestThatBinStatusSiteIDIsValid()
        {
            testBin.siteID = 1345;
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(0, results.Count);
           
        }

        [TestMethod]
        //testing that the siteID of a valid BinStatus object is indeed valid
        public void TestThatListIsValid()
        {
            testBin.siteID = 1345;
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(0, results.Count);

        }

    }
    
}
