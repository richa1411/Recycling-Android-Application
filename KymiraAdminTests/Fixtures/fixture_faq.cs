using KymiraAdmin.Data;
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
    public class fixture_faq
    {
        //Define the static list of FAQ objects to add to the FAQ table of the database
        public static List<FAQ> listFAQ = new List<FAQ>(new FAQ[] 
        {
            new FAQ
            {

                 question = "Where is Cosmo Industries?",
                 answer = "1302 Alberta Ave. Saskatoon."
            },
            new FAQ
            {

            question = "How can I register with different bin locations?",
                answer = "You can register as many times as you can with different addresses."
            },
            new FAQ
            {

                question = "How do I get more rewards?",
                answer = "Be the part of weekly quizes and kepp updated with next collection dates to make your bin filled."
            },
            new FAQ
            {

                question = "What is COSMO Industries?",
                answer = "It is a recycling place."
            },
            new FAQ
            {

                question = "Do I have to register to view bin collection dates?",
                answer = "Absolutely not, you can just open an application enter your bin address and there's your date!"

            },
            new FAQ
            {
                question = "What is the airspeed velocity of an unladden swallow?",
                answer = "African or European?",
                inactive = true
            }

        });

       

        /**
         * This function will create a connection to a local test database and load the specific data into it (the FAQ objects).
         * */
        public static void Load(KymiraAdminContext _context)
        {
            _context.FAQDBSet.AddRange(listFAQ);
            _context.SaveChanges();
        }

        /**
         * This function will remove everything from FAQ table.
         * */
        public static void Unload(KymiraAdminContext _context)
        {
            _context.FAQDBSet.RemoveRange(_context.FAQDBSet);
            _context.SaveChanges();
        }
    }
}

