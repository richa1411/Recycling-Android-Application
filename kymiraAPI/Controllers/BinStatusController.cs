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
         * This method will take in an address string from the application and return a List of BinStatus objects that are associated to that address.
         * It will search for a Site object with the address passed in and then go through that Site's corresponding list of BinStatus objects.
         * It will then bring back a list of BinStatus's with the most RECENT COLLECTION DATES.
         * 
         * The method will return a Bad Request if the string passed in is an empty string or if it is greater than 200 characters.
         * The method will return 404 not found if something went wrong (no matching site with that address).
         */
        // POST: api/BinStatus/123 Test Street
        [HttpPost]
        public async Task<IActionResult> PostAddressToSearch([FromBody]string searchAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if the string passed in is invalid in any way, return a Bad Request
            if (searchAddress == "" || searchAddress.Length > 200)
            {
                return BadRequest("Bad Request");

            }

            //finding matching site(s) - should only have one match
            var siteFound = await _context.Site.Where(m => m.address == searchAddress).ToListAsync();

            if (siteFound.Count.Equals(0))
            {
                //site was not found, return not found
                return NotFound("No match");
            }


            //find corresponding BinStatus objects
            var binsFound = await _context.BinStatus.Where(m => m.siteID == siteFound[0].siteID).ToListAsync();

            //sort by collection date then reverse the order -- TO DO: reverse list
            binsFound = binsFound.OrderBy(e => e.collectionDate).ToList();

            var latestDate = binsFound[binsFound.Count - 1 ].collectionDate;
            
            //list of most recent bin status objects to return to the front end
            List<BinStatus> recentBins = new List<BinStatus>();

            //make sure to grab only the most recent ones for each bin status
            for (int i = 0; i < binsFound.Count; i++)
            {
                //do some sort of comparisson with the dates here
                if (binsFound[i].collectionDate.Equals(latestDate))
                {
                    recentBins.Add(binsFound[i]);
                }
            }


            return Ok(recentBins);
            //return recentBins;
        }
    }

}