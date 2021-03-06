﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Models;
using KymiraApplication.Fragments;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime;
using KymiraApplication;


namespace KymiraApplicationTests
{
    /// <summary>
    /// Summary description for TestRecyclables
    /// </summary>
    [TestClass]
    public class DisposablesTests
    { //TODO: Make sure the methods used in ListDisposable are called in the tests, finish adding Objects and arrays for them to work

        List<Disposable> disposables;

        [TestInitialize]
        public void TestInitialize()
        {


            disposables = new List<Disposable>(new Disposable[] { new Disposable
        {

            name = "Cardboard",
            description = "Cardboard Description",
            imageURL = "Cardboard",
            isRecyclable = true,
            recycleReason = "Cardboard Reason",
            endResult = "Cardboard End Result",
            qtyRecycled = 1000,
            inactive = false
        }, new Disposable
        {

            name = "Paper",
            description = "Paper Description",
            imageURL = "",
            isRecyclable = true,
            recycleReason = "Paper Reason",
            endResult = "Paper End Result",
            qtyRecycled = 2500,
            inactive = false
        },
            new Disposable
        {

            name = "Tin Cans",
            description = "Tins Cans Description",
            imageURL = "TinCans",
            isRecyclable = true,
            recycleReason = "Tin Cans Reason",
            endResult = "Tin Cans End Result",
            qtyRecycled = 1200,
            inactive = false
        },
            new Disposable
        {

            name = "Pizza",
            description = "Pizza Description",
            imageURL = "Pizza",
            isRecyclable = false,
            recycleReason = "Pizza Reason",
            endResult = "Pizza End Result",
            qtyRecycled = 0,
            inactive = false
        },
            new Disposable
        {

            name = "Orange Peels",
            description = "Orange Peels Description",
            imageURL = "OrangePeels",
            isRecyclable = false,
            recycleReason = "Orange Peels Reason",
            endResult = "Orange Peels End Result",
            qtyRecycled = 0,
            inactive = false
        },
            new Disposable
        {

            name = "Candy",
            description = "Candy Description",
            imageURL = "Candy",
            isRecyclable = false,
            recycleReason = "Candy Reason",
            endResult = "Candy End Result",
            qtyRecycled = 0,
            inactive = false
        }
        });

        }

        #region Validation Tests


        /**
      * Tests that the model allows a valid object
      * */
        [TestMethod]
        public void AllRecyclableInformationIsValidTest()
        {

            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);

        }

