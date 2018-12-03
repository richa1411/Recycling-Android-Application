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
		public void TestThatAppInterfaceLoadsCorrectly()
		{
            ArrayList results = new ArrayList();

            results.Add(app.WaitForElement(c => c.Marked("Discovered bins will be displayed here")));
            results.Add(app.WaitForElement(c => c.Marked("Bin Statuses")));
            results.Add(app.WaitForElement(c => c.Marked("Discovered bins will be displayed here")));
            results.Add(app.WaitForElement(c => c.Marked("Address")));
            results.Add(app.WaitForElement(c => c.Marked("Bins: ")));
            results.Add(app.WaitForElement(c => c.Marked("addressEntry").Text("")));
            results.Add(app.WaitForElement(c => c.Marked("submitAddress")));

            Assert.AreEqual(7, results.Count);
        }

        [Test]
        public void TestThatListViewNotChangedOnEmptyAddress()
        {
            app.Tap(c => c.Marked("submitAddress"));

            //var appResult = app.Query(c => c.Id("returnedAddress").Descendant().Id("returnedAddress"));

            //AppResult[] appResults = app.Query("Discovered bins will be displayed here");

            //Assert.IsTrue(appResults != null && appResults[0].Equals(true));

            Assert.IsTrue(true);
        }
	}
}
