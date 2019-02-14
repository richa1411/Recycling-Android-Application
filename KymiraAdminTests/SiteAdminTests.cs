using KymiraAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KymiraAdminTests
{
    [TestClass]
    public class SiteAdminTests
    {


        //valid Site object to be used to validate
        Site testSite;

        [TestInitialize]
        public void Setup()
        {
             testSite = new Site
            {
                SiteID = 10,
                Address = "123 Test Street",
                Frequency = Site.PickupFrequency.Weekly,
                SitePickupDays = Site.PickupDays.Monday
             };
        }


        /*--------------------------------Site validation tests--------------------------------*/
        [TestMethod]
        //testing that the valid Site object is indeed valid
        public void TestThatValidSiteIsValid()
        {
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the siteID of a Site object cannot be less than 0
        public void TestThatSiteIDLessThanOneIsInvalid()
        {
            testSite.SiteID = -1;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The siteID must be a valid integer", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that siteID cannot be 0
        public void TestThatSideIDOfZeroIsInvalid()
        {
            testSite.SiteID = 0;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The siteID must be a valid integer", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the siteID of a Site object of 1 is valid
        public void TestThatSiteIDOfOneIsValid()
        {
            testSite.SiteID = 1;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the address of a Site object cannot be an empty string
        public void TestThatSiteAddressOfEmptyStringIsInvalid()
        {
            testSite.Address = "";
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the address of a Site object can be 1 character
        public void TestThatSiteAddressOfOneCharacterIsValid()
        {
            testSite.Address = "a";
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the address of a Site object can be 200 characters
        public void TestThatSiteAddressOf200CharactersIsValid()
        {
            testSite.Address = new string('a', 200);
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }


        [TestMethod]
        //testing that the address of a Site object cannot be 201 characters
        public void TestThatSiteAddressOfLargeStringIsInvalid()
        {
            testSite.Address = new string('a', 201);
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //Test that a Site object with an "empty" frequency is not valid
        public void TestThatSiteFrequencyOfZeroIsInvalid()
        {
            testSite.Frequency = 0;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Pickup Frequency must be Weekly or BiWeekly", results[0].ErrorMessage);

        }

        //Test that a Site object with a frequency of "Weekly" is valid
        [TestMethod]
        public void TestThatSiteFrequencyOfWeeklyIsValid()
        {
            testSite.Frequency = Site.PickupFrequency.Weekly;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

        }

        //Test that a Site object with a frequency of "BiWeekly" is valid
        [TestMethod]
        public void TestThatSiteFrequencyOfBiWeeklyIsValid()
        {
            testSite.Frequency = Site.PickupFrequency.BiWeekly;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

        }

        //Test that a Site object with a collection 1 day of Monday to Friday is valid
        [TestMethod]
        public void TestThatCollectionDayOfWeekMondayToFridayIsValid()
        {
            testSite.SitePickupDays = Site.PickupDays.Monday | Site.PickupDays.Tuesday | Site.PickupDays.Wednesday | Site.PickupDays.Thursday | Site.PickupDays.Friday;

            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

        }







    }
}
