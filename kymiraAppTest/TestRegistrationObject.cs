using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kymiraApp.Droid;
using NUnit.Framework;

using Xamarin.UITest;
using Xamarin.UITest.Queries;



namespace kymiraAppTest
{
    [TestFixture(Platform.Android)]
    class TestRegistrationObject
    {


        Registration obReg;


       [SetUp]
        public void TestsetUp()
        {
            obReg = new Registration("test@test.com", "donthackthis", "3065221213", "nick", "pyle", "09-8-1992", " 2309 argyle ave",
                "A", "Saskatoon", "Saskatchewan", "S472C8", true);
        }

        [Test]
        public void TestThatWeCanCreateARegistrationObject()
        {
            Assert.IsInstanceOf(typeof(Registration),obReg);
        }
        [Test]
        public void TestThatRegistrationFieldsWereCreatedCorrectly()
        {
            Assert.AreEqual("test@test.com",obReg.emailAddress);
            Assert.AreEqual("donthackthis", obReg.password);
            Assert.AreEqual("3065221213",obReg.phoneNumber);
            Assert.AreEqual("nick", obReg.firstName);
            Assert.AreEqual("pyle", obReg.lastName);
            Assert.AreEqual("09-8-1992", obReg.birthDate);
            Assert.AreEqual(" 2309 argyle ave", obReg.addressLine1);
            Assert.AreEqual("A", obReg.addressLine1);
            Assert.AreEqual("Saskatoon", obReg.city);
            Assert.AreEqual("Saskatchewan", obReg.province);
            Assert.AreEqual("S472C8", obReg.postalCode);
            Assert.IsTrue(obReg.checkBox);
        }


    }
}
