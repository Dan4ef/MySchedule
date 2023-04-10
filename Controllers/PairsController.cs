using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScheduler.Data;
using MyScheduler.Models;

namespace MyScheduler.Controllers
{
    public class PairsController : Controller
    {
        private readonly MySchedulerDbContext _context;

        public PairsController(MySchedulerDbContext context)
        {
            _context = context;
        }

        // GET: Pairs
        public async Task<IActionResult> Index()
        {
              return _context.Pairs != null ? 
                          View(await _context.Pairs.ToListAsync()) :
                          Problem("Entity set 'MySchedulerDbContext.Pairs'  is null.");
        }

        // GET: Pairs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Pairs == null)
            {
                return NotFound();
            }

            var pair = await _context.Pairs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pair == null)
            {
                return NotFound();
            }

            return View(pair);
        }

        // GET: Pairs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubjectId,Time")] Pair pair)
        {
            if (ModelState.IsValid)
            {
                pair.Id = Guid.NewGuid();
                _context.Add(pair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pair);
        }

        // GET: Pairs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Pairs == null)
            {
                return NotFound();
            }

            var pair = await _context.Pairs.FindAsync(id);
            if (pair == null)
            {
                return NotFound();
            }
            return View(pair);
        }

        // POST: Pairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SubjectId,Time")] Pair pair)
        {
            if (id != pair.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PairExists(pair.Id))
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
            return View(pair);
        }

        // GET: Pairs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Pairs == null)
            {
                return NotFound();
            }

            var pair = await _context.Pairs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pair == null)
            {
                return NotFound();
            }

            return View(pair);
        }

        // POST: Pairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Pairs == null)
            {
                return Problem("Entity set 'MySchedulerDbContext.Pairs'  is null.");
            }
            var pair = await _context.Pairs.FindAsync(id);
            if (pair != null)
            {
                _context.Pairs.Remove(pair);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PairExists(Guid id)
        {
          return (_context.Pairs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
