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
            //app.Tap(c => c.Marked("nav_view"));
            //app.Tap(c => c.Marked("nav_bin_status"));
        }

        [Test]
        //test that all elements load onto the app upon startup
        public void TestThatAppInterfaceLoadsCorrectly()
        {
            ArrayList results = new ArrayList();
            results.Add(app.WaitForElement(c => c.Marked("Bin Statuses")));
            results.Add(app.WaitForElement(c => c.Marked("Address")));
            results.Add(app.WaitForElement(c => c.Marked("addressEntry").Text("")));
            results.Add(app.WaitForElement(c => c.Marked("btnSubmit")));
            results.Add(app.WaitForElement(c => c.Marked("lblCollected")));
            results.Add(app.WaitForElement(c => c.Marked("lblContaminated")));
            results.Add(app.WaitForElement(c => c.Marked("lblInaccessible")));

            //check that all elements are here
            Assert.AreEqual(7, results.Count);
        }


        //-----------------Address UI tests-------------------------------
        [Test]
        //test that after tapping the Submit button with no address entered, the user gets a message saying that
        //there is no bins associated with the address submitted. 
        public void TestThatListViewNotChangedOnEmptyAddress()
        {
            ArrayList results = new ArrayList();

            app.Tap(c => c.Marked("btnSubmit"));

            results.Add(app.WaitForElement(c => c.Marked("Address cannot be empty")));

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        //test that address cannot be greater than 200 characters
        public void TestThatListViewNotChangedOnLargeAddress()
        {
            ArrayList results = new ArrayList();

            app.Tap(c => c.Marked("addressEntry"));
            app.EnterText(new String('a', 201));
            app.Tap(c => c.Marked("btnSubmit"));

            results.Add(app.WaitForElement(c => c.Marked("Address must be 1 to 200 characters")));

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        //test that address can be 200 characters (no matching bins but does not give user an error)
        public void TestThatListViewUnchangedOn200CharAddress()
        {
            ArrayList results = new ArrayList();

            app.Tap(c => c.Marked("addressEntry"));
            app.EnterText(new String('a', 200));
            app.Tap(c => c.Marked("btnSubmit"));

            results.Add(app.WaitForElement(c => c.Marked("No matching bins with that address")));

            Assert.AreEqual(1, results.Count);
        }

        [Test]
        //test that correct address updates the textviews with the correct information. A fixture class has data that
        //states that there are three bins for the supplied address two of which are collected and one contaminated. This
        //test checks that the lables and the associated values load in
        public void TestThatCorrectAddressUpdatesListView()
        {
            ArrayList results = new ArrayList();

            app.EnterText("123 Test Street");
            app.Tap(c => c.Marked("btnSubmit"));

            //make sure populated textviews are correct/not empty
            results.Add(app.WaitForElement(c => c.Marked("2/3")));
            results.Add(app.WaitForElement(c => c.Marked("1/3")));
            results.Add(app.WaitForElement(c => c.Marked("0/3")));

            Assert.AreEqual(2, results.Count);
        }

        [Test]
        //test that incorrect address leaves the textviews unchanged
        public void TestThatIncorrectAddressAffectsListView()
        {
            ArrayList results = new ArrayList();

            app.EnterText("12345 Fake Street");
            app.Tap(c => c.Marked("btnSubmit"));

            results.Add(app.WaitForElement(c => c.Marked("No bins associated with that address.")));

            Assert.AreEqual(1, results.Count);
        }
    }

    //add emtpy test 
}