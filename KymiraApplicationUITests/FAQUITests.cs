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

    class FAQUITests
    {

        IApp app;
        Platform platform;

        public FAQUITests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        //Test that all elements load onto the app upon startup
        public void TestThatAppInterfaceLoadsCorrectly()
        {
            ArrayList results = new ArrayList();
            results.Add(app.WaitForElement(c => c.Marked("drawer_layout"))); //look for the drawer layout on the app startup page
            Assert.AreEqual(1, results.Count);
        }

        //Test that clicking the FAQ button in the navigation pane will open the FAQ page
        [Test]
        public void TestThatFAQOptionClickOpensFAQPage()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100); //tap the hamburger button
            app.Tap("FAQ"); //tap the FAQ button in the navigation drawer
            results.Add(app.WaitForElement(c => c.Marked("FAQ")));
            results.Add(app.WaitForElement(c => c.Marked("tvList")));

            Assert.AreEqual(2, results.Count);
        }

        /*
         * When the user taps an item on the list, it will open up a new fragment showing the entire answer to the question
         */ 
        [Test]
        public void TestThatTappingQuestionOpensDetailsPage()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100); //tap the hamburger button
            app.Tap("FAQ"); //tap the FAQ button in the navigation drawer
            app.Tap("lvItem"); //list item ID
            results.Add(app.WaitForElement(c => c.Marked("FAQ Details")));
            results.Add(app.WaitForElement(c => c.Marked("tvListDetails")));

            Assert.AreEqual(2, results.Count);

        }


    }
}
