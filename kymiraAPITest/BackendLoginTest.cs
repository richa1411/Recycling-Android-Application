using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kymiraAPITest
{
    [TestClass]
    public class BackendLoginTest
    {
        string phoneNumber;
        string password;
        string message;

        backendLoginValidation = new BackendLoginValidation;

        [TestInitialize]
        public void InitializeTest()
        {
            phoneNumber = "";
            password = "";
            message = "";
        }

        [TestMethod]
        public void PhoneNumberEmpty()
        {
            
            Assert.AreEqual("", phoneNumber);
            message = 
        }
    }
}
