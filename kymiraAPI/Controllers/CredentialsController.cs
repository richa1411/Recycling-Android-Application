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
        public Guid base64Guid; 

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
                return BadRequest("{ Error:1 Message:Incorrect phone number or password }");
            }

            // This will queury the database with a Credentials Object and compare it to a Resident Object
            // already inside the database with a matching Phone Number and Password 
           var resident = await _context.ResidentDBSet.SingleOrDefaultAsync(r => r.phoneNumber == credentials.phoneNumber && r.password == credentials.password);

            if (resident == null)
            {
                return NotFound("{ Error:1 Message:Incorrect phone number or password }");
            }

            base64Guid = Guid.NewGuid();

            return Ok(base64Guid);
        }

    }
}