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
    //this is home controller concerned with actions of each individual page
    public class HomeController : Controller
    {
        //context object - readonly - needed for saving data into the database
        private readonly KymiraAdminContext _context;

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
            //BinstyatusParser class sends validated and parsed object as a list
            //List of objects will besaved to database

            //save data to _context / database
            return Ok();
        }

        
    }
}
