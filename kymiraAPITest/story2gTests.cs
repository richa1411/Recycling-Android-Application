using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using kymiraAPI;
using kymiraAPI.Models;
using System.Collections.Generic;
using System.Text;

namespace kymiraAPITest
{
    [TestClass]
    class story2gTests
    {
        Disposable testDbItem = new Disposable{ name = "Glass Bottles", description = "These are Glass Bottles", pictureID = 1,
            recyclableReason = "Glass Bottles Reason", endResult = "Glass Bottles End Result", qtyRecycled = 1000};


        [TestMethod]
        public void AllRecyclableInformationIsValidTest()
        {
            Assert.IsNotNull(testDbItem.name);
            Assert.AreEqual("Glass Bottles", testDbItem);

        }

        ////*********** ID ***********

        /**
        * Test that ID cannot be empty. result is invalid.
        * */
        [TestMethod]
        public void TestThatIDIsEmpty()
        {
            
            //Error

        }



        //*********** NAME ***********
        /**
        * Test that name cannot be empty. result is invalid.
        * */
        [TestMethod]
        public void TestThatNameIsEmpty()
        {
            testDbItem.name = null;
            //ErrorMessage = "Name is required"

        }
        /**
        * Test that Name cannot be greater than 50 characters. result is invalid.
        * */
        [TestMethod]
        public void TestThatNameIs51CharsLong()
        {
            
            //ErrorMessage = "name must be 50 characters or less."

        }

        /**
        * Test that Name is 50 charactesr long. result is valid
        * */
        [TestMethod]
        public void TestThatNameIs50CharsLong()
        {
          
            //no errors

        }

        //*********** DESCRIPTION ***********
        /**
         * Test that the description is valid.
         * */
        [TestMethod]
        public void TestThatDescriptionisValid()
        {

            //NoError

        }
        /**
         * Test that Description is empty. result will be invalid.
         * */
        [TestMethod]
        public void TestThatDescriptionisEmpty()
        {

            //error

        }
        /**
         * Test that the description is greater than 500 chracters. result will be invalid
         * */
        [TestMethod]
        public void TestThatDescriptionisGreaterThan500Characters()
        {

            //error

        }

        //*********** PICTURE ***********
        /**
        * Tests that pictureID cannot be empty. result is invalid.
        * */
        [TestMethod]
        public void TestThatPictureIDIsEmpty()
        {
            
            //no errors

        }
        /**
        * Test that pictureID is a Number. result is valid
        * */
        [TestMethod]
        public void TestThatPictureIDIsANum()
        {

            //no errors

        }

        /**
        * Test that Picture must be a number. result invalid.
        * */
        [TestMethod]
        public void TestThatPictureIDIsNOTANum()
        {

            //error

        }

        //*********** isRECYCLABLE ***********
        /**
         * Tests that is recyclable cannot be empty. Result is Invalid.
         * */
        [TestMethod]
        public void TestThatisRecyclableIsEmpty()
        {

            //error

        }
        /**
         * Test that the disposable item is not recyclable. IsRecyclable set to false is Valid
         * */
        [TestMethod]
        public void TestThatisRecyclableIsFalse()
        {

            //NoError

        }
        /**
         * Test that the disposible item is recyclable. isRecyclable set to true is valid
         * */
        [TestMethod]
        public void TestThatisRecyclableIsTrue()
        {

            //NoError

        }



        //*********** RECYCLABLEREASON ***********
        /**
        * Tests that RecyclableReason passes validation and is valid. 
        * */
        [TestMethod]
        public void TestThatRecyclableReasonIsValid()
        {
            //noerror
            

        }

        /**
        * Tests that recycable reason cannot be greater than 500 characters. result is invalid
        * */
        [TestMethod]
        public void TestThatRecyclableReasonIsGreaterThan500Characters()
        {
            //error


        }

        /**
        * Test that Recyable Reason cannot be empty. result is invalid
        * */
        [TestMethod]
        public void TestThatRecyclableReasonIsEmpty()
        {
            //error


        }



        //*********** ENDRESULT ***********
        /**
        * Tests that end result is valid and passes validations. 
        * */
        [TestMethod]
        public void TestThatisEndResultisValid()
        {
            //Noerror


        }
        /**
        * Tests that the end result cannot be greater than 500 characters. Result is invalid
        * */
        [TestMethod]
        public void TestThatisEndResultIsGreaterThan500Characters()
        {
            //error


        }
        /**
         * Tests that the end result cannot be empty. Result is invalid
         * */
        [TestMethod]
        public void TestThatisEndResultIsEmpty()
        {
            //error


        }


        //*********** qtyRecycled ***********
        /**
         * Tests that the qty Recycled cannot be empty. result is invalid.
         * */
        [TestMethod]
        public void TestThatisqtyRecycledIsEmpty()
        {
            //error


        }
        /**
         * Tests that the qty Recycled is a valid input ( int). result is valid
         * */
        [TestMethod]
        public void TestThatisqtyRecycledIsValid()
        {
            //Noerror


        }


       
    }
}
