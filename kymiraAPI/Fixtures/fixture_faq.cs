using kymiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kymiraAPI.Fixtures
{ /*
     * This class will be responsible for loading and unloading the FAQ table in a test database with some sample data for testing purposes. 
     */
    public static class fixture_faq
    {
        //Define the static list of FAQ objects to add to the FAQ table of the database
        private static List<FAQ> listFAQ = new List<FAQ> { 
           
                new FAQ {
                 
                 question = "Where is Cosmo Industries?",
                 answer = "1302 Alberta Ave. Saskatoon"
                },
            
            new FAQ
            {
                  
            question = "How can I register with different bin locations",
                answer = "You can register as many time as you can with different addresses"
            },
            new FAQ
            {
               
                question = "How do I get more rewards?",
                answer = "Be the part of weekly quizes and kepp updated with next collection dates to make your bin filled "
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

            }

        };

       

        /**
         * This function will create a connection to a local test database and load the specific data into it (the FAQ objects).
         * */
        public static void Load(kymiraAPIContext _context)
        {
            _context.FAQDBSet.AddRange(listFAQ);
            _context.SaveChanges();
        }

        /**
         * This function will remove everything from FAQ table.
         * */
        public static void Unload(kymiraAPIContext _context)
        {
            _context.FAQDBSet.RemoveRange(_context.FAQDBSet);
            _context.SaveChanges();
        }
    }
}

