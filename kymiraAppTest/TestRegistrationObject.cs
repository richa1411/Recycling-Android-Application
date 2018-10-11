using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using kymiraApp.Droid;

namespace kymiraAppTest
{
    [TestFixture(Platform.Android)]
    class TestRegistrationObject
    {


        RegistrationObject obReg;

       [SetUp]
        public void TestsetUp()
        {
            obReg = new RegistrationObject("", "", "", "", "", "", "", "", "", "","", true);
        }

        [Test]
        public void TestThatWeCanCreateARegistrationObject()
        {
            Assert.IsTrue(obReg.testStuff());
        }

    }
}
