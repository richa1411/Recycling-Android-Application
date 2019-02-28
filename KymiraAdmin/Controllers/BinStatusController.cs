using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KymiraAdmin.Models;


namespace KymiraAdmin.Controllers
{
    public class BinStatusController : Controller
    {
        //database context object
        private readonly KymiraAdminContext _context;

        public BinStatusController(KymiraAdminContext context)
        {
            _context = context;
        }

        // GET: BinStatus
        public async Task<IActionResult> Index()
        {
            //return the list of all binstatuses here ---- TODO: sort by siteID then binID
            List<BinStatus> list = await _context.BinStatus.Where(o => o.inactive == false).ToListAsync();
            list.OrderBy(o => o.siteID).ThenByDescending(o=>o.binID);

            return View(list);
        }
        // GET: BinStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //find the requested bin status
            var binStatus = await _context.BinStatus
                .SingleOrDefaultAsync(m => m.pickupID == id);
            if (binStatus == null)
            {
                //the binstatus was not found
                return NotFound();
            }

            //return a view containing the info for the requested binstatus
            return View(binStatus);
        }

        // POST: BinStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var binStatus = await _context.BinStatus.SingleOrDefaultAsync(m => m.pickupID == id);
            //change this so that it changes the inactive field and does not remove the record
            binStatus.inactive = true;
           
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
