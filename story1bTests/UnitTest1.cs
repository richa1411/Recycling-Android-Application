using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace story1bTests
{
    [TestClass]
    public class UnitTest1
    {
        string phoneNumber;
        string password;
        public UnitTest1(string phoneNumber, string password)
        {
            this.phoneNumber = phoneNumber;
            this.password = password;
        }

        [TestMethod]
        public static void TestPhoneNumberNotEmpty()
        {

            UnitTest1 testObj = new UnitTest1("", "");

            Assert.AreEqual("", testObj.phoneNumber);

        }

        [TestMethod]
        public static void TestPhoneNumberOnlyDigits()
        {
            UnitTest1 testObj = new UnitTest1("456723456", "");
            string phoneCheck = testObj.phoneNumber;
            bool trueDigit;
            foreach (char c in phoneCheck)
            {
                if (c >= '0' || c <= '9')
                {
                    trueDigit = true;
                    Assert.IsTrue(trueDigit);
                }
            }

        }

        [TestMethod]
        public static void TestPhoneNumberNineDigitLegth()
        {
            UnitTest1 testObj = new UnitTest1("123456789", "");
            Assert.AreEqual(9, testObj.phoneNumber.Length);
        }

        [TestMethod]
        public static void TestPhoneNumberExceedNineDigit()
        {
            UnitTest1 testObj = new UnitTest1("1234567895675", "");
            Assert.IsTrue(testObj.phoneNumber.Length > 9);
        }

        [TestMethod]
        public static void TestPhoneNumberLessThanNineDigit()
        {
            UnitTest1 testObj = new UnitTest1("12345", "");
            Assert.IsTrue(testObj.phoneNumber.Length < 9);
        }

        [TestMethod]
        public static void TestPasswordNotEmpty()
        {
            UnitTest1 testObj = new UnitTest1("123456789", "");
            Assert.AreEqual("", testObj.password);
        }

        [TestMethod]
        public static void TestPasswordLessThanSixChar()
        {
            UnitTest1 testObj = new UnitTest1("123456789", "shah1");
            Assert.IsTrue(testObj.password.Length < 6);
        }

        [TestMethod]
        public static void TestPasswordBetweenSixAndTwelveChar()
        {
            UnitTest1 testObj = new UnitTest1("123456789", "shah11");
            Assert.IsTrue(testObj.password.Length == 6);
            UnitTest1 testObj2 = new UnitTest1("123456789", "shahricha110");
            Assert.IsTrue(testObj.password.Length == 12);

        }

        [TestMethod]
        public static void TestPasswordGreaterThanTwelveChar()
        {
            UnitTest1 testObj = new UnitTest1("123456789", "shahricha11089");
            Assert.IsTrue(testObj.password.Length > 12);
        }
    }
}
