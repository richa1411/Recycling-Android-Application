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
        //tests that if an address given which is over 200 characters throws an error
        public void TestThat201CharAddressIsInvalid()
        {

        }

        [TestMethod]
        //tests that if an address given which is in the database returns bins
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

        //BINNAME

        [TestMethod]
        //tests that a bin object can have a binName
        public void TestThatBinsWithStringBinNamesAreValid()
        {

        }

        [TestMethod]
        //tests that a bin object does not have to have a binName
        public void TestThatBinsWithEmptyBinNamesAreValid()
        {

        }

        [TestMethod]
        //tests that a bin object binName has to be a string if it is not null
        public void TestThatBinsWithNonStringBinNameAreInvalid()
        {

        }

        //ADDRESSID

        [TestMethod]
        //tests that a proper bin object addressid is accepted
        public void TestThatBinsWithNumAddressIdsAreValid()
        {

        }

        [TestMethod]
        //tests that a bin object can not have an empty AddressID
        public void TestThatBinsWithEmptyAddressIdsAreInvalid()
        {

        }

        [TestMethod]
        //tests that a bin object addressid has to be within 0 and 200 chars long
        public void TestThatBinsWith201CharAddressIdsAreInvalid()
        {

        }

        [TestMethod]
        //tests that a bin object addressid has to be a number
        public void TestThatBinsWithNonNumAddressIdsAreInvalid()
        {

        }

        //BINSTATUS

        [TestMethod]
        //tests that a bin object BinStatus cannot be empty
        public void TestThatBinsWithEmptyBinStatusAreInvalid()
        {

        }


        //PICKUPFREQUENCY

        [TestMethod]
        //tests that a bin object can only have an int as an id
        public void TestThatBinsWithEmptyPickupFrequencysAreInvalid()
        {

        }


        //PICKUPDAY

        [TestMethod]
        //tests that a bin object can only have an int as an id
        public void TestThatBinsWithEmptyPickupDaysAreInvalid()
        {

        }
        //************* BIULDING TESTS *************
    }
}
