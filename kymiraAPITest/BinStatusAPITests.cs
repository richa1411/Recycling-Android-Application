using kymiraAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace kymiraAPITest
{
    [TestClass]
    public class BinStatusAPITests
    {
        //valid BinStatus object to be used to validate
        BinStatus testBin = new BinStatus {
            binID = 1,
            status = 1,
            collectionDate = "2019-01-01",
            siteID = 101010
        };

        //valid Site object to be used to validate
        Site testSite = new Site {
            siteID = 10,
            address = "123 Test Street",
        };

        //list to hold ValidationResults
        public IList<ValidationResult> results;

        /*--------------------------------BinStatus validation tests--------------------------------*/
        

        [TestMethod]
        //testing that the status of a BinStatus object cannot be less than 1
        public void TestThatBinStatusLessThan1IsInvalid()
        {
            testBin.status = 0;
            results = HelperTestModel.Validate(testBin);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("A status can only be the value of 1, 2, or 3", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the status of a BinStatus object cannot be greater than 3
        public void TestThatBinStatusGreaterThan3IsInvalid()
        {
            testBin.status = 4;
            results = HelperTestModel.Validate(testBin);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("A status can only be the value of 1, 2, or 3", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the valid BinStatus object is indeed valid
        public void TestThatValidBinStatusIsValid()
        {
            results = HelperTestModel.Validate(testBin);
            Assert.AreEqual(0, results.Count);
        }




        /*--------------------------------Site validation tests--------------------------------*/
        [TestMethod]
        //testing that the siteID of a Site object cannot be less than 1
        public void TestThatSiteIDLessThanOneIsInvalid()
        {
            testSite.siteID = 0;
            results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The siteID must be a valid integer", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the valid Site object is indeed valid
        public void TestThatValidSiteIsValid()
        {
            results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the address of a Site object cannot be an empty string
        public void TestThatSiteAddressOfEmptyStringIsInvalid()
        {
            testSite.address = "";
            results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        [TestMethod]
        //testing that the address of a Site object can be 1 character
        public void TestThatSiteAddressOfOneCharacterIsValid()
        {
            testSite.address = "a";
            results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        //testing that the address of a Site object can be 200 characters
        public void TestThatSiteAddressOf200CharactersIsValid()
        {
            testSite.address = new string('a',200);
            results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(0, results.Count);
        }


        [TestMethod]
        //testing that the address of a Site object cannot be 201 characters
        public void TestThatSiteAddressOfLargeStringIsInvalid()
        {
            testSite.address = new string('a',201);
            results = HelperTestModel.Validate(testSite);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address must be 1 to 200 characters", results[0].ErrorMessage);
        }

        




    }
}
