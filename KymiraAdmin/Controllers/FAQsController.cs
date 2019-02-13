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
            return View(await _context.FAQDBSet.ToListAsync());
        }

        //// GET: FAQs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var fAQ = await _context.FAQDBSet
        //        .SingleOrDefaultAsync(m => m.id == id);
        //    if (fAQ == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(fAQ);
        //}

        // GET: FAQs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FAQs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,question,answer,inactive")] FAQ fAQ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fAQ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fAQ);
        }

        // GET: FAQs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fAQ = await _context.FAQDBSet.SingleOrDefaultAsync(m => m.id == id);
            if (fAQ == null)
            {
                return NotFound();
            }
            return View(fAQ);
        }

        // POST: FAQs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,question,answer,inactive")] FAQ fAQ)
        {
            if (id != fAQ.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fAQ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FAQExists(fAQ.id))
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
            return View(fAQ);
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
            await this.Edit(id, fAQ);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FAQExists(int id)
        {
            return _context.FAQDBSet.Any(e => e.id == id);
        }
    }
}
