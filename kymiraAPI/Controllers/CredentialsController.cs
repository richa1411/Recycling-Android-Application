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
    [Route("api/Credentials")]
    public class CredentialsController : Controller
    {
        private readonly kymiraAPIContext _context;

        public CredentialsController(kymiraAPIContext context)
        {
            _context = context;
        }

        // GET: api/Credentials
        [HttpGet]
        public IEnumerable<Credentials> GetCredentials()
        {
            return _context.Credentials;
        }

        // GET: api/Credentials/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCredentials([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var credentials = await _context.Credentials.SingleOrDefaultAsync(m => m.ID == id);

            if (credentials == null)
            {
                return NotFound();
            }

            return Ok(credentials);
        }

        // PUT: api/Credentials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCredentials([FromRoute] int id, [FromBody] Credentials credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != credentials.ID)
            {
                return BadRequest();
            }

            _context.Entry(credentials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CredentialsExists(id))
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

        // POST: api/Credentials
        [HttpPost]
        public async Task<IActionResult> PostCredentials([FromBody] Credentials credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Credentials.Add(credentials);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCredentials", new { id = credentials.ID }, credentials);
        }

        // DELETE: api/Credentials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCredentials([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var credentials = await _context.Credentials.SingleOrDefaultAsync(m => m.ID == id);
            if (credentials == null)
            {
                return NotFound();
            }

            _context.Credentials.Remove(credentials);
            await _context.SaveChangesAsync();

            return Ok(credentials);
        }

        private bool CredentialsExists(int id)
        {
            return _context.Credentials.Any(e => e.ID == id);
        }
    }
}