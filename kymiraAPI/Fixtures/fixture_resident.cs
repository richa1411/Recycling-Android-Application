using kymiraAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace kymiraAPI.Fixtures
{
    public static class fixture_resident
    {
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

        public static async Task load()
        {
            //check to see if database exists   

            //foreach on the resident list going through the database

        }

        public static async Task delete()
        {

        }
    }
}
