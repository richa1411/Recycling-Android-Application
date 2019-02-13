
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KymiraAdmin.Models;
using System.Text;

namespace KymiraAdmin.Fixtures
{ /*
     * This class will be responsible for loading and unloading the FAQ table in a test database with some sample data for testing purposes. 
     */
    public class fixture_site
    {
        public static List<Site> obSites = new List<Site>(new Site[] { new Site { siteID = 10, address = "123 Test Street", binStatus = {
            new BinStatus
            {
                siteID = 10,
                binID = "W114-320-203",
                collectionDate = "2018-01-01",
                status = 1

            } }, frequency = Site.PickupFrequency.Weekly,pickupDays = Site.PickupDays.Monday },

            new Site { siteID = 20, address = "123 Another Street", binStatus = {
            new BinStatus
            {
                siteID = 20,
                binID = "W114-320-213",
                collectionDate = "2018-05-01",
                status = 1

            } }, frequency = Site.PickupFrequency.BiWeekly,pickupDays = Site.PickupDays.Thursday }


        });


        /**
         * This function will create a connection to a local test database and load the specific data into it (the FAQ objects).
         * */
        public static void Load(KymiraAdminContext _context)
        {
            _context.Site.AddRange(obSites);
            _context.SaveChanges();
        }

        /**
         * This function will remove everything from FAQ table.
         * */
        public static void Unload(KymiraAdminContext _context)
        {
            _context.Site.RemoveRange(_context.Site);
            _context.SaveChanges();
        }
    }
}

