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
        //test that Invalid Phonenumber Displays Error
        public void TestThatInvalidPhonenumberDisplaysError()
       {
          
       }

       [Test]
        //test that Invalid Password Displays Error
        public void TestThatInvalidPasswordDisplaysError()
       {
          
       }
        [Test]
        //test that Invalid Password Displays Error
        public void TestThatValidPhonenumberPasswordDisplaysHomeScreen()
        {

        }
    }
}