using kymiraAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using kymiraAPI.Fixtures;

namespace kymiraAPITest
{
    [TestClass]
    public class ResidentAPITests
    {
        //Valid resident to use for testing
        Resident resident = new Resident
        {
            id = 1,
            firstName = "John",
            lastName = "Smith",
            birthDate = "1996-05-12",
            emailAddress = "john.smith@hotmail.com",
            phoneNumber = "3061234780",
            addressLine1 = "Fairhaven",
            addressLine2 = "Unit 6",
            city = "Saskatoon",
            province = "Saskatchewan",
            postalCode = "S7L5W4",
            password = "P@ssw0rd"
        };

        [TestInitialize]
        public async Task setup()
        {
            await fixture_story6b.load();
        }

        [TestCleanup]
        public async Task teardown()
        {
            await fixture_story6b.delete();
        }

        /*--------------------------------------First Name Field Testing-------------------------------------------------------------*/
        [TestMethod]
        /**
         * This method tests that the resident Model created above truly contains a valid first name.
         */
        public void TestThatFirstNameFieldGeneralIsValid()
        {
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident with a first name of 50 characters is valid.
         */
        public void TestThatFirstNameFieldOf50CharsIsValid()
        {
            resident.firstName = new string('h', 50);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident first name of an empty string is invalid.
         */
        public void TestThatFirstNameFieldOfEmptyStringIsInvalid()
        {
            resident.firstName = "";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("First name is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        /**
         * This method tests that a resident first name of 51 characters is invalid.
         */
        public void TestThatFirstNameFieldOf51CharsIsInvalid()
        {
            resident.firstName = new string('j', 51);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("First name must be 50 characters or less.", results[0].ErrorMessage);
        }


        /*--------------------------------------Last Name Field Testing-------------------------------------------------------------*/
        [TestMethod]
        /**
         * This method tests that the resident Model created above truly contains a valid last name.
         */
        public void TestThatLastNameFieldGeneralIsValid()
        {
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident with a last name of 50 characters is valid.
         */
        public void TestThatLastNameFieldOf50CharsIsValid()
        {
            resident.lastName = new string('h', 50);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident last name of an empty string is invalid.
         */
        public void TestThatLastNameFieldEmptyIsInvalid()
        {
            resident.lastName = "";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Last name is required.", results[0].ErrorMessage);
        }


        [TestMethod]
        /**
         * This method tests that a resident last name of 51 characters is invalid.
         */
        public void TestThatLastNameFieldOf51CharsIsInvalid()
        {
            resident.lastName = new string('j', 51);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Last name must be 50 characters or less.", results[0].ErrorMessage);
        }

        /*--------------------------------------Birth Date Field Testing-------------------------------------------------------------*/
        [TestMethod]
        /**
         * This method tests that the resident Model created above truly contains a valid birth date.
         */
        public void TestThatBirthDateFieldGeneralIsValid()
        {
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }


        [TestMethod]
        /**
         * This method tests that a resident birth date of any empty string is invalid.
         */
        public void TestThatDOBFieldEmptyIsInvalid()
        {
            resident.birthDate = "";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Birth Date is required.", results[0].ErrorMessage);
        }


        [TestMethod]
        /**
         * This method tests that a resident birth date NOT in the date format yyyy-dd-mm is invalid.
         */
        public void TestThatDOBFieldWrongFormatIsInvalid()
        {
            resident.birthDate = "222-99-038976";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Birth date must be a valid date.", results[0].ErrorMessage);
        }


        /*--------------------------------------Email Field Testing-------------------------------------------------------------*/
        [TestMethod]
        /**
         * This method tests that the resident Model created above truly contains a valid email.
         */
        public void TestThatEmailFieldGeneralIsValid()
        {
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident email of 100 characters following the correct email format is valid.
         */
        public void TestThatEmailFieldOf100CharsIsValid()
        {
            resident.emailAddress = new string('d', 88) + "@sasktel.net";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident email of an empty string is invalid.
         */
        public void TestThatEmailFieldEmptyIsInvalid()
        {
            resident.emailAddress = "";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Email is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        /**
         * This method tests that a resident email of 101 characters is invalid.
         */
        public void TestThatEmailFieldOf101CharsIsInvalid()
        {
            //test that email of 101 characters (following the correct format) is invalid
            resident.emailAddress = new string('y', 101) + "@sasktel.net";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Email must be 100 characters or less.", results[0].ErrorMessage);
        }

        [TestMethod]
        /**
         * This method tests that a resident email of NOT following the correct email format is invalid.
         */
        public void TestThatEmailFieldOfWrongFormatIsInvalid()
        {
            resident.emailAddress = new string('o', 7);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Email must be in email address format.", results[0].ErrorMessage);
        }

        /*--------------------------------------AddressLine1 Field Testing-------------------------------------------------------------*/
        [TestMethod]
        /**
         * This method tests that the resident Model created above truly contains a valid AddressLine1.
         */
        public void TestThatAddressLine1FieldGeneralIsValid()
        {
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }


        [TestMethod]
        /**
         * This method tests that a resident AddressLine1 of 200 characters is valid.
         */
        public void TestThatAddressLine1FieldOf200CharsIsValid()
        {
            resident.addressLine1 = new string('h', 200);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }


        [TestMethod]
        /**
         * This method tests that a resident AddressLine1 of 1 character is valid.
         */
        public void TestThatAddressLine1FieldOf1CharIsValid()
        {
            resident.addressLine1 = "g";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident AddressLine1 of empty string is invalid.
         */
        public void TestThatAddressLine1FieldEmptyIsInvalid()
        {
            resident.addressLine1 = "";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address line 1 is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        /**
         * This method tests that a resident AddressLine1 of 201 characters is invalid.
         */
        public void TestThatAddressLine1FieldOf201CharsIsInvalid()
        {
            resident.addressLine1 = new string('d', 201);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address line 1 must be 200 characters or less.", results[0].ErrorMessage);
        }


        /*--------------------------------------AddressLine2 Field Testing-------------------------------------------------------------*/
        [TestMethod]
        /**
         * This method tests that the resident Model created above truly contains a valid AddressLine2.
         */
        public void TestThatAddressLine2FieldGeneralIsValid()
        {
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }


        [TestMethod]
        /**
         * This method tests that a resident AddressLine2 of 200 characters is valid.
         */
        public void TestThatAddressLine2FieldOf200CharsIsValid()
        {
            //test that addressLine2 of 200 characters is valid
            resident.addressLine2 = new string('p', 200);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }


        [TestMethod]
        /**
         * This method tests that a resident AddressLine2 of 0 characters is valid.
         */
        public void TestThatAddressLine2FieldOf0CharsIsValid()
        {
            //test that Address2 of 0 characters is valid
            resident.addressLine2 = "";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }
        [TestMethod]
        /**
            * This method tests that an AddressLine2 field of 201 characters is invalid.
            */
        public void TestThatAddressLine2FieldOf201CharsIsInvalid()
        {
            //test that addressLine2 of 201 characters is invalid
            resident.addressLine2 = new string('d', 201);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address line 2 must be 200 characters or less.", results[0].ErrorMessage);
        }

        /*--------------------------------------Postal Code Field Testing-------------------------------------------------------------*/
        [TestMethod]
        /**
         * This method tests that the resident Model created above truly contains a valid Postal Code.
         */
        public void TestThatPostalCodeFieldGeneralIsValid()
        {
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a PostalCode Field of 5 characters is invalid
         */
        public void TestThatPostalCodeFieldOf5CharsIsInvalid()
        {
            //test that postalCode of 5 characters/digits is invalid
            resident.postalCode = "S0L0K";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);
        }

        [TestMethod]
        /**
         * This method tests that a PostalCode Field of 7 characters is invalid
         */
        public void TestThatPostalCodeFieldOf7CharsIsInvalid()
        {
            //test that postalCode of 7 characters/digits is invalid
            resident.postalCode = "S0L0K0E";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);
        }

        [TestMethod]
        /**
         * This method tests that a PostalCode Field in incorrect format is invalid
         */
        public void TestThatPostalCodeFieldOfIncorrectFormatIsInvalid()
        {
            //test that postalCode of incorrect format is invalid
            resident.postalCode = "SSS000";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);
        }

        [TestMethod]
        /**
         * This method tests that an empty PostalCode Field is invalid
         */
        public void TestThatPostalCodeFieldOfEmptyStringIsInvalid()
        {
            //test that postalCode of empty string is invalid
            resident.postalCode = "";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Postal code is required and must be 6 characters.", results[0].ErrorMessage);
        }

        /*--------------------------------------Province Field Testing-------------------------------------------------------------*/
        [TestMethod]
        /**
         * This method tests that the resident Model created above truly contains a valid Province.
         */
        public void TestThatProvinceFieldGeneralIsValid()
        {
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident Province of 100 characters is valid.
         */
        public void TestThatProvinceFieldOf100CharsIsValid()
        {
            resident.province = new string('h', 100);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident Province of 1 character is valid.
         */
        public void TestThatProvinceFieldOf1CharIsValid()
        {
            resident.province = "g";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that an empty resident Province is invalid.
         */
        public void TestThatEmptyProvinceFieldIsInvalid()
        {
            //test that province of empty string is invalid
            resident.province = "";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Province is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        /**
         * This method tests that a resident Province of 101 characters is invalid.
         */
        public void TestThatProvinceFieldOf101CharsIsInvalid()
        {
            //test that province of 101 characters is invalid
            resident.province = new string('i', 101);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Province must be 100 characters or less.", results[0].ErrorMessage);
        }


        /*--------------------------------------City Field Testing-------------------------------------------------------------*/
        [TestMethod]
        /**
         * This method tests that the resident Model created above truly contains a valid city.
         */
        public void TestThatCityFieldGeneralIsValid()
        {
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident city of 100 characters is valid.
         */
        public void TestThatCityFieldOf100CharsIsValid()
        {
            resident.city = new string('f', 100);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident city of 1 character is valid.
         */
        public void TestThatCityFieldOf1CharIsValid()
        {
            resident.city = "W";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);

        }

        [TestMethod]
        /**
         * This method tests that an empty resident City is invalid.
         */
        public void TestThatEmptyCityFieldIsInvalid()
        {
            //test that City of empty string is invalid
            resident.city = "";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("City is required.", results[0].ErrorMessage);

        }

        [TestMethod]
        /**
         * This method tests that a resident City of 101 characters is invalid.
         */
        public void TestThatCityFieldOf101CharsIsInvalid()
        {
            //test that city of 101 characters is invalid
            resident.city = new string('s', 101);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("City must be 100 characters or less.", results[0].ErrorMessage);
        }

        /*--------------------------------------Password Field Testing-------------------------------------------------------------*/
        [TestMethod]
        /**
         * This method tests that the resident Model created above truly contains a valid password.
         */
        public void TestThatPasswordFieldGeneralIsValid()
        {
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that a resident password of 50 characters is valid.
         */
        public void TestThatPasswordFieldOf50CharsIsValid()
        {
            resident.password = new string('s', 50);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that an empty resident password is invalid.
         */
        public void TestThatEmptyPasswordFieldIsInvalid()
        {
            //test that password of empty string is invalid
            resident.password = "";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        /**
         * This method tests that a resident password of 51 characters is invalid.
         */
        public void TestThatPasswordFieldOf51CharsIsInvalid()
        {
            //test that password of 51 characters is invalid
            resident.password = new string('o', 51);
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password must be 50 characters or less.", results[0].ErrorMessage);
        }

        /*--------------------------------------Phone Field Testing-------------------------------------------------------------*/
        [TestMethod]
        /**
         * This method tests that the resident Model created above truly contains a valid phone.
         */
        public void TestThatPhoneFieldGeneralIsValid()
        {
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        /**
         * This method tests that an empty resident Phone is invalid.
         */
        public void TestPhoneFieldInvalid()
        {
            //test that phone number of empty string is invalid
            resident.phoneNumber = "";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Phone number is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        /**
         * This method tests that a resident Phone in incorrect format is invalid.
         */
        public void TestThatEmptyPhoneFieldIsInvalid()
        {
            //test that phone number in incorrect format is invalid
            resident.phoneNumber = "4325";
            var results = TestValidationHelper.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Phone number must be in phone number format.", results[0].ErrorMessage);
        }
    }
}
