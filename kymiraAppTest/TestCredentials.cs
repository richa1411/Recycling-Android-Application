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
	public class TestCredentials
	{
		IApp app;
		Platform platform;
        String phoneNumber;
        String password;
        public TestCredentials(String phoneNumber, String password)
        {
            this.phoneNumber = phoneNumber;
            this.password = password;

        }

		public TestCredentials(Platform platform)
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
        public static void TestPhoneNumberNotEmpty()
        {
           
            TestCredentials testObj = new TestCredentials("", "");

            Assert.AreEqual("",testObj.phoneNumber);
            
        }

        [Test]
        public static void TestPhoneNumberOnlyDigits()
        {
            TestCredentials testObj = new TestCredentials("456723456", "");
            String phoneCheck = testObj.phoneNumber;
            bool trueDigit;
            foreach(char c in phoneCheck)
            {
                if(c >='0'  || c <= '9')
                {
                    trueDigit = true;
                    Assert.IsTrue(trueDigit);
                }

            }
           
        }

        [Test]
        public static void TestPhoneNumberNineDigitLegth()
        {
            TestCredentials testObj = new TestCredentials("123456789", "");
            Assert.AreEqual(9, testObj.phoneNumber.Length);
        }

        [Test]
        public static void TestPhoneNumberExceedNineDigit()
        {
            TestCredentials testObj = new TestCredentials("1234567895675", "");
            Assert.IsTrue(testObj.phoneNumber.Length > 9);
        }

        [Test]
        public static void TestPhoneNumberLessThanNineDigit()
        {
            TestCredentials testObj = new TestCredentials("12345", "");
            Assert.IsTrue(testObj.phoneNumber.Length < 9);
        }

        [Test]
        public static void TestPasswordNotEmpty()
        {
            TestCredentials testObj = new TestCredentials("123456789", "");
            Assert.AreEqual("", testObj.password);
        }

        [Test]
        public static void TestPasswordLessThanSixChar()
        {
            TestCredentials testObj = new TestCredentials("123456789", "shah1");
            Assert.IsTrue(testObj.password.Length < 6);
        }

        [Test]
        public static void TestPasswordBetweenSixAndTwelveChar()
        {
            TestCredentials testObj = new TestCredentials("123456789", "shah11");
            Assert.IsTrue(testObj.password.Length == 6);
            TestCredentials testObj2 = new TestCredentials("123456789", "shahricha110");
            Assert.IsTrue(testObj.password.Length ==12);

        }

        [Test]
        public static void TestPasswordGreaterThanTwelveChar()
        {
            TestCredentials testObj = new TestCredentials("123456789", "shahricha11089");
            Assert.IsTrue(testObj.password.Length >12);
        }
    }
}
