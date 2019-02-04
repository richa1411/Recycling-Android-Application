using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KymiraAdmin
{
    /*
     *  This static class will contain all the private methods for parsing data in the Excel spreadsheet.
     */
	public static class ExcelParser 
	{
        /*
         * This method will parse the date in an Excel sheet in the format of "3-Jan-18" or "1/1/2018"
         * It will return the correct format required to create a Bin Status object: "2018-01-01"
         */
		public static string ParseDate(List<string> values)
        {

            //accommodate for either format - either slashes or dashes, leading zeros, etc.

            //grab the year
            //grab the month
            //grab the day

            return "";
        }

        /*
         * This method will parse the ContainerCollectionRecord field from the Excel sheet. 
         * It will return the corresponding integer value needed to create a Bin Status object.
         * If the status passed in is not any of the following strings, it will be considered Inaccessible:
         * "Collected" = int of 1
         * "Inaccessible" = int of 2 
         * "Contaminated" = int of 3
         */
        private static int ParseStatus(List<string> values)
        {
            //case statement on string passed in
            //return corresponding int value or default of 3 (Inaccessible)
            return 0;
        }

        /*
         * This method will parse the ContainerSerialNumber from the Excel sheet. 
         * It will grab the correct information from the sheet and then return the correct string
         * to be used to create a valid BinStatus object.
         */
        private static string ParseSerialNumber(List<string> values)
        {
            //find the correct column
            //grab the string and return it

            return "";
        }

        /*
         * This method will parse the SiteID field in the Excel spreadsheet.
         * It will return the SiteID as a string.
         */
        private static string ParseSiteID(List<string> values)
        {
            return "";
        }
       
	}
}