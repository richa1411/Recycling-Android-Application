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
            //is item there, is Icon there(if added)
            app.TapCoordinates(120, 120);

        }


        [Test]

        public void TestThatListViewShowsProperAmountOfRecylcableItems()
        {
           
        }

        [Test]

        public void TestThatListViewShowProperAmountofNonRecyclableItems()
        {
       
        }

        [Test]

        public void TestThatListViewShowsRecyclableItemsAlphabeticalOrder()
        {
         
        }
        [Test]
        public void TestThatListViewShowsNonRecyclableItemsInAlphabeticalOrder()
        {

        }
        [Test]
        public void TestThatListViewRecyclableItemsContainExpectedInformation()
        {

        }
        [Test]
        public void TestThatListViewNonRecyclableItemsContainExpectedInformation()
        {

        }
        [Test]
        public void TestThatRecyclableButtonPopulatesListWithOnlyRecyclableItems()
        {

        }
        [Test]
        public void TestThatNonRecylcableButtonPopulatesListwithOnlyNonRecyclableItems()
        {

        }


    }
}