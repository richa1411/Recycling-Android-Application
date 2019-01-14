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
    [Produces("application/json")]
    [Route("api/BinStatus")]
    public class BinStatusController : Controller
    {
        private readonly kymiraAPIContext _context;

        public BinStatusController(kymiraAPIContext context)
        {
            _context = context;
        }

        /**
         * 
         * gets all binStatus objects from DB
         * */
        // GET: api/BinStatus
        [HttpGet]
        public IEnumerable<BinStatus> GetBinStatus()
        {
            return _context.BinStatus;
        }


        /**
         * This method will take in an address string from the application and return a List of BinStatus objects that are associated to that address.
         * It will search for a Site object with the address passed in and then go through that Site's corresponding list of BinStatus objects.
         * It will then bring back a list of BinStatus's with the most RECENT COLLECTION DATES.
         * 
         * The method will return a Bad Request if the string passed in is an empty string or if it is greater than 200 characters.
         * The method will return 404 not found if something went wrong (no matching site with that address).
         **/
        // PUT: api/BinStatus/5
        [HttpPut]
        public async Task<IActionResult> PutBinStatus( [FromBody] string address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if the string passed in is invalid in any way, return a Bad Request
            if(address == "" || address.Length >200)
            {
                return BadRequest("Bad Request");

            }
            
            //finding matching site
            var siteFound = await _context.Site.Where(m => m.address == address).ToListAsync();

            if (siteFound == null)
            {
                return NotFound();
            }

            //find corresponding BinStatus objects
//            var binsFound = await _context.BinStatus.Where(m => m.siteID == siteFound.siteID).ToListAsync();

            //return matching BinStatus's
            return Ok(siteFound);
        }

  


       
        /**
         * Checks the database if a BinStatus exists with the given ID.
         * */
        private bool BinStatusExists(int id)
        {
            return _context.BinStatus.Any(e => e.binID == id);
        }
    }



}