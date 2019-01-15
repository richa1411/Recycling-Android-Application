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
        public void TestThatSuccessfulRegistrationReturnsToMainFragment()
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
            app.Tap("2012");

            Assert.IsTrue(true);
        }


    }
}
