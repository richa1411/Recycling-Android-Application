using KymiraAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KymiraAdminTests
{
    [TestClass]
    public class SiteAdminViewDeleteTests
    {
        //test database class object
        static TestDatabaseContext db = new TestDatabaseContext("kymira_db2");
        public static IWebDriver driver; //browser to interact with

        //list of sites expected to be shown on the page (added to the db using fixture_sites)
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
        },
        new Site
        {
            siteID = 40,
            address = "123 Again Street",
            frequency = Site.PickupFrequency.BiWeekly,
            sitePickupDays = Site.PickupDays.Thursday
        }
        };



        [ClassInitialize] //this method will run once before all of the tests
        public static void ClassInitialize(TestContext context)
        {
           // Fixtures.fixture_sites.Load(db.context);

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
        

        [TestInitialize] //this method will run before each test and load the appropriate data
        public void InitializeTest()
        {
            //load content into test db
            Fixtures.fixture_sites.Load(db.context);

            //navigate to proper page
            driver.Navigate().GoToUrl("http://localhost:55271/Sites");
        }

        [TestCleanup]
        //this method will run after each test and unload the data
        public void TestCleanup()
        {
            //unload content from test db
            Fixtures.fixture_sites.Unload(db.context);
        }


        [TestMethod]
        //Test that a deleted Site is removed from the list
        public void TestThatDeletedStatusNotDisplayed()
        {
            //click to delete the first collection status
            var deleteLink = driver.FindElement(By.CssSelector(".table tbody tr:last-child td:last-child a"));
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
            Assert.AreEqual(siteInfo[0].Text, obSites[2].siteID.ToString());
            Assert.AreEqual(siteInfo[1].Text, obSites[2].address);
            Assert.AreEqual(siteInfo[2].Text, obSites[2].frequency.ToString());
            Assert.AreEqual(siteInfo[3].Text, obSites[2].sitePickupDays.ToString());

            driver.FindElement(By.LinkText("Back to List")); //verify link is showing
            var btnDelete = driver.FindElement(By.CssSelector(".btn-default")); //delete button
            btnDelete.Click();

            //back to list page
            //ensure item is no longer there
            var item = driver.FindElement(By.CssSelector(".table tbody tr td:nth-child(2)"));
            //Assert.AreNotEqual(item.Text, itemToDelete.Text);

            //ensure list is one less
            Assert.AreEqual(driver.FindElements(By.CssSelector(".table tbody tr")).Count, obSites.Count - 1);

            //ensure the Site object is still in the database (has not been actually deleted)
            var testSite = db.context.Site.Where(m => m.siteID == 30).ToList();
            Assert.IsNotNull(testSite[0]);
        }

        [TestMethod]
        //test that list is displayed in the correct order
        public void TestThatListIsDisplayedInOrder()
        {
            //list of siteID data shown in list
            var siteIdData = driver.FindElements(By.CssSelector(".table tbody tr td:first-child"));

            //check matching data from expected list defined above
            for (int i = 0; i < siteIdData.Count; i++)
            {
                Assert.AreEqual(siteIdData[i].Text, obSites[i].siteID.ToString());
            }

            //ensure all rows are shown
            Assert.AreEqual(siteIdData.Count, obSites.Count - 1);
        }


        [TestMethod]
        //test that if admin cancels deletion that they are taken back to the list and the list has not changed
        public void TestThatAdminIsTakenBackToList()
        {
            //check that list has not changed / collection item has not been deleted
            var initialRows = driver.FindElements(By.CssSelector(".table tr"));

            //var deleteLink = driver.FindElement(By.CssSelector(".table tr:nth-child(1) td:nth-child(3) a"));
            //click to view the confirmation page
            var deleteLinkMain = driver.FindElement(By.CssSelector(".table tr:nth-child(2) td:nth-child(5) a"));
            deleteLinkMain.Click();

            //ensure is on confirmation page - verify elements are here
            driver.FindElements(By.CssSelector("dl dd"));
            driver.FindElements(By.CssSelector("dl dt"));

            var deleteLink = driver.FindElement(By.LinkText("Back to List"));//link to go back
            deleteLink.Click(); //click to go back

            //back to list page
            //ensure list size has not changed
            var rows = driver.FindElements(By.CssSelector(".table tr"));
            Assert.AreEqual(initialRows.Count, rows.Count);
        }

        [TestMethod]
        //testing that the headers on the page are properly shown to the admin
        public void TestThatHeadersAreCorrect()
        {
            //header values shown to the admin
            var intialRows = driver.FindElements(By.CssSelector(".table thead th"));

            //list of strings to compare against
            List<String> listHeaders = new List<String> {
                "Site ID", "Full Address", "Frequency", "Site Pickup Day(s)"
            };

            //ensure the list shown is the same as the hard-coded expected values
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
        //This test method will verify that the table headers are bold
        public void TestThatTableHeadersAreBold()
        {
            //grab all header text items from the view
            var headers = driver.FindElements(By.CssSelector(".table thead tr th"));

            Assert.AreEqual("700", headers[0].GetCssValue("font-weight"));
            Assert.AreEqual("700", headers[1].GetCssValue("font-weight"));
            Assert.AreEqual("700", headers[2].GetCssValue("font-weight"));
            Assert.AreEqual("700", headers[3].GetCssValue("font-weight"));
        }

        [TestMethod]
        //testing that the sort by siteid is correct (ASCENDING)
        public void TestThatAscSiteIDIsCorrect()
        {
            //grab the header text displayed
            var siteTitles = driver.FindElement(By.CssSelector(".table thead tr:first-child th:first-child a"));
            siteTitles.Click(); //click the Site ID text twice
            siteTitles = driver.FindElement(By.CssSelector(".table thead tr:first-child th:first-child a"));
            siteTitles.Click();

            //checking that the first object displayed in the list contains the same site id as the first site in the expected list
            var firstSite = driver.FindElement(By.CssSelector(".table tr td"));
            Assert.AreEqual(Convert.ToInt32(firstSite.Text),obSites[0].siteID);
        }

        [TestMethod]
        //testing that the sort by siteid is correct (DESCENDING)
        public void TestThatDescSiteIDIsCorrect()
        {
            //grab the header text displayed
            var siteTitles = driver.FindElement(By.CssSelector(".table thead tr:first-child th:first-child a"));

            siteTitles.Click(); //click the Site ID text once for descending

            //checking that the first object displayed in the list contains the same site id as the last site in the expected list
            var lastSite = driver.FindElement(By.CssSelector(".table tbody tr td"));
            Assert.AreEqual(Convert.ToInt32(lastSite.Text), obSites[3].siteID);
        }

        [TestMethod]
        //testing that the sort by siteid is correct (ASCENDING)
        public void TestThatAscAddressIsCorrect()
        {
            //grab the header text displayed
            var siteTitles = driver.FindElement(By.CssSelector(".table thead tr:first-child th:nth-child(2) a"));
            siteTitles.Click(); //click the Full Address text once

            //checking that the first object displayed in the list contains the same address as the first site in the expected list
            var firstSite = driver.FindElement(By.CssSelector(".table tr td:nth-child(2)"));
            Assert.AreEqual(firstSite.Text, obSites[3].address);
        }

        [TestMethod]
        //testing that the sort by siteid is correct (DESCENDING)
        public void TestThatDescAddressIsCorrect()
        {
            //grab the header text displayed
            var siteTitles = driver.FindElement(By.CssSelector(".table thead tr:first-child th:nth-child(2) a"));

            siteTitles.Click();

            siteTitles = driver.FindElement(By.CssSelector(".table thead tr:first-child th:nth-child(2) a"));

            siteTitles.Click(); //click the Full Address text twice for descending

            //checking that the first object displayed in the list contains the same address as the last site in the expected list
            var lastSite = driver.FindElement(By.CssSelector(".table tr td:nth-child(2)"));
            Assert.AreEqual(lastSite.Text, obSites[0].address);
        }

        [TestMethod]
        //testing that the admin can see data located on the 5th page
        public void TestThatAdminViewsSecondPage()
        {
            //grabs the active page "link" we are currently on
            var firstPage = driver.FindElement(By.CssSelector(".pagination .active span"));
            //check to see if we're already on the first page
            if (firstPage.Text != "1")
            {
                //navigate to 1st page
                var firstPageLink = driver.FindElement(By.CssSelector(".pagination li:nth-child(1) a"));
                firstPageLink.Click();
            }
            

            //grab reference to the first item on the first page
            var firstPageItem = driver.FindElement(By.CssSelector(".table tr td:nth-child(2)"));
            var idText = driver.FindElement(By.CssSelector(".table tbody tr:first-child td:first-child"));
            Assert.AreEqual(Convert.ToInt32(idText.Text),obSites[0].siteID);

            //grab reference to 2nd page button and click on it
            var pageLink = driver.FindElement(By.CssSelector(".pagination li:nth-child(2) a"));
            pageLink.Click();

            //now on 2nd page
            var secondPageItem = driver.FindElement(By.CssSelector(".table tr td:nth-child(2)"));

            //check reference to first item on the second page
            var idText2 = driver.FindElement(By.CssSelector(".table tbody tr:first-child td:first-child"));
            Assert.AreEqual(Convert.ToInt32(idText2.Text), obSites[3].siteID);
        }
    }
}
