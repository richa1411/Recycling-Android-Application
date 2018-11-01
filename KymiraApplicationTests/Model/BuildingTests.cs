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
    public class BuildingTests
    {


        [TestInitialize]
        public void TestSetup()
        {
            Building testBin = new Building
            {
                addressID = 1,
                addressName = "justabuilding",
                NbhdID = 1
            };
        }
        [TestMethod()]
        public void BuildingTest()
        {
            Assert.Fail();
        }
    }
}