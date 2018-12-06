﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Collections;




namespace TestGUIBinCollectionDate
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
        public void TestThatBinCollectionAddressPageLoadsCorrectly()
        {
            ArrayList results = new ArrayList();
            results.Add(app.WaitForElement(c => c.Marked("etAddress")));
            results.Add(app.WaitForElement(c => c.Marked("tvError")));
            results.Add(app.WaitForElement(c => c.Marked("btnSubmit")));

            Assert.AreEqual(3, results.Count);
        }

        [Test]
        public void TestThatEmptyAddressFieldShowsError()
        {
            ArrayList results = new ArrayList();
            app.Tap(c => c.Marked("btnSubmit"));
            results.Add(app.WaitForElement(c => c.Marked("etAddress")));
            results.Add(app.WaitForElement(c => c.Marked("tvError")));
           

            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void TestThatAddressNotInDatabaseShowsError()
        {
            ArrayList results = new ArrayList();

            app.EnterText("123 Invalid Address");
            app.Tap(c => c.Marked("btnSubmit"));
            results.Add(app.WaitForElement(c => c.Marked("etAddress")));
            results.Add(app.WaitForElement(c => c.Marked("tvError")));


            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void TestThatAddressNotValidShowsError()
        {
            ArrayList results = new ArrayList();

            app.EnterText("fff Test34");
            app.Tap(c => c.Marked("btnSubmit"));
            results.Add(app.WaitForElement(c => c.Marked("etAddress")));
            results.Add(app.WaitForElement(c => c.Marked("tvError")));


            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void TestThatAddresValidLoadsNextPage()
        {
            ArrayList results = new ArrayList();

            app.EnterText("123 Test Street");
            app.Tap(c => c.Marked("btnSubmit"));
            
            results.Add(app.WaitForElement(c => c.Marked("Your upcoming recycling bin collection dates are.. ")));
            results.Add(app.WaitForElement(c => c.Marked("tvCollectionDate1")));
            results.Add(app.WaitForElement(c => c.Marked("tvCollectionDate2")));

            Assert.AreEqual(3, results.Count);
        }



    }
}
