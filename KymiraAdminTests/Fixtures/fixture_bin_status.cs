using KymiraAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KymiraAdminTests.Fixtures
{
    public class fixture_bin_status
    {
        //This class is used to add and delete data from the database for testing which items are displayed to the page.

        //This class is used to add and delete data from the database for testing which items are displayed to the page.
        //Site objects to add to the database
        public static List<Site> obSites = new List<Site>(new Site[] {
            new Site { siteID = 10, address = "123 Test Street", sitePickupDays = Site.PickupDays.Monday, frequency = Site.PickupFrequency.Weekly },
            new Site { siteID = 20, address = "123 Another Street", sitePickupDays = Site.PickupDays.Monday, frequency = Site.PickupFrequency.Weekly},
            new Site { siteID = 30, address = "123 Fake Street", sitePickupDays = Site.PickupDays.Monday, frequency = Site.PickupFrequency.Weekly } });
        //list of BinStatus objects to be added to database
        public static List<BinStatus> obBins = new List<BinStatus> {
        new BinStatus
        {
            binID = "W114-320-203",
            siteID = obSites[0].siteID,
            status = BinStatus.CollectionStatus.Collected,
            collectionDate = "2019-01-01",
            inactive = false
        },
        new BinStatus
        {
            binID = "W114-320-204",
            siteID = obSites[0].siteID,
            status = BinStatus.CollectionStatus.Inaccessible,
            collectionDate = "2019-01-01",
        inactive = false
        },
        new BinStatus
        {
            binID = "W114-320-205",
            siteID = obSites[1].siteID,
            status = BinStatus.CollectionStatus.Collected,
            collectionDate = "2019-01-01",
            inactive = true
        },
        new BinStatus
        {
             binID = "COSMO123",
            siteID = obSites[1].siteID,
            status = BinStatus.CollectionStatus.Collected,
            collectionDate = "2019-01-01",
            inactive = false
        },
        new BinStatus
        {
            binID = "12345",
            siteID = obSites[2].siteID,
            status = BinStatus.CollectionStatus.Contaminated,
            collectionDate = "2019-01-01",
            inactive = true
        }};

        /* This function will load specific Bin Status objects to the Bin Status table in the database passed in.*/
        public static void Load(KymiraAdminContext _context)
        {
            //load data and save changes
            _context.Site.AddRange(obSites);
            _context.BinStatus.AddRange(obBins);
            _context.SaveChanges();
        }

        /* This function will remove all Bin Status objects in the Bin Status table from the database passed in. */
        public static void Unload(KymiraAdminContext _context)
        {
            //unload data and save changes
            _context.Site.RemoveRange(_context.Site);
            
            _context.SaveChanges();
        }
        
    }
}
