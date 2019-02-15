using kymiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using kymiraAPI;

namespace kymiraAPI.Fixtures
{
    //This class is used to add and delete data from the database in order for backend API tests to pass.

    public class fixture_bin_status
    {
        //Site objects to add to the database
        public static List<Site> obSites = new List<Site>(new Site[] {
            new Site { siteID = 10, address = "123 Test Street", sitePickupDays = Site.PickupDays.Monday, frequency = Site.PickupFrequency.Weekly },
            new Site { siteID = 20, address = "123 Another Street", sitePickupDays = Site.PickupDays.Monday, frequency = Site.PickupFrequency.Weekly},
            new Site { siteID = 30, address = "123 Fake Street", sitePickupDays = Site.PickupDays.Monday, frequency = Site.PickupFrequency.Weekly } });
        
        //BinStatus objects to add to the database
        public static List<BinStatus> obBins = new List<BinStatus>(new BinStatus[] { new BinStatus
        {
            binID = "1",
            siteID = obSites[0].siteID,
            status = 1,
            collectionDate = "2019-01-01"
        },
            new BinStatus
        {
            binID = "2",
            siteID = obSites[0].siteID,
            status = 2,
            collectionDate = "2019-01-01"
        },
            new BinStatus
        {
            binID = "3",
            siteID = obSites[1].siteID,
            status = 1,
            collectionDate = "2019-01-01"
        },
            new BinStatus
        {
             binID = "4",
            siteID = obSites[1].siteID,
            status = 1,
            collectionDate = "2019-01-01"
        },
            new BinStatus
        {
            binID = "5",
            siteID = obSites[1].siteID,
            status = 3,
            collectionDate = "2019-01-01"
        },
            new BinStatus
        {
            binID = "6",
            siteID = obSites[2].siteID,
            status = 1,
            collectionDate = "2019-01-01"
        },
            //---------history pickups for 3 bins---------------
            new BinStatus
        {
            binID = "3",
            siteID = obSites[1].siteID,
            status = 1,
            collectionDate = "2019-02-02"
        },
            new BinStatus
        {
             binID = "4",
            siteID = obSites[1].siteID,
            status = 1,
            collectionDate = "2019-02-02"
        },
            new BinStatus
        {
            binID = "5",
            siteID = obSites[1].siteID,
            status = 3,
            collectionDate = "2019-02-02"
        }});

        /**
         * This function will create a connection to a local test database and load the specific data into it.
         * It first adds the Site objects needed and then loads in the following BinStatus objects.
         * */
        public static void Load(kymiraAPIContext _context)
        {
            _context.Site.AddRange(obSites);
           _context.BinStatus.AddRange(obBins);
           _context.SaveChanges();
        }

        /**
         * This function will delete all test information in the database.
         * */
        public static void Unload(kymiraAPIContext _context)
        {
            _context.Site.RemoveRange(_context.Site); //removes corresponding BinStatus's for each Site as well
            _context.SaveChanges();
        }
    }
}
