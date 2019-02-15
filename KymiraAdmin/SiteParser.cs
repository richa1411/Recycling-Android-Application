using KymiraAdmin.Models;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KymiraAdmin
{
    /*
     * Static utility class with helper methods for KymiraAdmin web application operations
     **/
    public static class SiteParser
    {
        const int numberOfCollectionDigits = 4;
        const int numberOfExcelColumns = 19;

        public enum ColumnName
        {
            SiteIDCol = 1,
            FullAddressCol = 7,
            FrequencyCol = 10,
            Collection1Col = 15,
            Collection2Col = 16,
            Collection3Col = 17,
            Collection4Col = 18
        }

        //Method that tries to create a valid Site object given the current row's data
        public static Site GenerateSiteObjectFromRow(List<string> sRow, bool isHeaderRow)
        {   
            //If Excel file does not have the correct number of columns
            if(isHeaderRow && sRow.Count > 19 || sRow.Count < 19)
            {
                //Return an invalid site
                return new Site
                {
                    sitePickupDays = Site.PickupDays.Invalid,
                    frequency = Site.PickupFrequency.Invalid
                };
            }

            // Check if all the columns we need to parse have valid headers
            if (isHeaderRow && !(sRow[(int)ColumnName.SiteIDCol].Equals("Site ID") && sRow[7].Equals("Full Address") && sRow[10].Equals("Frequency") && sRow[15].Equals("Collection1")
                    && sRow[16].Equals("Collection2") && sRow[17].Equals("Collection3") && sRow[18].Equals("Collection4")))
            {
                // If this is reached, it means the headers are incorrect, so return an invalid object
                return new Site
                {
                    sitePickupDays = Site.PickupDays.Invalid
                };
            }
            //If row is a header row, but has all required fields
            else if(isHeaderRow)
            {
                // Return a valid site object (this one won't be parsed, and added to the array)
                return new Site
                {
                    siteID = 1,
                    address = "valid",
                    frequency = Site.PickupFrequency.BiWeekly,
                    sitePickupDays = Site.PickupDays.Monday
                };
            }
            //Else row is NOT a header row, try to parse
            else
            {
                //Create a new Site object to hold data from the row
                Site siteFromRow = new Site();

                //Parse the ID and add it to the Site object
                siteFromRow.siteID = ParseSiteID(sRow[1]);

                //Parse the address and add it to the Site object
                siteFromRow.address = ParseAddress(sRow[7]);

                //Parse the frequency and add it to the Site object
                siteFromRow.frequency = ParseFrequency(sRow[10]);

                //Create a string array to hold each potential collection day
                string[] collections = new string[4];

                collections[0] = sRow[15];
                collections[1] = sRow[16];
                collections[2] = sRow[17];
                collections[3] = sRow[18];

                //Parse the pickup days and add it to the site object
                siteFromRow.sitePickupDays = ParsePickupDays(collections);
            
                return siteFromRow;

            }
        }


        // This method will take in a String value of an Excel cell
        // and tries to parse to a valid SiteID. If the ID can't be parsed, function will return 0
        public static int ParseSiteID(String siteIDString)
        {
            //Create an integer to hold the converted value
            int convertedID = 0;

            //Try to parse the string ID into an integer
            bool success = Int32.TryParse(siteIDString, out convertedID);

            //If parse successful
            if(success)
            {
                //Return 0 if value is negative, otherwise return the ID
                return convertedID > 0 ? convertedID : 0;
            }
            //If parsing failed, return 0
            else
            {
                return 0;
            }
        }

        // This method will take in a String value of an Excel cell
        // and tries to parse to a valid Address. If the address can't be parsed, function will return an empty string
        public static string ParseAddress(String fullAddressString)
        {
            string convertedString = "";

            //If address is not empty and is less than or equal to 200 characters
            if(!String.IsNullOrEmpty(fullAddressString) && fullAddressString.Length <= 200)
            {
                convertedString = fullAddressString;
            }

            //Address is OK, return it
            return convertedString;
        }

        // This method will take in a String value of an Excel cell
        // and tries to parse to a valid Pickup Frequency
        public static Site.PickupFrequency ParseFrequency(String pickupFrequency)
        {
            //Set the parsed frequency to initially be invalid
            Site.PickupFrequency parsedFrequency = Site.PickupFrequency.Invalid;

            //Check for all allowable values for the pickup frequency string and set the parsed frequency accordingly
            switch(pickupFrequency.ToLower())
            {
                case "weekly":
                    parsedFrequency = Site.PickupFrequency.Weekly;
                    break;
                case "bi-weekly":
                case "biweekly":
                    parsedFrequency = Site.PickupFrequency.BiWeekly;
                    break;
                case "twice a week":
                    parsedFrequency = Site.PickupFrequency.Weekly;
                    break;
                default:
                    parsedFrequency = Site.PickupFrequency.Invalid;
                    break;
            }

            return parsedFrequency;
        }

        // This method will take in a String value of an Excel cell
        // and tries to parse to a valid PickupDay. If it fails, it will return an invalid PickupDay
        public static Site.PickupDays ParsePickupDays(string[] pickupDays)
        {
            //Order the pickupDays string array in descending order for each collection that has data (is not null or empty)
            pickupDays = pickupDays.Where(s => !string.IsNullOrEmpty(s)).OrderByDescending(s=>s).ToArray();

            Site.PickupDays parsedPickupDays = (Site.PickupDays) 0;

            int largestNumber = 0;

            //If there are no collection days to parse, immediately set the PickupDays to invalid and return
            if (pickupDays.Length == 0)
            {
                return Site.PickupDays.Invalid;
            }

            //Find and parse the largest number (also most recent) of the given collection days
            Int32.TryParse(pickupDays[0], out largestNumber);

            //If the largest number falls outside of the valid ranges, immediately set the PickupDays to invalid and return  
            if(largestNumber > 9999 || largestNumber < 1000 || largestNumber == 0)
            {
                return Site.PickupDays.Invalid;
            }

            //Create a string array to hold the largest collection day value
            string collectionDay = pickupDays[0];

            //Create a char array to store individual digits of each collection day
            char largestDigit = collectionDay[0];

            //For each digit in the current collection day
            foreach(string day in pickupDays)
            {
                //If the first digit in the day is the largest digit and the entire number is 4 digits (valid)
                if(day[0] == largestDigit && day.Length == 4)
                {
                    //Get the last digit of the collection (numeric day of the week)
                    int lastDigit = Convert.ToInt32(day[3].ToString());

                    //Get the last pick up day of the collection (convert to value our enum can use)
                    int lastPickupDay = Convert.ToInt32(Math.Pow(2, (lastDigit - 1)));

                    //Append the parsed pickup day to the existing variable of pickup days
                    parsedPickupDays = parsedPickupDays | ((Site.PickupDays) lastPickupDay);
                }
                else
                {
                    break;
                }
            }

            return parsedPickupDays;
        }
        
    }
}
