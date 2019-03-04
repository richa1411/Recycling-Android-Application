using KymiraAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using KymiraAdminTests.Fixtures;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;

namespace KymiraAdminTests
{
    [TestClass]
    public class AdminViewCollectionTests
    {
        static TestDatabaseContext db = new TestDatabaseContext("KymiraAdminDatabase34");
        public static KymiraAdminContext context;
       

        public static IWebDriver driver; //browser to interact with

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

        [ClassCleanup] //this method will remove all items from BinStatus table in the database
        public static void ClassCleanup()
        {
            //fixture_bin_status.Unload(db.context);
        }

        [TestInitialize]
        public void InitializeTest()
        {
            //navigate to proper page each time
            driver.Navigate().GoToUrl("http://localhost:55270/BinStatus");
        }

        [TestMethod]
        //Test that a deleted collection status is removed from the list (and database)
        //TO DO: GET LAST ITEM TO DELETE - grab text of this record and once back on the 
        // list page, go through all fields and search for this text to ensure that it is not anywhere on the page!!!

        public void TestThatDeletedStatusNotDisplayed()
        {
            //do an initial count of items
            int initCount = driver.FindElements(By.CssSelector(".table tr")).Count;

            //select item to remove - 1st item
            var itemToDelete = driver.FindElement(By.CssSelector(".table tr td:nth-child(2)")).Text;
            
            //click to delete the first collection status
            var deleteLink = driver.FindElement(By.CssSelector(".table tr td:last-child a"));
            deleteLink.Click();


            //on delete confirmation page - shows info about specific bin selected
            var binTitles = new List<IWebElement>(driver.FindElements(By.CssSelector("dl dt")));

            //above lists come back as empty********

            //ensure titles displayed are correct
            Assert.AreEqual(binTitles[0].Text,"binID");
            Assert.AreEqual(binTitles[1].Text, "status");
            Assert.AreEqual(binTitles[2].Text, "siteID");
            Assert.AreEqual(binTitles[3].Text, "collectionDate");
            
            driver.FindElement(By.LinkText("Back to List")); //verify link is showing
            var btnDelete = driver.FindElement(By.CssSelector("#btnDelete")); //delete button
            btnDelete.Click();

            //back to list page
            //ensure item is no longer there
            
            var list = driver.FindElements(By.CssSelector(".table tr"));
            for (int i = 1; i < list.Count; i++)
            {
                var item = driver.FindElement(By.CssSelector(".table tr td:nth-child(" + (i+1) + ")")).Text; 
                Assert.AreNotEqual(item, itemToDelete);
            }
            
            //ensure list is one less
            Assert.AreEqual(initCount-1, driver.FindElements(By.CssSelector(".table tr")).Count);
        }

        [TestMethod]
        //test that list is displayed in the correct order
        public void TestThatListIsDisplayedInOrder()
        {
            //list of all rows
            var list = driver.FindElements(By.CssSelector(".table tr"));

            //list of siteID data shown in list
            var siteIdData = driver.FindElements(By.CssSelector(".table tr td:first-child"));
            var binIdData = driver.FindElements(By.CssSelector(".table tr td:nth-child(2)"));

            var lastSiteID = 0;
            var lastBinID = "";

            //check matching data from expected list defined above
            for (int i = 1; i < list.Count - 1; i++)
            {
                //check the site id
                Assert.IsTrue(Convert.ToInt32(siteIdData[i].Text) >= lastSiteID);

                if (Convert.ToInt32(siteIdData[i].Text) == lastSiteID)
                {
                    string binID = binIdData[i].Text;
                    //check the bin id
                    Assert.IsTrue( binID.CompareTo(lastBinID) >= 0);
                }

                lastSiteID = Convert.ToInt32(siteIdData[i].Text);
                lastBinID = binIdData[i].Text;
            }
        }

        [TestMethod]
        //test that an empty list (no bin status objects to display) displays message
        public void TestThatEmptyListDisplaysMessage()
        {
            //removing data from database
            fixture_bin_status.Unload(db.context);
            //assert is true that list received is empty
            var initialRows = driver.FindElements(By.CssSelector(".table tr"));
            Assert.AreEqual(1, initialRows.Count);
            //assert is true that message is displayed
            var errText = driver.FindElement(By.CssSelector(".table tr td")).Text;
            Assert.AreEqual("No collection records to display", errText);
        }

        [TestMethod]
        //test that if admin cancels deletion that they are taken back to the list and the list has not changed
        //TODO: add checking detail fields for specific item
        public void TestThatAdminIsTakenBackToList()
        {
            //check that list has not changed / collection item has not been deleted
            var initialRows = driver.FindElements(By.CssSelector(".table tr"));

            //click to view the confirmation page
            var delLink = driver.FindElement(By.CssSelector(".table tr td:last-child a"));
            delLink.Click();
            //ensure is on confirmation page - verify elements are here
            driver.FindElements(By.CssSelector("dl dd"));
            driver.FindElements(By.CssSelector("dl dt"));
            //driver.FindElement(By.CssSelector("#btnDelete"));

            var list = driver.FindElement(By.LinkText("Back to List"));
            list.Click(); //link to go back
            //back to list page
            //ensure list size has not changed
            var rows = driver.FindElements(By.CssSelector(".table tr"));
            Assert.AreEqual(initialRows.Count,rows.Count);
        }

        //This test will check that the nav bar is black
        [TestMethod]
        public void TestThatNavBarIsBlack()
        {
            var navbar = driver.FindElement(By.CssSelector("nav:first-child"));
            var color = navbar.GetCssValue("background-color");
            //color returns a stinrg which is what is below. we googled it and its right
            Assert.AreEqual("rgba(34, 34, 34, 1)", color);
        }

        //This test will check that the fontsize of the title is 30 pixels large
        [TestMethod]
        public void TestAdminpageFontSizes()
        {
            var KymiraAdminText = driver.FindElement(By.CssSelector(".navbar-brand"));
            var navBarItemText = driver.FindElement(By.CssSelector(".container div:nth-child(2) ul li:first-child"));
            var FaqTitleText = driver.FindElement(By.CssSelector("div h2"));
            var FAQHeaderText = driver.FindElement(By.CssSelector(".table tr:first-child th:first-child"));
            var TableText = new List<IWebElement>(driver.FindElements(By.CssSelector(".table tbody tr td")));
            Assert.AreEqual("18px", KymiraAdminText.GetCssValue("font-size"));
            Assert.AreEqual("14px", navBarItemText.GetCssValue("font-size"));
            Assert.AreEqual("30px", FaqTitleText.GetCssValue("font-size"));
            Assert.AreEqual("14px", FAQHeaderText.GetCssValue("font-size"));
            foreach (var td in TableText)
            {
                var size = td.GetCssValue("font-size");
                Assert.AreEqual("14px", size);
            }
        }
        [TestMethod]
        public void TestThatTableHeadersAreBold()
        {
            var FaqQuestionHeaderText = driver.FindElement(By.CssSelector(".table thead tr:first-child th:first-child"));
            var FaqAnswerHeaderText = driver.FindElement(By.CssSelector(".table thead tr:first-child th:nth-child(2)"));
            Assert.AreEqual("700", FaqQuestionHeaderText.GetCssValue("font-weight"));
            Assert.AreEqual("700", FaqAnswerHeaderText.GetCssValue("font-weight"));
        }
        
     }
}
