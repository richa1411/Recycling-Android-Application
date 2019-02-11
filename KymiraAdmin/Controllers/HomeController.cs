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

namespace KymiraAdmin.Controllers
{
    //this is home controller concerned with actions of uploading an excel file
    public class HomeController : Controller
    {
        //context object - needed for saving data into the database
        private readonly KymiraAdminContext _context;
        //private readonly kymiraAPI.Models.kymiraAPIContext _context;

        private List<BinStatus> validBins = new List<BinStatus>(); //list of valid BinStatus objects to be added to the database
        private List<BinStatus> invalidBins = new List<BinStatus>(); //list of invalid BinStatus objects to be displayed to user (future story**)
        ISheet sheet;

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
        public  IActionResult Index(IFormFile excelFile)
        {
            //checks mime type of excelFile and creates appropriate workbook
            if (excelFile.ContentType == "application/vnd.ms-excel") //This will read the Excel 97-2000 formats   
            {
                HSSFWorkbook hssfwb = new HSSFWorkbook(excelFile.OpenReadStream()); 
                sheet = hssfwb.GetSheetAt(1); //get BinCollectionStatus sheet from workbook   
            }
            else if (excelFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")//This will read 2007 Excel format   
            {
               XSSFWorkbook hssfwb = new XSSFWorkbook(excelFile.OpenReadStream()); 
               sheet = hssfwb.GetSheetAt(1); //get BinCollectionStatus sheet from workbook    
            }
            else
            {
                //wrong file was chosen
                ViewData["Message"] = "Upload unsuccessful. Please select an Excel file to upload.";
                return View();
            }

            //converts rows from excel sheet to array of strings
            IRow headerRow = sheet.GetRow(0); //Get Header Row 
            int cellCount = headerRow.LastCellNum; //the total number of cells in the header row

            //checks if each cell in the header row isn't empty
            for (int j = 0; j < cellCount; j++)
            {
                NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) {
                    ViewData["Message"] = "Upload unsuccessful. Your Excel file needs headers to upload.";
                    return View();
                }
            }

            List<int> invalidRows = new List<int>();

            //go through each cell for each row in the sheet
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i); //get current row

                //converts current row to an array of strings
                var stringRow = row.Cells.Select(c => c.ToString()).ToArray();

                //calls BinStatusParser to get BinStatus back
                BinStatus binToAdd = BinStatusParser.ParseBinStatusData(stringRow);

                List<ValidationResult> validationResults = ValidationHelper.Validate(binToAdd);

                //add converted BinStatus to appropriate list based on validationResults
                if (validationResults.Count == 0)
                {
                    validBins.Add(binToAdd);
                }
                else
                {
                    invalidRows.Add(i);
                    break;
                }
            }

            /*
            string isOrAre = invalidBins.Count > 0 ? "are " : "is ";
            if(invalidBins.Count > 0)
            {
                ViewData["Message"] += "There " + isOrAre + invalidBins.Count + "row(s) in your Excel file.";
            }

            foreach(int row in invalidRows)
            {
                ViewData["Message"] += "There is an error in the row of line " + row + ".";
            }*/

            //only accesses database if there are valid Bins to add
            if (validBins.Count > 0)
            {
                //attempts to add the list of BinStatuses to the database
                _context.BinStatus.AddRange(validBins);
                try
                {
                    var result = _context.SaveChanges();
                    if (result > 0)
                    {
                        //display success message if save changes was successful
                        ViewData["Message"] = "Upload Successful.";
                        return View();
                    }
                }
                catch(Exception e)
                {
                    //display unsuccess message
                    ViewData["Message"] = "Upload unsuccessful. something went wrong, try again.";
                    return View();
                }
            }
            else
            {
                //display appropriate message
                ViewData["Message"] = "something went wrong, try again.";
            }
            
            return View();
        }
        
    }
}
