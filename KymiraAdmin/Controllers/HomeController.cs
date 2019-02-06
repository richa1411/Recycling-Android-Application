using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KymiraAdmin.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace KymiraAdmin.Controllers
{
    //this is home controller concerned with actions of uploading an excel file
    public class HomeController : Controller
    {
        //context object - needed for saving data into the database
        private readonly KymiraAdminContext _context;

        private List<BinStatus> validBins; //list of valid BinStatus objects to be added to the database
        private List<BinStatus> invalidBins; //list of invalid BinStatus objects to be displayed to user (future story**)

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

        [HttpPost]
        /* This method gets called upon a POST request. It takes in a file and then returns an appropriate response.
         */
        public  IActionResult Index(IFormFile excelFile)
        {
            //converts rows for excel sheet to array of strings
            //then sends array of strings to the BinStatusParser class

            //while (true) //loop while there are still rows of data to convert
            //{
            string[] rowData = { };

            BinStatus binToAdd = BinStatusParser.ParseBinStatusData(rowData);

            
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

            //}

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
