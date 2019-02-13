using KymiraAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KymiraAdmin.Fixtures
{
    public class fixture_bin_status
    {
        //This class is used to add and delete data from the database for testing which items are displayed to the page.

        //list of BinStatus objects to be added to database
        public static List<BinStatus> obBins = new List<BinStatus> {
        new BinStatus
        {
            binID = "W114-320-203",
            siteID = 1609312,
            status = 1,
            collectionDate = "2019-01-01"
        },
        new BinStatus
        {
            binID = "W114-320-204",
            siteID = 1609312,
            status = 2,
            collectionDate = "2019-01-01"
        },
        new BinStatus
        {
            binID = "W114-320-205",
            siteID = 1609312,
            status = 1,
            collectionDate = "2019-01-01"
        },
        new BinStatus
        {
             binID = "COSMO123",
            siteID = 1609320,
            status = 1,
            collectionDate = "2019-01-01"
        },
        new BinStatus
        {
            binID = "12345",
            siteID = 1609320,
            status = 3,
            collectionDate = "2019-01-01"
        }};

        /* This function will load specific Bin Status objects to the Bin Status table in the database passed in.*/
        public static void Load(KymiraAdminContext _context)
        {
                //load data and save changes
        }

        /* This function will remove all Bin Status objects in the Bin Status table from the database passed in. */
        public static void Unload(KymiraAdminContext _context)
        {
                //unload data and save changes
        }
        
    }
}
