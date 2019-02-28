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


        //list of sites expected to be shown on the page (in the DB)
        List<Site> obSites = new List<Site> {
        new Site
        {
            siteID = 10,
            address = "123 Test Street",
            frequency = Site.PickupFrequency.Weekly,
            sitePickupDays = Site.PickupDays.Monday
        },
        new Site
        {
            siteID = 20,
            address = "123 Another Street",
            frequency = Site.PickupFrequency.Weekly,
            sitePickupDays = Site.PickupDays.Monday
        },
        new Site
        {
            siteID = 30,
            address = "123 Fake Street",
            frequency = Site.PickupFrequency.Weekly,
            sitePickupDays = Site.PickupDays.Monday
        }

        };



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
        

        [TestInitialize]
        public void InitializeTest()
        {
            //navigate to proper page each time
            driver.Navigate().GoToUrl("http://localhost:55270/Sites");
        }


        [TestMethod]
        //Test that a deleted Site is removed from the list
        public void TestThatDeletedStatusNotDisplayed()
        {
            //select item to remove - last item
            var itemToDelete = driver.FindElement(By.CssSelector(".table tr td:nth-child(3)"));

            //click to delete the first collection status
            var deleteLink = driver.FindElement(By.CssSelector(".table tr td:last-child"));
            deleteLink.Click();


            //on delete confirmation page - shows info about specific bin selected
            var siteInfo = new List<IWebElement>(driver.FindElements(By.CssSelector("dl dd")));
            var siteTitles = new List<IWebElement>(driver.FindElements(By.CssSelector("dl dt")));
            
            //ensure titles displayed are correct
            Assert.AreEqual(siteTitles[0].Text, "siteID");
            Assert.AreEqual(siteTitles[1].Text, "address");
            Assert.AreEqual(siteTitles[2].Text, "frequency");
            Assert.AreEqual(siteTitles[3].Text, "sitePickupDays");

            //ensure detail info is correct
            Assert.AreEqual(siteInfo[0].Text, obSites[0].siteID);
            Assert.AreEqual(siteInfo[1].Text, obSites[0].address);
            Assert.AreEqual(siteInfo[2].Text, obSites[0].frequency);
            Assert.AreEqual(siteInfo[3].Text, obSites[0].sitePickupDays);

            driver.FindElement(By.LinkText("Back to List")); //verify link is showing
            var btnDelete = driver.FindElement(By.CssSelector("btn btn-default")); //delete button
            btnDelete.Click();

            //back to list page
            //ensure item is no longer there
            var item = driver.FindElement(By.CssSelector(".table tr td:nth-child(3)"));
            Assert.AreNotEqual(item.Text, itemToDelete.Text);

            //ensure list is one less
            Assert.AreEqual(driver.FindElements(By.CssSelector(".table tr")).Count, obSites.Count - 1);

            //ensure the Site's inactive field is set to true
            Site testSite = context.Site.Find("30");
            Assert.IsTrue(testSite.inactive);
        }

        [TestMethod]
        //test that list is displayed in the correct order
        //DO NOT LOOK AT LAST ITEM (will be deleted in other test)
        public void TestThatListIsDisplayedInOrder()
        {
            //list of all rows
            var list = driver.FindElements(By.CssSelector(".table tr"));

            //list of siteID data shown in list
            var siteIdData = driver.FindElements(By.CssSelector(".table tr td:first-child"));

            //check matching data from expected list defined above
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(siteIdData[i++].Text, obSites[i].siteID.ToString());
            }

            //ensure all rows are shown
            Assert.AreEqual(siteIdData.Count, obSites.Count);
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

            driver.FindElement(By.LinkText("Back to List")).Click(); //link to go back

            //back to list page
            //ensure list size has not changed
            var rows = driver.FindElements(By.CssSelector(".table tr"));
            Assert.AreEqual(initialRows.Count, rows.Count);
            
        }

        [TestMethod]
        //testing that the headers on the page are properly shown to the admin
        public void TestThatHeadersAreCorrect()
        {
            var intialRows = driver.FindElements(By.CssSelector(".table thead th"));

            List<String> listHeaders = new List<String>();

            listHeaders.Add("Site ID");
            listHeaders.Add("Full Address");
            listHeaders.Add("Frequency");
            listHeaders.Add("Site Pickup Day(s)");

            for(int i = 0; i < intialRows.Count; i++)
            {
                Assert.AreEqual(intialRows[i].Text, listHeaders[i]);
            }
        }


        
        [TestMethod]
        //This test will check that the nav bar is black
        public void TestThatNavBarIsBlack()
        {
            var navbar = driver.FindElement(By.CssSelector("nav:first-child"));
            var color = navbar.GetCssValue("background-color");
            Assert.AreEqual("rgba(34, 34, 34, 1)", color);
        }

        [TestMethod]
        //testing that all font displayed on the page is what is expected
        public void TestThatFontSizesAreCorrect()
        {
            var kymiraAdminText = driver.FindElement(By.CssSelector(".navbar-brand"));
            var navBarItemText = driver.FindElement(By.CssSelector(".container div:nth-child(2) ul li:first-child"));
            var siteTitleText = driver.FindElement(By.CssSelector("div h2"));
            var siteHeaderText = driver.FindElement(By.CssSelector(".table tr:first-child th:first-child"));
            var tableText = new List<IWebElement>(driver.FindElements(By.CssSelector(".table tbody tr td")));
            
            //checking navbar text size
            Assert.AreEqual("18px", kymiraAdminText.GetCssValue("font-size"));
            Assert.AreEqual("14px", navBarItemText.GetCssValue("font-size"));

            //checking page specific font sizes
            Assert.AreEqual("30px", siteTitleText.GetCssValue("font-size"));
            Assert.AreEqual("14px", siteHeaderText.GetCssValue("font-size"));
            
            //checking each row text size
            foreach (var td in tableText)
            {
                var size = td.GetCssValue("font-size");
                Assert.AreEqual("14px", size);
            }
        }

        [TestMethod]
        //testing that the sort by siteid is correct (ASCENDING)
        public void TestThatAscSiteIDIsCorrect()
        {
            //grab the header text displayed
            var siteTitles = new List<IWebElement>(driver.FindElements(By.CssSelector("dl dt")));

            siteTitles[0].Click(); //click the Site ID text once

            //checking that the first object displayed in the list contains the same site id as the first site in the expected list
            var firstSite = driver.FindElement(By.CssSelector(".table tr td"));
            Assert.AreEqual(firstSite.Text,obSites[0].siteID);
        }

        [TestMethod]
        //testing that the sort by siteid is correct (DESCENDING)
        public void TestThatDescSiteIDIsCorrect()
        {
            //grab the header text displayed
            var siteTitles = new List<IWebElement>(driver.FindElements(By.CssSelector("dl dt")));

            siteTitles[0].Click(); 
            siteTitles[0].Click(); //click the Site ID text twice for descending

            //checking that the first object displayed in the list contains the same site id as the last site in the expected list
            var lastSite = driver.FindElement(By.CssSelector(".table tr td"));
            Assert.AreEqual(lastSite.Text, obSites[2].siteID);
        }

        [TestMethod]
        //testing that the sort by siteid is correct (ASCENDING)
        public void TestThatAscAddressIsCorrect()
        {
            //grab the header text displayed
            var siteTitles = new List<IWebElement>(driver.FindElements(By.CssSelector("dl dt")));

            siteTitles[1].Click(); //click the Full Address text once

            //checking that the first object displayed in the list contains the same address as the first site in the expected list
            var firstSite = driver.FindElement(By.CssSelector(".table tr td:nth-child(2)"));
            Assert.AreEqual(firstSite.Text, obSites[0].siteID);
        }

        [TestMethod]
        //testing that the sort by siteid is correct (DESCENDING)
        public void TestThatDescAddressIsCorrect()
        {
            //grab the header text displayed
            var siteTitles = new List<IWebElement>(driver.FindElements(By.CssSelector("dl dt")));

            siteTitles[1].Click();
            siteTitles[1].Click(); //click the Full Address text twice for descending

            //checking that the first object displayed in the list contains the same address as the last site in the expected list
            var lastSite = driver.FindElement(By.CssSelector(".table tr td:nth-child(2)"));
            Assert.AreEqual(lastSite.Text, obSites[2].siteID);
        }
    }
}
