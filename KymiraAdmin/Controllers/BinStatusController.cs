using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KymiraAdmin.Models;
using Microsoft.AspNetCore.Http;

namespace KymiraAdmin.Controllers
{
    /**
     *  This controller class will handle the post request of a file that the admin wants to upload.
     */
    public class BinStatusController : Controller
    {
        //context object - readonly
        private readonly KymiraAdminContext _context;

        public BinStatusController(KymiraAdminContext context)
        {
            _context = context;
        }




        /*
         * This method will go through the excel file uploaded from the view. It will first check to ensure that the 
         * file is an excel file and then it will go through each record of the file and create a BinStatus object. 
         * It will then validate the object and add it to a list to be added to the database.
         * The method will return the correct View or error messages if something went wrong.
         */
        public IActionResult UploadFile(IFormCollection objForm)
        {

            return Ok();
        }

    }
}
