using KymiraAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using KymiraAdmin.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KymiraAdminTests
{
    [TestClass]
    public class AdminViewCollectionTests
    {
        //static TestDatabaseContext db = new TestDatabaseContext("KymiraAdminDatabase30");

        /*
        List<BinStatus> list = new List<BinStatus>
        {
            new BinStatus{ binID = "W114-320-123", collectionDate = "2018-01-01", siteID = 1609312, status = 1 },
            new BinStatus{ binID = "W114-320-124", collectionDate = "2018-01-01", siteID = 1609312, status = 1 },
            new BinStatus{ binID = "W114-320-125", collectionDate = "2018-01-01", siteID = 1609312, status = 1 },
            new BinStatus{ binID = "W114-320-123", collectionDate = "2018-02-02", siteID = 1609313, status = 1 }
        };
        */


        List<BinStatus> obBins = new List<BinStatus> {
        new BinStatus
        {
            binID = "W114-320-203",
            siteID = 1609312,
            status = 1,
            collectionDate = "2019-01-01"
        },
        new BinStatus
        {
            binID = "W114-320-204",
            siteID = 1609312,
            status = 2,
            collectionDate = "2019-01-01"
        },
        new BinStatus
        {
            binID = "W114-320-205",
            siteID = 1609312,
            status = 1,
            collectionDate = "2019-01-01"
        },
        new BinStatus
        {
             binID = "COSMO123",
            siteID = 1609320,
            status = 1,
            collectionDate = "2019-01-01"
        },
        new BinStatus
        {
            binID = "12345",
            siteID = 1609320,
            status = 3,
            collectionDate = "2019-01-01"
        }};


        //list of BinStatuses to compare test results to -- in order (siteID, binID, collectionDate(?))
        //List<BinStatus> dbBins = fixture_bin_status.obBins;


        public static IWebDriver driver;

        [ClassInitialize] //this method will run once before all of the tests
        public static void ClassInitialize(TestContext context)
        {
            //load items into test database
            //fixture_bin_status.Load(db.context);

            ChromeOptions chrome_options = new ChromeOptions();
            //Wont open up a new chrome tab when run
            chrome_options.AddArgument("--headless");

            //disable various chrome services that may interfere with the test
            chrome_options.AddArgument("--disable-sync");
            chrome_options.AddArgument("--disable-extensions");
            chrome_options.AddArgument("--remote-debugging-address=0.0.0.0");
            chrome_options.AddArgument("--remote-debugging-port=9222");
            //Not necessary if running in headless mode
            chrome_options.AddArgument("--window-size=1280,720");

            //Assign the driver to the location of the chromedriver.exe on the local drive
            driver = new ChromeDriver("D:\\COSACPMG\\prj2.cosmo\\KymiraAdminTests\\bin\\Debug\\netcoreapp2.0", chrome_options);

        }

        [ClassCleanup] //this method will remove everything
        public static void ClassCleanup()
        {
            //remove all items from test database
            //fixture_bin_status.Unload(db.context);
        }

        [TestInitialize]
        public void InitializeTest()
        {
            //navigate to proper page
            driver.Navigate().GoToUrl("http://localhost:55270/BinStatus");
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
            //count of rows
            //int totalRows = driver.FindElements(By.CssSelector(".table tr")).Count;

            //list of all rows
            var list = driver.FindElements(By.CssSelector(".table tr"));

            //list of siteID data shown in list
            var siteIdData = driver.FindElements(By.CssSelector(".table tr td:first-child"));

            //check matching data from expected list defined above
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(siteIdData[i++], obBins[i++].siteID);
            }

            //ensure all rows are shown
            Assert.AreEqual(siteIdData.Count, obBins.Count);
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

        [TestMethod]
        //test that upon clicking the delete button for a collection status takes the admin to a confirmation page
        public void TestThatAdminIsTakenToDeleteConfirmationPage()
        {

        }

        [TestMethod]
        //test that if admin cancels deletion that they are taken back to the list and the list has not changed
        public void TestThatAdminIsTakenBackToList()
        {
            //check that list has not changed / collection item has not been deleted
        }
    }
}
