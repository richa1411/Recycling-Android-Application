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

            //var stringRow = row.Cells.Select(c => c.ToString()).ToList();

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
            int siteID = SiteParser.parseSiteID("1252181");

            Assert.IsTrue(siteID != 0);
        }

        //Test that an invalid site ID returns a flag value of 0
        [TestMethod]
        public void TestThatParseSiteIDWithInvalidIDReturnsZero()
        {
            int siteID = SiteParser.parseSiteID("wklas");

            Assert.IsTrue(siteID == 0);
        }

        //Test that a valid address is correctly parsed
        [TestMethod]
        public void TestThatParseSiteAddressValidAddress()
        {
            string address = SiteParser.parseAddress("123 Test St");

            Assert.IsTrue(address.Length > 0);
        }

        //Test that an invalid address returns a flag value of empty string
        [TestMethod]
        public void TestThatParseSiteAddressWithInvalidAddressReturnsEmptyString()
        {
            string testString = new String('a', 201);

            string address = SiteParser.parseAddress(testString);

            Assert.IsTrue(address.Length == 0);
        }

        //Test that a valid frequency is parsed correctly
        [TestMethod]
        public void TestThatParseSiteFrequencyValidFrequency()
        {
            Site.PickupFrequency frequency = SiteParser.parseFrequency("Weekly");

            Assert.IsTrue(frequency == Site.PickupFrequency.Weekly);
        }

        //Test that an invalid frequency returns a flag value of null
        [TestMethod]
        public void TestThatParseSiteFrequencyWithInvalidFrequencyReturnsNull()
        {

            Site.PickupFrequency frequency = SiteParser.parseFrequency("kljas");

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

            Site.PickupDays pickupDays = SiteParser.parsePickupDays(collectionDays);

            Assert.IsTrue(pickupDays == Site.PickupDays.Friday);
        }



        // Test that an invalid Collection Day returns null
        [TestMethod]
        public void TestThatParseSitePickupDaysWithInvalidDaysReturnsNull()
        {
            string[] collectionDays = new string[]
            {
                "SomeRandomString",
                "String",
                "1092",
                "12321"
            };

            Site.PickupDays pickupDays = SiteParser.parsePickupDays(collectionDays);

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

            Site.PickupDays pickupDays = SiteParser.parsePickupDays(collectionDays);

            Assert.IsTrue(pickupDays == (Site.PickupDays.Tuesday | Site.PickupDays.Friday));
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

        
        
    }
}
