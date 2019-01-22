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

    class BinStatusUITestNoServer
    {
        IApp app;
        Platform platform;

        public BinStatusUITestNoServer(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void SetUp()
        {
            //navigate to the bin status view page each time
            app = AppInitializer.StartApp(platform);
            app.Tap(c => c.Marked("nav_view"));
            app.Tap(c => c.Marked("nav_bin_status"));
        }

        public void TestThatGetErrorMessageNoConnection()
        {
            ArrayList results = new ArrayList();

            app.EnterText("1 Example Street");

            app.Tap(c => c.Marked("btnSubmit"));

            results.Add(app.WaitForElement(c => c.Marked("Sorry, something went wrong, please try again in a few minutes")));

            Assert.AreEqual(1, results.Count);
        }
    }
}
