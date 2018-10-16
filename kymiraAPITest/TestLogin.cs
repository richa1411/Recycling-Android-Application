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
            Assert.AreEqual("Phone number is empty", results[0].ErrorMessage);


            Assert.AreEqual("JohnDoe123", phoneNumber);
            Assert.AreEqual("{ error:1 message: “Incorrect phone number or password”}", errorMessage);
        }

        /*
         *  Tests that the phone number is exactly 10 digits long
         */
        [TestMethod]
        public void PhoneNumberMustBeTenDigitsInLengthTest()
        {
            Assert.AreEqual("1234567890", phoneNumber);
            Assert.AreEqual("{ error:0 message: “This is a valid phone number”}", errorMessage);
        }

        /*
         *  Tests that the phone number cannot exceed 10 digits
         */
        [TestMethod]
        public void PhoneNumberCannotExceedTenDigitsInLengthTest()
        {
            Assert.AreEqual("12345678901", phoneNumber);
            Assert.AreEqual("{ error:1 “Incorrect username or password” }", errorMessage);
        }

        /*
         *  Tests that the phone number is exactly 10 digits long
         */
        [TestMethod]
        public void PhoneNumberCannotBeLessThanTenDigitsInLengthTest()
        {
            Assert.AreEqual("123456789", phoneNumber);
            Assert.AreEqual("{ error:1 “Incorrect username or password” }", errorMessage);
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
            Assert.AreEqual("", password);
            Assert.AreEqual("{ error:1 message: “Password is empty” }", errorMessage);
        }

        /*
         *  Tests that the password cannot be less than six characters
         */
        [TestMethod]
        public void PasswordCannotBeLessThanSixCharactersLongTest()
        {
            Assert.AreEqual("P@ssw", password);
            Assert.AreEqual("{ error:1 “Incorrect username or password” }", errorMessage);
        }

        /*
         *  Tests that the password must be 6 - 12 characters long
         */
        [TestMethod]
        public void PasswordMustBeSixToTwelveCharactersLong()
        {
            Assert.AreEqual("P@ssw0", password);
            Assert.AreEqual("{ error:0 “This is a valid password” }", errorMessage);

            Assert.AreEqual("P@ssw0rd1234", password);
            Assert.AreEqual("{ error:0 “This is a valid password” }", errorMessage);
        }

        /*
         *  Tests that the password cannot exceed 12 characters
         */
        [TestMethod]
        public void PasswordCannotExceedTwelveCharactersInLength()
        {
            Assert.AreEqual("P@ssw0rd12345", password);
            //errorMessage = loginCreds.validatePasswordDatabase(password);
            Assert.AreEqual("{ error:1 “Incorrect username or password” }", errorMessage);
        }

    }
}
