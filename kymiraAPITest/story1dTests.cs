using Microsoft.VisualStudio.TestTools.UnitTesting;
using kymiraAPI.Models;
using System;

namespace kymiraAPITest
{
    [TestClass]
    public class Story1dTests
    {
        
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
            //test that first name will allow valid names
        }

        [TestMethod]
        public void TestLastNameField()
        {
            //test that last name will allow valid lastnames
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
            //test that Province will allow valid entries
        }

        [TestMethod]
        public void TestCityField()
        {
            //test that City will allow valid entries
        }

        [TestMethod]
        public void TestPasswordField()
        {
            //test that password will allow valid entries
        }

        [TestMethod]
        public void TestPhoneField()
        {
            //test that phone will allow valid entries
        }

        //**************** TESTING FOR INVALIDS BELOW ****************/

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestFirstNameFieldInvalid()
        {
            //test that first name will not allow invalid names
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestLastNameFieldInvalid()
        {
            //test that last name will not allow invalid names
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
            //test that email will not allow invalid entries
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddress1FieldInvalid()
        {
            //test that address1 will not allow invalid entries
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAddress2FieldInvalid()
        {
            //test that address2 will not allow invalid entries
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPostalCodeFieldInvalid()
        {
            //test that postalCode will not allow invalid entries
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestProvinceFieldInvalid()
        {
            //test that province will not allow invalid entries
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCityFieldInvalid()
        {
            //test that City will not allow invalid entries
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPasswordFieldInvalid()
        {
            //test that password will not allow invalid entries
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPhoneFieldInvalid()
        {
            //test that phone will not allow invalid entries
        }
    }
}
