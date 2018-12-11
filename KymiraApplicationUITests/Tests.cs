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

            results.Add(app.WaitForElement(c => c.Marked("Discovered bins will be displayed here")));
            results.Add(app.WaitForElement(c => c.Marked("Bin Statuses")));
            results.Add(app.WaitForElement(c => c.Marked("Address")));
            results.Add(app.WaitForElement(c => c.Marked("Bins: ")));
            results.Add(app.WaitForElement(c => c.Marked("addressEntry").Text("")));
            results.Add(app.WaitForElement(c => c.Marked("submitAddress")));

            //check that all elements are here
            Assert.AreEqual(6, results.Count);
        }

        [Test]
        //test that after tapping the Submit button with no address entered, the list view does not change
        public void TestThatListViewNotChangedOnEmptyAddress()
        {
            ArrayList results = new ArrayList();

            app.Tap(c => c.Marked("submitAddress"));

            results.Add(app.WaitForElement(c => c.Marked("Discovered bins will be displayed here")));

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        //test that correct address updates the listview with the correct information
        public void TestThatCorrectAddressUpdatesListView()
        {
            ArrayList results = new ArrayList();

            app.EnterText("123 Test Street");
            app.Tap(c => c.Marked("submitAddress"));

            results.Add(app.WaitForElement(c => c.Marked("Bin ID: 1\tStatus: Good")));
            results.Add(app.WaitForElement(c => c.Marked("Bin ID: 2\tStatus: Contaminated")));

            Assert.AreEqual(2, results.Count);
        }

        [Test]
        //test that incorrect address leaves the listview unchanged
        public void TestThatIncorrectAddressAffectsListView()
        {
            ArrayList results = new ArrayList();

            app.EnterText("12345 Fake Street");
            app.Tap(c => c.Marked("submitAddress"));

            results.Add(app.WaitForElement(c => c.Marked("No bins associated with that address.")));

            Assert.AreEqual(1, results.Count);
        }
    }
}