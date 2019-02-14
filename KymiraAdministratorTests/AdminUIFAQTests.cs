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
        //FAQ newFAQ1;
        static IWebDriver driver;
        public static List<FAQ> obList;
        private static TestDatabaseContext db;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            db = new TestDatabaseContext("kymiraAPIDatabase26");
            
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
            var table = driver.FindElement(By.CssSelector(".table"));
            var btnAdd = driver.FindElement(By.CssSelector("#btnAdd"));
            var elementList = driver.FindElements(By.CssSelector(".table tr"));


            //check that there are the same amount of Qs as As
            var QCount = driver.FindElements(By.CssSelector("#question")).Count;
            var ACount = driver.FindElements(By.CssSelector("#answer")).Count;

            Assert.AreEqual(QCount, ACount);
            
        }

        /**
         * Test that all elements are diplayed on the create page
         * **/
        [TestMethod]
        public void TestThatCreatePageDisplaysCorrectly()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnAdd = driver.FindElement(By.CssSelector("#btnAdd"));
            btnAdd.Click();
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSubmit"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));
        }

        /**
         * Test that all elements are diplayed on the edit page
         * **/
        [TestMethod]
        public void TestThatEditPageDisplaysCorrectly()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var table = driver.FindElement(By.CssSelector(".table"));
            var listQuestion = driver.FindElement(By.CssSelector("#question")).Text;
            var listAnswer = driver.FindElement(By.CssSelector("#answer")).Text;
            var btnEdit = driver.FindElement(By.CssSelector("#btnEdit"));

            btnEdit.Click();

            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion")).GetAttribute("value");
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer")).GetAttribute("value");
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSave"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));

            Assert.AreEqual(listQuestion, inptQuestion);
            Assert.AreEqual(listAnswer, inptAnswer);
            
        }

        /**
        * Test to ensure that the confirmation page shows the correct object information
        * **/
        [TestMethod]
        public void TestThatDeletePageDisplaysCorrectly()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            //change up the list - record the changes? 
            var questionOG = driver.FindElement(By.CssSelector("#question")).Text;
            var answerOG = driver.FindElement(By.CssSelector("#answer")).Text;

            var btnDelete = driver.FindElement(By.CssSelector("#btnDelete"));
            btnDelete.Click();

            var question = driver.FindElement(By.CssSelector("#question")).Text;
            var answer = driver.FindElement(By.CssSelector("#answer")).Text;
            driver.FindElement(By.CssSelector("#btnDel"));
            driver.FindElement(By.CssSelector("#btnBack"));

            Assert.AreEqual(questionOG, question);
            Assert.AreEqual(answerOG, answer);

        }

        [TestMethod]
        public void TestThatDetailPageDisplaysCorrectly()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            //change up the list - record the changes? 
            var questionOG = driver.FindElement(By.CssSelector(".table #question")).Text;
            var answerOG = driver.FindElement(By.CssSelector("#answer")).Text;

            var btnDetails = driver.FindElement(By.CssSelector("#btnDetails"));
            btnDetails.Click();

            var question = driver.FindElement(By.CssSelector("#question")).Text;
            var answer = driver.FindElement(By.CssSelector("#answer")).Text;
            driver.FindElement(By.CssSelector("#btnBack"));

            Assert.AreEqual(questionOG, question);
            Assert.AreEqual(answerOG, answer.Substring(0, 10) + "...");

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
            var table = driver.FindElement(By.CssSelector(".table"));
            var listQuestion = driver.FindElements(By.CssSelector("#question"));
            var btnDel = driver.FindElement(By.CssSelector("#btnDelete"));
       
            var elementList = table.FindElements(By.CssSelector(".table tr"));
            //count the items displayed on the page
            int itemCount = listQuestion.Count;

            //delete an object from the list
            //click on the delete link and the delete link on the delete page

            var deletedQuestion = table.FindElement(By.CssSelector(".table #question")).Text;

            btnDel.Click();
            btnDel = driver.FindElement(By.CssSelector("#btnDel"));
            btnDel.Click();
            
            //upon return to the list page, check that the count of items is one less than it was before
            table = driver.FindElement(By.CssSelector(".table"));
            listQuestion = driver.FindElements(By.CssSelector("#question"));

            Assert.AreEqual(itemCount - 1, listQuestion.Count);

            for (int i = 0; i < listQuestion.Count; i++)
            {
                Assert.AreNotEqual(listQuestion[i].Text, deletedQuestion);
            }

        }

        /**
         * Tests that we can add a FAQ to the page's list
         * **/
        [TestMethod]
        public void TestThatListItemAdded()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var table = driver.FindElement(By.CssSelector(".table"));
            var listQuestion = driver.FindElements(By.CssSelector("#question"));

            var itemCount = listQuestion.Count;

            //navigate to the add new item page
            var btnCreate = driver.FindElement(By.CssSelector("#btnAdd"));
            btnCreate.Click();

            //find all the page elements
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            btnCreate = driver.FindElement(By.CssSelector("#btnSubmit"));

            //create a new FAQ to add to the site's list
            inptQuestion.SendKeys("This is a new test question to make sure that this works");
            inptAnswer.SendKeys("This is the matching test answer");

            //add the new FAQ
            btnCreate.Click();

            //check that the page's list contains the newly added FAQ
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            table = driver.FindElement(By.CssSelector(".table"));
            listQuestion = driver.FindElements(By.CssSelector("#question"));

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
            var question = driver.FindElement(By.CssSelector("#question")).Text;
            var btn = driver.FindElement(By.CssSelector("#btnEdit"));
            btn.Click();

            //change one of the faqs already in list
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            inptQuestion.SendKeys("Testing functionality");

            //call the edit method
            var save = driver.FindElement(By.CssSelector("#btnSave"));
            save.Click();

            //get the FAQ from the list
            var text = driver.FindElement(By.CssSelector("#question")).Text;

            //check that the answer has changed as expected
            Assert.AreEqual(question + "Testing functionality", text);
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

            var table = driver.FindElement(By.CssSelector(".table"));
            var elementList = driver.FindElements(By.CssSelector("#question"));

            ArrayList originalList = new ArrayList();

            foreach(IWebElement item in elementList)
            {
                originalList.Add(item.Text);
            }

            ArrayList alphaList = (ArrayList)originalList.Clone();
            //use a sort method to sort the questions then make sure they are in the correct order 
            alphaList.Sort();

            CollectionAssert.AreEqual(originalList, alphaList);
        }

        /**
         * Test to ensure that the confirmation page cancels properly
         * **/
        [TestMethod]
        public void TestThatDeletePageCanCancelChanges()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            //Record the orgiginal page
            var table = driver.FindElement(By.CssSelector(".table"));
            int elementList = table.FindElements(By.CssSelector(".table tr")).Count;

            var btndel = driver.FindElement(By.CssSelector("#btnDelete"));
            btndel.Click();
            //Make some changes tp the (new duplicated) list 
            var btn = driver.FindElement(By.CssSelector("#btnBack"));
            //press cancel
            btn.Click();
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
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");

            var table = driver.FindElement(By.CssSelector(".table"));
            var listQuestion = driver.FindElements(By.CssSelector("#question"));
            
            //make sure our monty python reference is not in the list
            for(int i = 0; i < listQuestion.Count; i++)
            {
                Assert.AreNotEqual(listQuestion[i].Text, "What is the airspeed velocity of an unladden swallow?");
            }

        }

        [TestMethod]
        public void TestThatBlankNewShowsErrors()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnAdd = driver.FindElement(By.CssSelector("#btnAdd"));
            btnAdd.Click();
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSubmit"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));

            btnSubmit.Click();

            var errQuestion = driver.FindElement(By.CssSelector("#inptQuestion-error"));
            var errAnswer = driver.FindElement(By.CssSelector("#inptAnswer-error"));
        }

        [TestMethod]
        public void TestThatBlankQuestionShowsErrors()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnAdd = driver.FindElement(By.CssSelector("#btnAdd"));
            btnAdd.Click();
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSubmit"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));

            inptAnswer.SendKeys("This is the standalone answer");

            btnSubmit.Click();

            var errQuestion = driver.FindElement(By.CssSelector("#inptQuestion-error"));
        }

        [TestMethod]
        public void TestThatBlankAnswerShowsErrors()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnAdd = driver.FindElement(By.CssSelector("#btnAdd"));
            btnAdd.Click();
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSubmit"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));

            inptQuestion.SendKeys("This is the standalone question");

            btnSubmit.Click();

            var errAnswer = driver.FindElement(By.CssSelector("#inptAnswer-error"));
        }

        [TestMethod]
        public void TestThat256QuestionShowsError()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnAdd = driver.FindElement(By.CssSelector("#btnAdd"));
            btnAdd.Click();
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSubmit"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));

            inptQuestion.SendKeys(new string('a', 256));

            btnSubmit.Click();

            var errQuestion = driver.FindElement(By.CssSelector("#inptQuestion-error"));
        }

        [TestMethod]
        public void TestThat14QuestionShowsError()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnAdd = driver.FindElement(By.CssSelector("#btnAdd"));
            btnAdd.Click();
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSubmit"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));

            inptQuestion.SendKeys(new string('a', 14));

            btnSubmit.Click();

            var errQuestion = driver.FindElement(By.CssSelector("#inptQuestion-error"));
        }

        [TestMethod]
        public void TestThatBlankEditShowsErrors()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnEdit = driver.FindElement(By.CssSelector("#btnEdit"));
            btnEdit.Click();
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSave"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));

            inptQuestion.Clear();
            inptAnswer.Clear();

            btnSubmit.Click();

            var errQuestion = driver.FindElement(By.CssSelector("#inptQuestion-error"));
            var errAnswer = driver.FindElement(By.CssSelector("#inptAnswer-error"));
        }

        [TestMethod]
        public void TestThatBlankEditRemoveQuestionShowsErrors()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnEdit = driver.FindElement(By.CssSelector("#btnEdit"));
            btnEdit.Click();
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSave"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));

            inptQuestion.Clear();

            btnSubmit.Click();

            var errQuestion = driver.FindElement(By.CssSelector("#inptQuestion-error"));
        }

        [TestMethod]
        public void TestThatBlankEditRemoveAnswerShowsErrors()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnEdit = driver.FindElement(By.CssSelector("#btnEdit"));
            btnEdit.Click();
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSave"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));

            inptAnswer.Clear();

            btnSubmit.Click();

            var errQuestion = driver.FindElement(By.CssSelector("#inptAnswer-error"));
        }

        [TestMethod]
        public void TestThatBlankEditQuestionExceedShowsErrors()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnEdit = driver.FindElement(By.CssSelector("#btnEdit"));
            btnEdit.Click();
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSave"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));

            inptQuestion.SendKeys(new string('a', 256));

            btnSubmit.Click();

            var errQuestion = driver.FindElement(By.CssSelector("#inptQuestion-error"));
        }

        [TestMethod]
        public void TestThatBlankEditQuestionBelowMinShowsErrors()
        {
            driver.Navigate().GoToUrl("http://localhost:60225/FAQs");
            var btnEdit = driver.FindElement(By.CssSelector("#btnEdit"));
            btnEdit.Click();
            var inptQuestion = driver.FindElement(By.CssSelector("#inptQuestion"));
            var inptAnswer = driver.FindElement(By.CssSelector("#inptAnswer"));
            var btnSubmit = driver.FindElement(By.CssSelector("#btnSave"));
            var btnBack = driver.FindElement(By.CssSelector("#btnBack"));

            inptQuestion.Clear();
            inptQuestion.SendKeys(new string('a', 14));

            btnSubmit.Click();

            var errQuestion = driver.FindElement(By.CssSelector("#inptQuestion-error"));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            fixture_faq.Unload(db.context);
        }
    }
}
