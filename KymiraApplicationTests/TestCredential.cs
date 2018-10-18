using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using KymiraApplication.Model;

namespace KymiraApplicationTests
{
    [TestClass]
    public class TestCredentials
    {
       

        Credentials objCred;
        /*
        *  Setups a Credentials object with a phone number, password, and message
        */
        [TestInitialize]
        public void InitializeTest()
        {
            objCred = new Credentials { phoneNumber = "1234567890", password = "P@ssw0rd" };
        }


        /*   Unit tests for Phonenumber   */

        [TestMethod]
        public void TestPhoneNumberIsEmpty()

        {
            //Test phone number is empty string
            objCred.phoneNumber = "";


            var results = HelperTestModel.Validate(objCred);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone number is required", results[0].ErrorMessage);
        }
        [TestMethod]
        public void TestPhoneNumberIsNotEmpty()

        {
            //test phonenumber is non empty
            var results = HelperTestModel.Validate(objCred);
            
            objCred.phoneNumber = "1234567890";
            results = HelperTestModel.Validate(objCred);
            Assert.AreEqual(0, results.Count());
            

        }

        [TestMethod]
        public void TestPhoneNumberNonDigits()
        {
            //test phonenumber contains characters instead digits
            objCred.phoneNumber = "shahsjhghr";
            var results = HelperTestModel.Validate(objCred);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone Number is not 10 digits", results[0].ErrorMessage);

            //Test phone number contains combination of charcatres and digits
            objCred.phoneNumber = "shahsjh678";
            results = HelperTestModel.Validate(objCred);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone Number is not 10 digits", results[0].ErrorMessage);
        }

            [TestMethod]
        public void TestPhoneNumberOnlyDigits()
        {
            //Test phone number contains digits
            objCred.phoneNumber = "1234567890";
            var results = HelperTestModel.Validate(objCred);
            Assert.AreEqual(0, results.Count());

        }

         [TestMethod]
          public void TestPhoneNumberTenDigitLegth()
          {
            //Test phone number contains 10 digits
            objCred.phoneNumber = "3456789096";
            var results = HelperTestModel.Validate(objCred);
            Assert.AreEqual(0, results.Count());
            
        }

          [TestMethod]
          public  void TestPhoneNumberExceedTenDigit()
          {
            //Test phoneNumber contains more than 10 digits
            objCred.phoneNumber = "34567890965657";
            var results = HelperTestModel.Validate(objCred);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone Number is not 10 digits", results[0].ErrorMessage);
        }

          [TestMethod]
          public  void TestPhoneNumberLessThanTenDigit()
          {
            //Test phoneNumber contains less than 10 digits
            objCred.phoneNumber = "345678";
            var results = HelperTestModel.Validate(objCred);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone Number is not 10 digits", results[0].ErrorMessage);

        }

        /*  Unit tests for Password  */



        [TestMethod]
          public  void TestPasswordIsEmpty()
          {
            //Test password with an empty string
            objCred.password = "";
            var results = HelperTestModel.Validate(objCred);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password is required", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestPasswordIsNotEmpty()
        {
            //Test password with an non empty string
            objCred.password = "shah1108";
            var results = HelperTestModel.Validate(objCred);

            Assert.AreEqual(0, results.Count);
           
        }

        [TestMethod]
        public void TestPasswordISSixChar()
        {
            //Test Password is  6 characters
            objCred.password = "Shh@11"; 

            var results = HelperTestModel.Validate(objCred);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestPasswordISFiftyChar()
        {
            //Test Password is  50 characters
            objCred.password = new string('a', 50);

            var results = HelperTestModel.Validate(objCred);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
          public  void TestPasswordLessThanSixChar()
          {
            //Test password is less than 6 characters
            objCred.password = "Shh@1"; // Password is only 5 characters

            var results = HelperTestModel.Validate(objCred);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password must be in between 6 and 50 charcaters", results[0].ErrorMessage);

        }

          [TestMethod()]
          public  void TestPasswordBetweenSixAndFiftyChar()
          {
            //Test password is greater than 6 characters but less than 50 charcaters
            objCred.password = "P@ssw0rd1178"; // Password at lower boundary

            var results = HelperTestModel.Validate(objCred);

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod()]
          public  void TestPasswordGreaterThanFiftyChar()
          {
            //Test Password is  51 characters
            objCred.password = new string('a', 51);

            var results = HelperTestModel.Validate(objCred);

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password must be in between 6 and 50 charcaters", results[0].ErrorMessage);
        }
          }

    }

