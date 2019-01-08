using kymiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kymiraAPITest.Fixtures
{
    static class fixture_story6c
    {

        //** Recyclable Items **/

        static Disposable disposable1 = new Disposable
        {
            name = "Cardboard",
            description = "Cardboard Description",
            pictureID = "Cardboard.png",
            isRecyclable = true,
            recyclableReason = "Cardboard Reason",
            endResult = "Cardboard End Result",
            qtyRecycled = 1000
        };

        static Disposable disposable2 = new Disposable
        {
            name = "Paper",
            description = "Paper Description",
            pictureID = "",
            isRecyclable = true,
            recyclableReason = "Paper Reason",
            endResult = "Paper End Result",
            qtyRecycled = 2500
        };

        static Disposable disposable3 = new Disposable
        {
            name = "Tin Cans",
            description = "Tins Cans Description",
            pictureID = "TinCans.png",
            isRecyclable = true,
            recyclableReason = "Tin Cans Reason",
            endResult = "Tin Cans End Result",
            qtyRecycled = 1200
        };

        //** Non-Recyclable Items */

        static Disposable disposable4 = new Disposable
        {
            name = "Pizza",
            description = "Pizza Description",
            pictureID = "Pizza.png",
            isRecyclable = false,
            recyclableReason = "Pizza Reason",
            endResult = "Pizza End Result",
            qtyRecycled = 0
        };

        static Disposable disposable5 = new Disposable
        {
            name = "Orange Peels",
            description = "Orange Peels Description",
            pictureID = "OrangePeels.png",
            isRecyclable = false,
            recyclableReason = "Orange Peels Reason",
            endResult = "Orange Peels End Result",
            qtyRecycled = 0
        };

        static Disposable disposable6 = new Disposable
        {
            name = "Candy",
            description = "Candy Description",
            pictureID = "Candy.png",
            isRecyclable = false,
            recyclableReason = "Candy Reason",
            endResult = "Candy End Result",
            qtyRecycled = 0
        };

        public async Task load()
        {

            // _context.DisposableDBSet.Add(disposable);
            // await _context.SaveChangesAsync();

            kymiraAPIContext kymiraAPIContext;

            kymiraAPIContext.DisposableDBSet;

            jsonHandler testJSON = new jsonHandler();
            var successReceived = await testJSON.receiveJsonAsync(dispURL);


            //takes list of json objects, converts it to list of binStatus
            List<Disposable> binList = JsonConvert.DeserializeObject<List<Disposable>>(successReceived);

            var countTrue = 0;  //count of how many objects in list contains true as isRecyclable
            var countFalse = 0; //count of how many objects in list contains false as isRecyclable

            //loop through all objects received, counting how many true and false isRecyclable objects are in the list
            foreach (Disposable item in binList)
            {
                //increase the count depending on this item's property value
                if (item.isRecyclable == true)
                {
                    countTrue++;
                }
                else
                {
                    countFalse++;
                }

            }

            //add object with isRecyclable as true if count of true in list is not 1
            if (countTrue != 1)
            {
                sendTest.isRecyclable = true;
                var success = await testJSON.sendJsonAsync(sendTest, dispURL);
                Assert.AreEqual("Success", success);    //check that sending object was successful
            }

            //add object with isRecyclable as false if count of false in list is not 1
            if (countFalse != 1)
            {
                sendTest.isRecyclable = false;
                var success = await testJSON.sendJsonAsync(sendTest, dispURL);
                Assert.AreEqual("Success", success);    //check that sending object was successful
            }
        }
    }
}
