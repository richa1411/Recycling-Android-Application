using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KymiraAdmin.Models;
using X.PagedList;


namespace KymiraAdmin.Controllers
{
    public class SitesController : Controller
    {
        private readonly KymiraAdminContext _context;

        public SitesController(KymiraAdminContext context)
        {
            _context = context;
        }

        // GET: Sites
        public async Task<IActionResult> Index(int? page)
        {

            if(page == null)
            {
                page = 1;
            }


            var list = await _context.Site.ToListAsync();




            //return only active sites (where clause)
            return View(list.ToPagedList( (int) page, 100));
        }



        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Site
                .SingleOrDefaultAsync(m => m.siteID == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await _context.Site.SingleOrDefaultAsync(m => m.siteID == id);
            _context.Site.Remove(site);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(int id)
        {
            return _context.Site.Any(e => e.siteID == id);
        }
    }
}
