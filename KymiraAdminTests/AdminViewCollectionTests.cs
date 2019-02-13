using KymiraAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using KymiraAdmin.Fixtures;

namespace KymiraAdminTests
{
    [TestClass]
    public class AdminViewCollectionTests
    {
        
        /*
        List<BinStatus> list = new List<BinStatus>
        {
            new BinStatus{ binID = "W114-320-123", collectionDate = "2018-01-01", siteID = 1609312, status = 1 },
            new BinStatus{ binID = "W114-320-124", collectionDate = "2018-01-01", siteID = 1609312, status = 1 },
            new BinStatus{ binID = "W114-320-125", collectionDate = "2018-01-01", siteID = 1609312, status = 1 },
            new BinStatus{ binID = "W114-320-123", collectionDate = "2018-02-02", siteID = 1609313, status = 1 }
        };
        */

        //list of BinStatuses to compare test results to -- in order (siteID, binID, collectionDate(?))
        List<BinStatus> dbBins = fixture_bin_status.obBins;
        

        [TestInitialize]
        public void Setup()
        {
            //remove all items from the database and add data to be displayed to test for
            //call fixture class to load bin statuses
        }

        [TestMethod]
        //Test that a deleted collection status is removed from the list (and database)
        public void TestThatDeletedStatusNotDisplayed()
        {
            //List<BinStatus> list = BinStatusPage.Index();
            //Assert.IsTrue(!dbBins.Contains());
        }

        [TestMethod]
        //test that list is displayed in the correct order
        public void TestThatListIsDisplayedInOrder()
        {
            //Assert.IsTrue(dbBins.Equals());
        }

        [TestMethod]
        //test that an empty list (no bin status objects to display) displays message
        public void TestThatEmptyListDisplaysMessage()
        {
            //assert is true that list received is empty
            //assert is true that message is displayed
        }

        [TestMethod]
        //test that message is displayed if connection cannot be made / is timed out
        public void TestThatNoConnectionDisplaysMessage()
        {
            //assert is true that message is displayed
            //assert is true that list is not displayed
        }
    }
}
