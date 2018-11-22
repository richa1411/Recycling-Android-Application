using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Model;
using KymiraApplication;
using System.Linq;

namespace KymiraApplicationTests
{
    [TestClass]
    public class TestBinCollectionDate
    {
        BinCollectionDate binColl;

        [TestInitialize]
        public void InitializeTest()
        {
            binColl = new BinCollectionDate { Address = "123 Test Dr", collectionDate = "11/30/2018" }; //date is just a string right now.
        }

        [TestMethod]
        public void testAddressEmpty()
        {
            binColl.Address = "";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Address cannot be an empty field", results[0].ErrorMessage);
        }

        [TestMethod]
        public void testDateEmpty()
        {
            //This will be seem by the backend
            binColl.collectionDate = "";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Date is Required", results[0].ErrorMessage);

        }
        [TestMethod]
        public void testValidAddress()
        {
            binColl.Address = "123 Test Dr";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        public void testValidDate()
        {
            binColl.collectionDate = "11/30/2018";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(0, results.Count());
          
        }

        [TestMethod]
        public void testInValidDate()
        {
            binColl.collectionDate = "This is not a valid date";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Invalid Date format", results[0].ErrorMessage);

        }

        [TestMethod]
        public void testInValidAddress()
        {
            binColl.Address = "this is not a valid address";
            var results = HelperTestModel.Validate(binColl);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Invalid Address", results[0].ErrorMessage);
        }


        //UI Tests
          
        public void testEmptyAddress()
        {
            //when the there is an empty string in the address textView field and the user taps the submit button
            //the application will show an error message specifying an invalid address
        }

        public void testValidAddress()
        {
            //when the user enters a valid address string in the address textView field and the user taps the submit button
            //the application will take the user to the second activity which will display the next two collection dates
        }

        public void testInvalidAddress()
        {
            //when the user enters an invalid address string in the address textView field (address is in the incorrect format) 
            //and the user taps the submit button, the application will show an error message specifying an invalid address
        }

        public void testUserNavigatesToSecondActivity()
        {
            //when the user enters a valid address (correct format) and taps the submit button
            //as a result the user will be taken to a new page (second activity) that will display the next two collection dates if in the database
        }

        public void testNoAvailableDates()
        {
            //when the user enters a valid address (correct format) and taps the submit button
            //as a result the user will be taken to a new page (second activity) that will display an error message "No dates available, please try again later"
            //if there are no dates in the database
        }





    }
}
