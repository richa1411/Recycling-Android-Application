using Microsoft.VisualStudio.TestTools.UnitTesting;
using kymiraAPI;
using kymiraAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kymiraAPITest
{
    /**********************************/
    /******* PHONE NUMBER TESTS *******/
    /**********************************/
    [TestClass]
    public class TestLogin
    {
        string phoneNumber; // The phone number used to log in
        string password; // The password used to log in
        string errorMessage; // The error message

        Credentials loginCreds;

        /*
         *  Setups a Credentials object with a phone number, password, and message
         */
        [TestInitialize]
        public void InitializeTest()
        {
            loginCreds = new Credentials { phoneNumber= "1234567890", password = "P@ssw0rd"};
        }

        /*
         *  Tests that the phone number cannot be empty
         */
        [TestMethod]
        public void PhoneNumberCannotBeEmptyTest()
        {
            loginCreds.phoneNumber = "";

            var results = HelperTestModel.Validate(loginCreds);

            Assert.AreEqual(1,results.Count);
            Assert.AreEqual("Phone number is empty", results[0].ErrorMessage);
        }
        
        /*
         *  Tests that the phone number is only digits 
         */
        [TestMethod]
        public void PhoneNumberMustBeOnlyDigitsTest()
        {
            loginCreds.phoneNumber = "JohnDoe123";

            var results = HelperTestModel.Validate(loginCreds);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Phone Number is not 10 digits", results[0].ErrorMessage);

        }

        /*
         *  Tests that the phone number is exactly 10 digits long
         */
        [TestMethod]
        public void PhoneNumberMustBeTenDigitsInLengthTest()
        {
            loginCreds.phoneNumber = "1234567890"; // 10 digits

            var results = HelperTestModel.Validate(loginCreds);

            Assert.AreEqual(0, results.Count);
        }

        /*
         *  Tests that the phone number cannot exceed 10 digits
         */
        [TestMethod]
        public void PhoneNumberCannotExceedTenDigitsInLengthTest()
        {
            loginCreds.phoneNumber = "123456789012345"; // 15 digits

            var results = HelperTestModel.Validate(loginCreds);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Phone Number is not 10 digits", results[0].ErrorMessage);
        }

        /*
         *  Tests that the phone number is exactly 10 digits long
         */
        [TestMethod]
        public void PhoneNumberCannotBeLessThanTenDigitsInLengthTest()
        {

            loginCreds.phoneNumber = "1234567"; // 7 digits

            var results = HelperTestModel.Validate(loginCreds);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Phone Number is not 10 digits", results[0].ErrorMessage);

        }


        /**********************************/
        /********* PASSWORD TESTS *********/
        /**********************************/


        /*
         *  Tests that the password cannot be empty
         */
        [TestMethod]
        public void PasswordCannotBeEmptyTest()
        {

            loginCreds.password = ""; // Empty Password

            var results = HelperTestModel.Validate(loginCreds);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password is empty", results[0].ErrorMessage);
        }

        /*
         *  Tests that the password cannot be less than six characters
         */
        [TestMethod]
        public void PasswordCannotBeLessThanSixCharactersLongTest()
        {

            loginCreds.password = "P@ssw"; // Password is only 5 characters

            var results = HelperTestModel.Validate(loginCreds);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password must be between 6 - 50 characters", results[0].ErrorMessage);

        }

        /*
         *  Tests that the password must be 6 - 50 characters long
         */
        [TestMethod]
        public void PasswordMustBeSixToFiftyCharactersLongLowerBoundaryTest()
        {

            loginCreds.password = "P@ssw0"; // Password at lower boundary

            var results = HelperTestModel.Validate(loginCreds);

            Assert.AreEqual(0, results.Count);


        }


        /*
        *  Tests that the password must be 6 - 50 characters long
        */
        [TestMethod]
        public void PasswordMustBeSixToFiftyCharactersLongHigherBoundaryTest()
        {


            loginCreds.password = new string('a', 50); // Password is exactly 50 characters

            var results = HelperTestModel.Validate(loginCreds);

            Assert.AreEqual(0, results.Count);

        }



        /*
         *  Tests that the password cannot exceed 50 characters
         */
        [TestMethod]
        public void PasswordCannotExceedFiftyCharactersInLength()
        {
            loginCreds.password = new string('a', 51); // Password is exactly 51 characters

            var results = HelperTestModel.Validate(loginCreds);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password must be between 6 - 50 characters", results[0].ErrorMessage);
        }

    }
}
