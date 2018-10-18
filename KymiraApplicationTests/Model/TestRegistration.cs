using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kymiraApp.Droid;
using kymiraApp.Droid.validators;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace kymiraAppTest
{
    [TestFixture(Platform.Android)]
    class TestValidationObject
    {
        ValidatableObject obValidatable;

        [Test]
        public void TestValidEmail()
        {
            //Validate a correct email address
            obValidatable = new EmailValidator("test@test.com");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);

            //Validate an empty email address
            obValidatable = new EmailValidator("");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate email address longer than 100 characters
            obValidatable = new EmailValidator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate email address in invalid format
            obValidatable = new EmailValidator("testemail.com");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);
        }

        [Test]
        public void TestValidPassword()
        {
            //Validate an empty password
            obValidatable = new PasswordValidator("");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a password with less than 8 characters
            obValidatable = new PasswordValidator("hhhhh");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a valid password
            obValidatable = new PasswordValidator("123456jh");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);

            //Validate a valid password
            obValidatable = new PasswordValidator("1hf8djgkt81hf8djgkt81hf8djgkt81hf8djgkt81hf8djgkt8");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);

            //Validate a password that is too long
            obValidatable = new PasswordValidator("1hf8djgkt81hf8djgkt81hf8djgkt81hf8djgkt81hf8djgkt86");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);
        }

        [Test]
        public void TestValidPhoneNumber()
        {
            //Validate an empty phone number
            obValidatable = new PhoneNumberValidator("");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a phone number with non-numeric characters
            obValidatable = new PhoneNumberValidator("johndoe123");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a phone number with too many digits
            obValidatable = new PhoneNumberValidator("12345678910");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a valid phone number
            obValidatable = new PhoneNumberValidator("3062224469");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);

            //Validate phone number with too few digits
            obValidatable = new PhoneNumberValidator("306222");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);
        }

        [Test]
        public void TestValidFirstName()
        {
            //Validate an empty first name
            obValidatable = new FirstNameValidator("");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a first name field that isn't blank
            obValidatable = new FirstNameValidator("a");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);

            //Validate a first name field that has too many characters
            obValidatable = new FirstNameValidator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a first name with max characters (valid)
            obValidatable = new FirstNameValidator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);

        }

        [Test]
        public void TestValidLastName()
        {
            //Validate an empty last name field
            obValidatable = new LastNameValidator("");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a last name field that isn't blank
            obValidatable = new LastNameValidator("a");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a last name field that has too many characters
            obValidatable = new LastNameValidator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a first name with max characters (valid)
            obValidatable = new LastNameValidator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);
        }

        [Test]
        public void TestValidBirthDate()
        {
            //Validate an empty birth date
            obValidatable = new BirthDateValidator("");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a birth date with too few characters
            obValidatable = new BirthDateValidator("101118");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a birth date with the correct number of characters
            obValidatable = new BirthDateValidator("10112018");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);
        }

        [Test]
        public void TestValidAddressLine1()
        {
            //Validate an empty address line 1 field
            obValidatable = new AddressLine1Validator("");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate an address line 1 field that isn't empty
            obValidatable = new AddressLine1Validator("a");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);

            //Validate an address line 1 that is the max number of characters (valid)
            obValidatable = new AddressLine1Validator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);

            //Validate an address line 1 that is over the max number of characters
            obValidatable = new AddressLine1Validator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
         "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaagfdsgfds");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);
        }

        [Test]
        public void TestValidAddressLine2()
        {
            //Validate an empty address line 2 field (valid)
            obValidatable = new AddressLine2Validator("");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate an empty address line 2 field with max characters
            obValidatable = new AddressLine1Validator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);

            //Validate an address line 2 field with too many characters
            obValidatable = new AddressLine1Validator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaljkkjhlkj");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);
        }

        public void TestValidCity()
        {
            //Validate an empty City field
            obValidatable = new CityValidator("");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a city field with the max number of characters
            obValidatable = new CityValidator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);

            //Validate a city field with more than the max number of characters
            obValidatable = new CityValidator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaagfdgdfsgdfs");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

        }

        [Test]
        public void TestValidProvince()
        {
            //Validate an empty province field
            obValidatable = new ProvinceValidator("");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a province field with max number of characters
            obValidatable = new ProvinceValidator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);

            //Validate a province with too many characters
            obValidatable = new ProvinceValidator("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaagfdsgddfaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);
        }

        [Test]
        public void TestValidPostalCode()
        {
            //Validate a postal code in the wrong format
            obValidatable = new PostalCodeValidator("");
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a postal code in the correct format
            obValidatable = new PostalCodeValidator("S7J4J6");
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);
        }

        [Test]
        public void TestValidCheckBox()
        {
            //Validate a check box that isn't checked
            obValidatable = new CheckBoxValidator(false);
            obValidatable.Validate();
            Assert.IsFalse(obValidatable.isValid);

            //Validate a check box that is checked
            obValidatable = new CheckBoxValidator(true);
            obValidatable.Validate();
            Assert.IsTrue(obValidatable.isValid);
        }

    }
}
