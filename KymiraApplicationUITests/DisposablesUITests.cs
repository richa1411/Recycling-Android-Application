using System;
using System.Collections;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace KymiraApplicationUITests
{
    [TestFixture(Platform.Android)]
    public class DisposablesUITests
    {
        IApp app;
        Platform platform;

        public DisposablesUITests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }


        [Test]
        public void TestThatNavigationBurgerExistsAndDispsoableItemsButtonExists()
        {

            ArrayList results = new ArrayList();
            //is item there, is Icon there(if added)

            app.TapCoordinates(100, 100);
            results.Add(app.WaitForElement(c => c.Marked("Disposables List")));
            Assert.AreEqual(1, results.Count);


        }
        [Test]
        public void TestThatRecyclableButtonExistsAndPopulatesListWithOnlyRecyclableItemsinAlpheticalOrder()
        {
            ArrayList results = new ArrayList();
            app.TapCoordinates(100, 100);
            app.Tap("Disposables List");

            results.Add(app.WaitForElement(c => c.Marked("Show recyclable items")));
            Assert.AreEqual(1, results.Count);
            results = new ArrayList();
            app.Tap("Show recyclable items");

           


            results.Add(app.WaitForElement(c => c.Marked("Cardboard")));
            results.Add(app.WaitForElement(c => c.Marked("Paper")));
            results.Add(app.WaitForElement(c => c.Marked("Tin Cans")));

            ArrayList obNames = new ArrayList { "Cardboard", "Paper", "Tin Cans" };
            int i = 0;
            foreach (AppResult o in results)
            {

                Assert.AreEqual(obNames[i], o.Text);
                i++;
            }


            Assert.AreEqual(3, results.Count);
        }
        [Test]
        public void TestThatNonRecylcableButtonExistsAndPopulatesListwithOnlyNonRecyclableItemsInAlphabeticalOrder()
        {

            ArrayList results = new ArrayList();
            app.TapCoordinates(100, 100);
            app.Tap("Disposables List");

            results.Add(app.WaitForElement(c => c.Marked("Show Non-recyclable items")));
            Assert.AreEqual(1, results.Count);
            results = new ArrayList();
            app.Tap("Show Non-recyclable items");


            results.Add(app.WaitForElement(c => c.Marked("Candy")));
            results.Add(app.WaitForElement(c => c.Marked("Orange Peels")));
            results.Add(app.WaitForElement(c => c.Marked("Pizza")));


            ArrayList obNames = new ArrayList { "Candy", "Orange Peels", "Pizza" };

            int i = 0;
            foreach (AppResult o in results)
            {

                Assert.AreEqual(obNames[i], o.Text);
                i++;
            }


            Assert.AreEqual(3, results.Count);


        }



     

    }
}