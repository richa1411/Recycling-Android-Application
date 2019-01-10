using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace KymiraApplicationUITests
{
    [TestFixture(Platform.Android)]
    public class ResidentUITests
    {
        IApp app;
        Platform platform;

        public ResidentUITests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void TestThatInterfaceLoadsCorrectly()
        {
            //
        }


    }
}
