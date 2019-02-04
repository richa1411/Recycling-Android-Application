using kymiraAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KymiraAdminTests
{
    [TestClass]
    public class AdminViewFAQTests
    {
        FAQ newFAQ1; 

        [TestInitialize]
        public void Setup()
        {
            newFAQ1 = new FAQ { question = "This is a test question", answer = "Test" };
        }

        /**
         * Test that after being deleted the item is no longer in the list. Afte selecting the item to delete
         * it will be passed into the delete method and then be removed from the list BUT NOT from the database
         * until the save button is pressed. 
         * **/
        [TestMethod]
        public void TestThatListItemRemoved()
        {
            //create some FAQs to add
            FAQ newFAQ1 = new FAQ { question = "What is Cosmo", answer = "A reccyling place" };
            FAQ newFAQ2 = new FAQ { question = "is paper recyclable", answer = "yes" };
            FAQ newFAQ3 = new FAQ { id = 3, question = "is glass recyclable", answer = "no" };

            //use the controller to add some questions
            FAQPage.addQuestion(newFAQ1);
            FAQPage.addQuestion(newFAQ2);
            FAQPage.addQuestion(newFAQ3);

            //Removes the question based on the ID
            FAQPage.removeQuestion(newFAQ1);

            //check that the FAQ removed is no longer in the site's list
            var res = !faqList.Contains(newFAQ1);

            Assert.IsTrue(res);
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
            FAQPage.addQuestion(newFAQ);

            //check that the page's list contains the newly added FAQ
            var res = FAQPage.faqList.Contains(newFAQ);

            Assert.IsTrue(res);
        }

        /**
         * Test to confirm that save button makes changes to the database list
         * **/
        [TestMethod]
        public void TestThatChangesSaveSuccessfully()
        {
            //send a list of questions to save to the database
            FAQController.saveList(/** enter list of FAQs here **/);

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
            newFAQ1.answer = "tests2";

            //call the edit method
            FAQPage.editFAQ(newFAQ1);

            //get the FAQ from the list
            FAQ checkFAQ = FAQPage.faqList.Get(newFAQ1);

            //check that the answer has changed as expected
            Assert.IsTrue(checkFAQ.answer == "tests2");
        }

        /**
         * Test to ensure that the list is being viewed in alphabetical order
         * **/
        [TestMethod]
        public void TestThatFAQsInAlphabeticalOrder()
        {
            //test that the FAQ list item titles are alphabetical

        }

        /**
         * Test to ensure that the confirmation page cancels properly
         * **/
        [TestMethod]
        public void TestThatCancelPageCanCancelChanges()
        {
            

        }

        /**
         * Test to ensure that the confirmation page shows the correct object information
         * **/
        [TestMethod]
        public void TestThatCancelPageShowsObject()
        {


        }

        /**
         * Test to ensure that the confirmation page opens on changes
         * **/
        [TestMethod]
        public void TestThatCancelPageOpens()
        {


        }


    }
}
