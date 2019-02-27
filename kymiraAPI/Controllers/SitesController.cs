﻿using System;
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
    [Route("api/Sites")]
    //Class responsible for handling HTTP requests related to Site objects
    public class SitesController : Controller
    {
        private readonly kymiraAPIContext _context;

        public SitesController(kymiraAPIContext context)
        {
            _context = context;
        }

        // GET: api/Sites
        [HttpGet]
        public IEnumerable<Site> GetSite()
        {
            return _context.Site;
        }

        // GET: api/Sites/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var site = await _context.Site.SingleOrDefaultAsync(m => m.siteID == id);

            if (site == null)
            {
                return NotFound();
            }

            return Ok(site);
        }

        // PUT: api/Sites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSite([FromRoute] int id, [FromBody] Site site)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != site.siteID)
            {
                return BadRequest();
            }

            _context.Entry(site).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteExists(id))
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

        // POST: api/Sites
        //Function responsible for querying the database for the given search address
        //Function also will utliize an internal helper function that will calculate the next two pick up dates to return based on the site found
        //Returns an empty array of DateTime objects if the address is not matched to a site in the database
        [HttpPost]
        public async Task<IActionResult> PostAddressToSearch([FromBody] string searchAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Site.Add(search);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SiteExists(site.siteID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSite", new { id = site.siteID }, site);
        }

        // DELETE: api/Sites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSite([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var site = await _context.Site.SingleOrDefaultAsync(m => m.siteID == id);
            if (site == null)
            {
                return NotFound();
            }

            _context.Site.Remove(site);
            await _context.SaveChangesAsync();

            return Ok(site);
        }

        private bool SiteExists(int id)
        {
            return _context.Site.Any(e => e.siteID == id);
        }
    }
}