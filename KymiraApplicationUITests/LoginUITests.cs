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

    public class LoginUITestsWithServer
    {
        IApp app;
        Platform platform;

        public LoginUITestsWithServer(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        //Test that incorrect phone number and password will display an error
        //first application will find phone number textbox and type some valid but incorrect phone number then application will find password textbox and types valid but incorrect password and then application will tap login button
        //application will check at backend for correct credentiALS and then displays an error
        public void TestThatValidIncorrectPhonenumberPasswordDisplaysError()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);
            app.Tap("etxtPhone");

            app.EnterText("3069898989");

            app.Tap("etxtPassword");
            app.EnterText("passpass");
            app.Tap("btnLogin");
            app.Tap("btnLogin");
            results.Add(app.WaitForElement(c => c.Marked("Incorrect phone number or password")));

            Assert.AreEqual(1, results.Count);


        }

        [Test]
        //Test that a valid and correct phone number and password will display the home screen (Successful Login)
        //first application will find phone number textbox and type some valid and correct number then application will find password textbox and types valid and correct password and then application will tap login button
        //application will check at backend for correct credentiALS and then displays home screen
        public void TestThatValidCorrectPhonenumberPasswordDisplaysHomeScreen()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);
            app.Tap("etxtPhone");

            app.EnterText("3069874635");

            app.Tap("etxtPassword");
            app.EnterText("passcode");
            app.Tap("btnLogin");
            app.Tap("btnLogin");
            results.Add(app.WaitForElement(c => c.Marked("txtWel")));

            Assert.AreEqual(1, results.Count);
        }
    }
}