using KymiraAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KymiraAdminTests
{
    [TestClass]
    public class AdminViewCollectionTests
    {
        //list of BinStatuses to compare test results to -- in order (siteID, binID, collectionDate(?))
        List<BinStatus> list = new List<BinStatus>
        {
            new BinStatus{ binID = "W114-320-123", collectionDate = "2018-01-01", siteID = 1609312, status = 1 },
            new BinStatus{ binID = "W114-320-124", collectionDate = "2018-01-01", siteID = 1609312, status = 1 },
            new BinStatus{ binID = "W114-320-125", collectionDate = "2018-01-01", siteID = 1609312, status = 1 },
            new BinStatus{ binID = "W114-320-123", collectionDate = "2018-02-02", siteID = 1609313, status = 1 }
        };

        [TestInitialize]
        public void Setup()
        {
            //remove all items from the database and add data to be displayed to test for
            
        }

        [TestMethod]
        //Test that a deleted collection status is removed from the list (and database)
        public void TestThatDeletedStatusNotDisplayed()
        {
            
        }

        [TestMethod]
        //test that list is displayed in the correct order
        public void TestThatListIsDisplayedInOrder()
        {

        }

        [TestMethod]
        //test that an empty list (no bin status objects to display) displays message
        public void TestThatEmptyListDisplaysMessage()
        {

        }

        [TestMethod]
        //test that message is displayed if connection cannot be made / is timed out
        public void TestThatNoConnectionDisplaysMessage()
        {

        }
    }
}
