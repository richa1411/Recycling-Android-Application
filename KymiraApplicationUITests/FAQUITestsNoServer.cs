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

    class FAQUITestsNoServer
    {

        IApp app;
        Platform platform;

        public FAQUITestsNoServer(Platform platform)
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
        public void TestThatAppDisplaysError()
        {
            ArrayList results = new ArrayList();

            app.TapCoordinates(100, 100); //tap the hamburger button
            app.Tap("FAQ"); //tap the FAQ button in the navigation drawer

            //There will be a timeout so  and when that happens the following error message will be displayed
            results.Add(app.WaitForElement(c => c.Marked("Something went wrong, please try again later")));

            Assert.AreEqual(1, results.Count);

        }
    }
}
