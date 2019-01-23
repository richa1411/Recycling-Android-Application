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
    public class BinStatusUITests
    {
        IApp app;
        Platform platform;

        public BinStatusUITests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void SetUp()
        {
            //navigate to the bin status view page each time
            app = AppInitializer.StartApp(platform);
            app.TapCoordinates(100, 100);
            app.Tap(c => c.Marked("View Recent Bin Statuses"));
        }

        [Test]
        //test that all elements load onto the app upon startup
        public void TestThatAppInterfaceLoadsCorrectly()
        {
            ArrayList results = new ArrayList();
           // results.Add(app.WaitForElement(c => c.Marked("Bin Statuses")));
            results.Add(app.WaitForElement(c => c.Marked("Address")));
            results.Add(app.WaitForElement(c => c.Marked("addressEntry").Text("")));
            results.Add(app.WaitForElement(c => c.Marked("btnSubmit")));
            results.Add(app.WaitForElement(c => c.Marked("lblCollected")));
            results.Add(app.WaitForElement(c => c.Marked("lblContaminated")));
            results.Add(app.WaitForElement(c => c.Marked("lblInaccessible")));
            //results.Add(app.WaitForElement(c => c.Marked("lblError")));

            //check that all elements are here
            Assert.AreEqual(6, results.Count);
        }

        [Test]
        //test that we get the correct error message when an address with no matching bins is returned
        public void TestThatAddressWithNoBinsReturnsMsg()
        {
            ArrayList results = new ArrayList();
            app.Tap(c => c.Marked("addressEntry"));
            app.EnterText("12345 Fake Street");
            app.Tap(c => c.Marked("btnSubmit"));
            results.Add(app.WaitForElement(c => c.Marked("No bins associated with that address.")));
            Assert.AreEqual(1, results.Count);
        }

        [Test]
        //test that address cannot be greater than 200 characters (error msg is displayed)
        public void TestThatLargeAddressReturnsErrorMsg()
        {
            ArrayList results = new ArrayList();

            app.Tap(c => c.Marked("addressEntry"));
            app.EnterText(new String('a', 201));
            app.Tap(c => c.Marked("btnSubmit"));

            results.Add(app.WaitForElement(c => c.Marked("Address must be 1 to 200 characters")));

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        //test that correct address returns matching bins and displayed on the app layout
        public void TestThatCorrectAddressReturnsBins()
        {
            ArrayList results = new ArrayList();
            app.Tap(c => c.Marked("addressEntry"));
            app.EnterText("123 Another Street");
            app.Tap(c => c.Marked("btnSubmit"));

            //make sure populated textviews are correct/not empty
            results.Add(app.WaitForElement(c => c.Marked("2/3")));
            results.Add(app.WaitForElement(c => c.Marked("1/3")));
            results.Add(app.WaitForElement(c => c.Marked("0/3")));

            Assert.AreEqual(3, results.Count);
        }

        [Test]
        //test that address can be 200 characters (no matching bins but does not give user an error)
        public void TestThatMaxAddressShowsNoMatch()
        {
            ArrayList results = new ArrayList();

            app.Tap(c => c.Marked("addressEntry"));
            app.EnterText(new String('a', 200));
            app.Tap(c => c.Marked("btnSubmit"));

            results.Add(app.WaitForElement(c => c.Marked("No bins associated with that address.")));

            Assert.AreEqual(1, results.Count);
        }
        
        [Test]
        //test that an empty address will show an error message
        public void TestThatEmptyAddressReturnsErrorMsg()
        {
            ArrayList results = new ArrayList();

            app.Tap(c => c.Marked("btnSubmit"));

            results.Add(app.WaitForElement(c => c.Marked("Address must be 1 to 200 characters")));

            Assert.AreEqual(1, results.Count);
        }
    } 
}