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

        // POST: api/Residents
        /**
         * This method takes in a resident object in JSON notation, checks that the model is valid,
         * and saves the resident to the DB if it is valid (returns the JSON object back with a 201: Created) otherwise
         * returns a 400: Bad Request with an error message in JSON notation.
         */
        [HttpPost]
        public async Task<IActionResult> PostResident([FromBody] Resident resident)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ResidentDBSet.Add(resident);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResident", new { id = resident.id }, resident);
        }
    }
}