using kymiraAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KymiraAdminTests
{
    [TestClass]
    public class AdminViewFAQTests
    {
        /**
         * Test that after being deleted the item is no longer in the list
         * **/
        [TestMethod]
        public void TestThatListItemRemoved()
        {
            List<FAQ> faqList = new List<FAQ>();

            faqList.Add(new FAQ { question="What is Cosmo", answer="A reccyling place" });
            faqList.Add(new FAQ { question = "is paper recyclable", answer = "yes" });
            faqList.Add(new FAQ { question = "is glass recyclable", answer = "no" });

            removeQuestion((new FAQ { question = "What is Cosmo", answer = "A reccyling place" });

            var res = !faqList.Contains((new FAQ { question = "What is Cosmo", answer = "A reccyling place" });

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
