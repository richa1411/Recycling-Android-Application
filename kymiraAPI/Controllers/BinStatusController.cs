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

        // GET: api/BinStatus
        [HttpGet]
        public IEnumerable<BinStatus> GetBinStatus()
        {
            return _context.BinStatus;
        }

       
        /**
         * This method will take a binStatus Object from the application and return a List of binStatus objects that have a matching 
         * binStatus Address. 
         * will return a 404 not found if nothing is matching.
         * */
        // PUT: api/BinStatus/5
        [HttpPut]
        public async Task<IActionResult> PutBinStatus( [FromBody] BinStatus bin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var binStatus = await _context.BinStatus.Where(m => m.binAddress == bin.binAddress).ToListAsync();

            if (binStatus == null)
            {
                return NotFound();
            }

            return Ok(binStatus);
        }
       
        /**
         * This function takes in a binStatus object and will post it to the Database.
         * */
        // POST: api/BinStatus
        [HttpPost]
        public async Task<IActionResult> PostBinStatus([FromBody] BinStatus binStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BinStatus.Add(binStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBinStatus", new { id = binStatus.binID }, binStatus);
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