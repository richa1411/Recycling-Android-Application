using kymiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Fixtures
{
    public class fixture_faq
    {
        private static List<FAQ> obFAQ = new List<FAQ> (
            new FAQ[] {
                new FAQ {
                    ID=1,
            question = "How can I register with different bin locations",
                answer = "You can register as many time as you can with different addresses"},
            
            new FAQ
            {

            },
            new FAQ
            {

            },
            new FAQ
            {

            },
            new FAQ
            {

            },

        });

        //public static Site site1 = new Site { siteID = 10, address = "123 Test Street" };

        //public static BinStatus obBinAdd = new BinStatus { binID = 100, siteID = site1.siteID, collectionDate = "2019-01-01", status = 2 };

        /**
         * This function will create a connection to a local test database and load the specific data into it.
         * It first adds the Site objects needed and then loads in the following BinStatus objects.
         * */
        public static void load(kymiraAPIContext _context)
        {
            _context.FAQ.AddRange(obFAQ);

            _context.SaveChangesAsync();

           

        }

        /**
         * This function will delete all test information in the database.
         * */
        public static void delete(kymiraAPIContext _context)
        {
            _context.FAQ.RemoveRange(_context.FAQ); 
            _context.SaveChangesAsync();
        }
    }
}

