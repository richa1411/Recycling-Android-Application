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
    /**
     * This controller is used to send and receive JSON objects relating to the disposableDB set.
     * */
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

          
            
            var disposable = await _context.DisposableDBSet.Where(m => m.isRecyclable == isRecyclable).ToListAsync();

            if (disposable == null)
            {
                return NotFound();
            }
            
            return Ok(disposable);
        }



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


    }
}