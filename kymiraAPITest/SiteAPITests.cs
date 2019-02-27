using kymiraAPI;
using kymiraAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace kymiraAPITest
{
    //Class responsible for testing that a valid address is given to the Site controller, a database query returns a result if it exists
    //and finally calculating the next two pick up dates for that site based on the site matched by the query
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

        //Test that an empty address sent from the application returns an error
        [TestMethod]
        public void TestThatEmptyAddressIsInvalid()
        {
            testSite.address = "";
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        //Test that an address of 201 characters sent by the application returns an error
        [TestMethod]
        public void TestThatAddressOf201CharactersInvalid()
        {
            testSite.address = new string('a', 201);
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        //Test that an address of one character sent by the application is valid
        [TestMethod]
        public void TestThatAddressOfOneCharacterIsValid()
        {
            testSite.address = "a";
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        //Test that an address of 200 characters sent by the application is valid
        [TestMethod]
        public void TestThatAddressOf200CharactersIsValid()
        {
            testSite.address = new string('a', 200);
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        //Test that an address of characters within allowable boundaries sent by the application is valid
        [TestMethod]
        public void TestThatValidAddressIsValid()
        {
            testSite.address = "123 Test Street";
            results = TestValidationHelper.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        //Test that next two pick up dates are correctly calculated for a valid site
        [TestMethod]
        public void TestThatPickupDatesAreCorrect()
        {
            DateTime[] pickupDates = PickupDateCalculatorHelper.CalculateNextPickupDates(testSite, new DateTime(2019, 2, 27)); //Hard code input date so we can get an expected output date

            //DateTime result = DateTime.Now.AddDays(1);
            //while (result.DayOfWeek != DayOfWeek.Monday)
            //    result = result.AddDays(1);

            Assert.AreEqual(new DateTime(2019, 3, 4), pickupDates[0]);

            Assert.AreEqual(new DateTime(2019, 3, 11), pickupDates[0]);

        }

        //Test that a site with an invalid value off pickup days returns an empty array of dates
        [TestMethod]
        public void TestThatInvalidSitePickupDaysReturnsEmptyArray()
        {
            testSite.sitePickupDays = 0;

            DateTime[] pickupDates = PickupDateCalculatorHelper.CalculateNextPickupDates(testSite, new DateTime(2019, 2, 27));

            Assert.AreEqual(0, pickupDates.Length);
        }

        //Test that a site with an invalid value of frequency returns an empty array of dates
        [TestMethod]
        public void TestThatInvalidSiteFrequencyReturnsEmptyArray()
        {
            testSite.frequency = 0;

            DateTime[] pickupDates = PickupDateCalculatorHelper.CalculateNextPickupDates(testSite, new DateTime(2019, 2, 27));

            Assert.AreEqual(0, pickupDates.Length);
        }


    }
}