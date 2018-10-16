using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kymiraApp.Droid;
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
        }
    }
}
