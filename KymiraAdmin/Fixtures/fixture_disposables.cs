using KymiraAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KymiraAdmin;

namespace KymiraAdmin.Fixtures
{/**
    this class will be used to wipe and reload the database with test data used in unit tests
        */
    public class fixture_disposables
    {

     

        //** Recyclable Items **/
        public static List<Disposable> obList = new List<Disposable>(new Disposable[] { new Disposable
        {

            name = "Cardboard",
            description = "Cardboard Description",
            imageURL = "Cardboard",
            isRecyclable = true,
            recycleReason = "Cardboard Reason",
            endResult = "Cardboard End Result",
            qtyRecycled = 1000,
            inactive = false
        }, new Disposable
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
            
            name = "Candy",
            description = "Candy Description",
            imageURL = "Candy",
            isRecyclable = false,
            recycleReason = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
            endResult = "Candy End Result",
            qtyRecycled = 0,
             inactive = false
        }
        });


        /**
         * This function will create a connection to a local test database and load the specific data into it.
         * */
        public static void Load(KymiraAdminContext _context)
        {
                    _context.DisposableDBSet.AddRange(obList);
                    _context.SaveChanges();
        }
        /**
         * this function will delete all entries  in the database.
         * */
        public static void Unload(KymiraAdminContext _context) {
                _context.DisposableDBSet.RemoveRange(_context.DisposableDBSet);
                _context.SaveChanges();
        }
    }
}
