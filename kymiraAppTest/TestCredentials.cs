using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace kymiraAppTest
{
<<<<<<< HEAD
    public class TestCredentials
    {
=======
    
    [TestFixture(Platform.Android)]
	
	public class TestCredentials
	{
		IApp app;
		Platform platform;
       
       

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
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90

        [Test]
        public static void TestPhoneNumberNotEmpty()
        {

            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("", "shah11081");

            Assert.AreEqual("", objCredentials.getPhone());
<<<<<<< HEAD

=======
            
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90
        }

        [Test]
        public static void TestPhoneNumberOnlyDigits()
        {

<<<<<<< HEAD
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shah11081");


            String phoneCheck = objCredentials.getPhone();
            bool trueDigit;
            foreach (char c in phoneCheck)
=======
          kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shah11081");

           
          String phoneCheck = objCredentials.getPhone();
         bool trueDigit;
          foreach(char c in phoneCheck)
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90
            {
                if (c >= '0' || c <= '9')
                {
<<<<<<< HEAD

=======
                   
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90
                    trueDigit = true;
                    Assert.IsTrue(trueDigit);
                }
            }
<<<<<<< HEAD

=======
            
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90
        }

        [Test]
        public static void TestPhoneNumberTenDigitLegth()
        {
<<<<<<< HEAD
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shah11081");
            Assert.AreEqual(9, objCredentials.getPhone().Length);
=======
           kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shah11081");
           Assert.AreEqual(9, objCredentials.getPhone().Length);
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90
        }

        [Test]
        public static void TestPhoneNumberExceedTenDigit()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892454656", "shah11081");
<<<<<<< HEAD


            Assert.IsTrue(objCredentials.getPhone().Length > 10);
=======
           
            
             Assert.IsTrue(objCredentials.getPhone().Length > 10);
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90
        }

        [Test]
        public static void TestPhoneNumberLessThanTenDigit()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512", "shah11081");
<<<<<<< HEAD

=======
            
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90
            Assert.IsTrue(objCredentials.getPhone().Length < 10);
        }

        [Test]
        public static void TestPasswordNotEmpty()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "");
<<<<<<< HEAD

            Assert.AreEqual("", objCredentials.getPassword());
=======
          
            Assert.AreEqual("", objCredentials.getPass());
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90
        }

        [Test]
        public static void TestPasswordLessThanSixChar()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shah1");
<<<<<<< HEAD

            Assert.IsTrue(objCredentials.getPassword().Length < 6);
=======
            
            Assert.IsTrue(objCredentials.getPass().Length < 6);
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90
        }

        [Test]
        public static void TestPasswordBetweenSixAndTwelveChar()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shah11");
            kymiraApp.Credentials objCredentials2 = new kymiraApp.Credentials("4512367892", "shahricha110");
<<<<<<< HEAD


            Assert.IsTrue(objCredentials2.getPassword().Length == 6);

            Assert.IsTrue(objCredentials.getPassword().Length == 12);
=======
           
           
            Assert.IsTrue(objCredentials2.getPass().Length == 6);
            
            Assert.IsTrue(objCredentials.getPass().Length ==12);
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90

        }

        [Test]
        public static void TestPasswordGreaterThanTwelveChar()
        {
            kymiraApp.Credentials objCredentials = new kymiraApp.Credentials("4512367892", "shahricha110464fg");
<<<<<<< HEAD
            Assert.IsTrue(objCredentials.getPassword().Length > 12);
=======
            Assert.IsTrue(objCredentials.getPass().Length >12);
>>>>>>> d37cb3949258b29b35c3665c38cf2efc584f3a90
        }
    }
}
