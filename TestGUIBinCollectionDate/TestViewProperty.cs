using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Collections;




namespace TestGUI
{
    [TestFixture(Platform.Android)]

    public class TestViewProperty
    {
        IApp app;
        Platform platform;

        public TestViewProperty(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        //Test that the elements exist in the current page and store them into an Array to check
        [Test]
        public void TestThatPropertyAddressPageLoadsCorrectly()
        {
            ArrayList results = new ArrayList();
            results.Add(app.WaitForElement(c => c.Marked("etAddress")));
            results.Add(app.WaitForElement(c => c.Marked("tvError")));
            results.Add(app.WaitForElement(c => c.Marked("btnSubmit")));

            Assert.AreEqual(3, results.Count);
        }

        //Test that the elements exist in the current page and store them into an Array to check
        [Test]
        public void TestThatEmptyAddressFieldShowsError()
        {
            ArrayList results = new ArrayList();
            app.Tap(c => c.Marked("btnSubmit"));
            results.Add(app.WaitForElement(c => c.Marked("etAddress")));
            results.Add(app.WaitForElement(c => c.Marked("tvError")));


            Assert.AreEqual(2, results.Count);
        }

        //Test that the elements exist in the current page and store them into an Array to check
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

        //Test that the elements exist in the current page and store them into an Array to check
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

        //Test that the elements exist in the page that is navigated to after a successful login 
        //and store them into an Array to check.
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
