using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplicationTests.Models;
using System.Linq;

namespace KymiraApplicationTests
{
    [TestClass]
    public class CredentialsTest
    {
        Credentials objCred;
        Token objToken;
        /*
        *  Setups a Credentials object with a phone number, password, and message
        */
        [TestInitialize]
        public void InitializeTest()
        {
            objCred = new Credentials { phoneNumber = "1234567890", password = "P@ssw0rd" };
            objToken = new Token { token = "1bf89a1c-3934-4e5b-b7be-7bfb766689c2" };
        }


        /*   Unit tests for Phonenumber   */

        [TestMethod]
        public void TestPhoneNumberIsEmpty()

        {
            //Test phone number is empty string
            objCred.phoneNumber = "";


            var results = TestValidationHelper.Validate(objCred);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Please Enter your Phone Number", results[0].ErrorMessage);
        }
        [TestMethod]
        public void TestPhoneNumberIsNotEmpty()

        {
            //test phonenumber is non empty
            var results = TestValidationHelper.Validate(objCred);

            objCred.phoneNumber = "1234567890";
            results = TestValidationHelper.Validate(objCred);
            Assert.AreEqual(0, results.Count());


        }

        [TestMethod]
        public void TestPhoneNumberNonDigits()
        {
            //test phonenumber contains characters instead digits
            objCred.phoneNumber = "shahsjhghr";
            var results = TestValidationHelper.Validate(objCred);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Incorrect Username or Password", results[0].ErrorMessage);

            //Test phone number contains combination of charcatres and digits
            objCred.phoneNumber = "shahsjh678";
            results = TestValidationHelper.Validate(objCred);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Incorrect Username or Password", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestPhoneNumberOnlyDigits()
        {
            //Test phone number contains digits
            objCred.phoneNumber = "1234567890";
            var results = TestValidationHelper.Validate(objCred);
            Assert.AreEqual(0, results.Count());

        }

        [TestMethod]
        public void TestPhoneNumberTenDigitLegth()
        {
            //Test phone number contains 10 digits
            objCred.phoneNumber = "3456789096";
            var results = TestValidationHelper.Validate(objCred);
            Assert.AreEqual(0, results.Count());

        }

        [TestMethod]
        public void TestPhoneNumberExceedTenDigit()
        {
            //Test phoneNumber contains more than 10 digits
            objCred.phoneNumber = "34567890965657";
            var results = TestValidationHelper.Validate(objCred);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Incorrect Username or Password", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestPhoneNumberLessThanTenDigit()
        {
            //Test phoneNumber contains less than 10 digits
            objCred.phoneNumber = "345678";
            var results = TestValidationHelper.Validate(objCred);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Incorrect Username or Password", results[0].ErrorMessage);

        }

        /*  Unit tests for Password  */



        [TestMethod]
        public void TestPasswordIsEmpty()
        {
            //Test password with an empty string
            objCred.password = "";
            var results = TestValidationHelper.Validate(objCred);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Please Enter your Password", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestPasswordIsNotEmpty()
        {
            //Test password with an non empty string
            objCred.password = "shah1108";
            var results = TestValidationHelper.Validate(objCred);

            Assert.AreEqual(0, results.Count);

        }

        [TestMethod]
        public void TestPasswordISSixChar()
        {
            //Test Password is  6 characters
            objCred.password = "Shh@11";

            var results = TestValidationHelper.Validate(objCred);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestPasswordISFiftyChar()
        {
            //Test Password is  50 characters
            objCred.password = new string('a', 50);

            var results = TestValidationHelper.Validate(objCred);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestPasswordLessThanSixChar()
        {
            //Test password is less than 6 characters
            objCred.password = "Shh@1"; // Password is only 5 characters

            var results = TestValidationHelper.Validate(objCred);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Incorrect Username or Password", results[0].ErrorMessage);

        }

        [TestMethod()]
        public void TestPasswordBetweenSixAndFiftyChar()
        {
            //Test password is greater than 6 characters but less than 50 charcaters
            objCred.password = "P@ssw0rd1178"; // Password at lower boundary

            var results = TestValidationHelper.Validate(objCred);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod()]
        public void TestPasswordGreaterThanFiftyChar()
        {
            //Test Password is  51 characters
            objCred.password = new string('a', 51);

            var results = TestValidationHelper.Validate(objCred);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Incorrect Username or Password", results[0].ErrorMessage);
        }

        [TestMethod()]
        public void TestThatTokenIsGUIDFormat()
        {
            //Test token  is  in GUID format 
           objToken.token = "1bf89a1c-3934-4e5b-b7be-7bfb766689c2";
           
            var results = TestValidationHelper.Validate(objToken);

            Assert.AreEqual(0, results.Count);
           
        }
        [TestMethod()]
        public void TestThatTokenIsNotInGUIDFormat()
        {
            //Test token  is  in GUID format 
            objToken.token = "1bf89a1c/fdhdhdf4356656546+fghf&";

            var results = TestValidationHelper.Validate(objToken);

            Assert.AreEqual(1, results.Count);
           Assert.AreEqual("token is not in proper GUID format", results[0].ErrorMessage);
        }

        [TestMethod()]
        public void TestThatTokenIsNull()
        {
            //Test token  is  in GUID format 
            objToken.token = "";

            var results = TestValidationHelper.Validate(objToken);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Token can not be empty string", results[0].ErrorMessage);
        }
    }
}
