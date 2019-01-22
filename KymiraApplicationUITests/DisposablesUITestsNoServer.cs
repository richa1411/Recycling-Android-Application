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
    public class DisposablesUITestsNoServer
    {
        IApp app;
        Platform platform;

        public DisposablesUITestsNoServer(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }


        [Test]
        public void TestsThatErrorTextViewShowsUpWhenServerDoesNotReturnADisposableList()
        {

            ArrayList results = new ArrayList();
            app.TapCoordinates(100, 100);
            app.Tap("Disposables List");

            results.Add(app.WaitForElement(c => c.Marked("btnViewNonRecyclableItems")));
            Assert.AreEqual(1, results.Count);
            results = new ArrayList();
            app.Tap("btnViewNonRecyclableItems");
            results.Add(app.WaitForElement(c => c.Marked("errorLabel")));





        }






    }
}