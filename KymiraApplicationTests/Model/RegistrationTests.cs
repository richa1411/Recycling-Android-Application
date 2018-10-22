using Microsoft.VisualStudio.TestTools.UnitTesting;
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
           regTestgood = new Registration("guy@email.com", "password1", "3066545456", "Guy", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T5N3", true);



            regtestBad = new Registration("guy@email.com", "password1", "3045456", "Guy", "Dude", "10102018", "123 steve ave", "A", "Regina", "Saskatchewan", "S4T53", true);
        }
        [TestMethod()]
        public void RegistrationTest()
        {
            
        }
        [TestMethod()]
        public void testThatwedid()
        {
            //var results = new List<ValidationResult>(); //regTestgood.Validate(new ValidationContext(regTestgood, null, null));

            //bool isValid = Validator.TryValidateObject(regTestgood, new ValidationContext(regTestgood, null, null), results, false);

            results = HelperTestModel.Validate(regTestgood);

            Assert.AreEqual(0, results.Count());

            results = HelperTestModel.Validate(regtestBad);

            Assert.AreEqual(0, results.Count());

        }
    }
}