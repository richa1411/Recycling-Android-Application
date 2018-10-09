using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace kymiraAppTest
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void WelcomeTextIsDisplayed()
		{
			AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
			app.Screenshot("Welcome screen.");

			Assert.IsTrue(results.Any());
		}

        [Test]
        public static void TestPhoneNumberNotEmptyFail()
        {
            String phoneNumberDummy = "";

            Assert.AreEqual("", phoneNumberDummy);
        }

        [Test]
        public static void TestPhoneNumberOnlyDigitsSucceed()
        {

        }

        [Test]
        public static void TestPhoneNumberNineDigitLegthSucceed()
        {

        }

        [Test]
        public static void TestPhoneNumberExceedNineDigitFail()
        {

        }

        [Test]
        public static void TestPhoneNumberLessThanNineDigitFail()
        {

        }

        [Test]
        public static void TestPasswordNotEmptyFail()
        {

        }

        [Test]
        public static void TestPasswordLessThanSixCharFail()
        {

        }

        [Test]
        public static void TestPasswordBetweenSixAndTwelveCharSucceed()
        {

        }

        [Test]
        public static void TestPasswordGreaterThanTwelveCharFail()
        {

        }
    }
}
