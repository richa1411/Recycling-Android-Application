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
        public void TestThatValidRegistrationReturnsToMain()
        {
            app.ScrollUpTo("birthDateSpinnerMonth");

            app.Tap("birthDateSpinnerMonth");
            app.Tap("April");

            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("Welcome to the Main Page");
        }

        /**
         * Test that invalid birth date entries result in appropriate toasts 
         **/
        [Test]
        public void TestThatInvalidBirthDateThrowsError()
        {
            app.ScrollDownTo("btnSubmit");

            app.Tap("btnSubmit");

            app.WaitForElement("Birth date must be a valid date.");
        }
    }
}
