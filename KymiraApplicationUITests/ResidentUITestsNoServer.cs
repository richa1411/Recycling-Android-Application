using Android.App;
using Android.Views.InputMethods;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace KymiraApplicationUITests
{
    [TestFixture(Platform.Android)]
    public class ResidentUITestsNoServer
    {
        IApp app;
        Platform platform;

        public ResidentUITestsNoServer(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);

            app.TapCoordinates(100, 100);
            app.Tap("Registration");

            //common valid field entries
            app.Tap("email_value");
            app.EnterText("test@asddsa.com");

            app.Tap("password_value");
            app.EnterText("testingpassword");

            app.Tap("phone_value");
            app.EnterText("3063828221");

            app.Tap("firstName_value");
            app.EnterText("Joey");

            app.Tap("lastName_value");
            app.EnterText("Only");

            app.ScrollDownTo("addressLine2_label");

            app.Tap("birthDateSpinnerMonth");
            app.Tap("June");

            app.Tap("birthDateSpinnerYear");
            app.Tap("2019");

            app.Tap("addressLine1_value");
            app.EnterText("128 Cooper Cres");

            app.ScrollDownTo("btnSubmit");

            app.Tap("city_value");
            app.EnterText("Saskatoon");

            app.Tap("provinceSpinner");
            app.ScrollDownTo(m => m.Text("Saskatchewan"), x => x.Id("provinceSpinner"), strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("Saskatchewan");

            app.Tap("postalCode_value");
            app.EnterText("S7M2K7");

            app.ScrollDownTo("btnSubmit");
            app.Tap("termsCheckbox");
        }

        [Test]
        public void TestThatInterfaceLoadsCorrectly()
        {
            ArrayList results = new ArrayList();
            app.ScrollUpTo("email_value");

            //Hide the keyboard
            app.DismissKeyboard();

            results.Add(app.WaitForElement(c => c.Marked("Register for Kymira!")));
            results.Add(app.WaitForElement(c => c.Marked("Email Address:")));
            results.Add(app.WaitForElement(c => c.Marked("Password:")));
            results.Add(app.WaitForElement(c => c.Marked("Phone #:")));
            results.Add(app.WaitForElement(c => c.Marked("First name:")));
            results.Add(app.WaitForElement(c => c.Marked("Last name:")));
            results.Add(app.WaitForElement(c => c.Marked("Birth Date:")));
            results.Add(app.WaitForElement(c => c.Marked("Address Line 1:")));
            results.Add(app.WaitForElement(c => c.Marked("Address Line 2:")));
            results.Add(app.WaitForElement(c => c.Marked("City:")));

            app.ScrollDownTo("btnSubmit");

            results.Add(app.WaitForElement(c => c.Marked("Province:")));
            results.Add(app.WaitForElement(c => c.Marked("Postal Code:")));
            //results.Add(app.WaitForElement(c => c.Marked("I agree to the terms and conditions:")));
            results.Add(app.WaitForElement(c => c.Marked("Register")));

            //check that all elements are here
            Assert.AreEqual(13, results.Count);
        }

        [Test]
        public void TestThatValidRegistrationNoConnectionErrorMessage()
        {
            app.Tap("btnSubmit");

            app.WaitForElement("Something went wrong, try again later");
        }

        /**
         * Test that invalid email entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidEmailThrowsError()
        {
            //empty email
            app.ScrollUpTo("email_value");
            app.Tap("email_value");
            app.ClearText("email_value");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("An email address is required");

            //invalid format
            app.ScrollUpTo("email_value");

            app.Tap("email_value");
            app.EnterText("test");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("Email address is not in a valid format");

        }

        /**
         *Test that invalid password entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidPasswordThrowsError()
        {
            //empty
            app.ScrollUpTo("email_value");

            app.Tap("password_value");
            app.ClearText("password_value");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A password is required");

            //too short
            app.ScrollUpTo("email_value");

            app.Tap("password_value");
            app.EnterText("te");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("Password must be between 8 and 50 characters");

            //too long
            app.ScrollUpTo("email_value");

            app.Tap("password_value");
            app.ClearText("password_value");
            app.EnterText(new string('k', 51));

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("Password must be between 8 and 50 characters");
        }

        /**
         * Test that invalid phone entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidPhoneThrowsError()
        {
            //empty
            app.ScrollUpTo("email_value");

            app.Tap("phone_value");
            app.ClearText("phone_value");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A phone number is required");

            //too short
            app.ScrollUpTo("email_value");

            app.Tap("phone_value");
            app.EnterText("76");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("Phone number must contain 10 digits");

        }

        /**
         * Test that invalid first name entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidFNameThrowsError()
        {
            //empty
            app.ScrollUpTo("email_value");

            app.Tap("firstName_value");
            app.ClearText("firstName_value");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A first name is required");

            //too long
            app.ScrollUpTo("email_value");

            app.Tap("firstName_value");
            app.EnterText(new string('k', 51));

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("First name must be between 1 and 50 characters");
        }

        /**
         * Test that invalid last name entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidLNameThrowsError()
        {
            //empty
            app.ScrollUpTo("email_value");

            app.Tap("lastName_value");
            app.ClearText("lastName_value");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A last name is required");

            //too long
            app.ScrollUpTo("email_value");

            app.Tap("lastName_value");
            app.EnterText(new string('k', 51));

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("Last name must be between 1 and 50 characters");
        }

        /**
         * Test that invalid address line 1 entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidAddress1ThrowsError()
        {
            //empty
            app.ScrollUpTo("addressLine1_value");

            app.Tap("addressLine1_value");
            app.ClearText("addressLine1_value");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("An Address is required");

            //too long
            app.ScrollUpTo("addressLine1_value");

            app.Tap("addressLine1_value");
            app.EnterText(new string('k', 201));

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("The address must be between 10 and 200 characters");

            //too short
            app.ScrollUpTo("addressLine1_value");

            app.Tap("addressLine1_value");
            app.ClearText("addressLine1_value");
            app.EnterText("as");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("The address must be between 10 and 200 characters");
        }

        /**
         * Test that invalid city entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidCityThrowsError()
        {
            //empty
            app.ScrollUpTo("city_value");

            app.Tap("city_value");
            app.ClearText("city_value");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A City is required");

            //too long
            app.ScrollUpTo("city_value");

            app.Tap("city_value");
            app.EnterText(new string('k', 101));

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("The city must be between 1 and 100 characters");

        }

        /**
         * Test that invalid province entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidProvinceThrowsError()
        {
            //not selected
            app.ScrollUpTo("provinceSpinner");

            app.Tap("provinceSpinner");
            app.ScrollUpTo(m => m.Text("Select Province"), x => x.Id("provinceSpinner"), strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("Select Province");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A province is required");
        }


        /**
         * Test that invalid postal code entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidPostalCodeThrowsError()
        {
            //empty
            app.ScrollUpTo("provinceSpinner");

            app.Tap("postalCode_value");
            app.ClearText("postalCode_value");

            app.ScrollDownTo("btnSubmit");
            app.Tap("btnSubmit");

            app.WaitForElement("A postal code is required");

            //wrong format
            app.ScrollUpTo("provinceSpinner");

            app.Tap("postalCode_value");
            app.EnterText("asddddd");

            app.ScrollDownTo("btnSubmit");
            app.Tap("btnSubmit");

            app.WaitForElement("Postal code is required and must be 6 characters in the Canadian postal code format.");
        }

        /**
         * Test that unchecked terms checkbox results in appropriate toast
         **/
        [Test]
        public void TestThatUncheckedTermsThrowsError()
        {
            //not selected
            app.Tap("termsCheckbox");

            app.ScrollDownTo("btnSubmit");
            app.Tap("btnSubmit");

            app.WaitForElement("You must agree to the terms and conditions");
        }
    }
}
