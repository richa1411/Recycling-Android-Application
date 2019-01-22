using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Models;
using System.Linq;

namespace KymiraApplicationTests
{
    [TestClass]
    public class FAQTests
    {
        FAQ objFAQ;
        /*
        *  Setup a FAQ object with an ID, question, and answer
        *  ID is not important for the story but could prove to be beneficial if needing to pinpoint FAQ objects in the future
        */
        [TestInitialize]
        public void InitializeTest()
        {
            objFAQ = new FAQ { ID = 1, question = "Where is Cosmo Industries?", answer = "1302 Alberta Ave. Saskatoon" };
        }


        /*   Unit tests for Phonenumber   */
        [TestMethod]
        public void TestThatQuestionIsEmpty()

        {
            //Test that the question is an empty string
            objFAQ.question = "";

            //checks against the validation helper class and sends the FAQ object and matches errors
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Question cannot be empty", results[0].ErrorMessage);
        }
        [TestMethod]
        public void TestThatAnswerIsEmpty()

        {
            //Test that the question is an empty string
            objFAQ.answer = "";

            //checks against the validation helper class and sends the FAQ object and matches errors
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Answer cannot be empty", results[0].ErrorMessage);
        }

        [TestMethod]
        public void TestThatAnswerIsEmpty()

        {
            //Test that the question is an empty string
            objFAQ.answer = "";

            //checks against the validation helper class and sends the FAQ object and matches errors
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("Answer cannot be empty", results[0].ErrorMessage);
        }





        /*
         * MIGHT NOT BE NECESSARY
         */


        [TestMethod]
        public void TestThatInvalidSearchStringReturnsError()

        {
            //Test that the question is an empty string
            objFAQ.question = "1234";

            //checks against the validation helper class and sends the FAQ object and matches errors
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(1, results.Count());
            Assert.AreEqual("The search didn’t match any answers", results[0].ErrorMessage);
        }
    }
}
