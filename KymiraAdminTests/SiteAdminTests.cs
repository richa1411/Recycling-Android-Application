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
                siteID = 10,
                address = "123 Test Street",
                frequency = Site.PickupFrequency.Weekly,
                pickupDays = Site.PickupDays.Monday


             };
        }


        /*--------------------------------Site validation tests--------------------------------*/
        [TestMethod]
        //testing that the siteID of a Site object cannot be less than 1
        public void TestThatSiteIDLessThanOneIsInvalid()
        {
            testSite.siteID = 0;
           var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The siteID must be a valid integer", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the valid Site object is indeed valid
        public void TestThatValidSiteIsValid()
        {
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the address of a Site object cannot be an empty string
        public void TestThatSiteAddressOfEmptyStringIsInvalid()
        {
            testSite.address = "";
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the address of a Site object can be 1 character
        public void TestThatSiteAddressOfOneCharacterIsValid()
        {
            testSite.address = "a";
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the address of a Site object can be 200 characters
        public void TestThatSiteAddressOf200CharactersIsValid()
        {
            testSite.address = new string('a', 200);
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }


        [TestMethod]
        //testing that the address of a Site object cannot be 201 characters
        public void TestThatSiteAddressOfLargeStringIsInvalid()
        {
            testSite.address = new string('a', 201);
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //Test that a Site object with an "empty" frequency is not valid
        public void TestThatEmptySiteFrequencyIsInValid()
        {
            testSite.frequency = 0;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Pickup Frequency must be Weekly or BiWeekly", results[0].ErrorMessage);

        }

        //Test that a Site object with a frequency of "Weekly" is valid
        [TestMethod]
        public void TestThatSiteFrequencyOfWeeklyIsValid()
        {
            testSite.frequency = Site.PickupFrequency.Weekly;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

        }

        //Test that a Site object with a frequency of "BiWeekly" is valid
        [TestMethod]
        public void TestThatSiteFrequencyOfBiWeeklyIsValid()
        {
            testSite.frequency = Site.PickupFrequency.BiWeekly;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

        }

        //Test that a Site object with a collection 1 day of Monday to Friday is valid
        [TestMethod]
        public void TestThatCollection1WithDayOfWeekMondayToFridayIsValid()
        {
            testSite.pickupDays = (Site.PickupDays) 127;

            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

        }

        //Test that a Site object with a collection 1 day that isn't Monday to Friday is invalid
        [TestMethod]
        public void TestThatCollection1WithDayOfWeekNotMonToFriIsInvalid()
        {
            testSite.pickupDays = Site.PickupDays.Friday | Site.PickupDays.Monday;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Collection date must be a valid day of the week (Monday to Friday)", results[0].ErrorMessage);
        }






    }
}
