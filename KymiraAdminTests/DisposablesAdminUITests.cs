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
    class DisposablesAdminUITests
    {

        [TestMethod]
        public void TestMethod()
        {
            IWebDriver driver = new ChromeDriver("D:\\COSACPMG\\prj2.cosmo\\KymiraAdminTests\\bin\\Debug\\netcoreapp2.0");

            driver.Navigate().GoToUrl("http://localhost:55085/api/Disposables");

            ArrayList results = new ArrayList();

            var btn = driver.FindElement(By.Id("delete22"));

            results.Add(driver.FindElement(By.Id("delete22")));

            Assert.AreEqual(1, results.Count);

            btn.Click();
        }
        
    }
}
