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
            email = "john.smith@hotmail.com",phoneNumber = "3061234780", address1 = "Fairhaven", address2 = "Unit 6",
            city = "Saskatoon", province = "Saskatchewan", postalCode = "S7L5W4", password = "P@ssw0rd"};

        [TestMethod]
        public void TestFirstNameField()
        {
            //test that 'general' first name is valid
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        
            //test that first name of 50 characters is valid
            resident.firstName = new string('h', 50);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestLastNameField()
        {
            //test that 'general' last name is valid
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);

            //test that last name of 50 characters is valid
            resident.lastName = new string('h', 50);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestDOBField()
        {
            //test that DOB will allow valid entries
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
            //TODO: Check the sending/recieving function within 'run'/'socket' for date conversion 

        }

        [TestMethod]
        public void TestEmailField()
        {
            //test that 'general' email passes
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
            //test that email of 100 characters following the correct email format is valid
            resident.email = new string('d',88) + "@sasktel.net";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestAddress1Field()
        {
            //test that 'general' address1 field passes
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
            //test that Address1 of 200 characters is valid
            resident.address1 = new string('h', 200);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);

            //test that Address1 of 1 character is valid
            resident.address1 = "g";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestAddress2Field()
        {
            //test that 'general' address2 field passes
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
            //test that address2 of 200 characters is valid
            resident.address2 = new string('p', 200);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
            //test that Address2 of 0 characters is valid
            resident.address2 = "";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestPostalCodeField()
        {
            //test that postalCode will allow valid entries (uses current valid resident created at the top of
            //this class)
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestProvinceField()
        {
            //test that 'general' test passes
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
            //test that Province of 100 characters is valid
            resident.province = new string('h', 100);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);

            //test that province of 1 character is valid
            resident.province = "g";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestCityField()
        {
            //test that 'general' test passes
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
            //test that City of 100 characters is valid
            resident.city = new string('f',100);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);

            //test that city of 1 character is valid
            resident.city = "W";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);

        }

        [TestMethod]
        public void TestPasswordField()
        {
            //test that password of 8 characters is valid
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);

            //test that password of 50 characters is valid
            resident.password = new string('s',50);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestPhoneField()
        {
            //test that phone will allow valid entries (uses current valid resident created at the top of
            //this class)
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(0, results.Count);
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
            Assert.AreEqual("First name must be 50 characters or less.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestLastNameFieldInvalid()
        {
            //test that last name of empty string is invalid
            resident.lastName = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Last name is required.", results[0].ErrorMessage);

            //test that last name of 51 characters is invalid
            resident.lastName = new string('j', 51);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Last name must be 50 characters or less.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestDOBFieldInvalid()
        {
            //test that DOB will not allow invalid entries
            //resident.dateOfBirth = "12/4432/11244"; -- Requires a date object and will not compile
            // TODO: Check the sending/recieving function within 'run'/'socket' for improper date conversion 


        }

        [TestMethod]
        public void TestEmailFieldInvalid()
        {
            //test that email of empty string is invalid
            resident.email = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Email is required.", results[0].ErrorMessage);

            //test that email of 101 characters (following the correct format) is invalid
            resident.email = new string('y',101) + "@sasktel.net";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Email must be 100 characters or less.", results[0].ErrorMessage);

            //test that email of incorrect format is invalid
            resident.email = new string('o',7);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Email must be in email address format.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestAddress1FieldInvalid()
        {
            //test that address1 of empty string is invalid
            resident.address1 = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address line 1 is required.", results[0].ErrorMessage);

            //test that address1 of 201 characters is invalid
            resident.address1 = new string('d', 201);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address line 1 must be 200 characters or less.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestAddress2FieldInvalid()
        {
            //test that address2 of 201 characters is invalid
            resident.address2 = new string('d', 201);
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Address line 2 must be 200 characters or less.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestPostalCodeFieldInvalid()
        {
            //test that postalCode of 5 characters/digits is invalid
            resident.postalCode = "S0L0K";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);

            //test that postalCode of 7 characters/digits is invalid
            resident.postalCode = "S0L0K0E";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);

            //test that postalCode of incorrect format is invalid
            resident.postalCode = "SSS000";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Postal code is required and must be 6 characters in the Canadian postal code format.", results[0].ErrorMessage);

            //test that postalCode of empty string is invalid
            resident.postalCode = "";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Postal code is required and must be 6 characters.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestProvinceFieldInvalid()
        {
            //test that province of empty string is invalid
            resident.province = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Province is required.", results[0].ErrorMessage);

            //test that province of 101 characters is invalid
            resident.province = new string('i', 101);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Province must be 100 characters or less.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestCityFieldInvalid()
        {
            //test that City of empty string is invalid
            resident.city = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("City is required.", results[0].ErrorMessage);

            //test that city of 101 characters is invalid
            resident.city = new string('s',101);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("City must be 100 characters or less.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestPasswordFieldInvalid()
        {
            //test that password of empty string is invalid
            resident.password = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password is required.", results[0].ErrorMessage);

            //test that password of 51 characters is invalid
            resident.password = new string('o', 51);
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Password must be 50 characters or less.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestPhoneFieldInvalid()
        {
            //test that phone number of empty string is invalid
            resident.phoneNumber = "";
            var results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Phone number is required.", results[0].ErrorMessage);

            //test that phone number in incorrect format is invalid
            resident.phoneNumber = "4325";
            results = HelperTestModel.Validate(resident);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("Phone number must be in phone number format.", results[0].ErrorMessage);
        }
    }
}
