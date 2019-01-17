﻿using System;
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
        //Application finds text box for phone number and make it invalid and  make valid password field 
        //taps login button and application will display error message
        public void TestThatInvalidPhonenumberDisplaysError()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);
            app.TapCoordinates(100, 980);

            app.EnterText("JohnDoe1238");
            app.WaitForElement(c => c.Marked("JohnDoe1238"));

            app.TapCoordinates(100, 1150);
            app.EnterText("P@ssw0rd");
            app.Tap("btnLogin");
            
            results.Add(app.WaitForElement(c => c.Marked("Phone number must be 10 digits")));

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        //test that empty Phone number Displays Error
        //Application finds text box for phone number and make it empty and  make password field some valid entry
        //taps login button and application will display error message
        public void TestThatEmptyPhonenumberDisplaysError()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);

            app.TapCoordinates(100, 1150);
            app.EnterText("P@ssw0rd");
            app.Tap("btnLogin");

            results.Add(app.WaitForElement(c => c.Marked("Please enter a valid phone number")));

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        //test that Invalid Password Displays Error
        //Application finds text box for phone number and types some valid number and make password field invalid
        //taps login button and application will display error message
        public void TestThatInvalidPasswordDisplaysError()
       {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);
            app.TapCoordinates(100, 980);

            app.EnterText("1234567890");

            
            app.WaitForElement(c => c.Marked("1234567890"));
            app.TapCoordinates(100, 1150);
            app.EnterText("P@ssw");
            app.Tap("btnLogin");

            results.Add(app.WaitForElement(c => c.Marked("Password must be between 6 - 50 characters")));

            Assert.AreEqual(1, results.Count);
        }
        

        [Test]
        //test that Empty Password Displays Error
        //Application finds text box for phone number and types some valid number and make password field empty
        //taps login button and application will display error message
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
        //Test that incorrect phone number and password will display an error
        //first application will find phone number textbox and type some valid but incorrect phone number then application will find password textbox and types valid but incorrect password and then application will tap login button
        //application will check at backend for correct credentiALS and then displays an error
        public void TestThatValidIncorrectPhonenumberPasswordDisplaysError()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 750);
            app.TapCoordinates(100, 980);

            app.EnterText("3069898989");
            app.WaitForElement(c => c.Marked("3069898989"));

            app.TapCoordinates(100, 1150);
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
            app.TapCoordinates(100, 980);

            app.EnterText("3069874635");
            app.WaitForElement(c => c.Marked("3069874635"));

            app.TapCoordinates(100, 1150);
            app.EnterText("passcode");
            app.Tap("btnLogin");
            app.Tap("btnLogin");
             results.Add(app.WaitForElement(c => c.Marked("txtWel")));

            Assert.AreEqual(1, results.Count);

           
        }
    }
}