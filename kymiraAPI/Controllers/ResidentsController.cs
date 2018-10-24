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
    [Route("api/Residents")]
    public class ResidentsController : Controller
    {
        private readonly kymiraAPIContext _context;

        public ResidentsController(kymiraAPIContext context)
        {
            _context = context;
        }

        // GET: api/Residents
        [HttpGet]
        public IEnumerable<Resident> GetResident()
        {
            return _context.ResidentDBSet;
        }

        // GET: api/Residents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResident([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resident = await _context.ResidentDBSet.SingleOrDefaultAsync(m => m.id == id);

            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }

        // PUT: api/Residents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResident([FromRoute] int id, [FromBody] Resident resident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resident.id)
            {
                return BadRequest();
            }

            _context.Entry(resident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentExists(id))
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

        // POST: api/Residents
        [HttpPost]
        public async Task<IActionResult> PostResident([FromBody] Resident resident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("{ Error: 1 Message: Make sure all required fields are valid }");
            }

            _context.ResidentDBSet.Add(resident);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResident", new { id = resident.id }, resident);
        }

        // DELETE: api/Residents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResident([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resident = await _context.ResidentDBSet.SingleOrDefaultAsync(m => m.id == id);
            if (resident == null)
            {
                return NotFound();
            }

            _context.ResidentDBSet.Remove(resident);
            await _context.SaveChangesAsync();

            return Ok(resident);
        }

       
        private bool ResidentExists(int id) //This method COULD be changed further down the line to take in different parameters instead of just an ID.
        {
            return _context.ResidentDBSet.Any(e => e.id == id);
        }
    }
}