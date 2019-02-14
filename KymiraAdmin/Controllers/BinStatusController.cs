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
            return View(await _context.BinStatus.ToListAsync());
        }

        // GET: BinStatus/Details/5
        /*
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binStatus = await _context.BinStatus
                .SingleOrDefaultAsync(m => m.pickupID == id);
            if (binStatus == null)
            {
                return NotFound();
            }

            return View(binStatus);
        }

        // GET: BinStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BinStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pickupID,binID,status,siteID,collectionDate")] BinStatus binStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(binStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(binStatus);
        }

        // GET: BinStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binStatus = await _context.BinStatus.SingleOrDefaultAsync(m => m.pickupID == id);
            if (binStatus == null)
            {
                return NotFound();
            }
            return View(binStatus);
        }

        // POST: BinStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pickupID,binID,status,siteID,collectionDate")] BinStatus binStatus)
        {
            if (id != binStatus.pickupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinStatusExists(binStatus.pickupID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(binStatus);
        }
        */

        // GET: BinStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //change to be inactive

            var binStatus = await _context.BinStatus
                .SingleOrDefaultAsync(m => m.pickupID == id);
            if (binStatus == null)
            {
                return NotFound();
            }

            return View(binStatus);
        }

        // POST: BinStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var binStatus = await _context.BinStatus.SingleOrDefaultAsync(m => m.pickupID == id);
            _context.BinStatus.Remove(binStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /*
        private bool BinStatusExists(int id)
        {
            return _context.BinStatus.Any(e => e.pickupID == id);
        }
        */
    }
}
