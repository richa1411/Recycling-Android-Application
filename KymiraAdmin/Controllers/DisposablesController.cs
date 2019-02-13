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
    public class DisposablesController : Controller
    {
        private readonly KymiraAdminContext _context;

        public DisposablesController(KymiraAdminContext context)
        {
            _context = context;
        }

        // GET: Disposables
        public async Task<IActionResult> Index()
        {
            //Will sort the list alphabetically by name and only display the items that are NOT inactive
            var list = await _context.DisposableDBSet.ToListAsync();
            list.RemoveAll(m => m.inactive == true);
            return View(list);

            //return View(await _context.DisposableDBSet.ToListAsync());
        }

               

        // GET: Disposables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disposable = await _context.DisposableDBSet
                .SingleOrDefaultAsync(m => m.ID == id);
            if (disposable == null)
            {
                return NotFound();
            }

            return View(disposable);
        }

        // POST: Disposables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Instead of deleting the object from the database, just set the inactive 
            var disposable = await _context.DisposableDBSet.SingleOrDefaultAsync(m => m.ID == id);
            // _context.DisposableDBSet.Remove(disposable);
            disposable.inactive = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisposableExists(int id)
        {
            return _context.DisposableDBSet.Any(e => e.ID == id);
        }
    }
}
