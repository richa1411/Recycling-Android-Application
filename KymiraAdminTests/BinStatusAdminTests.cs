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

        [DataTestMethod]
        [DataRow("COSMO-123")]
        [DataRow("1234567")]
        [DataRow("W114-320-257")]
        [DataRow("DFGHRT")]
        
        //testing that the valid binID of a BinStatus object is valid
        public void TestThatBinStatusBinIDIsValid(string binId)
        {
            testBin.binID = binId;
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

        [DataTestMethod]
        [DataRow("------")]
        [DataRow("A3/D")]
        [DataRow("////")]
        //testing that the binID of a BinStatus object cannot be in an invalid format
        public void TestThatBinStatusBinIDInvalidFormatIsInvalid(string binID)
        {
            testBin.binID = binID;
            results = TestValidationHelper.Validate(testBin);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("BinID is not valid", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the siteID of a BinStatus object cannot be in an invalid format
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

      


        /*-----------------------Testing ExcelParser methods---------------------------*/
        
        [DataTestMethod]
        [DataRow("2-Jul-18")]
        [DataRow("2-Jul-2018")]
        [DataRow("7/2/2018")]
        [DataRow("2018-07-02")]
        //testing that the above date formats are parsed correctly
        public void TestThatParseDateReturnsValidDateFormat(string dateString)
        {
            Assert.AreEqual("2018-07-02", BinStatusParser.ParseDate(dateString));
        }

        [TestMethod]
        //testing that the siteID is parsed correctly
        public void TestThatValidSiteIDReturnsValidInt()
        {
            Assert.AreEqual(1609312, BinStatusParser.ParseSiteID("1609312"));
        }

        [DataTestMethod]
        [DataRow("Collected")]
        //testing that the expected bin status is parsed correctly
        public void TestThatExpectedStatusReturnsValidInt(string status)
        {
            Assert.AreEqual(1, BinStatusParser.ParseStatus(status));
        }
        
        [DataTestMethod]
        [DataRow("Blocked")]
        [DataRow("Empty")]
        [DataRow("Not Out")]
        //testing that the unexpected bin status is parsed correctly
        public void TestThatUnexpectedStatusReturnsValidInt(string status)
        {
            Assert.AreEqual(2, BinStatusParser.ParseStatus(status));
        }

        [DataTestMethod]
        [DataRow("W114-320-203")]
       
        //testing that the serial number is parsed correctly
        public void TestThatValidSerialNumReturnsValidString(string serialnum)
        {
            Assert.AreEqual("W114-320-203", BinStatusParser.ParseSerialNum(serialnum));
        }
        

        [TestMethod]
        //testing that the invalid date (empty, other charcters except -, /) is parsed correctly
        public void TestThatInValidParseDateReturnsEmptystring()
        {
            Assert.AreEqual("", BinStatusParser.ParseDate(""));
        }

        [TestMethod]
        //testing that the invalid siteID is parsed correctly
        public void TestThatValidSiteIDReturnsZero()
        {
            Assert.AreEqual(0, BinStatusParser.ParseSiteID(""));
        }

     

        [TestMethod]
        //testing that theinvalid  bin status is parsed correctly
        public void TestThatInvalidStatusReturnsZero()
        {
            Assert.AreEqual(0, BinStatusParser.ParseStatus(""));
        }

        [TestMethod]
        //testing that the invalid serial number is parsed correctly
        public void TestThatInValidSerialNumReturnsEmptyString()
        {
            Assert.AreEqual("", BinStatusParser.ParseSerialNum(""));
        }


        [TestMethod]
        //testing that valid data returns parsed bin status object with same data
        public void TestThatParseDataMethodReturnsBinStatusObjectWithValidData()
        {
            var binStatus = BinStatusParser.ParseBinStatusData(new string[] { "1609312", "w114-320-203", "1-Jan-18", "Collected" });


            Assert.AreEqual("W114-320-203", binStatus.binID);
            Assert.AreEqual(1609312, binStatus.siteID);
            Assert.AreEqual(1, binStatus.status);
            Assert.AreEqual("2018-01-01", binStatus.collectionDate);

            //ensure bin received back is valid
            results = TestValidationHelper.Validate(binStatus);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that invalid data returns parsed bin status object with invalid data
        public void TestThatParseDataMethodReturnsBinStatusObjectWithInalidData()
        {
            BinStatus binStatus = BinStatusParser.ParseBinStatusData(new string[] { "", "", "", "" });
          
            Assert.AreEqual("", binStatus.binID);
            Assert.AreEqual(0, binStatus.siteID);
            Assert.AreEqual(0, binStatus.status);
            Assert.AreEqual("", binStatus.collectionDate);

            //ensure bin received back is invalid
            results = TestValidationHelper.Validate(binStatus);
            Assert.AreEqual(4, results.Count);
        }
    }
}
