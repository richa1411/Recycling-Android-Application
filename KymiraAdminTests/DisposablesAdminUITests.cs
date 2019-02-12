﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using KymiraAdmin.Models;
using KymiraAdmin.Fixtures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KymiraAdminTests
{
    //*******************************************************************************************//
    //Will need to load the disposables fixture each time so we will populate our database again.//
    //*******************************************************************************************//

    [TestClass]
    public class DisposablesAdminUITests
    {
        public static List<Disposable> obList;   
        IWebDriver driver;

        [TestInitialize]
        public void InitializeTest()
        {


            var db = new TestDatabaseContext("kymiraAPIDatabase29");
            fixture_disposables.Unload(db.context);
            fixture_disposables.Load(db.context);

              obList = new List<Disposable>(new Disposable[] {
                  new Disposable
        {

            name = "Candy",
            description = "Candy Description",
            imageURL = "Candy",
            isRecyclable = false,
            recycleReason = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
            endResult = "Candy End Result",
            qtyRecycled = 0,
             inactive = false
        }, new Disposable
        {

            name = "Cardboard",
            description = "Cardboard Description",
            imageURL = "Cardboard",
            isRecyclable = true,
            recycleReason = "Cardboard Reason",
            endResult = "Cardboard End Result",
            qtyRecycled = 1000,
            inactive = false
        },
                  new Disposable
        {

            name = "Orange Peels",
            description = "Orange Peels Description",
            imageURL = "OrangePeels",
            isRecyclable = false,
            recycleReason = "Orange Peels Reason",
            endResult = "Orange Peels End Result",
            qtyRecycled = 0,
            inactive = false
        },



                  new Disposable
        {

            name = "Paper",
            description = "Paper Description",
            imageURL = "",
            isRecyclable = true,
            recycleReason = "Paper Reason",
            endResult = "Paper End Result",
            qtyRecycled = 2500,
            inactive = false
        },
                        //Non Recyclable items
            new Disposable
        {

            name = "Pizza",
            description = "Pizza Description",
            imageURL = "Pizza",
            isRecyclable = false,
            recycleReason = "Pizza Reason",
            endResult = "Pizza End Result",
            qtyRecycled = 0,
            inactive = false
        },
            new Disposable
        {

            name = "Tin Cans",
            description = "Tins Cans Description",
            imageURL = "tincan",
            isRecyclable = true,
            recycleReason = "Tin Cans Reason",
            endResult = "Tin Cans End Result",
            qtyRecycled = 1200,
            inactive = false
        }
      
     
            
        });

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
            driver = new ChromeDriver("D:\\COSACPMG\\prj2.cosmo\\KymiraAdminTests\\bin\\Debug\\netcoreapp2.0", chrome_options);

            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");
        }

        //Test that the list displays correctly on launch
        [TestMethod]
        public void TestThatAListDisplaysCorrectly()
        {

            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");

            int rows = driver.FindElements(By.XPath("//table[@class='table']//tr")).Count;

            var list = driver.FindElements(By.XPath("//table[@class='table']//tr"));

            var names = new List<string>(list[0].Text.Split(' '));

            Assert.IsFalse(names.Contains("recycleReason"));
            Assert.IsFalse(names.Contains("endResult"));
            Assert.IsFalse(names.Contains("qtyRecycled"));
            Assert.IsFalse(names.Contains("inactive"));

            //Loop through
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreEqual(list[i+1].Text, obList[i].name + " " + obList[i].description + " " + obList[i].imageURL + " " + "Delete");
            }

            //Assert there are 7 rows in the table
            Assert.AreEqual(rows, 7);


        }

        //Test that the Delete link visible for each item
        [TestMethod]
        public void TestThatADeleteLinkIsVisible()
        {

            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");

            //Will search for the delete link by its text
            //Could also search each individual Delete button 
            driver.FindElement(By.LinkText("Delete"));
        }

        //Test that the deleting an item removes it from the list
        [TestMethod]
        public void TestThatDeletingItemRemovesItFromList()
        {
      

            int rows = driver.FindElements(By.XPath("//table[@class='table']//tr")).Count;

            //Assert there are 7 rows in the table
            Assert.AreEqual(7, rows);
            //click the delete link for Candy
            var delCandyLink = driver.FindElement(By.Id("deleteCandy"));
            delCandyLink.Click();

            //the Back to List link.. Just to verify that it is seeing the next page
            driver.FindElement(By.LinkText("Back to List"));
            //Click the delete button to remove the item
            var delBtn = driver.FindElement(By.Id("btnDelete"));
            delBtn.Click();

            //Check how many rows are in the table now
            rows = driver.FindElements(By.XPath("//table[@class='table']//tr")).Count;

            //Assert that there are 6 rows (one less) than before
            Assert.AreEqual(6, rows);


        }

        //Will test that an inactive item does not show up in the table
        [TestMethod]
        public void TestThatInactiveItemIsNotVisibleInList()
        {
            Disposable disposableItem = new Disposable();
            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");


            int rows = driver.FindElements(By.XPath("//table[@class='table']//tr")).Count;

            var list = driver.FindElements(By.XPath("//table[@class='table']//tr"));

            //Assert there are 7 rows in the table
            Assert.AreEqual(rows, 7);

            //Find a way to set a piece of data in the list to inactive
            

            foreach (var item in list)
            {
                var names = new List<string>(item.Text.Split(' '));

                Assert.IsFalse(names.Contains("Candy"));
            }


            
        }

  



    }




        
}
