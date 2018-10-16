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
    [Route("api/Credentials")]
    public class CredentialsController : Controller
    {
        private readonly kymiraAPIContext _context;

        public CredentialsController(kymiraAPIContext context)
        {
            _context = context;
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


        private bool CredentialsExists(int id)
        {
            return _context.Credentials.Any(e => e.ID == id);
        }
    }
}