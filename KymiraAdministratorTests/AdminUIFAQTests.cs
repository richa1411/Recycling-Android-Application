using KymiraAdmin.Fixtures;
using KymiraAdmin.Models;
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
    public class AdminUIFAQTests
    {
        static IWebDriver driver;
        public static List<FAQ> obList;
        private static TestDatabaseContext db = new TestDatabaseContext("kymiraAPIDatabase30");

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        { 
            
            fixture_faq.Load(db.context);

            ChromeOptions chrome_options = new ChromeOptions();
            //Wont open up a new chrome tab when run
            chrome_options.AddArgument("--headless");

            //disable various chrome services that may interfer with the test
            chrome_options.AddArgument("--disable-sync");
            chrome_options.AddArgument("--disable-extensions");
            chrome_options.AddArgument("--remote-debugging-address=0.0.0.0");
            chrome_options.AddArgument("--remote-debugging-port=9222");

            //Not necessary if running in headless mode
            //chrome_options.AddArgument("--window-size=1280,720");

            //Assign the driver to the location of the chromedriver.exe on the local drive
            driver = new ChromeDriver("D:\\COSACPMG\\prj2.cosmo\\KymiraAdministratorTests\\bin\\Debug\\netcoreapp2.0", chrome_options);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            fixture_faq.Unload(db.context);
        }

        [TestInitialize]
        public void InitializeTest()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
        }

        /**
        * Test that all elements are diplayed on the list page
        * **/
        [TestMethod]
        public void TestThatListPageLoadsCorrectly()
        {
            var table = driver.FindElement(By.CssSelector(".table"));

            var questionList = new List<IWebElement>(driver.FindElements(By.CssSelector(".table tr td:first-child"))); //Questions Column
            var answerList = new List<IWebElement>(driver.FindElements(By.CssSelector(".table tr td:nth-child(1)"))); //Answers Column

            //check that there are the same amount of Qs as As
            Assert.AreEqual(questionList.Count, answerList.Count);
            
        }

        //Test that the Delete link visible for each item
        [TestMethod]
        public void TestThatDeleteLinkIsVisible()
        {
            //Will search for the delete link by its Link Text
            //Could also search each individual Delete button 
            driver.FindElement(By.LinkText("Delete"));
        }


        /*
         *Need to fix the CSS Selectors for this test...
         */
        [TestMethod]
        public void TestThatDeletePageDisplaysCorrectly()
        {
            //change up the list - record the changes? 
            var questionOG = driver.FindElement(By.CssSelector(".table tr th:first-child")).Text; //#question
            var answerOG = driver.FindElement(By.CssSelector(".table tr th:nth-child(2)")).Text; //#answer

            var deleteLink = driver.FindElement(By.CssSelector(".table tr:nth-child(1) td:nth-child(3) a"));
            deleteLink.Click();

            var question = driver.FindElement(By.CssSelector(".dl-horizontal dt:first-child")).Text; //#question
            //var answer = driver.FindElement(By.CssSelector(".dl-horizontal dt:nth-child(2)")).Text; //#answer

            //driver.FindElement(By.CssSelector("btn btn-default"));
            driver.FindElement(By.LinkText("Back to List"));

            Assert.AreEqual(questionOG, question);
            //Assert.AreEqual(answerOG, answer.Substring(0, 10) + "...");

        }

        //Test that the FAQ list item questions are in alphabetical order
        [TestMethod]
        public void TestThatFAQsInAlphabeticalOrder()
        {
            var table = driver.FindElement(By.CssSelector(".table"));
            var questionList = new List<IWebElement>(driver.FindElements(By.CssSelector(".table tr td:first-child"))); //gets all the questions and puts them in a list

            ArrayList originalList = new ArrayList();

            foreach(IWebElement item in questionList)
            {
                originalList.Add(item.Text);
            }

            ArrayList sortedList = (ArrayList)originalList.Clone();
            //use a sort method to sort the questions then make sure they are in the correct order 
            sortedList.Sort();

            CollectionAssert.AreEqual(originalList, sortedList);
        }

        /**
         * Test to ensure that the confirmation page cancels properly
         * **/
        [TestMethod]
        public void TestThatDeletePageCanCancelChanges()
        {
            //Record the original page
            var table = driver.FindElement(By.CssSelector(".table"));
            int elementList = table.FindElements(By.CssSelector(".table tr")).Count;

            var deleteLink = driver.FindElement(By.CssSelector(".table tr:nth-child(1) td:nth-child(3) a"));
            deleteLink.Click();

            //the Back to List link.. Just to verify that it is seeing the next page
            var backtolist = driver.FindElement(By.LinkText("Back to List"));

            //press the Back To List button
            backtolist.Click();
            //check that the page is identical to the original page recorded.

            var table2 = driver.FindElement(By.CssSelector(".table"));
            int elementList2 = table2.FindElements(By.CssSelector(".table tr")).Count;

            Assert.AreEqual(elementList, elementList2);
        }

        /**
         * Test that when an item is deleted and set to inactive, it does
         * not show up in the list. 
         */
        [TestMethod]
        public void TestThatInactiveItemsDontShow()
        {
            var table = driver.FindElement(By.CssSelector(".table"));
            var listQuestion = new List<IWebElement>(driver.FindElements(By.CssSelector(".table tr td:first-child")));

            //make sure our monty python reference is not in the list
            for (int i = 0; i < listQuestion.Count; i++)
            {
                Assert.AreNotEqual(listQuestion[i].Text, "What is the airspeed velocity of an unladden swallow?");
            }

        }

        //This test will check that the nav bar is black
        [TestMethod]
        public void TestThatNavBarIsBlack()
        {
            

        }

        //This test will check that the fontsize of the title is 30 pixels large
        [TestMethod]
        public void TestThatTitleFontSizeIs30pxLarge()
        {
            

        }

        [TestMethod]
        public void TestThatTableHeadersAreBold()
        {


        }




        
    }
}
