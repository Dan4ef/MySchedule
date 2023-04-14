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
            var mySchedulerDbContext = _context.Pairs.Include(p => p.Schedule).Include(p => p.Subject);
            return View(await mySchedulerDbContext.ToListAsync());
        }

        // GET: Pairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pairs == null)
            {
                return NotFound();
            }

            var pair = await _context.Pairs
                .Include(p => p.Schedule)
                .Include(p => p.Subject)
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
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id");
            return View();
        }

        // POST: Pairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DayOfWeek,Time,SubjectId,ScheduleId")] Pair pair)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id", pair.ScheduleId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", pair.SubjectId);
            return View(pair);
        }

        // GET: Pairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id", pair.ScheduleId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", pair.SubjectId);
            return View(pair);
        }

        // POST: Pairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DayOfWeek,Time,SubjectId,ScheduleId")] Pair pair)
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
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id", pair.ScheduleId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", pair.SubjectId);
            return View(pair);
        }

        // GET: Pairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pairs == null)
            {
                return NotFound();
            }

            var pair = await _context.Pairs
                .Include(p => p.Schedule)
                .Include(p => p.Subject)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
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

        private bool PairExists(int id)
        {
          return (_context.Pairs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
