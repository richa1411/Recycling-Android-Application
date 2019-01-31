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

        //default constructor for BinStatusController
        public BinStatusController(KymiraAdminContext context)
        {
            _context = context;
        }




        /*
         * This method will go through the excel file uploaded from the view. It will first check to ensure that the 
         * file is an excel file and then it will go through each record of the file and create a BinStatus object. 
         * It will then validate the object and add it to a list to be added to the database.
         * The method will return a 200 OK response if upload was successful or error messages if something went wrong.
         */
        public IActionResult UploadFile(IFormCollection objForm)
        {
            //go through file and get list/collection of ROWS
            //send list/collection of ROWS to parser class
            //parser class goes through and grabs certain values, uses the parseDate/parseBinID/etc. methods to convert data into
            //"valid" BinStatus data to create a BinStatus -- then validate and add to list or send error message
            return Ok();
        }

    }
}
