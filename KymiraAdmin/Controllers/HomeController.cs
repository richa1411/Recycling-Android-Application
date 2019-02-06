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
    public class HomeController : Controller
    {
        private readonly KymiraAdminContext _context;
        private List<Site> listSites;

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
            //Handle uploading the Excel file

            // Go through each row in the excel file
            // Call SiteParser for each row
            // Add returned site to List

            //Parse the Excel file

            //Save data from Excel file to database

            return Ok();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
