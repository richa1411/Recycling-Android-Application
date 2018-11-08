using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Model;
using KymiraApplication;


namespace KymiraApplicationTests
{
    [TestClass]
    public class TestBinCollectionDate
    {
        BinCollectionDate binColl;

        [TestInitialize]
        public void InitializeTest()
        {
            binColl = new BinCollectionDate { Address = "123 Test Dr", collectionDate = "11/30/2018" }; //date is just a string right now.
        }

        public void testAddressEmpty()
        {
            var results = HelperTestModel.Validate(binColl);
            //Assert.AreEqual(1, results.Count());
            //Assert.AreEqual("Please Enter your Phone Number", results[0].ErrorMessage);
        }





        public TestBinCollectionDate()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
