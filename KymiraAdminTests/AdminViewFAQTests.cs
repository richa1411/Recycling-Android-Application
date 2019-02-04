using kymiraAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KymiraAdminTests
{
    [TestClass]
    public class AdminViewFAQTests
    {
        /**
         * Test that after being deleted the item is no longer in the list. Afte selecting the item to delete
         * it will be passed into the delete method and then be removed from the list BUT NOT from the database
         * until the save button is pressed. 
         * **/
        [TestMethod]
        public void TestThatListItemRemoved()
        {
            List<FAQ> faqList = new List<FAQ>();

            faqList.Add(new FAQ { question="What is Cosmo", answer="A reccyling place" });
            faqList.Add(new FAQ { question = "is paper recyclable", answer = "yes" });
            faqList.Add(new FAQ {id=3, question = "is glass recyclable", answer = "no" });

            //Removes the question based on the ID
            removeQuestion(3);

            var res = !faqList.Contains((new FAQ {id=3}));

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestThatListItemAdded()
        {
            List<FAQ> faqList = new List<FAQ>();

            //Removes the question based on the ID
            addQuestion(new FAQ { id=0, question = "Whats the meaning of life", answer = "42" });

            var res = faqList.Contains((new FAQ { id = 0 }));

            Assert.IsTrue(res);
        }

        /**
         * Test to confirm that save button makes changes to the database list
         * **/
        [TestMethod]
        public void TestThatChangesSaveSuccessfully()
        {

        }

        /**
         * Test to ensure that a FAQ will be editted in the list when the 
         * item loses focus after being editted
         * **/
        [TestMethod]
        public void TestThatFAQsEditCorrectlyInList()
        {

        }
    }
}
