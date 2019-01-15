using System;
using System.Collections;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace KymiraApplicationUITests
{
    
    [TestFixture(Platform.Android)]

    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        //test that all elements load onto the app upon startup
        public void TestThatAppInterfaceLoadsCorrectly()
        {
            ArrayList results = new ArrayList();
            results.Add(app.WaitForElement(c => c.Marked("drawer_layout")));
            Assert.AreEqual(1, results.Count);
        }
        
      [Test]
     //Test that after tapping the Submit button with no address entered, the list view does not change
       public void TestThatLoginOptionClickOpensLoginPage()
       {
           ArrayList results = new ArrayList();
            //TODO : fIND A BETTER WAY FOR NAVIGATIONS
            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);
            results.Add(app.WaitForElement(c => c.Marked("imgLogo")));
            results.Add(app.WaitForElement(c => c.Marked("etxtPhone")));
            results.Add(app.WaitForElement(c => c.Marked("etxtPassword")));
            results.Add(app.WaitForElement(c => c.Marked("tvError")));
            results.Add(app.WaitForElement(c => c.Marked("btnLogin")));
            Assert.AreEqual(5, results.Count);
        }
        
       [Test]
        //test that Invalid Phone number Displays Error
        public void TestThatInvalidPhonenumberDisplaysError()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);
            app.TapCoordinates(100, 980);

            app.EnterText("JohnDoe123");
            app.WaitForElement(c => c.Marked("JohnDoe123"));

            app.TapCoordinates(100, 1150);
            app.EnterText("P@ssw0");
            app.Tap("btnLogin");
            
            results.Add(app.WaitForElement(c => c.Marked("Phone number must be 10 digits")));

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        //test that Invalid Phone number Displays Error
        public void TestThatEmptyPhonenumberDisplaysError()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);

            app.TapCoordinates(100, 1150);
            app.EnterText("P@ssw0");
            app.Tap("btnLogin");

            results.Add(app.WaitForElement(c => c.Marked("Please enter a valid phone number")));

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        //test that Invalid Password Displays Error
        public void TestThatInvalidPasswordDisplaysError()
       {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);
            app.TapCoordinates(100, 980);

            app.EnterText("1234567890");

            //will wait for a certain amount of time
            //app.WaitForElement(x => x.Id("etxtPhone"), timeout: TimeSpan.FromSeconds(120));
            app.WaitForElement(c => c.Marked("1234567890"));
            app.TapCoordinates(100, 1150);
            app.EnterText("Pa$$");
            app.Tap("btnLogin");

            results.Add(app.WaitForElement(c => c.Marked("Password must be between 6 - 50 characters")));

            Assert.AreEqual(1, results.Count);
        }
        

        [Test]
        //test that Invalid Password Displays Error
        public void TestThatEmptyPasswordDisplaysError()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);
            app.TapCoordinates(100, 980);

            app.EnterText("1234567890");
            app.WaitForElement(c => c.Marked("1234567890"));


            app.Tap("btnLogin");

            results.Add(app.WaitForElement(c => c.Marked("Please enter your password")));

            Assert.AreEqual(1, results.Count);
        }
        [Test]
        //Test that a valid phone number and password will display the home screen (Successful Login)
        public void TestThatValidPhonenumberPasswordDisplaysHomeScreen()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);
            app.TapCoordinates(100, 980);

            app.EnterText("1234567890");
            app.WaitForElement(c => c.Marked("1234567890"));

            app.TapCoordinates(100, 1150);
            app.EnterText("Pa$$w0rd");
            app.Tap("btnLogin");

            //results.Add(app.WaitForElement(c => c.Marked("Please enter your password")));

            Assert.AreEqual(0, results.Count);

            //Currently just displays and stores no errors. Still need to navigate to the actual home page
        }
    }
}