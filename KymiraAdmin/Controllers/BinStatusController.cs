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
    public class BinStatusController : Controller
    {
        //database context object
        private readonly KymiraAdminContext _context;

        public BinStatusController(KymiraAdminContext context)
        {
            _context = context;
        }

        //// GET: BinStatus
        //public async Task<IActionResult> Index()
        //{
        //    //return the list of all binstatuses here ---- sort by siteID then binID
        //    List<BinStatus> list = await _context.BinStatus.Where(o => o.inactive == false).ToListAsync();
        //    //list.OrderBy(o => o.siteID).ThenBy(o=>o.binID);

        //    return View(list.OrderBy(o => o.siteID).ThenBy(o => o.binID).ThenBy(o => o.collectionDate));
        //}

        public async Task<ActionResult> Index(int? page,string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SiteSortParm = String.IsNullOrEmpty(sortOrder) ? "siteID_desc" : "";
            ViewBag.BinSortParam = sortOrder == "binID" ? "binID_desc" : "binID";
            ViewBag.StatusSortParm = sortOrder == "status" ? "status_desc" : "status";
            ViewBag.DateSortParm = sortOrder== "collDate" ? "collDate_desc" : "collDate";
            //default show page 1
            if (page == null)
            {
                page = 1;
            }
           
            List<BinStatus> binStatus;//var to hold the list to display to the page
            //sort the list to display by the order passed in - only grabs active collection sites with collection statuses
            switch (sortOrder)
            {
                
                case "binID":
                    binStatus = await _context.BinStatus.Where(o => o.inactive == false).OrderBy(b => b.binID).ToListAsync();
                    break;
                case "status":
                    binStatus = await _context.BinStatus.Where(o => o.inactive == false).OrderBy(b => b.status).ToListAsync();
                    break;
                case "collDate":
                    binStatus = await _context.BinStatus.Where(o => o.inactive == false).OrderBy(b => b.collectionDate).ToListAsync();
                    break;
                case "siteID_desc":
                    binStatus = await _context.BinStatus.Where(o => o.inactive == false).OrderByDescending(b => b.siteID).ToListAsync();
                    break;
                case "binID_desc":
                    binStatus = await _context.BinStatus.Where(o => o.inactive == false).OrderByDescending(b => b.binID).ToListAsync();
                    break;
                case "status_desc":
                    binStatus = await _context.BinStatus.Where(o => o.inactive == false).OrderByDescending(b => b.status).ToListAsync();
                    break;
                case "collDate_desc":
                    binStatus = await _context.BinStatus.Where(o => o.inactive == false).OrderByDescending(b => b.collectionDate).ToListAsync();
                    break;
                default:
                    binStatus = await _context.BinStatus.Where(o => o.inactive == false).OrderBy(b => b.siteID).ToListAsync();
                    break;
            }
                
            return View((binStatus.ToPagedList((int)page, 100)));
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

        private bool StatusExists(int id)
        {
            return _context.Site.Any(e => e.siteID == id);
        }

    }
}
