using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kymiraAPI.Models;

namespace kymiraAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Sites")]
    //Class responsible for handling HTTP requests related to Site objects
    public class SitesController : Controller
    {
        private readonly kymiraAPIContext _context;

        public SitesController(kymiraAPIContext context)
        {
            _context = context;
        }
      
        // POST: api/Sites
        //Function responsible for querying the database for the given search address
        //Function also will utliize an internal helper function that will calculate the next two pick up dates to return based on the site found
        //Returns an empty array of DateTime objects if the address is not matched to a site in the database
        [HttpPost]
        public async Task<List<String>> PostAddressToSearch([FromBody] string searchAddress)
        {
            if (!ModelState.IsValid)
            {
                return new List<string>();
            }

            //if the string passed in is invalid in any way, return an empty list
            if (searchAddress == "" || searchAddress.Length > 200)
            {
                return new List<String>();
            }

            var siteFound = await _context.Site.Where(m => m.address == searchAddress).ToListAsync();

            if (siteFound.Count.Equals(0) || siteFound == null)
            {
                //site was not found, return empty list
                return new List<String>();
            }

            Site site = siteFound[0];

            List<String> nextTwoDays = new List<string>();

            nextTwoDays = PickupDateCalculatorHelper.CalculateNextPickupDates(site, DateTime.Today);

            return nextTwoDays;  
        }

        private bool SiteExists(int id)
        {
            return _context.Site.Any(e => e.siteID == id);
        }
    }
}