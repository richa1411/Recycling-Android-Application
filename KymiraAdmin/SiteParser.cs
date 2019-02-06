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


        //Method that tries to create a valid Site object given the current row's data
        public static Site GenerateSiteObjectFromRow(List<string> sRow)
        {
            //Helper method to try and generate valid site objects from the rows of the Excel spreadsheet

            //Try and create a Site object from the row data

            //If Site object is invalid, set to null

            return new Site();
        }


        // This method will take in a String value of an Excel cell
        // and tries to parse to a valid SiteID
        public static int parseSiteID(String sCell)
        {
            throw new NotImplementedException();
        }

        // This method will take in a String value of an Excel cell
        // and tries to parse to a valid Address
        public static string parseAddress(String sCell)
        {
            throw new NotImplementedException();
        }

        // This method will take in a String value of an Excel cell
        // and tries to parse to a valid Pickup Frequency
        public static Site.PickupFrequency parseFrequency(String sCell)
        {
            throw new NotImplementedException();
        }

        // This method will take in a String value of an Excel cell
        // and tries to parse to a valid Pickup Day
        public static Site.PickupDays parsePickupDays(String[] sCells)
        {
            throw new NotImplementedException();
        }
    }
}
