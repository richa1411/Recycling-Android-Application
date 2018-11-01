using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KymiraApplication.Model.Tests
{
    [TestClass()]
    public class BinTests
    {


        [TestInitialize]
        public void TestSetup()
        {
            Bin testBin = new Bin {
                binID = 123455,
                binName = "justabin",
                addressID = 123,
                binStatus = 1,
                pickupFrequency = 1,
                pickupDay = null
                

            };
        }

        [TestMethod()]
        public void BinTest()
        {
            Assert.Fail();
        }
    }
}