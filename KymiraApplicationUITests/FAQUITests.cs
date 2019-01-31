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
            results.Add(app.WaitForElement(c => c.Marked("lvFAQ")));

            Assert.AreEqual(2, results.Count);
        }

        /*
         * When the user taps an item on the list, it will open up a new fragment showing the entire answer to the question
         */ 
        [Test]
        public void TestThatTappingQuestionExpandsListView()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100); //tap the hamburger button
            app.Tap("FAQ"); //tap the FAQ button in the navigation drawer
            app.Tap("Do I have to register to view bin collection dates?"); //List item text
            app.Tap("Where is Cosmo Industries?"); //List item text
            app.Tap("How can I register with different bin locations?"); //List item text
            app.Tap("How do I get more rewards?"); //List item text
            app.Tap("What is COSMO Industries?"); //List item text

            results.Add(app.WaitForElement(c => c.Marked("1302 Alberta Ave. Saskatoon.")));
            results.Add(app.WaitForElement(c => c.Marked("You can register as many times as you can with different addresses.")));
            results.Add(app.WaitForElement(c => c.Marked("Be the part of weekly quizes and kepp updated with next collection dates to make your bin filled.")));
            results.Add(app.WaitForElement(c => c.Marked("Absolutely not, \"you\"  can just open an application enter your bin address and there's your date!")));
            results.Add(app.WaitForElement(c => c.Marked("It is a recycling place.")));

            Assert.AreEqual(5, results.Count);

        }

        [Test]
        public void TestThatTappingQuestionsTwiceWillCloseTheExpandsListView()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100); //tap the hamburger button
            app.Tap("FAQ"); //tap the FAQ button in the navigation drawer
            app.Tap("Do I have to register to view bin collection dates?"); //List item text
            app.Tap("Where is Cosmo Industries?"); //List item text
            app.Tap("How can I register with different bin locations?"); //List item text
            app.Tap("How do I get more rewards?"); //List item text
            app.Tap("What is COSMO Industries?"); //List item text

            //Close some Expanded Lists
            app.Tap("How can I register with different bin locations?"); //List item text
            app.Tap("How do I get more rewards?"); //List item text
            app.Tap("What is COSMO Industries?"); //List item text

            results.Add(app.WaitForElement(c => c.Marked("1302 Alberta Ave. Saskatoon.")));
            results.Add(app.WaitForElement(c => c.Marked("Absolutely not, \"you\"  can just open an application enter your bin address and there's your date!")));
            

            Assert.AreEqual(5, results.Count);

        }

    }
}
