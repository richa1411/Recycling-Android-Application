using kymiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using kymiraAPI;

namespace kymiraAPI.Fixtures
{
    public class fixture_bin_status
    {
        //** Bin Statuses **/
        //TO DO: add Site objects FIRST then add BinStatus objects to link to the Site objects
        //TO DO: also add history for some BinStatus objects
        public static List<BinStatus> obList = new List<BinStatus>(new BinStatus[] { new BinStatus
        {
            binID = 1,
            binAddress = "123 Testone St",
            siteID = 1,
            status = 1,
            collectionDate = "2019-01-01"
        },
            new BinStatus
        {
            binID = 2,
            binAddress = "123 Testone St",
            siteID = 1,
            status = 2,
            collectionDate = "2019-01-01"
        },
            new BinStatus
        {
            binID = 3,
            binAddress = "123 Testtwo St",
            siteID = 2,
            status = 1,
            collectionDate = "2019-01-01"
        },
            new BinStatus
        {
             binID = 4,
            binAddress = "123 Testtwo St",
            siteID = 2,
            status = 1,
            collectionDate = "2019-01-01"
        },
            new BinStatus
        {
            binID = 5,
            binAddress = "123 Testtwo St",
            siteID = 2,
            status = 3,
            collectionDate = "2019-01-01"
        },
            new BinStatus
        {
            binID = 6,
            binAddress = "123 Testfour St",
            siteID = 3,
            status = 1,
            collectionDate = "2019-01-01"
        },
            new BinStatus
        {
            binID = 3,
            binAddress = "123 Testtwo St",
            siteID = 2,
            status = 1,
            collectionDate = "2019-02-02"
        },
            new BinStatus
        {
             binID = 4,
            binAddress = "123 Testtwo St",
            siteID = 2,
            status = 1,
            collectionDate = "2019-02-02"
        },
            new BinStatus
        {
            binID = 5,
            binAddress = "123 Testtwo St",
            siteID = 2,
            status = 3,
            collectionDate = "2019-02-02"
        }
        });

        /**
         * This function will create a connection to a local test database and load the specific data into it.
         * */
        public static void Load(kymiraAPIContext _context)
        {
            _context.BinStatus.AddRange(obList); //add site range first 
            _context.SaveChangesAsync();

        }
        /**
         * this function will delete all tests information in the database.
         * */
        public static void Unload(kymiraAPIContext _context)
        {
            _context.BinStatus.RemoveRange(_context.BinStatus);
            _context.SaveChangesAsync();
        }
    }
}
