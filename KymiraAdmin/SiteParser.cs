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
                    pickupDays = Site.PickupDays.Invalid,
                    frequency = Site.PickupFrequency.Invalid
                };
            }

            //Try and create a Site object from the row data
            if (isHeaderRow && !(sRow[(int)ColumnName.SiteIDCol].Equals("Site ID") || sRow[7].Equals("Full Address") || sRow[10].Equals("Frequency") || sRow[15].Equals("Collection1")
                    || sRow[16].Equals("Collection2") || sRow[17].Equals("Collection3") || sRow[18].Equals("Collection4")))
            {
                //Return a site with the flag value of 0 (header row is OK)
                return new Site
                {
                    pickupDays = Site.PickupDays.Invalid
                };
            }
            //If row is a header row and one or more columns are incorrect
            else if(isHeaderRow)
            {
                //Return an invalid site with flag value of -1 (header row is incorrect)
                return new Site
                {
                    siteID = 123,
                    address = "valid",
                    frequency = Site.PickupFrequency.BiWeekly,
                    pickupDays = Site.PickupDays.Monday
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
                siteFromRow.pickupDays = ParsePickupDays(collections);
            
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

            return convertedID;
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

            pickupDays = pickupDays.Where(s => !string.IsNullOrEmpty(s)).OrderByDescending(s=>s).ToArray();

            Site.PickupDays parsedPickupDays = (Site.PickupDays) 0;

            int largestNumber = 0;

            if (pickupDays.Length == 0)
            {
                return Site.PickupDays.Invalid;
            }

            Int32.TryParse(pickupDays[0], out largestNumber);
                
            if(largestNumber > 9999 || largestNumber < 1000 || largestNumber == 0)
            {
                return Site.PickupDays.Invalid;
            }

            string collectionDay = pickupDays[0];
            char largestDigit = collectionDay[0];

            foreach(string day in pickupDays)
            {
                if(day[0] == largestDigit && day.Length == 4)
                {
                    int lastDigit = Convert.ToInt32(day[3].ToString());
                    int lastPickupDay = Convert.ToInt32(Math.Pow(2, (lastDigit - 1)));
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
