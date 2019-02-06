using KymiraAdmin.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace KymiraAdministratorTests
{
    [TestClass]
    public class AdminViewFAQTests
    {
        FAQ newFAQ1;
        static IWebDriver driver;

        [ClassInitialize]
        public static void LoadDriver(TestContext context)
        {
            driver = new ChromeDriver("D:\\COSACPMG\\prj2.cosmo\\KymiraAdministratorTests\\bin\\Debug\\netcoreapp2.0");
            driver.Navigate().GoToUrl("http://localhost:59649/FAQs");
        }

        [TestInitialize]
        public void Setup()
        {
            newFAQ1 = new FAQ { question = "This is a test question", answer = "Test" };
        }

        [TestMethod]
        public void TestThatPageLoadsCorrectly()
        {
            var table = driver.FindElement(By.Id("FAQTable"));
            var btnEdit = driver.FindElement(By.Id("btnEdit"));
            var btnDel = driver.FindElement(By.Id("btnDelete"));
            var btnAdd = driver.FindElement(By.Id("btnAdd"));
            var elementList = table.FindElements(By.ClassName("tr"));
            //for each item in the list of FAQs check that the item is displayed properly
            for(int i = 0; i < elementList.Count; i++)
            {
                //find the item texts 
                var questionField = driver.FindElement(By.Id("question" + i));
                var answerField = driver.FindElement(By.Id("answer" + i));

                //check that the text is proper
                Assert.AreEqual(elementList[i].Text, questionField);
                Assert.AreEqual(elementList[i].Text, questionField);
            }
        }

        /**
         * Test that after being deleted the item is no longer in the list. Afte selecting the item to delete
         * it will be passed into the delete method and then be removed from the list BUT NOT from the database
         * until the save button is pressed. 
         * **/
        [TestMethod]
        public void TestThatListItemRemoved()
        {
            var btnDel = driver.FindElement(By.Id("btnDelete"));
            var question = driver.FindElement(By.Id("question6"));

            Assert.AreEqual(question.Text, "What is the airspeed velocity of an unladden swallow?");


            btnDel.Click();


        }

        /**
         * Tests that we can add a FAQ to the page's list
         * **/
        [TestMethod]
        public void TestThatListItemAdded()
        {
            //create a new FAQ to add to the site's list
            FAQ newFAQ = new FAQ { id = 0, question = "Whats the meaning of life", answer = "42" };

            //adds a new question to the page's list of questions (waiting to be saved to the database

            //check that the page's list contains the newly added FAQ

            //Assert.IsTrue(res);
        }

        /**
         * Test to confirm that save button makes changes to the database list
         * **/
        [TestMethod]
        public void TestThatChangesSaveSuccessfully()
        {
            //send a list of questions to save to the database

            //get a list back from the database


            //check that the list contains the items expected
        }

        /**
         * Test to ensure that a FAQ will be editted in the list when the 
         * item loses focus after being editted
         * **/
        [TestMethod]
        public void TestThatFAQsEditCorrectlyInList()
        {
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
            //test that the FAQ list item titles are alphabetical

            //Suggestion: Use CollectionAssert

            FAQ newFAQ1 = new FAQ { question = "A Question", answer = "no" };
            FAQ newFAQ2 = new FAQ { question = "B Question", answer = "yes" };
            FAQ newFAQ3 = new FAQ { question = "C Question", answer = "no" };

            
            //use the controller to add some questions


            //use a sort method to sort the questions then make sure they are in the correct order 

        }

        /**
         * Test to ensure that the confirmation page cancels properly
         * **/
        [TestMethod]
        public void TestThatCancelPageCanCancelChanges()
        {
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
            //change up the list - record the changes? 

            //display only the changes made to the user

        }

        /**
         * Test to ensure that the confirmation page opens on changes
         * **/
        [TestMethod]
        public void TestThatCancelPageOpens()
        {
            //check that it pops up containing a list and two buttons "yes" and "no" 

        }

        /**
         * Test that when an item is deleted and set to inactive, it does
         * not show up in the list. 
         */
        [TestMethod]
        public void TestThatInactiveItemsNoShow()
        {
            FAQ inacFAQ = new FAQ
            {
                question = "What is the airspeed velocity of an unladden swallow?",
                answer = "African or European?",
                inactive = true
            };
        }


    }
}
