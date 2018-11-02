using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KymiraApplicationTests
{
    [TestClass]
    public class BinStatusTests
    {
        //************* ADDRESS ENTRY TESTS *************
        [TestMethod]
        //tests that if an address given which is not in the database throws an error and does not return any bins
        public void TestThatUnknownAddressIsInvalid()
        {

        }

        [TestMethod]
        //tests that an address given which is over 200 characters throws an error
        public void TestThat201CharAddressIsInvalid()
        {

        }

        [TestMethod]
        //tests that an address given which is in the database returns bins
        public void TestThatKnownAddressIsValid()
        {

        }

        //************* BIN TESTS *************
        //ID

        [TestMethod]
        //tests that a bin object can only have an int as an id
        public void TestThatBinsWithNonIntIDsAreInvalid()
        {

        }

        [TestMethod]
        //tests that a bin object can only have an int as an id and must have one
        public void TestThatBinsWithNoIDsAreInvalid()
        {

        }

        [TestMethod]
        //tests that a bin object can only have an int as an id
        public void TestThatBinsWithIntIDsAreValid()
        {

        }

        //BINSTATUS

        [TestMethod]
        //tests that a bin object BinStatus cannot be empty
        public void TestThatBinsWithEmptyBinStatusAreInvalid()
        {

        }

        [TestMethod]
        //tests that a bin object BinStatus of one of the valid numbers is valid
        public void TestThatBinsWithProperBinStatusAreValid()
        {

        }

        //ADDRESSNAME
        [TestMethod]
        //tests that a bin object addressName cannot be empty
        public void TestThatBinsWithEmptyAddressNameAreInvalid()
        {

        }

        [TestMethod]
        //tests that a bin object addressName cannot be over 200 chars long
        public void TestThatBinsWith201CharAddressNameAreInvalid()
        {

        }
    }
}
