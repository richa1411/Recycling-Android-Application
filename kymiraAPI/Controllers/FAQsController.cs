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
    [Route("api/FAQs")]
    public class FAQsController : Controller
    {
        private readonly kymiraAPIContext _context;

        public FAQsController(kymiraAPIContext context)
        {
            _context = context;
        }

        // GET: api/FAQs
        [HttpGet]
        public IEnumerable<FAQ> GetFAQ()
        {
            return _context.FAQ;
        }

        // GET: api/FAQs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFAQ([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fAQ = await _context.FAQ.SingleOrDefaultAsync(m => m.ID == id);

            if (fAQ == null)
            {
                return NotFound();
            }

            return Ok(fAQ);
        }

        // PUT: api/FAQs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFAQ([FromRoute] int id, [FromBody] FAQ fAQ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fAQ.ID)
            {
                return BadRequest();
            }

            _context.Entry(fAQ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FAQExists(id))
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

        // POST: api/FAQs
        [HttpPost]
        public async Task<IActionResult> PostFAQ([FromBody] FAQ fAQ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FAQ.Add(fAQ);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFAQ", new { id = fAQ.ID }, fAQ);
        }

        // DELETE: api/FAQs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFAQ([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fAQ = await _context.FAQ.SingleOrDefaultAsync(m => m.ID == id);
            if (fAQ == null)
            {
                return NotFound();
            }

            _context.FAQ.Remove(fAQ);
            await _context.SaveChangesAsync();

            return Ok(fAQ);
        }

        private bool FAQExists(int id)
        {
            return _context.FAQ.Any(e => e.ID == id);
        }
    }
}