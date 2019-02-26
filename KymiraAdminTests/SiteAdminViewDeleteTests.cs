﻿using KymiraAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace KymiraAdminTests
{
    [TestClass]
    public class SiteAdminViewDeleteTests
    {
        static TestDatabaseContext db = new TestDatabaseContext("kymira_db2");
        public static KymiraAdminContext context;

        public static IWebDriver driver; //browser to interact with

        [ClassInitialize] //this method will run once before all of the tests
        public static void ClassInitialize(TestContext context)
        {
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
            driver.Navigate().GoToUrl("http://localhost:55270/Sites");
        }


        [TestMethod]
        //Test that a deleted Site is removed from the list
        //TO DO: GET LAST ITEM TO DELETE - grab text of this record and once back on the 
        // list page, go through all fields and search for this text to ensure that it is not anywhere on the page!!!
        public void TestThatDeletedStatusNotDisplayed()
        {
            //select item to remove - last item
            var itemToDelete = driver.FindElement(By.CssSelector(".table tr td:nth-child(3)"));

            //click to delete the first collection status
            var deleteLink = driver.FindElement(By.CssSelector(".table tr td:last-child"));
            deleteLink.Click();


            //on delete confirmation page - shows info about specific bin selected
            var binInfo = new List<IWebElement>(driver.FindElements(By.CssSelector("dl dd")));
            var binTitles = new List<IWebElement>(driver.FindElements(By.CssSelector("dl dt")));

            //above lists come back as empty********

            //ensure titles displayed are correct
            Assert.AreEqual(binTitles[0].Text, "binID");
            Assert.AreEqual(binTitles[1].Text, "status");
            Assert.AreEqual(binTitles[2].Text, "siteID");
            Assert.AreEqual(binTitles[3].Text, "collectionDate");

            //ensure detail info is correct
            Assert.AreEqual(binInfo[0].Text, obBins[0].binID);
            Assert.AreEqual(binInfo[1].Text, obBins[0].status);
            Assert.AreEqual(binInfo[2].Text, obBins[0].siteID);
            Assert.AreEqual(binInfo[3].Text, obBins[0].collectionDate);

            driver.FindElement(By.LinkText("Back to List")); //verify link is showing
            var btnDelete = driver.FindElement(By.CssSelector("btn btn-default")); //delete button
            btnDelete.Click();

            //back to list page
            //ensure item is no longer there
            var item = driver.FindElement(By.CssSelector(".table tr td:nth-child(1)")); //grab 1st item in list
            Assert.AreNotEqual(item.Text, itemToDelete.Text);
            //ensure list is one less
            Assert.AreEqual(driver.FindElements(By.CssSelector(".table tr")).Count, obBins.Count - 1);
        }

        [TestMethod]
        //test that list is displayed in the correct order
        //TODO: DO NOT LOOK AT LAST ITEM (will be deleted in other test)
        public void TestThatListIsDisplayedInOrder()
        {
            //list of all rows
            var list = driver.FindElements(By.CssSelector(".table tr"));

            //list of siteID data shown in list
            var siteIdData = driver.FindElements(By.CssSelector(".table tr td:first-child"));

            //check matching data from expected list defined above
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(siteIdData[i++].Text, obBins[i].siteID.ToString());
            }

            //ensure all rows are shown
            Assert.AreEqual(siteIdData.Count, obBins.Count);
        }


        [TestMethod]
        //test that if admin cancels deletion that they are taken back to the list and the list has not changed
        //TODO: add checking detail fields for specific item
        public void TestThatAdminIsTakenBackToList()
        {
            //check that list has not changed / collection item has not been deleted
            var initialRows = driver.FindElements(By.CssSelector(".table tr"));

            //click to view the confirmation page
            driver.FindElement(By.CssSelector(".table tr td:last-child")).Click();

            //ensure is on confirmation page - verify elements are here
            driver.FindElements(By.CssSelector("dl dd"));
            driver.FindElements(By.CssSelector("dl dt"));
            //driver.FindElement(By.CssSelector("#btnDelete"));

            driver.FindElement(By.LinkText("Back to List")).Click(); //link to go back

            //back to list page
            //ensure list size has not changed
            var rows = driver.FindElements(By.CssSelector(".table tr"));
            Assert.AreEqual(initialRows.Count, rows.Count);
        }

    }
}
