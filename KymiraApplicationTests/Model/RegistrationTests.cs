using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace KymiraApplication.Models.Tests
{
    [TestClass()]
    public class RegistrationTests
    {
        public Registration regTestgood;
        public Registration regtestBad;
        public List<ValidationResult> results;

        [TestInitialize()]
        public void setup()
        {
           results = new List<ValidationResult>();
            regtestBad = new Registration("guy@email.com", "password1", "3066545456", "Guy", "Dude", "2018-10-10", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            //regtestBad = new Registration("guy@email.com", "password1", "3045456", "Guy", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T53", true);
        }
        [TestMethod()]
        public void RegistrationTest()
        {
            
        }
        [TestMethod()]
        public void testThatEmailCannotBeEpmpty()
        {

            regtestBad.emailAddress = "";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("An email address is required", results[0].ErrorMessage);

        }
        [TestMethod()]
        public void testThatEmailCannotBeMoreThan100Characters()
        {

            regtestBad.emailAddress = new string('a', 91) + "@gmail.com";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Email address must be between 1 and 100 characters", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatEmailis100Characters()
        {
            regtestBad.emailAddress = new string('a', 90) + "@gmail.com";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
            
        }
        [TestMethod()]
        public void testThatEmailCannotBeInvalidFormat()
        {
            regtestBad.emailAddress = "guyemail.com";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Email address is not in a valid format", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatEmailEnteredIsValid()
        {
            regtestBad.emailAddress = "email@email.com";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
           
        }
        [TestMethod()]
        public void testThatPasswordCannotBeEmpty()
        {
            regtestBad.password = "";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A password is required", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatPasswordCannotbe5CharactersLong()
        {
            regtestBad.password = "aaaaa";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Password must be between 8 and 50 characters", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatPasswordisValidat8characters()
        {
            regtestBad.password = "aaaaaaaa";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
            
        }
        [TestMethod()]
        public void testThatPasswordis50Characters()
        {
            regtestBad.password = new string('a', 50);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
           
        }
        [TestMethod()]
        public void testThatPasswordCannotBeMorethan50Characters()
        {
            regtestBad.password = new string('a', 51);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Password must be between 8 and 50 characters", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatPhoneNumbercannotBeEmpty()
        {
            regtestBad.phoneNumber = "";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A phone number is required", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatPhoneNumberCanOnlyBeDigits()
        {
            regtestBad.phoneNumber = "a1231";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone number must contain 10 digits", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatPhoneNumberCanBe10Digits()
        {
            regtestBad.phoneNumber = "1234567891";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
           
        }
        [TestMethod()]
        public void testThatPhoneNumberCannotBe11digits()
        {
            regtestBad.phoneNumber = "30665245456";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone number must contain 10 digits", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatPhoneNumberCannotBe9Digits()
        {
            regtestBad.phoneNumber = "123467891";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Phone number must contain 10 digits", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatFirstNameFieldCannotBeEmpty()
        {
            regtestBad.firstName = "";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A first name is required", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatFirstNameFieldHas1Character()
        {
            regtestBad.firstName = "G";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
            
        }
        [TestMethod()]
        public void testThatFirstNameCannotHaveMorethan50Characters()
        {
            regtestBad.firstName = new string('a', 51);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("First name must be between 1 and 50 characters", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatFirstNameFieldHas50characters()
        {
            regtestBad.firstName = new string('a', 50);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
           
        }
        [TestMethod()]
        public void testThatLastNameCannotBeEmpty()
        {
            regtestBad.lastName = "";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A last name is required", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatLastNameFieldHas1Character()
        {
            regtestBad.lastName = ("a");
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
           
        }
        [TestMethod()]
        public void testThatLastNameFieldHasMoreThan50Characters()
        {
            regtestBad.lastName = new string('a', 51);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Last name must be between 1 and 50 characters", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatLastNameFieldHas50Characters()
        {
            regtestBad.lastName = new string('a', 50);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
           
        }
        [TestMethod()]
        public void testThatBirthDateCannotBeEmpty()
        {
            regtestBad.birthDate ="";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A birth date is required", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatBirthDateCannotHaveLessThan8Characters()
        {
            regtestBad.birthDate = "10193";

            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Birth date must be a valid date.", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatBirthDateHas8characters()
        {
            regtestBad.birthDate = "2000-10-10";

            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
            

        }
        [TestMethod()]
        public void testThatAddressLine1FieldCannotBeEmpty()
        {
            regtestBad.addressLine1 = "";

            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("An Address is required", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatAddressLine1CannotBeLessThan10Characters()
        {
            regtestBad.addressLine1 = "onetwoth";

            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("The address must be between 10 and 200 characters", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatAddressLine1CanHave10Characters()
        {
            regtestBad.addressLine1 = new string('a', 10);

            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
          
        }
        [TestMethod()]
        public void testThatAddressLine1CanHave200Characters()
        {
            regtestBad.addressLine1 = new string('a', 200);

            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
           
        }
        [TestMethod()]
        public void testThatAddressLine1CannotHaveMoreThan200Characters()
        {
            regtestBad.addressLine1 = new string('a', 201);

            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("The address must be between 10 and 200 characters", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatAddressLine2CanNotHaveMoreThan200Characters()
        {
            regtestBad.addressLine2 = new string('a', 201);

            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Must be less than 200 characters", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatAddressLine2CanBeEMpty()
        {
            regtestBad.addressLine2 = "";

  
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
            
        }
        [TestMethod()]
        public void testThatCityCannotBeEmpty()
        {
            regtestBad.city = "";

           
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A City is required", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatCityHas1Character()
        {

            regtestBad.city = "a";

            
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
          
        }
        [TestMethod()]
        public void testThatCityHas100Character()
        {
            regtestBad.city = new string ('a', 100);

            
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
           
        }
        [TestMethod()]
        public void testThatCityCannotHaveMoreThan100Character()
        {
            regtestBad.city = new string('a', 101);

           
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("The city must be between 1 and 100 characters", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatProvinceFieldCannotBeEmpty()
        {
            regtestBad.province = "";

           
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A province is required", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatProvinceFieldCanHave100Charcters()
        {
            regtestBad.province = new string('a', 100); ;



            
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
            
        }
        [TestMethod()]
        public void testThatProvinceFieldCannotHaveMorethan100Characters()
        {
            regtestBad.province = new string('a', 101); ;

            
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("The province must be between 1 and 100 characters ", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatPostalCodeCannotBeEmpty()
        {
            regtestBad.postalCode = "";

            
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("A postal code is required", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatPostalCodeCannotHaveLessThan6Characters()
        {
            regtestBad.postalCode = "s4t2n";

          
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatPostalCodeHas6Characters()
        {
            regtestBad.postalCode = "S4T2N4";

            
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
            
        }
        [TestMethod()]
        public void testThatPostalCodeCannotHaveMorethan6Characters()
        {
            regtestBad.postalCode = "s4t2n4a";

            
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void testThatPostalCodeisNotInValidForm()
        {
            regtestBad.postalCode = "s4t2n4a";


            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);
        }
        [TestMethod()]
        public void TestThatPostalCodeisInValidFormat()
        {
            regtestBad.postalCode = "S4T7P8";


            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
        }
        [TestMethod()]
        public void testThatTermsBoxIsChecked()
        {
            regtestBad.termsCheckBox = true;


            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());
        }
        [TestMethod()]
        public void testThatTermsCheckBoxIsNotChecked()
        {
            regtestBad.termsCheckBox = false;


            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("You must agree to the terms and conditions", results[0].ErrorMessage);
        }













    }
}