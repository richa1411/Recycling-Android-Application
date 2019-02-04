using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraAdmin.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using KymiraAdmin;

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

        /*------------------------Testing BinStatus validation-----------------------------------*/
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


        /*-----------------------Testing ExcelParser methods---------------------------*/
        //test row with valid information
        List<string> testRow = new List<string> { "" };

        //test row with invalid information
        List<string> testRowInvalid = new List<string> { "" };

        
        [TestMethod]
        //testing that the date format "1-Jan-18" is parsed correctly
        public void TestThatValidParseDateReturnsValidDateOneFormat()
        {
            string date = BinStatusParser.ParseDate(testRow);
            Assert.AreEqual("2018-01-01", date);
        }

        [TestMethod]
        //testing that the date format "1/1/2018" is parsed correctly
        public void TestThatValidParseDateReturnsValidDateOtherFormat()
        {
            //change testRow date to be other format
            string date = BinStatusParser.ParseDate(testRow);
            Assert.AreEqual("2018-01-01", date);
        }

        [TestMethod]
        //testing that the siteID is parsed correctly
        public void TestThatValidSiteIDReturnsValidString()
        {
            string siteID = BinStatusParser.ParseSiteID(testRow);
            Assert.AreEqual("1609312", siteID);
        }

        [TestMethod]
        //testing that the expected bin status is parsed correctly
        public void TestThatExpectedStatusReturnsValidInt()
        {
            int status = BinStatusParser.ParseStatus(testRow);
            Assert.AreEqual(1, status);
        }

        [TestMethod]
        //testing that the unexpected bin status is parsed correctly
        public void TestThatUnexpectedStatusReturnsValidInt()
        {
            int status = BinStatusParser.ParseStatus(testRow);
            Assert.AreEqual(2, status);
        }

        [TestMethod]
        //testing that the serial number is parsed correctly
        public void TestThatValidSerialNumReturnsValidString()
        {
            string status = BinStatusParser.ParseSerialNum(testRow);
            Assert.AreEqual(2, status);
        }


    }
}
