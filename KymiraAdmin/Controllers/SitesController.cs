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
        /* This method shows the correct page that the user selects to view,
         the view only includes a list of the Site objects that are active,
         it also by default sorts the list by the Site ID in ascending order. */
        public async Task<IActionResult> Index(int? page, string sortOrder)
        {
            //grab values passed from controller
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SiteSortParam = String.IsNullOrEmpty(sortOrder) ? "site_desc" : "";
            ViewBag.AddressSortParam = sortOrder == "Full Address" ? "address_desc" : "Full Address";

            //default show page 1
            if (page == null)
            {
                page = 1;
            }

            List<Site> list; //var to hold the list to display to the page

            //sort the list to display by the order passed in - only grabs active sites
            switch(sortOrder)
            {
                case "address_desc": //address descending order
                    list = await _context.Site.Where(e => e.inactive == false).OrderByDescending(e => e.address).ToListAsync();
                    break;
                case "Full Address": //address ascending order
                    list = await _context.Site.Where(e => e.inactive == false).OrderBy(e => e.address).ToListAsync();
                    break;
                case "site_desc": //site descending order
                    list = await _context.Site.Where(e => e.inactive == false).OrderByDescending(e => e.siteID).ToListAsync();
                    break;
                default: //site ascending order
                    list = await _context.Site.Where(e => e.inactive == false).OrderBy(e => e.siteID).ToListAsync();
                    break;
            }

            //return view using pages, showing only a max of 100 on a page at a time
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
        /* This method takes in the int id of the item the user selected to delete and
         * sets the Site's inactive field to be true (won't be displayed). */
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await _context.Site.SingleOrDefaultAsync(m => m.siteID == id);
            site.inactive = true; //set the inactive field of the Site to delete to be true
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(int id)
        {
            return _context.Site.Any(e => e.siteID == id);
        }
    }
}
