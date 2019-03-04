using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kymiraAPI.Models;

namespace kymiraAPI.Controllers
{
    //this controller handles requests from the front end and will return either all the data from the FAQDBSet table or
    //the id-specified FAQ object
    [Produces("application/json")]
    [Route("api/FAQs")]
    public class FAQsController : Controller
    {
        //defining the context object to use
        private readonly kymiraAPIContext _context;

        public FAQsController(kymiraAPIContext context)
        {
            _context = context;
        }

        // This method gets all the data from the FAQDBSet table in the database.
        // GET: api/FAQs
        [HttpGet]
        public IEnumerable<FAQ> GetFAQ()
        {

            return _context.FAQDBSet.Where(m => m.inactive == false);
        }


    }
}