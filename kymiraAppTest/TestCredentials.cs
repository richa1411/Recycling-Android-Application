using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace kymiraAppTest
{
    public class TestCredentials
    {

        [Test]
        public void Validate_Credentials_Valid_Test()
        {
            // Assemble
            var credential = new Credentials
                
        {
           phoneNumber = "1234567892",
           password="shah110811"
        };
 
    // Act
    var validationResults = new List<ValidationResult>();
    var actual = Validator.TryValidateObject(credential, new ValidationContext(credential), validationResults, true);
 
    // Assert
    Assert.IsTrue(actual, "Expected validation to succeed.");
    Assert.AreEqual(0, validationResults.Count, "Unexpected number of validation errors.");
}
        [Test]
        public void Validate_Credential_PhonenumberRequired_Test()
        {
            // Assemble
            var credential = new Credentials
            {
                
                phoneNumber = null,
                password = "ES330fg34545"
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(credential, new ValidationContext(credential), validationResults, true);

            // Assert
           // Assert.IsFalse(actual, "Expected validation to fail.");
//            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
          var msg = validationResults[0];
           // Assert.AreEqual(, msg.ErrorMessage);
            //Assert.AreEqual(1, msg.MemberNames.Count(), "Unexpected number of member names.");
           // Assert.AreEqual("phoneNumber", msg.MemberNames.ElementAt(0));
        }

       /* [Test]
        public static void TestPhoneNumberNotEmpty()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("", "shah11081");
            Assert.AreEqual("", objCredentials.getPhone());
        }

        [Test]
        public static void TestPhoneNumberOnlyDigits()
        {

         kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shah11081");

         String phoneCheck = objCredentials.getPhone();
         bool trueDigit;
          foreach(char c in phoneCheck)
            {
                if (c >= '0' || c <= '9')
                {
                    trueDigit = true;
                    Assert.IsTrue(trueDigit);
                }
            }
        }

        [Test]
        public static void TestPhoneNumberTenDigitLegth()
        {
           kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shah11081");
           Assert.AreEqual(10, objCredentials.getPhone().Length);
        }

        [Test]
        public static void TestPhoneNumberExceedTenDigit()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892454656", "shah11081");
            Assert.IsTrue(objCredentials.getPhone().Length > 10);
        }

        [Test]
        public static void TestPhoneNumberLessThanTenDigit()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512", "shah11081");
            Assert.IsTrue(objCredentials.getPhone().Length < 10);
        }

        [Test]
        public static void TestPasswordNotEmpty()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "");
            Assert.AreEqual("", objCredentials.getPassword());

        }

        [Test]
        public static void TestPasswordLessThanSixChar()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shah1");
            Assert.IsTrue(objCredentials.getPassword().Length < 6);
        }

        [Test]
        public static void TestPasswordBetweenSixAndTwelveChar()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shah11");
            kymiraApp.Credentials objCredentials2 = new kymiraApp.Credentials("4512367892", "shahricha110");
            kymiraApp.Credentials objCredentials3 = new kymiraApp.Credentials("4512367892", "richa11011");

            Assert.IsTrue(objCredentials.getPassword().Length == 6);
            Assert.IsTrue(objCredentials2.getPassword().Length == 12);
            Assert.IsTrue(objCredentials3.getPassword().Length <= 12 && objCredentials3.getPassword().Length >= 6);

        }

        [Test]
        public static void TestPasswordGreaterThanTwelveChar()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shahricha110464fg");
            Assert.IsTrue(objCredentials.getPassword().Length > 12);
        }*/
    }
}
