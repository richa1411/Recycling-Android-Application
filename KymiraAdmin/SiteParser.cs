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

        //Method that tries to create a valid Site object given the current row's data
        public static Site GenerateSiteObjectFromRow(List<string> sRow)
        {
            //Helper method to try and generate valid site objects from the rows of the Excel spreadsheet

            //Try and create a Site object from the row data

            //If Site object is invalid, set to null

            return new Site();
        }


        // This method will take in a String value of an Excel cell
        // and tries to parse to a valid SiteID. If the ID can't be parsed, function will return 0
        public static int parseSiteID(String siteIDString)
        {
            //Create an integer to hold the converted value
            int convertedID = 0;

            //Try to parse the string ID into an integer
            bool success = Int32.TryParse(siteIDString, out convertedID);

            return convertedID;
        }

        // This method will take in a String value of an Excel cell
        // and tries to parse to a valid Address. If the address can't be parsed, function will return an empty string
        public static string parseAddress(String fullAddressString)
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
        public static Site.PickupFrequency parseFrequency(String pickupFrequency)
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
        public static Site.PickupDays parsePickupDays(string[] pickupDays, Site.PickupFrequency pickupFrequency)
        {
            Site.PickupDays parsedPickupDays = Site.PickupDays.Invalid;

            List<string> validPickupDays = new List<string>();

            int validCollection = 0;

            //If array of pickup day strings is empty, return invalid PickupDay
            if(pickupDays.Length == 0)
            {
                return parsedPickupDays;
            }

            //
            for(int i = 0; i < pickupDays.Length; i++)
            {
                if((pickupDays[i].Length == numberOfCollectionDigits) && (Int32.TryParse(pickupDays[i], out validCollection) != false))
                {
                    for(int j = 0; j < pickupDays.Length; j++)
                    {
                        string pickupDayCollectionDay1 = pickupDays[i];
                        string pickupDayCollection2 = pickupDays[j];

                        if (pickupDayCollectionDay1[1] < pickupDayCollection2[1])
                        {

                        }
                    }
                }
            }
        }
    }
}
