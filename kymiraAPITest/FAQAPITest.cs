using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using kymiraAPI.Models;
using System.Linq;

namespace kymiraAPITest
{
    [TestClass]
    public class FAQAPITest
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


        /*   Unit tests for question  thatchecks if question is an empty string or not */
        [TestMethod]
        public void TestThatQuestionIsEmpty()

        {
            //Test that the question is an empty string
            objFAQ.question = "";

            //checks against the validation helper class and sends the FAQ object and matches errors
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(1, results.Count()); //finds one error
            Assert.AreEqual("Question cannot be empty", results[0].ErrorMessage);
        }

        /*   Unit tests for answer  that checks if question is an empty string or not */
        [TestMethod]
        public void TestThatAnswerIsEmpty()

        {
            //Test that the answer is an empty string
            objFAQ.answer = "";

            //checks against the validation helper class and sends the FAQ object and matches errors
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(1, results.Count());//finds one error
            Assert.AreEqual("Answer cannot be empty", results[0].ErrorMessage);
        }

        /* a test method that checks if a question field is non mepty string or not */
        [TestMethod]
        public void TestThatQuestionIsNonEmpty()

        {
            //Test that the question is an empty string
            objFAQ.question = "Where is Cosmo Industries?";

            //checks against the validation helper class and sends the FAQ object and finds that there are no any errors
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(0, results.Count());
           
        }

        /* a test method that checks if an answer field is non mepty string or not */
        [TestMethod]
        public void TestThatAnswerIsNonEmpty()

        {
            //Test that the question is an empty string
            objFAQ.answer = "1302 Alberta Ave. Saskatoon";

            //checks against the validation helper class and sends the FAQ object and finds that there are no any errors
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(0, results.Count());

        }






    }
}
