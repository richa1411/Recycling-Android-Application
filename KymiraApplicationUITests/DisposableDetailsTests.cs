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

    public class DisposableDetailsTests
    {
        IApp app;
        Platform platform;

        public DisposableDetailsTests(Platform platform)
        {
            this.platform = platform;
        }


        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            app.TapCoordinates(100, 100);
            app.Tap("Disposables List");

        }

        [Test]
        public void TestThatItemDescriptionDisplaysProperly()
        {
            //tap the list item
            app.Tap("Tin Cans");
            //check that the title apears
            app.WaitForElement(c => c.Marked("What is it? "));
            //check that the description contents appear
            app.WaitForElement(c => c.Marked("Tins Cans Description"));
        }

        [Test]
        public void TestThatItemRecycleReasonDisplaysProperly()
        {
            //tap the list item
            app.Tap("Tin Cans");
            //check that the title apears
            app.WaitForElement(c => c.Marked("Reason: "));
            //check that the recycle reason contents appear
            app.WaitForElement(c => c.Marked("Tin Cans Reason"));
        }

        [Test]
        public void TestThatItemEndResultDisplaysProperly()
        {
            //tap the list item
            app.Tap("Tin Cans");
            //check that the title apears
            app.WaitForElement(c => c.Marked("End Result: "));
            //check that the end results contents appear
            app.WaitForElement(c => c.Marked("Tin Cans End Result"));
        }

        [Test]
        public void TestThatItemQtyRecycledDisplaysProperly()
        {
            //tap the list item
            app.Tap("Tin Cans");
            //check that the title apears
            app.WaitForElement(c => c.Marked("Quantity Recycled: "));
            //check that the qtyRecycled contents appear
            app.WaitForElement(c => c.Marked("1200"));
        }

        //tests that if an item is pushed offscreen it can still be interacted with
        [Test]
        public void TestScrollingCapabilities()
        {
            //taps on cardboard to expand it
            app.Tap("Cardboard");
            //taps on paper item to expand it
            app.Tap("Paper");
            //scrolls down so Tin Cans is displayed properly on screen
            app.ScrollDownTo("Tin Cans");
            //taps on tin cans
            app.Tap("Tin Cans");



        }
    }
}
