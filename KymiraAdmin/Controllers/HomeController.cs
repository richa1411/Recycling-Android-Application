using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KymiraAdmin.Models;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace KymiraAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly KymiraAdminContext _context;
        private List<string> listRow;
        private List<Site> validSitesList;
        private List<Site> invalidSitesList;

        ISheet sheet;

        public HomeController(KymiraAdminContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile excelFile)
        {
            //List of type string to store the information a single row
            listRow = new List<string>();

            //Create a list of Site objects to be populated with valid sites that are parsed from the Excel file
            validSitesList = new List<Site>();

            //Create a list of Site objects to be populated with invalid sites that are parsed from the Excel file
            invalidSitesList = new List<Site>();

            //checks mime type of excelFile and creates appropriate workbook
            if (excelFile.ContentType == "application/vnd.ms-excel") //This will read the Excel 97-2000 formats  
            {
                HSSFWorkbook hssfwb = new HSSFWorkbook(excelFile.OpenReadStream());
                sheet = hssfwb.GetSheetAt(0); //get Site and Collection Data sheet from workbook   
            }
            else if (excelFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")//This will read 2007 Excel format   
            {
                XSSFWorkbook hssfwb = new XSSFWorkbook(excelFile.OpenReadStream());
                sheet = hssfwb.GetSheetAt(0); //get Site and Collection Data sheet from workbook    
            }
            else
            {
                //wrong file was chosen
                ViewData["Message"] = "Upload unsuccessful. Please select an Excel file to upload.";
                return View();
            }

            IRow headerRow = sheet.GetRow(0);
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
            if(validationResultsHeaderRow.Count > 0)
            {
                ViewData["Message"] = "Upload unsuccessful. Please ensure Excel file was uploaded in the proper format.";
                return View();
            }
            // The header Row is 19 Columns, and is in the right order
            else
            {
                //Go through each row of the Excel file (except the header row)
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    //If the current row has data
                    if(sheet.GetRow(i) != null)
                    {
                        //Create a row object from the row
                        IRow row = sheet.GetRow(i);

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
                            if(validSitesList.Where(s => s.SiteID == siteObject.SiteID).Count() == 0)
                            {
                                validSitesList.Add(siteObject);
                            }
                        }
                        //If the Site object craeted from the current row is invalid
                        else
                        {
                            //Add it to the list of invalid Site objects (if it doesn't already exist)
                            if(invalidSitesList.Where(s => s.SiteID == siteObject.SiteID).Count() == 0)
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
                    _context.Site.AddRange(validSitesList);

                    //If the database received a successful result of rows updated
                    var result = _context.SaveChanges();

                    if (result > 0)
                    {

                        //Display message letting user know that upload succeeded
                        ViewData["Message"] = "Upload Successful";

                        return View();
                    }
                }
                //If an exception is ensountered
                catch (Exception e)
                {
                    //******** WHERE I LEFT OFF ON FEB 13/19 **** CHANGING SITE pickupDays to SitePickupDays MADE DATABASE MAD, HAVE TO FIX*******
                    //Display message that upload was unsuccessful if something went wrong
                    ViewData["Message"] = "Error 1: Something went wrong, try again later";
                    return View();
                }
            }
            else
            {
                //display appropriate message
                ViewData["Message"] = "Error 2: Something went wrong, try again later";
            }

            return View();
        }


    }
}
