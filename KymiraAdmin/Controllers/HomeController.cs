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
         */
        public  IActionResult Index(IFormFile excelFile)
        {
           
            //converts rows for excel sheet to array of strings
            if (excelFile.ContentType == ".xls" || excelFile.ContentType == ".xlsx")
            {
                
                HSSFWorkbook hssfwb = new HSSFWorkbook(excelFile.OpenReadStream()); //This will read the Excel 97-2000 formats   
                sheet = hssfwb.GetSheetAt(1); //get first sheet from workbook   
            }
            else
            {
                XSSFWorkbook hssfwb = new XSSFWorkbook(excelFile.OpenReadStream()); //This will read 2007 Excel format   
                sheet = hssfwb.GetSheetAt(1); //get first sheet from workbook    
            }
            IRow headerRow = sheet.GetRow(0); //Get Header Row 

            int cellCount = headerRow.LastCellNum;
            for (int j = 0; j < cellCount; j++)
            {
                NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);
                if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
            }
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File 
            {
                IRow row = sheet.GetRow(i);
                if (row == null) continue;
                if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                var stringRow = row.Cells.Select(c => c.ToString()).ToArray();
                BinStatus binToAdd = BinStatusParser.ParseBinStatusData(stringRow);

                List<ValidationResult> validationResults = ValidationHelper.Validate(binToAdd);

                //add converted BinStatus to appropriate list
                if (validationResults.Count == 0)
                {
                    validBins.Add(binToAdd);
                }
                else
                {
                    invalidBins.Add(binToAdd);
                }
            }

            //only accesses database if there are valid Bins to add
            if (validBins.Count > 0)
            {
                _context.BinStatus.AddRange(validBins);
                _context.SaveChanges();
            }
            
            return Ok();
        }

        
    }
}
