using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace KymiraApplication.Model.Tests
{
    //This class will be used to test the Registration model object
    [TestClass()]
    public class RegistrationTests
    {
        //Create a Registration object to be used for testing purposes and a list to hold the validation results from each test 
        public Registration regTestOb;
        public List<ValidationResult> results;

        //Initialize the unit tests by instatiating the Registration object and validation results list
        [TestInitialize()]
        public void setup()
        {
           results = new List<ValidationResult>();
            regTestOb = new Registration("guy@email.com", "password1", "3066545456", "Guy", "Dude", "2018-10-10", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
        }

        //Test that an empty email address field in invalid
        [TestMethod()]
        public void TestThatEmailCannotBeEmpty()
        {

            regTestOb.emailAddress = "";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("An email address is required", results[0].ErrorMessage);

        }
        //Test that an email address that is more than 100 characters long is invalid
        [TestMethod()]
        public void TestThatEmailCannotBeMoreThan100Characters()
        {

            regTestOb.emailAddress = new string('a', 91) + "@gmail.com";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Email address must be between 1 and 100 characters", results[0].ErrorMessage);
        }
        //Test that an email address that is 100 characters is valid
        [TestMethod()]
        public void TestThatEmailis100Characters()
        {
            regTestOb.emailAddress = new string('a', 90) + "@gmail.com";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
            
        }
        //Test that an email address is in the correct format (has an @ symbol and a .com)
        [TestMethod()]
        public void TestThatEmailCannotBeInvalidFormat()
        {
            regTestOb.emailAddress = "guyemail.com";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Email address is not in a valid format", results[0].ErrorMessage);
        }
        //Test that an email address is in the correct format (has an @ symbol and a .com)
        [TestMethod()]
        public void TestThatEmailEnteredIsValid()
        {
            regTestOb.emailAddress = "email@email.com";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
           
        }
        //Test that a password field that is empty is not valid
        [TestMethod()]
        public void TestThatPasswordCannotBeEmpty()
        {
            regTestOb.password = "";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A password is required", results[0].ErrorMessage);
        }
        //Test that a password field can't be shorter than 8 characters
        [TestMethod()]
        public void TestThatPasswordCannotbe5CharactersLong()
        {
            regTestOb.password = "aaaaa";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Password must be between 8 and 50 characters", results[0].ErrorMessage);
        }
        //Test that a password that is 8 characters is valid
        [TestMethod()]
        public void TestThatPasswordisValidat8characters()
        {
            regTestOb.password = "aaaaaaaa";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
            
        }
        //Test that a password that is 50 characters long is valid
        [TestMethod()]
        public void TestThatPasswordis50Characters()
        {
            regTestOb.password = new string('a', 50);
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
           
        }
        //Test that a password cannot be more than 50 characters long
        [TestMethod()]
        public void TestThatPasswordCannotBeMorethan50Characters()
        {
            regTestOb.password = new string('a', 51);
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Password must be between 8 and 50 characters", results[0].ErrorMessage);
        }
        //Test that phone number field cannot be empty
        [TestMethod()]
        public void TestThatPhoneNumbercannotBeEmpty()
        {
            regTestOb.phoneNumber = "";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A phone number is required", results[0].ErrorMessage);
        }
        //Test that phone number field can only contain 10 digits
        [TestMethod()]
        public void TestThatPhoneNumberCanOnlyBeDigits()
        {
            regTestOb.phoneNumber = "a1231";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone number must contain 10 digits", results[0].ErrorMessage);
        }
        //Test that phone number field can only contain 10 digits
        [TestMethod()]
        public void TestThatPhoneNumberCanBe10Digits()
        {
            regTestOb.phoneNumber = "1234567891";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
           
        }
        //Test that a phone number can't be longer than 10 digits
        [TestMethod()]
        public void TestThatPhoneNumberCannotBe11digits()
        {
            regTestOb.phoneNumber = "30665245456";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone number must contain 10 digits", results[0].ErrorMessage);
        }
        //Test that a phone number can't be longer than 10 digits
        [TestMethod()]
        public void TestThatPhoneNumberCannotBe9Digits()
        {
            regTestOb.phoneNumber = "123467891";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone number must contain 10 digits", results[0].ErrorMessage);
        }
        //Test that first name field cannot be empty
        [TestMethod()]
        public void TestThatFirstNameFieldCannotBeEmpty()
        {
            regTestOb.firstName = "";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A first name is required", results[0].ErrorMessage);
        }
        //Test that first name field is at least 1 character long
        [TestMethod()]
        public void TestThatFirstNameFieldHas1Character()
        {
            regTestOb.firstName = "G";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
            
        }
        //Test that first name cannot be longer than 50 characters
        [TestMethod()]
        public void TestThatFirstNameCannotHaveMorethan50Characters()
        {
            regTestOb.firstName = new string('a', 51);
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("First name must be between 1 and 50 characters", results[0].ErrorMessage);
        }
        //Test that first name that is 50 characters long is valid
        [TestMethod()]
        public void TestThatFirstNameFieldHas50characters()
        {
            regTestOb.firstName = new string('a', 50);
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
           
        }
        //Test that last name field cannot be empty
        [TestMethod()]
        public void TestThatLastNameCannotBeEmpty()
        {
            regTestOb.lastName = "";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A last name is required", results[0].ErrorMessage);
        }
        //Test that last name field has at least 1 character
        [TestMethod()]
        public void TestThatLastNameFieldHas1Character()
        {
            regTestOb.lastName = ("a");
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
           
        }
        //Test that last name field has more than 50 characters
        [TestMethod()]
        public void TestThatLastNameFieldHasMoreThan50Characters()
        {
            regTestOb.lastName = new string('a', 51);
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Last name must be between 1 and 50 characters", results[0].ErrorMessage);
        }
        [TestMethod()]
        //Test that last name of 50 charactesr is valid
        public void TestThatLastNameFieldHas50Characters()
        {
            regTestOb.lastName = new string('a', 50);
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
           
        }
        //Test that birth date cannot be empty
        [TestMethod()]
        public void TestThatBirthDateCannotBeEmpty()
        {
            regTestOb.birthDate ="";
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A birth date is required", results[0].ErrorMessage);
        }
        //Test that birth date cannot be less than 8 characters
        [TestMethod()]
        public void TestThatBirthDateCannotHaveLessThan8Characters()
        {
            regTestOb.birthDate = "10193";

            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Birth date must be a valid date.", results[0].ErrorMessage);
        }
        //Test that birth date with 8 characters is valid
        [TestMethod()]
        public void TestThatBirthDateHas8characters()
        {
            regTestOb.birthDate = "2000-10-10";

            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
            

        }
        //Test that address line 1 field can't be empty
        [TestMethod()]
        public void TestThatAddressLine1FieldCannotBeEmpty()
        {
            regTestOb.addressLine1 = "";

            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("An Address is required", results[0].ErrorMessage);
        }
        //Test that address line 1 field can't be less than 10 characters
        [TestMethod()]
        public void TestThatAddressLine1CannotBeLessThan10Characters()
        {
            regTestOb.addressLine1 = "onetwoth";

            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("The address must be between 10 and 200 characters", results[0].ErrorMessage);
        }
        //Test that address line 1 with 10 characters is valid
        [TestMethod()]
        public void TestThatAddressLine1CanHave10Characters()
        {
            regTestOb.addressLine1 = new string('a', 10);

            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
          
        }
        //Test that address line 1 that is 200 characters long is valid
        [TestMethod()]
        public void TestThatAddressLine1CanHave200Characters()
        {
            regTestOb.addressLine1 = new string('a', 200);

            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
           
        }
        //Test that address line 1 can't be longer than 200 characters
        [TestMethod()]
        public void TestThatAddressLine1CannotHaveMoreThan200Characters()
        {
            regTestOb.addressLine1 = new string('a', 201);

            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("The address must be between 10 and 200 characters", results[0].ErrorMessage);
        }
        //Test that address line 2 cannot be more than 200 characters
        [TestMethod()]
        public void TestThatAddressLine2CanNotHaveMoreThan200Characters()
        {
            regTestOb.addressLine2 = new string('a', 201);

            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Must be less than 200 characters", results[0].ErrorMessage);
        }
        //Test that address line 2 is valid if it's empty (not required)
        [TestMethod()]
        public void TestThatAddressLine2CanBeEMpty()
        {
            regTestOb.addressLine2 = "";

  
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
            
        }
        //Test that city field cannot be empty
        [TestMethod()]
        public void TestThatCityCannotBeEmpty()
        {
            regTestOb.city = "";

           
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A City is required", results[0].ErrorMessage);
        }
        //Test that city field is at least 1 character long
        [TestMethod()]
        public void TestThatCityHas1Character()
        {

            regTestOb.city = "a";

            
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
          
        }
        //Test that city with 100 characters is valid
        [TestMethod()]
        public void TestThatCityHas100Character()
        {
            regTestOb.city = new string ('a', 100);

            
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
           
        }
        //Test that city cannot be longer than 100 characters
        [TestMethod()]
        public void TestThatCityCannotHaveMoreThan100Character()
        {
            regTestOb.city = new string('a', 101);

           
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("The city must be between 1 and 100 characters", results[0].ErrorMessage);
        }
        //Test that province field cannot be empty
        [TestMethod()]
        public void TestThatProvinceFieldCannotBeEmpty()
        {
            regTestOb.province = "";

           
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A province is required", results[0].ErrorMessage);
        }
        //Test that province field can have 100 characters
        [TestMethod()]
        public void TestThatProvinceFieldCanHave100Charcters()
        {
            regTestOb.province = new string('a', 100); ;



            
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
            
        }
        //Test that province field cannot be longer than 100 characters
        [TestMethod()]
        public void TestThatProvinceFieldCannotHaveMorethan100Characters()
        {
            regTestOb.province = new string('a', 101); ;

            
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("The province must be between 1 and 100 characters ", results[0].ErrorMessage);
        }
        //Test that postal code field can't be empty
        [TestMethod()]
        public void TestThatPostalCodeCannotBeEmpty()
        {
            regTestOb.postalCode = "";

            
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A postal code is required", results[0].ErrorMessage);
        }
        //Test that postal code field can't have less than 6 characters
        [TestMethod()]
        public void TestThatPostalCodeCannotHaveLessThan6Characters()
        {
            regTestOb.postalCode = "s4t2n";

          
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);
        }
        //Test that postal code that is 6 characters is valid
        [TestMethod()]
        public void TestThatPostalCodeHas6Characters()
        {
            regTestOb.postalCode = "S4T2N4";

            
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
            
        }
        //Test that postal code can't be longer than 6 characters
        [TestMethod()]
        public void TestThatPostalCodeCannotHaveMorethan6Characters()
        {
            regTestOb.postalCode = "s4t2n4a";

            
            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);
        }
        //Test that postal code that is in an invalid format is invalid
        [TestMethod()]
        public void TestThatPostalCodeisNotInValidForm()
        {
            regTestOb.postalCode = "s4t2n4a";


            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);
        }
        //Test that postal code that is in valid format is valid
        [TestMethod()]
        public void TestThatPostalCodeisInValidFormat()
        {
            regTestOb.postalCode = "S4T7P8";


            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
        }
        //Test that a checked terms check box is valid
        [TestMethod()]
        public void TestThatTermsBoxIsChecked()
        {
            regTestOb.termsCheckBox = true;


            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(0, results.Count());
        }
        //Test that an unchecked terms check box is invalid
        [TestMethod()]
        public void TestThatTermsCheckBoxIsNotChecked()
        {
            regTestOb.termsCheckBox = false;


            results = TestValidationHelper.Validate(regTestOb);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("You must agree to the terms and conditions", results[0].ErrorMessage);
        }













    }
}