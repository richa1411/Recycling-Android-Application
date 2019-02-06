using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KymiraAdminTests
{
    [TestClass]
    public class DisposablesAdminUITests
    {
        IWebDriver driver;

        [TestInitialize]
        public void InitializeTest()
        {

            ChromeOptions chrome_options = new ChromeOptions();
            //Wont open up a new chrome tab when run
            chrome_options.AddArgument("--headless");

            //disable various chrome services that may interfer with the test
            chrome_options.AddArgument("--disable-sync");
            chrome_options.AddArgument("--disable-extensions");
            chrome_options.AddArgument("--remote-debugging-address=0.0.0.0");
            chrome_options.AddArgument("--remote-debugging-port=9222");

            //Not necessary if running in headless mode
            chrome_options.AddArgument("--window-size=1280,720");

            //Assign the driver to the location of the chromedriver.exe on the local drive
            driver = new ChromeDriver("D:\\COSACPMG\\prj2.cosmo\\KymiraAdminTests\\bin\\Debug\\netcoreapp2.0", chrome_options);
        }

        //Test that the list displays correctly on launch
        [TestMethod]
        public void TestThatListDisplaysCorrectly()
        {

            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");

        }

        //Test that the recyclable reason is hidden from view
        [TestMethod]
        public void TestThatRecycleReasonIsHidden()
        {

            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");

        }

        //Test that the end result is hidden from view
        [TestMethod]
        public void TestThatEndResultIsHidden()
        {

            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");

        }

        //Test that the quantity recycled is hidden from view
        [TestMethod]
        public void TestThatQtyRecycledIsHidden()
        {

            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");

        }

        //Test that the Delete link visible for each item
        [TestMethod]
        public void TestThatDeleteLinkIsVisible()
        {

            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");

            var btn = driver.FindElement(By.Id("delete46"));

            btn.Click();


        }

        //Test that the deleting an item removes it from the list
        [TestMethod]
        public void TestThatDeletingItemRemovesItFromList()
        {

            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");

        }


        [TestMethod]
        public void TestThatInactiveItemIsNotVisibleInList()
        {
            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");

        }
    }
}
