using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KymiraAdmin.Models;

namespace KymiraAdministratorTests
{
    [TestClass]
    public class FAQAdminTest
    {
        FAQ objFAQ;
        /*
        *  Setup a FAQ object with an ID, question, and answer
        *  ID is not important for the story but could prove to be beneficial if needing to pinpoint FAQ objects in the future
        */
        [TestInitialize]
        public void InitializeTest()
        {
            objFAQ = new FAQ { question = "Where is Cosmo Industries?", answer = "1302 Alberta Ave. Saskatoon" };
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

        /* a test method that checks if a question field is between 15 and 255 characters */
        [TestMethod]
        public void TestThatQuestionIsValid()

        {
            //Test that the question is an empty string
            objFAQ.question = "Where is Cosmo Industries?";

            //checks against the validation helper class and sends the FAQ object and finds that there are no any errors
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(0, results.Count());
           
        }

        /* a test method that checks if an answer field is non empty string or not */
        [TestMethod]
        public void TestThatAnswerIsNonEmpty()

        {
            //Test that the question is an empty string
            objFAQ.answer = "1302 Alberta Ave. Saskatoon";

            //checks against the validation helper class and sends the FAQ object and finds that there are no any errors
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(0, results.Count());

        }

        /* a test method that checks if a question field is 255 characters or not */
        [TestMethod]
        public void TestThatQuestionIs255Character()

        {
            //Test that the question is a 255 characters string
            objFAQ.question = new string('a', 255);

            //checks against the validation helper class and sends the FAQ object and finds that there are no any errors
            var results = TestValidationHelper.Validate(objFAQ);

            Assert.AreEqual(0, results.Count);
            

        }

        /* a test method that checks if a question field is 15 characters or not */
        [TestMethod]
        public void TestThatQuestionIs15Character()

        {
            //Test that the question is a 15 character string
            objFAQ.question = new string('a', 15);

            //checks against the validation helper class and sends the FAQ object and finds that there are no any errors
            var results = TestValidationHelper.Validate(objFAQ);

            Assert.AreEqual(0, results.Count);


        }

        /* a test method that checks if a question field is less than 15 characters */
        [TestMethod]
        public void TestThatQuestionIsLessThan15Character()

        {
            //Test that the question is less than 15 character string
            objFAQ.question = new string('a', 14);

            //checks against the validation helper class and sends the FAQ object and finds that there is an error and matches with regards model class
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(1, results.Count());//finds one error
            Assert.AreEqual("Question must be between 15 - 255 characters", results[0].ErrorMessage);
        }

        //Test that the question is higher than 255 character string
        [TestMethod]
        public void TestThatQuestionIsHigherThan255Character()

        {
            objFAQ.question = new string('a', 256);
            //checks against the validation helper class and sends the FAQ object and finds that there is an error and matches with regards model class
            var results = TestValidationHelper.Validate(objFAQ);
            Assert.AreEqual(1, results.Count());//finds one error
            Assert.AreEqual("Question must be between 15 - 255 characters", results[0].ErrorMessage);

        }



    }
}
