using kymiraAPI;
using kymiraAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace kymiraAPITest
{
    [TestClass]
    public class SiteAPITests
    {
        //valid Site object to be used to validate
        Site testSite = new Site
        {
            siteID = 10,
            address = "123 Test Street",
            sitePickupDays = Site.PickupDays.Monday,
            frequency = Site.PickupFrequency.Weekly
        };

        //list to hold ValidationResults
        public IList<ValidationResult> results;

        [TestMethod]
        public void TestThatEmptyAddressIsInvalid()
        {
            testSite.address = "";
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestThatAddressOf201CharactersInvalid()
        {
            testSite.address = new string('a', 201);
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestThatAddressOfOneCharacterIsValid()
        {
            testSite.address = "a";
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestThatAddressOf200CharactersIsValid()
        {
            testSite.address = new string('a', 200);
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestThatValidAddressIsValid()
        {
            testSite.address = "123 Test Street";
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestThatPickupDatesAreCorrect()
        {
            // String[] returnStrings = PickupDateCalculatorHelper.CalculateNextDate(testSite);

            DateTime result = DateTime.Now.AddDays(1);
            while (result.DayOfWeek != DayOfWeek.Monday)
                result = result.AddDays(1);

            Assert.AreEqual(result, returnStrings[0]);

            result.AddDays(7);

            Assert.AreEqual(result, returnStrings[0]);


        }


    }
}