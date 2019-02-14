using KymiraAdmin;
using KymiraAdmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KymiraAdminTests
{
    [TestClass]
    public class SiteParserTests
    {

        public List<string> cellList;
        public List<Site> siteList;
        public IFormFile excelFile;

        [TestInitialize]
        public void Setup()
        {

            //Create a static "row" for testing that is actually a list of strings
            //Each string in the list is the string value of an indiviudal cell from the row
            cellList = new List<string>();

            #region Cells

            //Container Serial Number cell
            cellList.Add("W114-320-438");

            //Site ID cell
            cellList.Add("1252181");

            //Building Name cell
            cellList.Add("Chateu Laurier");

            //Street number cell
            cellList.Add("102");

            //Street name cell
            cellList.Add("104th");

            //Street Suffix cell
            cellList.Add("St");

            //Street direction cell
            cellList.Add("W");

            //Full address cell
            cellList.Add("102 104th St W");

            //Neighborhood name cell
            cellList.Add("Sutherland");

            //Neighborhood ID cell
            cellList.Add("048");

            //Frequency cell
            cellList.Add("Weekly");

            //Container type cell
            cellList.Add("Bin");

            //Size cell
            cellList.Add("4");

            //Status update cell
            cellList.Add("");

            //Status change date cell
            cellList.Add("");

            //Collection 1 cell
            cellList.Add("1005");

            //Collection 2 cell
            cellList.Add("2005");

            //Collection 3 cell
            cellList.Add("");

            //Collection 4 cell
            cellList.Add("");

            #endregion Cells


        }

        //Test that a valid site ID is correctly parsed
        [TestMethod]
        public void TestThatParseSiteIDValidSiteID()
        {
            int siteID = SiteParser.ParseSiteID("1252181");

            Assert.IsTrue(siteID != 0);
        }

        //Test that an invalid site ID returns a flag value of 0
        [TestMethod]
        public void TestThatParseSiteIDWithInvalidIDReturnsZero()
        {
            int siteID = SiteParser.ParseSiteID("wklas");

            Assert.IsTrue(siteID == 0);
        }

        //Test that an empty site ID returns a flag value of 0 (invalid)
        [TestMethod]
        public void TestThatParseSiteIDEmptyIDInvalidReturnsZero()
        {
            int siteID = SiteParser.ParseSiteID("");

            Assert.IsTrue(siteID == 0);
        }

        //Test that a site ID that is negative returns a flag value of 0 (invalid)
        [TestMethod]
        public void TestThatParseSiteIDNegativeIDInvalidReturnsZero()
        {
            int siteID = SiteParser.ParseSiteID("-1");

            Assert.IsTrue(siteID == 0);
        }

        //Test that site ID that is larger than what can be stored in an integer returns flag value of 0 (invalid)
        [TestMethod]
        public void TestThatParseSiteIDLargerThanIntegerReturnsZero()
        {
            int siteID = SiteParser.ParseSiteID("1000000000000000000000000");

            Assert.IsTrue(siteID == 0);
        }

        //Test that a valid address is correctly parsed
        [TestMethod]
        public void TestThatParseSiteAddressValidAddress()
        {
            string address = SiteParser.ParseAddress("123 Test St");

            Assert.AreEqual(address, "123 Test St");
        }

        //Test that an address that is one character is valid and correctly parsed
        [TestMethod]
        public void TestThatParseSiteAddressOneCharValid()
        {
            string address = SiteParser.ParseAddress("T");

            Assert.AreEqual(address, "T");
        }

        //Test that an address that is 200 characters long is valid and correctly parsed
        [TestMethod]
        public void TestThatParseSiteAddress200CharValid()
        {
            string testString = new string('a', 200);

            string address = SiteParser.ParseAddress(testString);

            Assert.IsTrue(address.Length == 200);
        }

        //Test that an invalid address returns a flag value of empty string
        [TestMethod]
        public void TestThatParseSiteAddressTooLongReturnsEmptyString()
        {
            string testString = new String('a', 201);

            string address = SiteParser.ParseAddress(testString);

            Assert.IsTrue(address.Length == 0);
        }

        //Test that a valid frequency is parsed correctly
        [TestMethod]
        public void TestThatParseSiteFrequencyWeeklyValidFrequency()
        {
            Site.PickupFrequency frequency = SiteParser.ParseFrequency("Weekly");

            Assert.IsTrue(frequency == Site.PickupFrequency.Weekly);
        }

        //Test that a valid frequency is parsed correctly
        [TestMethod]
        public void TestThatParseSiteFrequencyBiWeeklyValidFrequency()
        {
            Site.PickupFrequency frequency = SiteParser.ParseFrequency("Bi-Weekly");

            Assert.IsTrue(frequency == Site.PickupFrequency.BiWeekly);
        }

        //Test that an invalid frequency returns a flag value of null
        [TestMethod]
        public void TestThatParseSiteFrequencyWithInvalidFrequencyReturnsInvalid()
        {

            Site.PickupFrequency frequency = SiteParser.ParseFrequency("kljas");

            Assert.IsTrue(frequency == Site.PickupFrequency.Invalid);
        }

        //Test that a valid PickupDays value is parsed correctly
        [TestMethod]
        public void TestThatParseSitePickupDaysValidPickupDays()
        {
            string[] collectionDays = new string[4];

            collectionDays[0] = "1005";
            collectionDays[1] = "2005";
            collectionDays[2] = "";
            collectionDays[3] = "";

            Site.PickupDays pickupDays = SiteParser.ParsePickupDays(collectionDays);

            Assert.IsTrue(pickupDays == Site.PickupDays.Friday);
        }



        // Test that an invalid Collection Day returns invalid
        [TestMethod]
        public void TestThatParseSitePickupDaysWithInvalidDaysReturnsInvalid()
        {
            string[] collectionDays = new string[]
            {
                "SomeRandomString",
                "String",
                "1092",
                "12321"
            };

            Site.PickupDays pickupDays = SiteParser.ParsePickupDays(collectionDays);

            Assert.IsTrue(pickupDays == Site.PickupDays.Invalid);
        }

        // Test that a valid array of Collection days is parsed properly
        [TestMethod]
        public void TestThatParseSitePickupDaysWithMultipleDaysIsValid()
        {
            string[] collectionDays = new string[]
            {
                "1002",
                "1005",
                "2002",
                "2005",
            };

            Site.PickupDays pickupDays = SiteParser.ParsePickupDays(collectionDays);

            Assert.IsTrue(pickupDays == (Site.PickupDays.Tuesday | Site.PickupDays.Friday));
        }

        //Test that all empty strings returns an invalid PickupDays
        [TestMethod]
        public void TestThatParseSitePickupDaysAllEmptyStringsInvalid()
        {
            string[] collectionDays = new string[]
            {
                "",
                "",
                "",
                ""
            };
        }

        // Test that A Valid Site object is created when GenerateSiteObjectFromRow method is given valid info
        [TestMethod]
        public void TestThatValidSiteObjectIsCreatedWithValidSiteInformation()
        {
            Site site = SiteParser.GenerateSiteObjectFromRow(cellList, false);

            var results = HelperTestModel.Validate(site);
            Assert.AreEqual(0, results.Count);

        }

        // Test that An invalid Site object is created when GenerateSiteObjectFromRow method is given invalid info
        [TestMethod]
        public void TestThatInvalidSiteObjectIsCreatedWithInvalidSiteInformation()
        {
            cellList[1] = "jdasdfa";
            cellList[7] = "";
            cellList[10] = "jdfsal";
            cellList[15] = "23kjl32";

            Site site = SiteParser.GenerateSiteObjectFromRow(cellList, false);

            var results = HelperTestModel.Validate(site);
            Assert.AreEqual(4, results.Count);

            Assert.AreEqual("The siteID must be a valid integer", results[0].ErrorMessage);
            Assert.AreEqual("Address must be 1 to 200 characters", results[1].ErrorMessage);
            Assert.AreEqual("Pickup Frequency must be Weekly or BiWeekly", results[2].ErrorMessage);
            Assert.AreEqual("Specified Pickup Days are invalid", results[3].ErrorMessage);
        }

        //*************************WHERE I LEFT OFF ON FEB 13/19********************************************//

        [TestMethod]
        public void TestThatSiteObjectWithAddressOf1PassesValidation()
        {
            // Address field
            cellList[7] = "a";

            Site site = SiteParser.GenerateSiteObjectFromRow(cellList, false);

            var results = HelperTestModel.Validate(site);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestThatSiteObjectWithAddressOf200PassesValidation()
        {
            // Address field
            cellList[7] = new string('a', 200);

            Site site = SiteParser.GenerateSiteObjectFromRow(cellList, false);

            var results = HelperTestModel.Validate(site);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestThatSiteObjectWithAddressOf201FailsValidation()
        {
            // Address field
            cellList[7] = new string('a', 201);

            Site site = SiteParser.GenerateSiteObjectFromRow(cellList, false);

            var results = HelperTestModel.Validate(site);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestThatSiteObjectWithFrequencyOfInvalidFailsValidation()
        {
            // Frequency field
            cellList[10] = "sdfafa";

            Site site = SiteParser.GenerateSiteObjectFromRow(cellList, false);

            var results = HelperTestModel.Validate(site);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Pickup Frequency must be Weekly or BiWeekly", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestThatSiteObjectWithPickupDayOfInvalidFailsValidation()
        {
            // PickupDay field
            cellList[15] = "sdfafa";

            Site site = SiteParser.GenerateSiteObjectFromRow(cellList, false);

            var results = HelperTestModel.Validate(site);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Specified Pickup Days are invalid", results[0].ErrorMessage);
        }


        [TestMethod]
        public void TestThatTooManyColumnsInExcelSheetReturnsASiteObjectWithIDOfNegativeTwo()
        {
            
            cellList.Add("Sdawdawdawdaw");

            Site site = SiteParser.GenerateSiteObjectFromRow(cellList, false);

            Assert.AreEqual(-2, site.SiteID);
        }

        [TestMethod]
        public void TestThatTooFewColumnsInExcelSheetReturnsASiteObjectWithIDOfNegativeTwo()
        {

            cellList.Remove(cellList[5]);
            cellList.Remove(cellList[6]);

            Site site = SiteParser.GenerateSiteObjectFromRow(cellList, false);

            Assert.AreEqual(-2, site.SiteID);
        }


        //***** Header Row Tests *****//

        [TestMethod]
        public void TestThatHeaderRowWithValidDataReturnsASiteObjectWithSiteIDOfZero()
        {
            cellList[1] = "Site ID";
            cellList[7] = "Full Address";
            cellList[10] = "Frequency";
            cellList[15] = "Collection1";
            cellList[16] = "Collection2";
            cellList[17] = "Collection3";
            cellList[18] = "Collection4";

            Site site = SiteParser.GenerateSiteObjectFromRow(cellList, true);

            Assert.AreEqual(0, site.SiteID);


        }

        [TestMethod]
        public void TestThatHeaderRowWithInValidDataReturnsASiteObjectWithSiteIDOfNegativeOne()
        {
            cellList[1] = "Site ID";
            cellList[7] = "Full Address";
            cellList[10] = "Frequency";
            cellList[15] = "Colleasdasction1";
            cellList[16] = "Collection2";
            cellList[17] = "Collection3";
            cellList[18] = "Collection4";

            Site site = SiteParser.GenerateSiteObjectFromRow(cellList, true);

            Assert.AreEqual(-1, site.SiteID);


        }
    }
}
