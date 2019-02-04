using KymiraAdmin.Models;
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
    public static class ExcelParser
    {

        //Method that parses through Excel data and tries to create Site objects, adding them to a collection if valid. This collection will eventually be added to the database
        public static List<Site> ParseExcelForSiteData()
        {
            //Parse through the Excel file and try to create Site objects from the rows of the Excel spreadsheet

            //For each row in spreadsheet, grab raw data from that row
            //Call GenerateSiteObjectFromRow with raw data from current row

            //Check if GenerateSiteObjectFromRow returns a valid Site object or null

            //If not null, add it to list of Site objects

            return new List<Site>();
        }

        //Method that tries to create a valid Site object given the current row's data
        public static Site GenerateSiteObjectFromRow(IRow row)
        {
            //Helper method to try and generate valid site objects from the rows of the Excel spreadsheet

            //Try and create a Site object from the row data

            //If Site object is invalid, set to null

            return new Site();
        }
    }

    
}
