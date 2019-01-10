using kymiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kymiraAPI.Fixtures
{
    /*
     * This class will be responsible for loading and unloading the Resident table in a test database with some sample data for testing purposes. 
     */
    public static class fixture_resident
    {
        //Define the static list of Resident objects to add to the Resident table of the database
        private static List<Resident> residentList = new List<Resident> {
                new Resident
                {
                    
                }
                
            };

        /*
         * This function will be responsible for actually loading the test data into the Resident table. 
         */
        public static void load(kymiraAPIContext _context)
        {
            //Add the list of residents to the database
            
        }

        /*
         * This function will be responsible for removing the test data from the Resident table. 
         */
        public static void delete(kymiraAPIContext _context)
        {
            //Remove everything from the Resident table
            
        }
    }
}
