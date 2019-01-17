using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace KymiraApplicationUITests
{
    [TestFixture(Platform.Android)]
    public class ResidentUITests
    {
        IApp app;
        Platform platform;

        public ResidentUITests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);

            app.TapCoordinates(100, 100);
            app.TapCoordinates(370, 890);
        }

        [Test]
        public void TestThatInterfaceLoadsCorrectly()
        {
            ArrayList results = new ArrayList();

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
            app.Tap("email_value");
            app.EnterText("test@test.com");

            app.Tap("password_value");
            app.EnterText("p@ssw0rd");

            app.Tap("phone_value");
            app.EnterText("3062222222");

            app.Tap("firstName_value");
            app.EnterText("Tim");

            app.Tap("lastName_value");
            app.EnterText("Maughan");

            app.ScrollDownTo("addressLine2_label");

            app.Tap("birthDateSpinnerMonth");
            app.TapCoordinates(199, 1189);

            app.Tap("birthDateSpinnerYear");
            app.ScrollDownTo(m => m.Text("2004"), x => x.Id("birthDateSpinnerYear"), strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("2004");

            app.Tap("addressLine1_value");
            app.EnterText("123 Test Street");

            app.ScrollDownTo("btnSubmit");

            app.Tap("city_value");
            app.EnterText("Saskatoon");

            app.Tap("provinceSpinner");
            app.ScrollDownTo(m => m.Text("Saskatchewan"), x => x.Id("provinceSpinner"), strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("Saskatchewan");

            app.Tap("postalCode_value");
            app.EnterText("S7J4J6");

            app.Tap("termsCheckbox");

            app.Tap("btnSubmit");

            app.WaitForElement("Registration Failed: RequestTimeout");
        }

        [Test]
        public void TestThatValidRegistrationReturnsToMain()
        {
            app.Tap("email_value");
            app.EnterText("test@test.com");

            app.Tap("password_value");
            app.EnterText("p@ssw0rd");

            app.Tap("phone_value");
            app.EnterText("3062222222");

            app.Tap("firstName_value");
            app.EnterText("Tim");

            app.Tap("lastName_value");
            app.EnterText("Maughan");

            app.ScrollDownTo("addressLine2_label");

            app.Tap("birthDateSpinnerMonth");
            app.TapCoordinates(199, 1189);

            app.Tap("birthDateSpinnerYear");
            app.ScrollDownTo(m => m.Text("2004"), x => x.Id("birthDateSpinnerYear"), strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("2004");

            app.Tap("addressLine1_value");
            app.EnterText("123 Test Street");

            app.ScrollDownTo("btnSubmit");

            app.Tap("city_value");
            app.EnterText("Saskatoon");

            app.Tap("provinceSpinner");
            app.ScrollDownTo(m => m.Text("Saskatchewan"), x => x.Id("provinceSpinner"), strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("Saskatchewan");

            app.Tap("postalCode_value");
            app.EnterText("S7J4J6");

            app.Tap("termsCheckbox");

            app.Tap("btnSubmit");

            app.WaitForElement("Welcome to the Main Page");
        }

        /**
         * Test that invalid email entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidEmailThrowsError()
        {
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
            app.Tap("email_value");
            app.EnterText("test@asddsa.com");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A password is required");

            app.ScrollUpTo("password_value");

            app.Tap("password_value");
            app.EnterText("test");

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
            app.Tap("email_value");
            app.EnterText("test@asddsa.com");

            app.Tap("password_value");
            app.EnterText("testingpassword");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A phone number is required");

            app.ScrollUpTo("phone_value");
            app.Tap("phone_value");
            app.EnterText("123");

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
            app.Tap("email_value");
            app.EnterText("test@asddsa.com");

            app.Tap("password_value");
            app.EnterText("testingpassword");

            app.Tap("phone_value");
            app.EnterText("3063828221");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A first name is required");
        }

        /**
         * Test that invalid last name entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidLNameThrowsError()
        {
            app.Tap("email_value");
            app.EnterText("test@asddsa.com");

            app.Tap("password_value");
            app.EnterText("testingpassword");

            app.Tap("phone_value");
            app.EnterText("3063828221");

            app.Tap("firstName_value");
            app.EnterText("Joey");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A last name is required");
        }

        /**
         * Test that invalid birth date entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidBirthDateThrowsError()
        {
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

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("Birth date must be a valid date.");
        }

        /**
         * Test that invalid address line 1 entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidAddress1ThrowsError()
        {
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
            app.ScrollDownTo(m => m.Text("2004"), x => x.Id("birthDateSpinnerYear"), strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("2004");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("An Address is required");
        }

        /**
         * Test that invalid city entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidCityThrowsError()
        {
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
            app.ScrollDownTo(m => m.Text("2004"), x => x.Id("birthDateSpinnerYear"), strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("2004");

            app.Tap("addressLine1_value");
            app.EnterText("128 Cooper Cres");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A City is required");
        }

        /**
         * Test that invalid province entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidProvinceThrowsError()
        {
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
            app.ScrollDownTo(m => m.Text("2004"), x => x.Id("birthDateSpinnerYear"), strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("2004");

            app.Tap("addressLine1_value");
            app.EnterText("128 Cooper Cres");

            app.ScrollDownTo("btnSubmit");

            app.Tap("city_value");
            app.EnterText("Saskatoon");

            app.Tap("postalCode_value");
            app.EnterText("S7M2K7");

            app.ScrollDownTo("btnSubmit");

            app.Tap("termsCheckbox");

            app.Tap("btnSubmit");

            app.WaitForElement("A province is required");
        }
        
        
        /**
         * Test that invalid postal code entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidPostalCodeThrowsError()
        {
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
            app.ScrollDownTo(m => m.Text("2004"), x => x.Id("birthDateSpinnerYear"), strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("2004");

            app.Tap("addressLine1_value");
            app.EnterText("128 Cooper Cres");

            app.ScrollDownTo("btnSubmit");

            app.Tap("city_value");
            app.EnterText("Saskatoon");

            app.Tap("provinceSpinner");
            app.Tap("Alberta");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("A postal code is required");
        }

        /**
         * Test that unchecked terms checkbox results in appropriate toast
         **/
        [Test]
        public void TestThatUncheckedTermsThrowsError()
        {
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
            app.ScrollDownTo(m => m.Text("2004"), x => x.Id("birthDateSpinnerYear"), strategy: ScrollStrategy.Gesture, timeout: new TimeSpan(0, 1, 0));
            app.Tap("2004");

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

            app.Tap("btnSubmit");

            app.WaitForElement("You must agree to the terms and conditions");
        }
    }
}
