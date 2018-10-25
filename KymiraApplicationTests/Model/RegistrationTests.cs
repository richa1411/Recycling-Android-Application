﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using KymiraApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using KymiraApplicationTests;

namespace KymiraApplication.Model.Tests
{
    [TestClass()]
    public class RegistrationTests
    {
        public Registration regTestgood;
        public Registration regtestBad;
        public List<ValidationResult> results;

        [TestInitialize()]
        public void setup()
        {
           results = new List<ValidationResult>();
            regtestBad = new Registration("guy@email.com", "password1", "3066545456", "Guy", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            //regtestBad = new Registration("guy@email.com", "password1", "3045456", "Guy", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T53", true);
        }
        [TestMethod()]
        public void RegistrationTest()
        {
            
        }
        [TestMethod()]
        public void testThatEmailCannotBeEpmpty()
        {

            regtestBad.emailAddress = "";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatEmailCannotBeMoreThan100Characters()
        {

            regtestBad.emailAddress = new string('a', 100);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatEmailis100Characters()
        {
            regtestBad.emailAddress = new string('a', 90) + "@gmail.com";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatEmailCannotBeInvalidFormat()
        {
            regtestBad.emailAddress = "guyemail.com";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatEmailEnteredIsValid()
        {
            regtestBad.emailAddress = "email@email.com";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatPasswordCannotBeEmpty()
        {
            regtestBad.password = "";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatPasswordCannotbe5CharactersLong()
        {
            regtestBad.password = "aaaaa";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatPasswordisValidat8characters()
        {
            regtestBad.password = "aaaaaaaa";
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatPasswordis50Characters()
        {
            regtestBad.password = new string('a', 50);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatPasswordCannotBeMorethan50Characters()
        {
            regtestBad.password = new string('a', 51);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatPhoneNumbercannotBeEmpty()
        {
            regtestBad.password = new string('a', 51);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatPhoneNumberCantOnlyBeDigits()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "a1231", "Guy", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(2, results.Count());

        }
        [TestMethod()]
        public void testThatPhoneNumberCanBe10Digits()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "Guy", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatPhoneNumberCannotBe11digits()
        {

            regtestBad = new Registration("guy@email.com", "password1", "30665245456", "Guy", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(2, results.Count());

        }
        [TestMethod()]
        public void testThatPhoneNumberCannotBe9Digits()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "123467891", "Guy", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(2, results.Count());

        }
        [TestMethod()]
        public void testThatFirstNameFieldCannotBeEmpty()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatFirstNameFieldHas1Character()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "G", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatFirstNameCannotHaveMorethan50Characters()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghija", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatFirstNameFieldHas50characters()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghij", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatLastNameCannotBeEmpty()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatLastNameFieldHas1Character()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "a", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatLastNameFieldHasMoreThan50Characters()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "aabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijaas", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatLastNameFieldHas50Characters()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghij", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatBirthDateCannotBeEmpty()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatBirthDateCannotHaveLessThan8Characters()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10193", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatBirthDateHas8characters()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());


        }
        [TestMethod()]
        public void testThatAddressLine1FieldCannotBeEmpty()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000", "", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatAddressLine1CannotBeLessThan10Characters()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000", "onetwoth", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatAddressLine1CanHave10Characters()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000", "1234567891", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatAddressLine1CanHave200Characters()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000", 
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatAddressLine1CannotHaveMoreThan200Characters()
        {

            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatAddressLine2CanHaveMoreThan200Characters()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", new string('a',201), "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatAddressLine2CanBeEMpty()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", "", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatCityCannotBeEmpty()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", "asasdfasdfasdf", "", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatCityHas1Character()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", "asdfadfadf", "a", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatCityHas100Character()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", "asdfadfadf", new string('a',100), "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatCityCannotHaveMoreThan100Character()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", "asdfadfadf", new string('a', 101), "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatProvinceFieldCannotBeEmpty()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", "asdfadfadf", new string('a', 100), "", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatProvinceFieldCanHave100Charcters()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", "asdfadfadf", new string('a', 100), new string('a', 100), "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatProvinceFieldCannotHaveMorethan100Characters()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", "asdfadfadf", new string('a', 100), new string('a', 101), "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatPostalCodeCannotBeEmpty()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", "asdfadfadf", new string('a', 100), new string('a', 100), "", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatPostalCodeCannotHaveLessThan6Characters()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", "asdfadfadf", new string('a', 100), new string('a', 100), "s4n2p", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
        [TestMethod()]
        public void testThatPostalCodeHas6Characters()
        {
            regtestBad = new Registration("guy@email.com", "password1", "3066545456", "Guy", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(0, results.Count());

        }
        [TestMethod()]
        public void testThatPostalCodeCannotHaveMorethan6Characters()
        {
            regtestBad = new Registration("email@email.com", "asdadsasdas", "1234567891", "guy", "fghijabcdefghijabcdefghij", "10102000",
                "asdfgasdafg", "asdfadfadf", new string('a', 100), new string('a', 100), "s4na2p5", true);
            results = HelperTestModel.Validate(regtestBad);
            Assert.AreEqual(1, results.Count());

        }
 










    }
}