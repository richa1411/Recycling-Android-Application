using kymiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using kymiraAPI;

namespace kymiraAPI.Fixtures
{
    static class fixture_disposables
    {

        //** Recyclable Items **/
        public static List<Disposable> obList = new List<Disposable>(new Disposable[] { new Disposable
        {
          
            name = "Cardboard",
            description = "Cardboard Description",
            pictureID = "Cardboard.png",
            isRecyclable = true,
            recyclableReason = "Cardboard Reason",
            endResult = "Cardboard End Result",
            qtyRecycled = 1000
        }, new Disposable
        {
           
            name = "Paper",
            description = "Paper Description",
            pictureID = "",
            isRecyclable = true,
            recyclableReason = "Paper Reason",
            endResult = "Paper End Result",
            qtyRecycled = 2500
        },
            new Disposable
        {
           
            name = "Tin Cans",
            description = "Tins Cans Description",
            pictureID = "TinCans.png",
            isRecyclable = true,
            recyclableReason = "Tin Cans Reason",
            endResult = "Tin Cans End Result",
            qtyRecycled = 1200
        },
            new Disposable
        {
            
            name = "Pizza",
            description = "Pizza Description",
            pictureID = "Pizza.png",
            isRecyclable = false,
            recyclableReason = "Pizza Reason",
            endResult = "Pizza End Result",
            qtyRecycled = 0
        },
            new Disposable
        {
           
            name = "Orange Peels",
            description = "Orange Peels Description",
            pictureID = "OrangePeels.png",
            isRecyclable = false,
            recyclableReason = "Orange Peels Reason",
            endResult = "Orange Peels End Result",
            qtyRecycled = 0
        },
            new Disposable
        {
            
            name = "Candy",
            description = "Candy Description",
            pictureID = "Candy.png",
            isRecyclable = false,
            recyclableReason = "Candy Reason",
            endResult = "Candy End Result",
            qtyRecycled = 0
        }
        });

        /**
         * This function will create a connection to a local test database and load the specific data into it.
         * */
        public static void Load(kymiraAPIContext _context)
        {

                    _context.DisposableDBSet.AddRange(obList);
                    _context.SaveChangesAsync();
                
    
        }
        /**
         * this function will delete all tests information in the database.
         * */
        public static void Unload(kymiraAPIContext _context) {
           

                _context.DisposableDBSet.RemoveRange(_context.DisposableDBSet);
                _context.SaveChangesAsync();
 
        }
    }
}
