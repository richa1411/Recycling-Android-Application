using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Models;
using KymiraApplication;
using System.Linq;

namespace KymiraApplicationTests
{
    [TestClass]
    public class TestBinCollectionDate
    {
        BinCollectionDate binColl;

        //Set up some initial data for our BinCollectionDate object
        [TestInitialize]
        public void InitializeTest()
        {
            binColl = new BinCollectionDate { Address = "123 Test Dr", collectionDate1 = "11/30/2018" }; //date is just a string right now.
        }

        //Test if the address field is Empty, will result in an error if it is empty
        [TestMethod]
        public void testAddressEmpty()
        {
            binColl.Address = "";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Address cannot be an empty field", results[0].ErrorMessage);
        }

        //Test if the address field is a valid format as specified by our Regular Expression
        [TestMethod]
        public void testValidAddress()
        {
            binColl.Address = "123 Test Dr";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(0, results.Count());
        }

        //Test if the address field is a valid format as specified by our Regular Expression
        [TestMethod]
        public void testValidDate()
        {
            binColl.collectionDate1 = "11/30/2018";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(0, results.Count());
          
        }
        //Test if the address field is an invalid format as specified by our Regular Expression 
        [TestMethod]
        public void testInValidDate()
        {
            binColl.collectionDate1 = "This is not a valid date";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Invalid Date format", results[0].ErrorMessage);

        }

        //Test if the Address is invalid (from the backend)
        [TestMethod]
        public void testInValidAddress()
        {
            binColl.Address = "this is not a valid address";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Invalid Address", results[0].ErrorMessage);
        }


        //UI Tests
          
        public void testUIEmptyAddress()
        {
            //when the there is an empty string in the address textView field and the user taps the submit button
            //the application will show an error message specifying an invalid address
        }

        public void testUIValidAddress()
        {
            //when the user enters a valid address string in the address textView field and the user taps the submit button
            //the application will take the user to the second activity which will display the next two collection dates
        }

        public void testUIInvalidAddress()
        {
            //when the user enters an invalid address string in the address textView field (address is in the incorrect format) 
            //and the user taps the submit button, the application will show an error message specifying an invalid address
        }

        public void testUserNavigatesToSecondActivity()
        {
            //when the user enters a valid address (correct format) and taps the submit button
            //as a result the user will be taken to a new page (second activity) that will display the next two collection dates if in the database
        }

        public void testUINoAvailableDates()
        {
            //when the user enters a valid address (correct format) and taps the submit button
            //as a result the user will be taken to a new page (second activity) that will display an error message "No dates available, please try again later"
            //if there are no dates in the database
        }





    }
}
