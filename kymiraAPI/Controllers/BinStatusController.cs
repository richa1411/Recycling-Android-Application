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
        //context object
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
         * The method will return an empty list if the address is invalid or there was no matching site with that address passed in.
         */
        [HttpPost]
        public async Task<List<BinStatus>> PostAddressToSearch([FromBody]string searchAddress)
        {
            if (!ModelState.IsValid)
            {
                return new List<BinStatus>();
            }

            //if the string passed in is invalid in any way, return a Bad Request
            if (searchAddress == "" || searchAddress.Length > 200)
            {
                return new List<BinStatus>();
            }

            //finding matching site(s) - should only have one match
            var siteFound = await _context.Site.Where(m => m.address == searchAddress).ToListAsync();

            if (siteFound.Count.Equals(0) || siteFound == null)
            {
                //site was not found, return empty list
                return new List<BinStatus>();
            }


            //find corresponding BinStatus objects
            var binsFound = await _context.BinStatus.Where(m => m.siteID == siteFound[0].siteID).ToListAsync();

            //sort by collection date
            binsFound = binsFound.OrderBy(e => e.collectionDate).ToList();

            //grab the most recent pickup date to use to compare
            var latestDate = binsFound[binsFound.Count - 1].collectionDate;
            
            //list of most recent bin status objects to return to the front end
            List<BinStatus> recentBins = new List<BinStatus>();

            //make sure to grab only the most recent ones for each bin status
            for (int i = 0; i < binsFound.Count; i++)
            {
                //compare with the most recent date
                if (binsFound[i].collectionDate.Equals(latestDate))
                {
                    recentBins.Add(binsFound[i]);
                }
            }
            return recentBins;
        }
    }

}