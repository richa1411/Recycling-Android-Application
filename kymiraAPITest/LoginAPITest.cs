using Microsoft.VisualStudio.TestTools.UnitTesting;
using kymiraAPI;
using kymiraAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using kymiraAPITest;
using System.Linq;

namespace kymiraAPITest
{
    /**********************************/
    /******* PHONE NUMBER TESTS *******/
    /**********************************/
    [TestClass]
    public class TestLogin
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
            public void TestThatPhoneNumberIsEmpty()

            {
                //Test phone number is empty string
                objCred.phoneNumber = "";


                var results = APIValidationHelper.Validate(objCred);
                Assert.AreEqual(1, results.Count());
                Assert.AreEqual("Please enter a valid phone number", results[0].ErrorMessage);
            }
            [TestMethod]
            public void TestThatPhoneNumberIsNotEmpty()

            {
                //test phonenumber is non empty
                var results = APIValidationHelper.Validate(objCred);

                objCred.phoneNumber = "1234567890";
                results = APIValidationHelper.Validate(objCred);
                Assert.AreEqual(0, results.Count());


            }

            [TestMethod]
            public void TestThatPhoneNumberNonDigits()
            {
                //test phonenumber contains characters and digits instead of just digits
                objCred.phoneNumber = "JohnDoe1238";
                var results = APIValidationHelper.Validate(objCred);
                Assert.AreEqual(1, results.Count());
                Assert.AreEqual("Phone number must be 10 digits", results[0].ErrorMessage);

            }

            [TestMethod]
            public void TestThatPhoneNumberOnlyDigits()
            {
                //Test phone number contains digits
                objCred.phoneNumber = "1234567890";
                var results = APIValidationHelper.Validate(objCred);
                Assert.AreEqual(0, results.Count());

            }

            [TestMethod]
            public void TestThatPhoneNumberTenDigitLength()
            {
                //Test phone number contains 10 digits
                objCred.phoneNumber = "3456789096";
                var results = APIValidationHelper.Validate(objCred);
                Assert.AreEqual(0, results.Count());

            }

            [TestMethod]
            public void TestThatPhoneNumberExceedTenDigit()
            {
                //Test phoneNumber contains more than 10 digits
                objCred.phoneNumber = "34567890965657";
                var results = APIValidationHelper.Validate(objCred);
                Assert.AreEqual(1, results.Count());
                Assert.AreEqual("Phone number must be 10 digits", results[0].ErrorMessage);
            }

            [TestMethod]
            public void TestThatPhoneNumberLessThanTenDigit()
            {
                //Test phoneNumber contains less than 10 digits
                objCred.phoneNumber = "345678";
                var results = APIValidationHelper.Validate(objCred);
                Assert.AreEqual(1, results.Count());
                Assert.AreEqual("Phone number must be 10 digits", results[0].ErrorMessage);

            }

            /*  Unit tests for Password  */

            [TestMethod]
            public void TestThatPasswordIsEmpty()
            {
                //Test password with an empty string
                objCred.password = "";
                var results = APIValidationHelper.Validate(objCred);

                Assert.AreEqual(1, results.Count);
                Assert.AreEqual("Please enter your password", results[0].ErrorMessage);
            }

            [TestMethod]
            public void TestThatPasswordIsNotEmpty()
            {
                //Test password with an non empty string
                objCred.password = "shah1108";
                var results = APIValidationHelper.Validate(objCred);

                Assert.AreEqual(0, results.Count);

            }

            [TestMethod]
            public void TestThatPasswordIsSixChar()
            {
                //Test Password is 6 characters
                objCred.password = "Shh@11";

                var results = APIValidationHelper.Validate(objCred);

                Assert.AreEqual(0, results.Count);
            }

            [TestMethod]
            public void TestThatPasswordIsFiftyChar()
            {
                //Test Password is 50 characters
                objCred.password = new string('a', 50);

                var results = APIValidationHelper.Validate(objCred);

                Assert.AreEqual(0, results.Count);
            }

            [TestMethod]
            public void TestThatPasswordLessThanSixChar()
            {
                //Test password is less than 6 characters
                objCred.password = "Shh@1"; // Password is only 5 characters

                var results = APIValidationHelper.Validate(objCred);

                Assert.AreEqual(1, results.Count);
                Assert.AreEqual("Password must be between 6 - 50 characters", results[0].ErrorMessage);

            }

            [TestMethod()]
            public void TestThatPasswordBetweenSixAndFiftyChars()
            {
                //Test password is greater than 6 characters but less than 50 charcaters
                objCred.password = "P@ssw0rd1178"; // Password at lower boundary

                var results = APIValidationHelper.Validate(objCred);

                Assert.AreEqual(0, results.Count);
            }

            [TestMethod()]
            public void TestThatPasswordGreaterThanFiftyChars()
            {
                //Test Password is 51 characters
                objCred.password = new string('a', 51);

                var results = APIValidationHelper.Validate(objCred);

                Assert.AreEqual(1, results.Count);
                Assert.AreEqual("Password must be between 6 - 50 characters", results[0].ErrorMessage);
            }

            [TestMethod()]
        public void TestThatTokenIsGUIDFormat()
        {
            //Test token is in GUID format 
            objToken.token = "1bf89a1c-3934-4e5b-b7be-7bfb766689c2";

            var results = APIValidationHelper.Validate(objToken);

            Assert.AreEqual(0, results.Count);

        }
        [TestMethod()]
        public void TestThatTokenIsNotInGUIDFormat()
        {
            //Test token is not in GUID format 
            objToken.token = "1bf89a1c/fdhdhdf4356656546+fghf&";

            var results = APIValidationHelper.Validate(objToken);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Token is not in proper GUID format", results[0].ErrorMessage);
        }

        [TestMethod()]
        public void TestThatTokenIsNull()
        {
            //Test token is null (blank)
            objToken.token = "";

            var results = APIValidationHelper.Validate(objToken);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Token can not be empty string", results[0].ErrorMessage);
        }

    }
}