        ////*********** ID ***********
        /**
         * Tests that the model allows a valid id.
         * */
        [TestMethod]
        public void TestThatIDIsValid()
        {
           
            disposables[0].ID = 1;
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);


        }



        //*********** NAME ***********
        /**
        * Test that name cannot be empty. result is invalid.
        * */
        [TestMethod]
        public void TestThatNameIsEmpty()
        {
            disposables[0].name = null;
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Name is required", results[0].ErrorMessage);
        }
        /**
        * Test that Name cannot be greater than 50 characters. result is invalid.
        * */
        [TestMethod]
        public void TestThatNameIs51CharsLong()
        {

            //ErrorMessage = "name must be 50 characters or less."
            disposables[0].name = new string('a', 51);
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("name must be 50 characters or less.", results[0].ErrorMessage);

        }

        /**
        * Test that Name is 50 charactesr long. result is valid
        * */
        [TestMethod]
        public void TestThatNameIs50CharsLong()
        {
            disposables[0].name = new string('a', 50);
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);

            //no errors

        }

        //*********** DESCRIPTION ***********
        /**
         * Test that the description is valid.
         * */
        [TestMethod]
        public void TestThatDescriptionisValid()
        {
            disposables[0].description = "PRJ2Cosmo";
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);
            //NoError

        }
        /**
         * Test that Description is empty. result will be invalid.
         * */
        [TestMethod]
        public void TestThatDescriptionisEmpty()
        {
            disposables[0].description = null;
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Description is required", results[0].ErrorMessage);
            //error

        }
        /**
         * Test that the description is greater than 500 chracters. result will be invalid
         * */
        [TestMethod]
        public void TestThatDescriptionisGreaterThan500Characters()
        {
            disposables[0].description = new string('a', 501);
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Description must be 500 characters or less.", results[0].ErrorMessage);
            //error

        }
        /**
         * Tests the boundary case that the disposable description can be 500 characters.
         * */
        [TestMethod]
        public void TestThatDescriptionis500Characters()
        {
            disposables[0].description = new string('a', 500);
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);



        }

        //*********** PICTURE ***********
        /**
        * Tests that pictureID cannot be empty. result is invalid.
        * */
        [TestMethod]
        public void TestThatPictureIDIsEmpty()
        {
            disposables[0].imageURL = null;
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("PictureID is required", results[0].ErrorMessage);
            //errors

        }
        /**
        * Test that pictureID is a Number. result is valid
        * */
        [TestMethod]
        public void TestThatPictureIDIsAString()
        {
            disposables[0].imageURL = "pizza";
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);
            //no errors

        }

        /**
        * Test that Picture must be a number. result invalid.
        * */
        [TestMethod]
        public void TestThatPictureIDCanNotbeGreaterThan90Characters()
        {
            disposables[0].imageURL = new string('a', 91);
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("PictureID must be 90 characters or less", results[0].ErrorMessage);
            //error

        }
        /**
         * Tests that the disposable picture id is valid at 90 characters
         * */
        [TestMethod]
        public void TestThatPictureIDis90Characters()
        {
            disposables[0].imageURL = new string('a', 90);
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);
            //error

        }

        //*********** isRECYCLABLE ***********

        /**
         * Test that the disposable item is not recyclable. IsRecyclable set to false is Valid
         * */
        [TestMethod]
        public void TestThatisRecyclableIsFalse()
        {
            disposables[0].isRecyclable = false;
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);
            //NoError

        }
        /**
         * Test that the disposible item is recyclable. isRecyclable set to true is valid
         * */
        [TestMethod]
        public void TestThatisRecyclableIsTrue()
        {

            disposables[0].isRecyclable = true;
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);
            //NoError

        }



        //*********** RECYCLABLEREASON ***********
        /**
        * Tests that RecyclableReason passes validation and is valid. 
        * */
        [TestMethod]
        public void TestThatRecyclableReasonIsValid()
        {
            disposables[0].recycleReason = "Because stone cold steve austin said so";
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);
            //noerror


        }

        /**
        * Tests that recycable reason cannot be greater than 500 characters. result is invalid
        * */
        [TestMethod]
        public void TestThatRecyclableReasonIsGreaterThan500Characters()
        {
            disposables[0].recycleReason = new string('a', 501);
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Reason must be 500 characters or less.", results[0].ErrorMessage);

            //error


        }
        /**
         * Tests that the dispoable recyclable reason is valid at 500 characters.
         * */
        [TestMethod]
        public void TestThatRecyclableReasonIs500Characters()
        {
            disposables[0].recycleReason = new string('a', 500);
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);



        }

        /**
        * Test that Recyable Reason cannot be empty. result is invalid
        * */
        [TestMethod]
        public void TestThatRecyclableReasonIsEmpty()
        {
            disposables[0].recycleReason = null;
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Disposable must have a recyclable reason", results[0].ErrorMessage);

            //error


        }



        //*********** ENDRESULT ***********
        /**
        * Tests that end result is valid and passes validations. 
        * */
        [TestMethod]
        public void TestThatisEndResultisValid()
        {
            disposables[0].endResult = "toilet paper for babies. this ad was sponsered by huggies";
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);
            //Noerror


        }
        /**
        * Tests that the end result cannot be greater than 500 characters. Result is invalid
        * */
        [TestMethod]
        public void TestThatisEndResultIsGreaterThan500Characters()
        {

            disposables[0].endResult = new string('a', 501);
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Result must be 500 characters or less.", results[0].ErrorMessage);

            //error


        }
        /**
         * Tests that the disposable object end result is valid at 500 charactesr.
         * */
        [TestMethod]
        public void TestThatisEndResultIs500Characters()
        {

            disposables[0].endResult = new string('a', 500);
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);



        }
        /**
         * Tests that the end result cannot be empty. Result is invalid
         * */
        [TestMethod]
        public void TestThatisEndResultIsEmpty()
        {
            disposables[0].endResult = null;
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("An end result is required", results[0].ErrorMessage);


            //error


        }


        //*********** qtyRecycled ***********

        /**
         * Tests that the qty Recycled is a valid input ( int). result is valid
         * */
        [TestMethod]
        public void TestThatisqtyRecycledIsValid()
        {

            disposables[0].qtyRecycled = 1234567;
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);
            //Noerror


        }


        //*********** Inactive ***********

        //Test that the Inactive field is true
        [TestMethod]
        public void TestThatInactiveIsTrue()
        {

            disposables[0].inactive = true;
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);
            //NoError


        }

        //Test that the Inactive field is false
        [TestMethod]
        public void TestThatInactiveIsFalse()
        {

            disposables[0].inactive = false;
            var results = TestValidationHelper.Validate(disposables[0]);
            Assert.AreEqual(0, results.Count);
            //NoError


        }
        #endregion Validation Tests
    }
}
