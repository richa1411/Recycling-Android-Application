using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace kymiraAppTest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Example
    {
        int test;

        public Example()
        {
            test = 32;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            test = 32;
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            Assert.IsTrue(true);
        }
    }
}
