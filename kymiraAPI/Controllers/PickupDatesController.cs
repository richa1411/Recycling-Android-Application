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
    [Route("api/PickupDates")]
    public class PickupDatesController : Controller
    {
        private readonly kymiraAPIContext _context;

        public PickupDatesController(kymiraAPIContext context)
        {
            _context = context;
        }

        // GET: api/PickupDates
        [HttpGet]
        public IEnumerable<PickupDate> GetPickupDate()
        {
            return _context.PickupDate;
        }

        // GET: api/PickupDates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPickupDate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pickupDate = await _context.PickupDate.SingleOrDefaultAsync(m => m.binID == id);

            if (pickupDate == null)
            {
                return NotFound();
            }

            return Ok(pickupDate);
        }

        [HttpGet("{address}")]
        public async Task<IActionResult> GetPickupDate([FromRoute] int id, [FromBody] PickupDate pickupDate)
        {

        }
    }

       
}