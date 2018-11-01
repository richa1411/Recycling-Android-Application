using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using kymiraAPI;
using kymiraAPI.Models;
using System.Collections.Generic;
using System.Text;

namespace kymiraAPITest
{
    [TestClass]
    class story2gTests
    {
        DisposableQuery testDbItem;

       [TestInitialize]
       public void TestInitialize()
        {
            testDbItem = new DisposableQuery();
            testDbItem.name = "Glass Bottles";
            testDbItem.description = "These are Glass Bottles";
            testDbItem.picture = "../images/GlassBottles.jpg";
            testDbItem.recyclableReason = "Glass Bottles Reason";
            testDbItem.endResult = "Glass Bottles End Result";
            testDbItem.qtyRecycled = 1000;
        }

        [TestMethod]
        public void AllRecyclableInformationIsValidTest()
        {
            Assert.IsNotNull(testDbItem.name);
            Assert.AreEqual("Glass Bottles", testDbItem);

        }

        [TestMethod]
        public void NameIsNotValid()
        {
            testDbItem.name = null;

            
        }

    }
}
