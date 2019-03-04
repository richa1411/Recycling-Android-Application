
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KymiraAdmin.Models;

namespace KymiraAdminTests.Fixtures
{
    //This class is used to add and delete data from the database in order for backend API tests to pass.

    public class fixture_sites
    {
        //Site objects to add to the database
        public static List<Site> obSites = new List<Site>(new Site[] {
            new Site { siteID = 10, address = "123 Test Street", sitePickupDays = Site.PickupDays.Monday, frequency = Site.PickupFrequency.Weekly },
            new Site { siteID = 20, address = "123 Another Street", sitePickupDays = Site.PickupDays.Monday, frequency = Site.PickupFrequency.Weekly},
            new Site { siteID = 30, address = "123 Fake Street", sitePickupDays = Site.PickupDays.Monday, frequency = Site.PickupFrequency.Weekly },
        new Site { siteID = 40, address = "123 Again Street", sitePickupDays = Site.PickupDays.Thursday, frequency = Site.PickupFrequency.BiWeekly }});
        

        /**
         * This function will create a connection to a local test database and load the specific data into it.
         * It first adds the Site objects needed and then loads in the following BinStatus objects.
         * */
        public static void Load(KymiraAdminContext _context)
        {
            _context.Site.AddRange(obSites);
           _context.SaveChanges();
        }

        /**
         * This function will delete all test information in the database.
         * */
        public static void Unload(KymiraAdminContext _context)
        {
            _context.Site.RemoveRange(_context.Site); //removes Site objects from the DB
            _context.SaveChanges();
        }
    }
}
