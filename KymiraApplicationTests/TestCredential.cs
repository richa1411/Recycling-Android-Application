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
            loginCreds = new Credentials { phoneNumber = "1234567890", password = "P@ssw0rd" };
        }


        /*
        *  Tests that the phone number cannot be empty
        */
        [TestMethod]
        public void TestPhoneNumberNotEmpty()

        {
            loginCreds.phoneNumber = "";
            

            var results = HelperTestModel.Validate(loginCreds);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone number is required", results[0].ErrorMessage);
            loginCreds.phoneNumber = "1234567890";
            results = HelperTestModel.Validate(loginCreds);
            Assert.AreEqual(0, results.Count());
            

        }

         [TestMethod]
          public  void TestPhoneNumberOnlyDigits()
          {
            loginCreds.phoneNumber = "shahsjhd67";
            var results = HelperTestModel.Validate(loginCreds);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone Number is not 10 digits", results[0].ErrorMessage);

            loginCreds.phoneNumber = "1234567890";
            results = HelperTestModel.Validate(loginCreds);
            Assert.AreEqual(0, results.Count());

        }

        /*  [TestMethod()]
          public void TestPhoneNumberTenDigitLegth()
          {

              KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "shah11081");
              Assert.AreEqual(9, objCredentials.getPhone().Length);

             KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "shah11081");
             Assert.AreEqual(10, objCredentials.getPhone().Length);

          }

          [TestMethod()]
          public  void TestPhoneNumberExceedTenDigit()
          {
              KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892454656", "shah11081");


              Assert.IsTrue(objCredentials.getPhone().Length > 10);

              Assert.IsTrue(objCredentials.getPhone().Length > 10);

          }

          [TestMethod()]
          public static void TestPhoneNumberLessThanTenDigit()
          {
              KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512", "shah11081");

              Assert.IsTrue(objCredentials.getPhone().Length < 10);
          }

          [TestMethod()]
          public static void TestPasswordNotEmpty()
          {
              KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "");

              Assert.AreEqual("", objCredentials.getPassword());

          }

          [TestMethod()]
          public static void TestPasswordLessThanSixChar()
          {
              KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "shah1");

              Assert.IsTrue(objCredentials.getPassword().Length < 6);
          }

          [TestMethod()]
          public static void TestPasswordBetweenSixAndTwelveChar()
          {
              KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "shah11");
              KymiraApplication.Model.Credentials objCredentials2 = new KymiraApplication.Model.Credentials("4512367892", "shahricha110");




              Assert.IsTrue(objCredentials2.getPassword().Length == 6);

              Assert.IsTrue(objCredentials.getPassword().Length == 12);


              KymiraApplication.Model.Credentials objCredentials3 = new KymiraApplication.Model.Credentials("4512367892", "richa11011");

              Assert.IsTrue(objCredentials.getPassword().Length == 6);
              Assert.IsTrue(objCredentials2.getPassword().Length == 12);
              Assert.IsTrue(objCredentials3.getPassword().Length <= 12 && objCredentials3.getPassword().Length >= 6);


          }

          [TestMethod()]
          public static void TestPasswordGreaterThanTwelveChar()
          {
              KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "shahricha110464fg");
              Assert.IsTrue(objCredentials.getPassword().Length > 12);

          }
          }*/

    }
}
