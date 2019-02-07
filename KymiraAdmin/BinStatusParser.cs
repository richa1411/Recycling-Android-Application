using KymiraAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KymiraAdmin
{
    /*
     *  This static class will contain all the methods for parsing data in a string array that contains
     *  BinStatus information.
     */
	public static class BinStatusParser 
	{
        /*
         * This method takes in a string array to then be parsed with the Parse methods and used to create
         * a BinStatus object. The method will return the BinStatus object 
         * (without any regard to whether the object is valid or invalid).
         */
        public static BinStatus ParseBinStatusData(String[] stringRow)
        {
            BinStatus bin = new BinStatus
            {
                siteID = ParseSiteID(stringRow[0]),
                binID = ParseSerialNum(stringRow[1]),
                collectionDate = ParseDate(stringRow[2]),
                status = ParseStatus(stringRow[3])

            };
            
            return bin;
        }

        /*
         * This method will parse the date in an Excel sheet in the format of "3-Jan-18" or "1/1/2018"
         * It will return the correct format required to create a Bin Status object: "2018-01-01"
         */
		public static string ParseDate(string date)
        {
            string convertedDate;  
            try
            {
                //parse and convert string to proper format
                convertedDate = DateTime.Parse(date).ToString("yyyy-MM-dd");
            }
            //catch any exceptions thrown by the DateTime parsing method
            catch(Exception exp)
            {
                convertedDate = "";
            }
            //return converted string or empty string
            return convertedDate;
            
        }

        /*
         * This method will return the corresponding integer value needed to create a Bin Status object.
         * If the status passed in is not one of the following strings, it will be considered Inaccessible
         * and return an int of 2:
         * "Collected" = returns int of 1
         * "Inaccessible" = returns int of 2 
         * "Contaminated" = returns int of 3
         */
        public static int ParseStatus(string status)
        {
            if(status == "")
            {
                return 0;
            }
            switch(status) //return corresponding int value
            {
                case "Collected":
                    return 1;
                case "Contaminated":
                    return 3;
                default: //"Inaccessible"
                    return 2;
            }
        }

        /*
         * This method will parse the ContainerSerialNumber from the Excel sheet. 
         * It will grab the correct information from the sheet and then return the correct string
         * to be used to create a valid BinStatus object.
         */
        public static string ParseSerialNum(string serialnum)
        {
            if(serialnum == "")
            {
                return "";
            }
            return serialnum;
        }

        /*
         * This method will parse the SiteID field in the Excel spreadsheet.
         * It will return the SiteID as an int or 0.
         */
        public static int ParseSiteID(string siteid)
        {
            if(siteid == "")
            {
                return 0;
            }
            return Convert.ToInt32(siteid);
        }
       
	}
}