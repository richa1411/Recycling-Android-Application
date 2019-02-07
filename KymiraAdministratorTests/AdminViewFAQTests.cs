using KymiraAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KymiraAdministratorTests
{
    [TestClass]
    public class AdminViewFAQTests
    {
        //FAQ newFAQ1;
        static IWebDriver driver;

        [ClassInitialize]
        public static void InitializeTest(TestContext context)
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
            driver = new ChromeDriver("D:\\COSACPMG\\prj2.cosmo\\KymiraAdministratorTests\\bin\\Debug\\netcoreapp2.0", chrome_options);
        }

        /**
        * Test that all elements are diplayed on the list page
        * **/
        [TestMethod]
        public void TestThatListPageLoadsCorrectly()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var table = driver.FindElement(By.ClassName("table"));
            var btnAdd = driver.FindElement(By.Id("btnAdd"));
            var elementList = table.FindElements(By.TagName("tr"));
            //for each item in the list of FAQs check that the item is displayed properly
            for (int i = 0; i < elementList.Count; i++)
            {
                var item = elementList[i];
                var itemElementList = item.FindElements(By.TagName("td"));

                //check that there are 3 td elements
                Assert.AreEqual(3, itemElementList.Count);

                //check that the "question" id occurs
                item.FindElement(By.Id("question"));

                //check that the "answer" id occurs
                item.FindElements(By.TagName("answer"));

                //check that the two a elements are withing the 3rd td
                Assert.AreEqual(2, item.FindElements(By.TagName("a")).Count);
            }
        }


        /**
         * Test that all elements are diplayed on the create page
         * **/
        [TestMethod]
        public void TestThatCreatePageDisplaysCorrectly()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnAdd = driver.FindElement(By.Id("btnAdd"));
            btnAdd.Click();
            var inptQuestion = driver.FindElement(By.Id("inptQuestion"));
            var inptAnswer = driver.FindElement(By.Id("inptAnswer"));
            var btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            var btnBack = driver.FindElement(By.Id("btnBack"));
        }

        /**
         * Test that all elements are diplayed on the edit page
         * **/
        [TestMethod]
        public void TestThatEditPageDisplaysCorrectly()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var table = driver.FindElement(By.ClassName("table"));
            var listQuestion = table.FindElement(By.Id("question")).Text;
            var listAnswer = table.FindElement(By.Id("answer")).Text;
            var btnEdit = driver.FindElement(By.Id("btnEdit"));

            btnEdit.Click();

            var inptQuestion = driver.FindElement(By.Id("inptQuestion")).GetAttribute("value");
            var inptAnswer = driver.FindElement(By.Id("inptAnswer")).GetAttribute("value");
            var btnSubmit = driver.FindElement(By.Id("btnSave"));
            var btnBack = driver.FindElement(By.Id("btnBack"));

            Assert.AreEqual(listQuestion, inptQuestion);
            Assert.AreEqual(listAnswer, inptAnswer);
            
        }

        /**
         * Test that after being deleted the item is no longer in the list. Afte selecting the item to delete
         * it will be passed into the delete method and then be removed from the list
         * **/
        [TestMethod]
        public void TestThatListItemRemoved()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            //find all the page elements
            var table = driver.FindElement(By.ClassName("table"));
            var listQuestion = table.FindElements(By.Id("question"));
            var btnDel = table.FindElement(By.Id("btnDelete"));
       
            var elementList = table.FindElements(By.ClassName("tr"));
            //count the items displayed on the page
            int itemCount = listQuestion.Count;

            //delete an object from the list
                //click on the delete link and the delete link on the delete page
            btnDel.Click();
            btnDel = driver.FindElement(By.Id("btnDel"));
            btnDel.Click();

            //upon return to the list page, check that the count of items is one less than it was before
            table = driver.FindElement(By.ClassName("table"));
            listQuestion = table.FindElements(By.Id("question"));

            Assert.AreEqual(listQuestion.Count, itemCount - 1 );

        }

        /**
         * Tests that we can add a FAQ to the page's list
         * **/
        [TestMethod]
        public void TestThatListItemAdded()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var table = driver.FindElement(By.ClassName("table"));
            var listQuestion = table.FindElements(By.Id("question"));

            var itemCount = listQuestion.Count;

            //navigate to the add new item page
            var btnCreate = driver.FindElement(By.Id("btnAdd"));
            btnCreate.Click();

            //find all the page elements
            var inptQuestion = driver.FindElement(By.Id("inptQuestion"));
            var inptAnswer = driver.FindElement(By.Id("inptAnswer"));
            btnCreate = driver.FindElement(By.Id("btnSubmit"));

            //create a new FAQ to add to the site's list
            inptQuestion.SendKeys("This is a new test question to make sure that this works");
            inptAnswer.SendKeys("This is the matching test answer");

            //add the new FAQ
            btnCreate.Click();

            //check that the page's list contains the newly added FAQ
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            table = driver.FindElement(By.ClassName("table"));
            listQuestion = table.FindElements(By.Id("question"));

            Assert.AreEqual(itemCount + 1, listQuestion.Count);
        }
        
        /**
         * Test to ensure that a FAQ will be editted in the list when the 
         * item loses focus after being editted
         * **/
        [TestMethod]
        public void TestThatFAQsEditCorrectlyInList()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            //change one of the faqs already in list

            //call the edit method

            //get the FAQ from the list

            //check that the answer has changed as expected
        }

        /**
         * Test to ensure that the list is being viewed in alphabetical order
         * **/
        [TestMethod]
        public void TestThatFAQsInAlphabeticalOrder()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            //test that the FAQ list item titles are alphabetical

            //Suggestion: Use CollectionAssert

            //FAQ newFAQ1 = new FAQ { question = "A Question", answer = "no" };
            //FAQ newFAQ2 = new FAQ { question = "B Question", answer = "yes" };
            // FAQ newFAQ3 = new FAQ { question = "C Question", answer = "no" };


            //use the controller to add some questions


            //use a sort method to sort the questions then make sure they are in the correct order 

        }

        /**
         * Test to ensure that the confirmation page cancels properly
         * **/
        [TestMethod]
        public void TestThatCancelPageCanCancelChanges()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            //Record the orgiginal page
            //Make some changes tp the (new duplicated) list 
            //press cancel
            //check that the page is identical to the original page recorded.

        }

        /**
         * Test to ensure that the confirmation page shows the correct object information
         * **/
        [TestMethod]
        public void TestThatCancelPageShowsObject()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            //change up the list - record the changes? 

            //display only the changes made to the user

        }

        /**
         * Test that when an item is deleted and set to inactive, it does
         * not show up in the list. 
         */
        [TestMethod]
        public void TestThatInactiveItemsDontShow()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");

        }


    }
}
