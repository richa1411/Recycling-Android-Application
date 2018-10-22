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

namespace KymiraApplicationTests.Model
{
    public class TestCredentials
    {

        [TestMethod()]
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
//        [TestMethod()]
//        public void Validate_Credential_PhonenumberRequired_Test()
//        {
//            // Assemble
//            var credential = new Credentials
//            {
                
//                phoneNumber = null,
//                password = "ES330fg34545"
//            };

//            // Act
//            var validationResults = new List<ValidationResult>();
//            var actual = Validator.TryValidateObject(credential, new ValidationContext(credential), validationResults, true);

//            // Assert
//           // Assert.IsFalse(actual, "Expected validation to fail.");
////            Assert.AreEqual(1, validationResults.Count, "Unexpected number of validation errors.");
//          var msg = validationResults[0];
//           // Assert.AreEqual(, msg.ErrorMessage);
//            //Assert.AreEqual(1, msg.MemberNames.Count(), "Unexpected number of member names.");
//           // Assert.AreEqual("phoneNumber", msg.MemberNames.ElementAt(0));
//        }

//        [TestMethod()]
//        public static void TestPhoneNumberNotEmpty()
//        {
//            Credentials objCredentials = new Credentials { phoneNumber = "1234567890", password = "1234567" };
//            var results = HelperTestModel.Validate(objCredentials);
//            Assert.AreEqual(0, results.Count());
//        }

//        [TestMethod()]
//        public static void TestPhoneNumberOnlyDigits()
//        {

//            Credentials objCredentials = new Credentials { phoneNumber = "12345678900", password = "1234567" };


//            String phoneCheck = objCredentials.getPhone();
//            bool trueDigit;
//            foreach (char c in phoneCheck)
//            {
//                if (c >= '0' || c <= '9')
//                {


//                    Credentials objCredentials = new Credentials { phoneNumber = "12345678900", password = "1234567" };

//                    String phoneCheck = objCredentials.getPhone();
//                    bool trueDigit;
//                    foreach (char c in phoneCheck)
//                    {
//                        if (c >= '0' || c <= '9')
//                        {

//                            trueDigit = true;
//                            Assert.IsTrue(trueDigit);
//                        }
//                    }
//                }
//            }
//        }

        //[TestMethod()]
        //public static void TestPhoneNumberTenDigitLegth()
        //{

        //    KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "shah11081");
        //    Assert.AreEqual(9, objCredentials.getPhone().Length);

        //   KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "shah11081");
        //   Assert.AreEqual(10, objCredentials.getPhone().Length);

        //}

        //[TestMethod()]
        //public static void TestPhoneNumberExceedTenDigit()
        //{
        //    KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892454656", "shah11081");


        //    Assert.IsTrue(objCredentials.getPhone().Length > 10);

        //    Assert.IsTrue(objCredentials.getPhone().Length > 10);

        //}

        //[TestMethod()]
        //public static void TestPhoneNumberLessThanTenDigit()
        //{
        //    KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512", "shah11081");

        //    Assert.IsTrue(objCredentials.getPhone().Length < 10);
        //}

        //[TestMethod()]
        //public static void TestPasswordNotEmpty()
        //{
        //    KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "");

        //    Assert.AreEqual("", objCredentials.getPassword());

        //}

        //[TestMethod()]
        //public static void TestPasswordLessThanSixChar()
        //{
        //    KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "shah1");

        //    Assert.IsTrue(objCredentials.getPassword().Length < 6);
        //}

        //[TestMethod()]
        //public static void TestPasswordBetweenSixAndTwelveChar()
        //{
        //    KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "shah11");
        //    KymiraApplication.Model.Credentials objCredentials2 = new KymiraApplication.Model.Credentials("4512367892", "shahricha110");




        //    Assert.IsTrue(objCredentials2.getPassword().Length == 6);

        //    Assert.IsTrue(objCredentials.getPassword().Length == 12);


        //    KymiraApplication.Model.Credentials objCredentials3 = new KymiraApplication.Model.Credentials("4512367892", "richa11011");

        //    Assert.IsTrue(objCredentials.getPassword().Length == 6);
        //    Assert.IsTrue(objCredentials2.getPassword().Length == 12);
        //    Assert.IsTrue(objCredentials3.getPassword().Length <= 12 && objCredentials3.getPassword().Length >= 6);


        //}

        //[TestMethod()]
        //public static void TestPasswordGreaterThanTwelveChar()
        //{
        //    KymiraApplication.Model.Credentials objCredentials = new KymiraApplication.Model.Credentials("4512367892", "shahricha110464fg");
        //    Assert.IsTrue(objCredentials.getPassword().Length > 12);

        }
        }

    