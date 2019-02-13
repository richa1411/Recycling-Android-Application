using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using System.Threading;

namespace KymiraAdminTests
{
  

    [TestClass]
    public class DisposablesAdminUITests
    {
        //declarations
        static TestDatabaseContext db = new TestDatabaseContext("kymiraAPIDatabase29");
        public static List<Disposable> obList = new List<Disposable>(new Disposable[] {
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
        public static IWebDriver driver;
        


        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {

            fixture_disposables.Unload(db.context);
            fixture_disposables.Load(db.context);

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
        }
        // this method runs after the tests have finished and unloads the databse
        [ClassCleanup]
        public static void ClassCleanup()
        {
            fixture_disposables.Unload(db.context);
        }

        [TestInitialize]
        public void InitializeTest()
        {
            driver.Navigate().GoToUrl("http://localhost:59649/Disposables");
        }



        //Test that the list displays correctly on launch
        [TestMethod]
        public void TestThatAListDisplaysCorrectly()
        {

            //driver.Navigate().GoToUrl("http://localhost:59649/Disposables");

            int rows = driver.FindElements(By.CssSelector(".table tr")).Count;

            var list = driver.FindElements(By.CssSelector(".table tr"));

            //.table tr td:first-child

            var names = new List<IWebElement>(driver.FindElements(By.CssSelector(".table tr td:first-child")));
            //var names = new List<string>(list[0].Text.Split(' '));

            Assert.AreNotEqual(names[0].Text, "recycleReason");
            Assert.AreNotEqual(names[0].Text,"endResult");
            Assert.AreNotEqual(names[0].Text, "qtyRecycled");
            Assert.AreNotEqual(names[0].Text, "inactive");

            //Loop through
            for (int i = 0; i < list.Count; i++)
            {

                Assert.AreEqual(names[i + 1].Text, obList[i].name);
               // Assert.AreEqual(list[i+1].Text, obList[i].name + " " + obList[i].description + " " + obList[i].imageURL + " " + "Delete");
            }

            //Assert there are 7 rows in the table
            Assert.AreEqual(rows, 7);


        }

        //Test that the Delete link visible for each item
        [TestMethod]
        public void TestThatADeleteLinkIsVisible()
        {

            //driver.Navigate().GoToUrl("http://localhost:59649/Disposables");

            //Will search for the delete link by its text
            //Could also search each individual Delete button 
            driver.FindElement(By.LinkText("Delete"));
        }

        //Test that the deleting an item removes it from the list
        [TestMethod]
        public void TestThatDeletingItemRemovesItFromList()
        {

            int rows = driver.FindElements(By.CssSelector(".table tr")).Count;

            //Assert there are 7 rows in the table
            Assert.AreEqual(7, rows);
            //click the delete link for Candy
            var delCandyLink = driver.FindElement(By.CssSelector("#deleteCandy"));
            delCandyLink.Click();

            //on delete confirmation page.
            //list of dd elements that store information about specific item from database displayed on the webpage
            var ddList = new List<IWebElement>(driver.FindElements(By.CssSelector("dl dd")));

            //list of dt elements that contain identifier information, ie; name, description
            var dtList = new List<IWebElement>(driver.FindElements(By.CssSelector("dl dt")));


            Assert.AreEqual(ddList[0].Text, obList[0].name);
            Assert.AreEqual(ddList[1].Text, obList[0].description);
            Assert.AreEqual(ddList[2].Text, obList[0].imageURL);
            Assert.AreEqual(ddList[4].Text, obList[0].recycleReason);
            Assert.AreEqual(ddList[5].Text, obList[0].endResult);
            Assert.AreEqual(ddList[6].Text, obList[0].qtyRecycled.ToString());

            //making sure the proper information is displayed on the screen
            Assert.AreEqual(dtList[0].Text, "name");
            Assert.AreEqual(dtList[1].Text, "description");
            Assert.AreEqual(dtList[2].Text, "imageURL");
            Assert.AreEqual(dtList[3].Text, "isRecyclable");
            Assert.AreEqual(dtList[4].Text, "recycleReason");
            Assert.AreEqual(dtList[5].Text, "endResult");
            Assert.AreEqual(dtList[6].Text, "qtyRecycled");



            //the Back to List link.. Just to verify that it is seeing the next page
            driver.FindElement(By.LinkText("Back to List"));
            //Click the delete button to remove the item
            var delBtn = driver.FindElement(By.CssSelector("#btnDelete"));
            delBtn.Click();

            //Check how many rows are in the table now
            rows = driver.FindElements(By.CssSelector(".table tr")).Count;

            //Assert that there are 6 rows (one less) than before
            Assert.AreEqual(6, rows);
            

        }

       
       


    }


    

        
}
