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
    //this controller handles request from front end it will return a list containing question and answers
    [Produces("application/json")]
    [Route("api/FAQs")]
    public class FAQsController : Controller
    {
        private readonly kymiraAPIContext _context;

        public FAQsController(kymiraAPIContext context)
        {
            _context = context;
        }

        //gets all data from the database
        // GET: api/FAQs
        [HttpGet]
        public IEnumerable<FAQ> GetFAQ()
        {
            return _context.FAQDBSet;
        }

        //this getFAQ method will accept the request from frontend and grab all data from database and send back to the front end
        // GET: api/FAQs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFAQ([FromRoute] int id)
        {
            //checks if model is valid or not, if not then gives error with bad request status
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //gets data from database for particular id gets question and answer
            var fAQ = await _context.FAQDBSet.SingleOrDefaultAsync(m => m.ID == id);

            //if not got data from database then returns not found status
            if (fAQ == null)
            {
                return NotFound();
            }

            return Ok(fAQ);
        }

       //post method is saving data to FAQ database
        // POST: api/FAQs
        [HttpPost]
        public async Task<IActionResult> PostFAQ([FromBody] FAQ fAQ)
        {
            //checks if model is valid or not
            if (!ModelState.IsValid)
            {
                //if not then returns bad request status
                return BadRequest(ModelState);
            }
            //adds faq object to database of project
            _context.FAQDBSet.Add(fAQ);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFAQ", new { id = fAQ.ID }, fAQ);
        }

       

       
    }
}