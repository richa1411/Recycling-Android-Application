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
                    firstName = "John",
                    lastName = "Smith",
                    birthDate = "1996-05-12",
                    emailAddress = "john.smith@hotmail.com",
                    phoneNumber = "3061234780",
                    addressLine1 = "Fairhaven",
                    addressLine2 = "Unit 6",
                    city = "Saskatoon",
                    province = "Saskatchewan",
                    postalCode = "S7L5W4",
                    password = "P@ssw0rd"
                },
                new Resident
                {
                    firstName = "Ted",
                    lastName = "Richards",
                    birthDate = "1992-04-27",
                    emailAddress = "testEmail@test.com",
                    phoneNumber = "3062224612",
                    addressLine1 = "413 Perehudoff Cres",
                    city = "Saskatoon",
                    province = "Saskatchewan",
                    postalCode = "S7J4J6",
                    password = "anotherpassword"
                },
                new Resident
                {
                    firstName = "Leo",
                    lastName = "Ridley",
                    birthDate = "1990-04-13",
                    emailAddress = "yourbrand@nexus.com",
                    phoneNumber = "3069874635",
                    addressLine1 = "Katzman Place",
                    city = "Martensville",
                    province = "Saskatchewan",
                    postalCode = "S0k2T0",
                    password = "passcode"
                }
            };

        /*
         * This function will be responsible for actually loading the test data into the Resident table. 
         */
        public static void load(kymiraAPIContext _context)
        {
            //Add the list of residents to the database
            _context.ResidentDBSet.AddRange(residentList);
            _context.SaveChangesAsync();
        }

        /*
         * This function will be responsible for removing the test data from the Resident table. 
         */
        public static void delete(kymiraAPIContext _context)
        {
            //Remove everything from the Resident table
            _context.ResidentDBSet.RemoveRange(_context.ResidentDBSet);
            _context.SaveChangesAsync();
        }
    }
}
