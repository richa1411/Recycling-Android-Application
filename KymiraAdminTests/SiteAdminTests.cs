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
                collection1 = System.DayOfWeek.Monday,
                collection2 = System.DayOfWeek.Tuesday,
                collection3 = System.DayOfWeek.Thursday,
                collection4 = System.DayOfWeek.Wednesday


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
        public void TestThatEmptySiteFrequencyIsInValid()
        {
            testSite.frequency = 0;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Pickup Frequency must be Weekly or BiWeekly", results[0].ErrorMessage);

        }


        [TestMethod]
        public void TestThatSiteFrequencyOfWeeklyIsValid()
        {
            testSite.frequency = Site.PickupFrequency.Weekly;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

        }


        [TestMethod]
        public void TestThatSiteFrequencyOfBiWeeklyIsValid()
        {
            testSite.frequency = Site.PickupFrequency.BiWeekly;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

        }

        [TestMethod]
        public void TestThatCollection1WithDayOfWeekMondayToFridayIsValid()
        {
            // Collection1 is on Monday
            testSite.collection1 = System.DayOfWeek.Monday;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

            // Collection1 is on Tuesday
            testSite.collection1 = System.DayOfWeek.Tuesday;
             results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

            // Collection1 is on Wednesday
            testSite.collection1 = System.DayOfWeek.Wednesday;
             results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

            // Collection1 is on Thursday
            testSite.collection1 = System.DayOfWeek.Thursday;
             results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

            // Collection1 is on Friday
            testSite.collection1 = System.DayOfWeek.Friday;
             results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);

        }

        [TestMethod]
        public void TestThatCollection1WithDayOfWeekNotMonToFriIsInvalid()
        {
            testSite.collection1 = System.DayOfWeek.Saturday;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Collection date must be a valid day of the week (Monday to Friday)", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestThatCollection234AreEmptyButValid()
        {
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestThatCollection234ValidDaysOfWeekAndValid()
        {
            testSite.collection2 = System.DayOfWeek.Monday;
            testSite.collection3 = System.DayOfWeek.Tuesday;
            testSite.collection4 = System.DayOfWeek.Thursday;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        
        [TestMethod]
        public void TestThatCollections234WithDayOfWeekSaturdayOrSundayAreInvalid()
        {
            testSite.collection2 = System.DayOfWeek.Saturday;
            testSite.collection3 = System.DayOfWeek.Sunday;
            testSite.collection4 = System.DayOfWeek.Saturday;
            var results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("Collection date must be a valid day of the week (Monday to Friday)", results[0].ErrorMessage);
            Assert.AreEqual("Collection date must be a valid day of the week (Monday to Friday)", results[1].ErrorMessage);
            Assert.AreEqual("Collection date must be a valid day of the week (Monday to Friday)", results[2].ErrorMessage);
        }



    }
}
