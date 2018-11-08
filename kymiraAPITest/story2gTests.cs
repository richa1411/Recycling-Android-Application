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
        [TestMethod]
        public void IDIsEmpty()
        {
            
            //Error

        }



        //*********** NAME ***********
        //InValid
        [TestMethod]
        public void NameIsEmpty()
        {
            testDbItem.name = null;
            //ErrorMessage = "Name is required"

        }

        [TestMethod]
        public void InvalidNameIs51CharsLong()
        {
            
            //ErrorMessage = "name must be 50 characters or less."

        }

        //Valid
        [TestMethod]
        public void ValidNameIs50CharsLong()
        {
          
            //no errors

        }

        //*********** DESCRIPTION ***********


        //*********** PICTURE ***********
        //valid
        [TestMethod]
        public void ValidPictureIsEmpty()
        {
            
            //no errors

        }

        [TestMethod]
        public void ValidPictureIsANum()
        {

            //no errors

        }

        //invalid
        [TestMethod]
        public void InvalidPictureIsNOTANum()
        {

            //error

        }

        //*********** isRECYCLABLE ***********

        [TestMethod]
        public void ValidisRecyclableIsBool()
        {

            //error

        }

        //*********** RECYCLABLEREASON ***********

        //*********** ENDRESULT ***********

        //*********** NAME ***********

    }
}
