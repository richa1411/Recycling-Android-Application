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
            cellList[0] = "W114-320-438";

            //Site ID cell
            cellList[1] = "1252181";

            //Building Name cell
            cellList[2] = "Chateu Laurier";

            //Street number cell
            cellList[3] = "102";

            //Street name cell
            cellList[4] = "104th";

            //Street Suffix cell
            cellList[5] = "St";

            //Street direction cell
            cellList[6] = "W";

            //Full address cell
            cellList[7] = "102 104th St W";

            //Neighborhood name cell
            cellList[8] = "Sutherland";

            //Neighborhood ID cell
            cellList[9] = "048";

            //Frequency cell
            cellList[10] = "Weekly";

            //Container type cell
            cellList[11] = "Bin";

            //Size cell
            cellList[12] = "4";

            //Status update cell
            cellList[13] = "";

            //Status change date cell
            cellList[14] = "";

            //Collection 1 cell
            cellList[15] = "1005";

            //Collection 2 cell
            cellList[16] = "2005";

            //Collection 3 cell
            cellList[17] = "";

            //Collection 4 cell
            cellList[18] = "";

            #endregion Cells


        }

        //Test that a valid site ID is correctly parsed
        [TestMethod]
        public void TestThatParseSiteIDValidSiteID()
        {
            int siteID = SiteParser.parseSiteID(cellList[1]);

            Assert.IsTrue(siteID != 0);
        }

        //Test that an invalid site ID returns a flag value of 0
        [TestMethod]
        public void TestThatParseSiteIDWithInvalidIDReturnsZero()
        {
            cellList[1] = "wklas";

            int siteID = SiteParser.parseSiteID(cellList[1]);

            Assert.IsTrue(siteID == 0);
        }

        //Test that a valid address is correctly parsed
        [TestMethod]
        public void TestThatParseSiteAddressValidAddress()
        {
            string address = SiteParser.parseAddress(cellList[7]);

            Assert.IsTrue(address.Length > 0);
        }

        //Test that an invalid address returns a flag value of empty string
        [TestMethod]
        public void TestThatParseSiteAddressWithInvalidAddressReturnsEmptyString()
        {
            cellList[7] = new String('a', 201);

            string address = SiteParser.parseAddress(cellList[7]);

            Assert.IsTrue(address.Length == 0);
        }

        //Test that a valid frequency is parsed correctly
        [TestMethod]
        public void TestThatParseSiteFrequencyValidFrequency()
        {
            Site.PickupFrequency frequency = SiteParser.parseFrequency(cellList[10]);

            Assert.IsTrue(frequency == Site.PickupFrequency.Weekly);
        }

        //Test that an invalid frequency returns a flag value of null
        [TestMethod]
        public void TestThatParseSiteFrequencyWithInvalidFrequencyReturnsNull()
        {
            cellList[10] = "kljas";

            Site.PickupFrequency frequency = SiteParser.parseFrequency(cellList[10]);

            Assert.IsNull(frequency);
        }

        //Test that a valid PickupDays value is parsed correctly
        [TestMethod]
        public void TestThatParseSitePickupDaysValidPickupDays()
        {
            string[] collectionDays = new string[4];

            collectionDays[0] = cellList[15];
            collectionDays[1] = cellList[16];
            collectionDays[2] = cellList[17];
            collectionDays[3] = cellList[18];

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

            Assert.IsNull(pickupDays);
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
                "2005"
            };

            Site.PickupDays pickupDays = SiteParser.parsePickupDays(collectionDays);

            Assert.IsTrue(pickupDays == (Site.PickupDays.Tuesday | Site.PickupDays.Friday));
        }

        // Test that A Valid Site object is created when GenerateSiteObjectFromRow method is given valid info
        [TestMethod]
        public void TestThatValidSiteObjectIsCreatedWithValidSiteInformation()
        {
            Site site = SiteParser.GenerateSiteObjectFromRow(cellList);

            var results = HelperTestModel.Validate(site);
            Assert.AreEqual(0, results.Count);

        }

        // Test that An invalid Site object is created when GenerateSiteObjectFromRow method is given invalid info
        [TestMethod]
        public void TestThatInvalidSiteObjectIsCreatedWithInvalidSiteInformation()
        {
            cellList[1] = "dsfhjeswihfeh";
            cellList[7] = "";
            cellList[10] = "322343";
            cellList[15] = "asad4ttg";

            Site site = SiteParser.GenerateSiteObjectFromRow(cellList);

            var results = HelperTestModel.Validate(site);
            Assert.AreEqual(4, results.Count);

            Assert.AreEqual("The siteID must be a valid integer", results[0].ErrorMessage);
            Assert.AreEqual("Address must be between 1 and 200 characters", results[1].ErrorMessage);
            Assert.AreEqual("Pickup Frequency must be Weekly or BiWeekly", results[2].ErrorMessage);
            Assert.AreEqual("Specified Pickup Days are invalid", results[3].ErrorMessage);
        }

        
        
    }
}
