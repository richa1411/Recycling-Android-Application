using Microsoft.VisualStudio.TestTools.UnitTesting;
using kymiraAPI.Models;
using System;
using Newtonsoft.Json;

namespace kymiraAPITest
{
    [TestClass]
    public class Story1dTests
    {
        //Valid resident to use for testing
        Resident resident = new Resident{id = 1, firstName = "John", lastName = "Smith", dateOfBirth = new DateTime(),
            email = "john.smith@hotmail.com",phoneNumber = "3064567890", address1 = "Fairhaven", address2 = "Unit 6",
            city = "Saskatoon", province = "Saskatchewan", postalCode = "S7L5W4", password = "P@ssw0rd"};

        [TestMethod]
        public void TestPassToDatabase()
        {
            //attempt to create a new Resident and save it to the database
            
            //attempt to retrieve the Resident from the database
            //check the retrieved resident against the original resident object
        }

        [TestMethod]
        public void TestCreateResident()
        {
            //attempt to create a resident object
            //check that all of the new object's attributes were set as intended
        }

        [TestMethod]
        /**
         * Tests that a User can be extracted from the database reliably
         * */
        public void TestRetrieval()
        {
            //attempt to retrieve a valid Resident object from the database
        }

        [TestMethod]
        /**
         * Will test for boolean response from constructor
         * */
        public void TestResidentsController()
        {
            //test that the controller is active when it should be
        }

        [TestMethod]
        public void TestFirstNameField()
        {
            //test that first name of 50 characters is valid
            resident.firstName = new string('h', 50);
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestLastNameField()
        {
            //test that last name of 50 characters is valid
            resident.lastName = new string('h', 50);
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestDOBField()
        {
            //test that DOB will allow valid entries
        }

        [TestMethod]
        public void TestEmailField()
        {
            //test that email will allow valid entries
        }

        [TestMethod]
        public void TestAddress1Field()
        {
            //test that Address1 will allow valid entries
        }

        [TestMethod]
        public void TestAddress2Field()
        {
            //test that address2 will allow valid entries
        }

        [TestMethod]
        public void TestPostalCodeField()
        {
            //test that postalCode will allow valid entries
        }

        [TestMethod]
        public void TestProvinceField()
        {
            //test that Province of 100 characters is valid
            resident.province = new string('h', 100);
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);

            //test that province of 1 character is valid
            resident.province = "g";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestCityField()
        {
            //test that City will allow valid entries
        }

        [TestMethod]
        public void TestPasswordField()
        {
            //test that password 
        }

        [TestMethod]
        public void TestPhoneField()
        {
            //test that phone will allow valid entries
        }

        //**************** TESTING FOR INVALIDS BELOW ****************/

        [TestMethod]
        public void TestFirstNameFieldInvalid()
        {
            //test that first name of empty string is invalid
            resident.firstName = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("First name is required.", results[0].ErrorMessage);

            //test that first name of 51 characters is invalid
            resident.firstName = new string('j', 51);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("First name must less then 50 characters.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestLastNameFieldInvalid()
        {
            //test that last name of empty string is invalid
            resident.lastName = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Last name is required and must be between 1 and 50 characters.", results[0]);

            //test that last name of 51 characters is invalid
            resident.lastName = new string('j', 51);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Last name is required and must be between 1 and 50 characters.", results[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDOBFieldInvalid()
        {
            //test that DOB will not allow invalid entries
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestEmailFieldInvalid()
        {
            //test that email

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddress1FieldInvalid()
        {
            //test that address1 of empty string is invalid
            resident.address1 = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address line 1 is required and must be between 1 and 200 characters.", results[0]);

            //test that address1 of 201 characters is invalid
            resident.address1 = new string('d', 201);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address line 1 is required and must be between 1 and 200 characters.", results[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddress2FieldInvalid()
        {
            //test that address2 of 201 characters is invalid
            resident.address1 = new string('d', 201);
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address line 2 must be between 1 and 200 characters.", results[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostalCodeFieldInvalid()
        {
            //test that postalCode of 7 characters/digits is invalid
            resident.postalCode = "S0L0K0E";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0]);

            //test that postalCode of incorrect format is invalid
            resident.postalCode = "SSS000";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0]);

            //test that postalCode of empty string is invalid
            resident.postalCode = "";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Postal code is required and must be 6 characters.", results[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestProvinceFieldInvalid()
        {
            //test that province of empty string is invalid
            resident.province = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Province is required and must be less than 100 characters.", results[0]);

            //test that province of 101 characters is invalid
            resident.province = new string('i', 101);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Province is required and must be less than 100 characters.", results[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCityFieldInvalid()
        {
            //test that City of empty string is invalid
            resident.city = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("City is required and must be less than 100 characters.", results[0]);

            //test that city of 101 characters is invalid
            resident.city = new string('s',101);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("City is required and must be less than 100 characters.", results[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPasswordFieldInvalid()
        {
            //test that password of empty string is invalid
            resident.password = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password is required and must be 8 or more characters.", results[0]);

            //test that password of 51 characters is invalid
            resident.password = new string('o', 51);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password is required and must be 50 characters or less.", results[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPhoneFieldInvalid()
        {
            //test that phone will not allow invalid entries

        }
    }
}
