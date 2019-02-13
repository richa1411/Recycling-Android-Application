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
            listRow = new List<string>();
            validSitesList = new List<Site>();
            invalidSitesList = new List<Site>();


            //checks if each cell in the header row isn't empty
            for (int j = 0; j < cellCount; j++)
            {
                NPOI.SS.UserModel.ICell cell = headerRow.GetCell(j);

                listRow.Add(cell.ToString());
            }


            Site siteObject = SiteParser.GenerateSiteObjectFromRow(listRow, true);

            List<ValidationResult> validationResultsHeaderRow = ValidationHelper.Validate(siteObject);

            if(validationResultsHeaderRow.Count > 0)
            {
                ViewData["Message"] = "Upload unsuccessful. Please ensure Excel file was uploaded in the proper format.";
                return View();
            }
            else // The header Row is 19 Columns, and is in the right order
            {
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    if(sheet.GetRow(i) != null)
                    {
                        IRow row = sheet.GetRow(i);

                        listRow = row.Cells.Select(c => c.ToString()).ToList();

                        siteObject = SiteParser.GenerateSiteObjectFromRow(listRow, false);

                        List<ValidationResult> validationResults = ValidationHelper.Validate(siteObject);

                        //add converted BinStatus to appropriate list based on validationResults
                        if (validationResults.Count == 0)
                        {
                            if(validSitesList.Where(s => s.siteID == siteObject.siteID).Count() == 0)
                            {
                                validSitesList.Add(siteObject);
                            }
                        }
                        else
                        {
                            if(!invalidSitesList.Contains(siteObject))
                            {
                                invalidSitesList.Add(siteObject);
                            }
                        }
                    }
                }
            }

            //only accesses database if there are valid Bins to add
            if (validSitesList.Count > 0)
            {
                //attempts to add the list of BinStatuses to the database
                //_context.Site.AddRange(validSitesList);
                //_context.Site.UpdateRange(validSitesList);
                _context.Database.ExecuteSqlCommand("DELETE FROM Site");
                _context.Site.AddRange(validSitesList);


                // try
                // {
                var result = _context.SaveChanges();
                    if (result > 0)
                    {
                        //display success message if save changes was successful
                        ViewData["Message"] = "Upload Successful.";
                        return View();
                    }
                //}
                //catch (Exception e)
                //{
                    //display unsuccess message
                   // ViewData["Message"] = "Upload unsuccessful. something went wrong, try again.";
                   // return View();
                //}
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
