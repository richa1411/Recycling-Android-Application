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
            //Will sort the list alphabetically by name

            return View(await _context.DisposableDBSet.ToListAsync());
        }

        // GET: Disposables/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Disposables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disposables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,description,imageURL,isRecyclable,recycleReason,endResult,qtyRecycled")] Disposable disposable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disposable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disposable);
        }

        // GET: Disposables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disposable = await _context.DisposableDBSet.SingleOrDefaultAsync(m => m.ID == id);
            if (disposable == null)
            {
                return NotFound();
            }
            return View(disposable);
        }

        // POST: Disposables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,description,imageURL,isRecyclable,recycleReason,endResult,qtyRecycled")] Disposable disposable)
        {
            if (id != disposable.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disposable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisposableExists(disposable.ID))
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
            return View(disposable);
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
            var disposable = await _context.DisposableDBSet.SingleOrDefaultAsync(m => m.ID == id);
            _context.DisposableDBSet.Remove(disposable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisposableExists(int id)
        {
            return _context.DisposableDBSet.Any(e => e.ID == id);
        }
    }
}
