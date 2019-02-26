using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KymiraAdmin.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace KymiraAdmin.Controllers
{ // Start of Namespace

    //this is home controller concerned with actions of uploading an excel file
    public class HomeController : Controller
    {
        //context object - needed for saving data into the database
        private readonly KymiraAdminContext _context;
        private List<string> listRow;
        private List<Site> validSitesList;
        private List<Site> invalidSitesList;


        private List<BinStatus> validBins = new List<BinStatus>(); //list of valid BinStatus objects to be added to the database
                                                                   //For future we can save invalid binStatus objects
                                                                   // private List<BinStatus> invalidBins = new List<BinStatus>(); //list of invalid BinStatus objects to be displayed to user (future story**)
        private List<int> invalidRows = new List<int>(); //list that will store invalid rows which carries invalid bin object
        private ISheet sheetCollectionSheet;
        private ISheet sheetSiteSheet;
        private BinStatus binToAdd;

        //constructor that creates new context object (database)
        public HomeController(KymiraAdminContext context)
        {
            _context = context;
        }


        [HttpGet] //opens index view
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Home")]
        /* This method gets called upon a POST request. It takes in a file and then returns an appropriate response. 
         * It first checks the mime type of the excel file passed through the form posted and creates the appropriate workbook
         * to grab the data from.
         */
        public async Task<IActionResult> Index(IFormFile excelFile)
        {

            if (excelFile == null)
            {
                ViewData["Message"] = "Please select a file to upload";
                return View();
            }

            //checks mime type of excelFile and creates appropriate workbook
            if (excelFile.ContentType == "application/vnd.ms-excel") //This will read the Excel 97-2000 formats   
            {
                HSSFWorkbook hssfwb = new HSSFWorkbook(excelFile.OpenReadStream());
                sheetCollectionSheet = hssfwb.GetSheetAt(1); //get BinCollectionStatus sheet from workbook 
                sheetSiteSheet = hssfwb.GetSheetAt(0);
            }
            else if (excelFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")//This will read 2007 Excel format   
            {
                XSSFWorkbook hssfwb = new XSSFWorkbook(excelFile.OpenReadStream());
                sheetCollectionSheet = hssfwb.GetSheetAt(1); //get BinCollectionStatus sheet from workbook
                sheetSiteSheet = hssfwb.GetSheetAt(0);
            }
            else
            {
                //wrong file was chosen
                ViewData["Message"] += "Upload unsuccessful. Please select an Excel file to upload.";
                return View();
            }

            #region SiteUploadParsing
            //List of type string to store the information a single row
            listRow = new List<string>();

            //Create a list of Site objects to be populated with valid sites that are parsed from the Excel file
            validSitesList = new List<Site>();

            //Create a list of Site objects to be populated with invalid sites that are parsed from the Excel file
            invalidSitesList = new List<Site>();

            //***** If HeaderRow[0] = Container Serial Number 

            IRow headerRow = sheetSiteSheet.GetRow(0);
            int cellCount = headerRow.LastCellNum; //the total number of cells in the header row         

            //checks if each cell in the header row isn't empty
            for (int j = 0; j < cellCount; j++)
            {
                NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);

                listRow.Add(cell.ToString());
            }

            // *********************** SITE PARSING BLOCK **************************************** //

            //Check the header row of the worksheet in the Excel file that contains Site data
            Site siteObject = SiteParser.GenerateSiteObjectFromRow(listRow, true);

            //Create a list of validation results to hold the resulting header row validation
            List<ValidationResult> validationResultsHeaderRow = ValidationHelper.Validate(siteObject);

            //If header row is invalid in any way, display an error message to the user that the upload failed
            if (validationResultsHeaderRow.Count > 0)
            {
                ViewData["Message"] = "Upload unsuccessful. Please ensure Excel file was uploaded in the proper format.";
                return View();
            }
            // The header Row is 19 Columns, and is in the right order
            else
            {
                //Go through each row of the Excel file (except the header row)
                for (int i = (sheetSiteSheet.FirstRowNum + 1); i <= sheetSiteSheet.LastRowNum; i++)
                {
                    //If the current row has data
                    if (sheetSiteSheet.GetRow(i) != null)
                    {
                        //Create a row object from the row
                        IRow row = sheetSiteSheet.GetRow(i);

                        //Select each cell in the row and store the data from the row in a list of strings
                        listRow = row.Cells.Select(c => c.ToString()).ToList();

                        //Create a site object from the current row
                        siteObject = SiteParser.GenerateSiteObjectFromRow(listRow, false);

                        //Create a list of ValidationResults to validate the object created from the row
                        List<ValidationResult> validationResults = ValidationHelper.Validate(siteObject);

                        //If the Site object created from the current row is valid
                        if (validationResults.Count == 0)
                        {
                            //Add it to the list of valid Site objects (first check if it already exists, do not add duplicate rows)
                            if (validSitesList.Where(s => s.siteID == siteObject.siteID).Count() == 0)
                            {
                                validSitesList.Add(siteObject);
                            }
                        }
                        //If the Site object craeted from the current row is invalid
                        else
                        {
                            //Add it to the list of invalid Site objects (if it doesn't already exist)
                            if (invalidSitesList.Where(s => s.siteID == siteObject.siteID).Count() == 0)
                            {
                                invalidSitesList.Add(siteObject);
                            }
                        }
                    }
                }
            }

            //If there are more than 0 Site objects to add, access the database
            if (validSitesList.Count > 0)
            {
                try
                {
                    //Delete all rows from the Site table
                    //_context.Database.ExecuteSqlCommand("CREATE TABLE Site IF NOT EXISTS");

                    //Reload the site table with the new data from the Excel file
                    //_context.Database.ExecuteSqlCommand("DELETE FROM Site");
                    try
                    {
                        foreach (Site site in validSitesList)
                        {

                            var siteFromDB = await _context.Site.SingleOrDefaultAsync<Site>(s => s.siteID == site.siteID);

                            // If not in Database
                            if (siteFromDB == null)
                            {
                                // Add to database
                                await _context.Site.AddAsync(site);

                            }
                            else
                            {
                                siteFromDB.address = site.address;
                                siteFromDB.frequency = site.frequency;
                                siteFromDB.sitePickupDays = site.sitePickupDays;


                            }

                        }

                    }
                    catch
                    {

                    }

                    //If the database received a successful result of rows updated
                    var result = _context.SaveChangesAsync();

                    if (result.IsCompletedSuccessfully)
                    {

                        //Display message letting user know that upload succeeded
                        ViewData["Message"] = "Upload Successful -- Uploaded Site Data";

                        //return View();
                    }
                }
                //If an exception is ensountered
                catch (Exception e)
                {
                    //******** WHERE I LEFT OFF ON FEB 13/19 **** CHANGING SITE pickupDays to SitePickupDays MADE DATABASE MAD, HAVE TO FIX*******
                    //Display message that upload was unsuccessful if something went wrong
                    ViewData["Message"] = "Error 1: Something went wrong, try again later";
                    //return View();
                }
            }
            else
            {
                //display appropriate message
                ViewData["Message"] = "Error 2: Something went wrong, try again later";
            }

            //return View();
            #endregion SiteUploadParsing

            #region BinStatusUploadParsing
            

            //go through each cell for each row in the sheet
            for (int i = (sheetCollectionSheet.FirstRowNum + 1); i <= sheetCollectionSheet.LastRowNum; i++)
            {
                IRow row = sheetCollectionSheet.GetRow(i); //get current row

                //converts current row to an array of strings
                var stringRow = row.Cells.Select(c => c.ToString()).ToArray();
                //checks if any row is null 
                if (stringRow[0].Equals(""))
                {
                    string[] stringRowNull = { "", "", "", "" };
                    binToAdd = BinStatusParser.ParseBinStatusData(stringRowNull);
                }
                else
                {
                    //calls BinStatusParser to get BinStatus back
                    binToAdd = BinStatusParser.ParseBinStatusData(stringRow);
                }

                List<ValidationResult> validationResults = ValidationHelper.Validate(binToAdd);

                //add converted BinStatus to appropriate list based on validationResults
                if (validationResults.Count == 0)
                {
                    validBins.Add(binToAdd);
                }
                else
                {
                    invalidRows.Add(i);
                    continue;
                }

            }


            //only accesses database if there are valid Bins to add
            if (validBins.Count > 0)
            {
                //attempts to add the list of BinStatuses to the database
                _context.BinStatus.AddRange(validBins);
                try
                {
                    //saves valid objects to the database
                    var result = _context.SaveChanges();
                    if (result > 0)
                    {
                        //display success message if save changes was successful
                        ViewData["Message"] += "Upload Successful\n -- Uploaded Collection Data";

                        return View();
                    }

                }
                catch (Exception e)
                {
                    //display unsuccess message
                    ViewData["Message"] += "Upload unsuccessful. something went wrong, try again. -- Upload Collection Data";
                    return View();
                }
            }

            else
            {
                //display appropriate message
                ViewData["Message"] += "something went wrong, try again. -- Upload Collection Data";
            }

            return View();
            #endregion BinStatusUploadParsing


        }
    } // End of Class


} // Start of Namespace
