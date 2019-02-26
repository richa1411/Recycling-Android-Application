using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KymiraAdmin.Models;
using KymiraAdmin.Data;

namespace KymiraAdmin.Controllers
{
    public class FAQsController : Controller
    {
        private readonly KymiraAdminContext _context;

        public FAQsController(KymiraAdminContext context)
        {
            _context = context;
        }

        //will only send the faqs that are active
        // GET: FAQs
        public async Task<IActionResult> Index()
        {
            List<FAQ> list = await _context.FAQDBSet.Where(o => o.inactive == false).ToListAsync();

            list.OrderBy(o => o.question);

            

            return View(list.OrderBy(o => o.question));
        }

        // GET: FAQs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fAQ = await _context.FAQDBSet
                .SingleOrDefaultAsync(m => m.id == id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return View(fAQ);
        }

        //this will change the inactive field of the given fAQ to true so that it will not be used in the app, etc.
        // POST: FAQs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fAQ = await _context.FAQDBSet.SingleOrDefaultAsync(m => m.id == id);
            fAQ.inactive = true;
            //change the inactive field to true
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FAQExists(int id)
        {
            return _context.FAQDBSet.Any(e => e.id == id);
        }
    }
}
