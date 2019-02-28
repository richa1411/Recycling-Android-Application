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

        //// GET: BinStatus
        //public async Task<IActionResult> Index()
        //{
        //    //return the list of all binstatuses here ---- sort by siteID then binID
        //    List<BinStatus> list = await _context.BinStatus.Where(o => o.inactive == false).ToListAsync();
        //    //list.OrderBy(o => o.siteID).ThenBy(o=>o.binID);

        //    return View(list.OrderBy(o => o.siteID).ThenBy(o => o.binID).ThenBy(o => o.collectionDate));
        //}

        public ActionResult Index(string sortOrder)
        {
            ViewBag.SiteSortParm = sortOrder.Contains("siteID") ? "siteID_desc" : "";
            ViewBag.BinSortParam = sortOrder.Contains("binID") ? "binID_desc" : "binID";
            ViewBag.StatusSortParm = sortOrder.Contains("status") ? "status_desc" : "status";
            ViewBag.DateSortParm = sortOrder.Contains("collDate") ? "collDate_desc" : "collDate";

            var binStatus = from b in _context.BinStatus select b;

            switch(sortOrder)
            {
                case "binID":
                    binStatus = binStatus.OrderBy(b => b.binID);
                    break;
                case "status":
                    binStatus = binStatus.OrderBy(b => b.status);
                    break;
                case "collDate":
                    binStatus = binStatus.OrderBy(b => b.collectionDate);
                    break;
                case "siteID_desc":
                    binStatus = binStatus.OrderByDescending(b => b.siteID);
                    break;
                case "binID_desc":
                    binStatus = binStatus.OrderByDescending(b => b.binID);
                    break;
                case "status_desc":
                    binStatus = binStatus.OrderByDescending(b => b.status);
                    break;
                case "collDate_desc":
                    binStatus = binStatus.OrderByDescending(b => b.collectionDate);
                    break;
                default:
                    binStatus = binStatus.OrderBy(b => b.siteID);
                    break;
            }
                
            return View(binStatus.ToList());
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
