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
    [Route("api/Disposables")]
    public class DisposablesController : Controller
    {
        private readonly kymiraAPIContext _context;

        public DisposablesController(kymiraAPIContext context)
        {
            _context = context;
        }

        // GET: api/Disposables
        [HttpGet]
        public IEnumerable<Disposable> GetDisposable()
        {
            return _context.DisposableDBSet;
        }

        // GET: api/Disposables/true
        [HttpGet("{isRecyclable}")]
        public async Task<IActionResult> GetDisposable([FromRoute] bool isRecyclable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var disposable = await _context.DisposableDBSet.SingleOrDefaultAsync(m => m.isRecyclable == isRecyclable);
            
            //var disposable = await _context.DisposableDBSet.Where(m => m.isRecyclable == isRecyclable).ToListAsync();

            if (disposable == null)
            {
                return NotFound();
            }
            
            return Ok(disposable);
        }

        //// PUT: api/Disposables/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDisposable([FromRoute] int id, [FromBody] Disposable disposable)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != disposable.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(disposable).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DisposableExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Disposables
        [HttpPost]
        public async Task<IActionResult> PostDisposable([FromBody] Disposable disposable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DisposableDBSet.Add(disposable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisposable", new { id = disposable.ID }, disposable);
        }

        //// DELETE: api/Disposables/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDisposable([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var disposable = await _context.Disposable.SingleOrDefaultAsync(m => m.ID == id);
        //    if (disposable == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Disposable.Remove(disposable);
        //    await _context.SaveChangesAsync();

        //    return Ok(disposable);
        //}

        //private bool DisposableExists(int id)
        //{
        //    return _context.Disposable.Any(e => e.ID == id);
        //}
    }
}