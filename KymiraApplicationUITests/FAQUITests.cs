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
        //test that all elements load onto the app upon startup
        public void TestThatAppInterfaceLoadsCorrectly()
        {
            ArrayList results = new ArrayList();
            results.Add(app.WaitForElement(c => c.Marked("drawer_layout")));
            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void TestThatFAQOptionClickOpensFAQPage()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 890);
            results.Add(app.WaitForElement(c => c.Marked("etxtSearchBox")));
            results.Add(app.WaitForElement(c => c.Marked("lvFAQ")));
            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void TestThatValidSearchReturnsResults()
        {

            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 890);
            results.Add(app.WaitForElement(c => c.Marked("etxtSearchBox")));
            app.Tap("etxtSearchBox");
            app.EnterText("How can I register with different bin locations");
            results.Add(app.WaitForElement(c => c.Marked("You can register as many time as you can with different addresses")));
            Assert.AreEqual(2, results.Count);

        }

        [Test]
        public void TestThatInvalidSearchReturnsError()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100);
            app.TapCoordinates(350, 890);
            results.Add(app.WaitForElement(c => c.Marked("etxtSearchBox")));
            app.Tap("etxtSearchBox");
            app.EnterText("1234");
            results.Add(app.WaitForElement(c => c.Marked("The search didn’t match any answers")));
            Assert.AreEqual(2, results.Count);
        }



    }
}
