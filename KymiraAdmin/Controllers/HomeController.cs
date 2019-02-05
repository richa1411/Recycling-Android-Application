using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KymiraAdmin.Models;
using Microsoft.AspNetCore.Http;

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
        public IActionResult Index(List<IFormFile> files)
        {
            //converts rows for excel sheet to array of strings
            //then sends array of strings to the BinStatusParser class

            //BinstyatusParser class sends parsed object
            //here we will validate the object and add it to a list of either 
            //valid (to be added to database) or invalid
            //save valid list of bin status objects to database
            return Ok();
        }

        
    }
}
