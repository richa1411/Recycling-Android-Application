using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KymiraAdmin.Models;

namespace KymiraAdmin.Controllers
{
    //this is home controller concerned with actions of each individual page
    public class HomeController : Controller
    {
        //this opens index view
        public IActionResult Index()
        {
            return View();
        }

        //this method returns Upload view that display form with file input box and a submit button 
        public IActionResult Upload()
        {
            return View();
        }

        //this method return errorview
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
