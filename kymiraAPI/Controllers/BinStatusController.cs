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

        // GET: api/BinStatus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBinStatus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var binStatus = await _context.BinStatus.SingleOrDefaultAsync(m => m.binID == id);

            if (binStatus == null)
            {
                return NotFound();
            }

            return Ok(binStatus);
        }

        // PUT: api/BinStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBinStatus([FromRoute] int id, [FromBody] BinStatus binStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != binStatus.binID)
            {
                return BadRequest();
            }

            _context.Entry(binStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BinStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

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

        // DELETE: api/BinStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBinStatus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var binStatus = await _context.BinStatus.SingleOrDefaultAsync(m => m.binID == id);
            if (binStatus == null)
            {
                return NotFound();
            }

            _context.BinStatus.Remove(binStatus);
            await _context.SaveChangesAsync();

            return Ok(binStatus);
        }

        private bool BinStatusExists(int id)
        {
            return _context.BinStatus.Any(e => e.binID == id);
        }
    }
}