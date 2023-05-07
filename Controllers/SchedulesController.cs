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
    [Route("api/schedules")]
    [ApiController]
    public class SchedulesController : Controller
    {
        private readonly MySchedulerDbContext _context;

        public SchedulesController(MySchedulerDbContext context)
        {
            _context = context;
        }

        // GET: schedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetTodoItems()
        {
            return await _context.Schedules.ToListAsync();
        }

        // GET: schedules/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(Guid id)
        {

            var schedule = await _context.Schedules.FindAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return schedule;

        }

        // POST: schedules
        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule(Schedule schedule)
        {
            Console.WriteLine("Schedule");
            Console.WriteLine(schedule);
            // _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSchedule), new { id = schedule.Id }, schedule);
        }

        // PUT: schedules/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Schedule>> PutSchedule(Guid id, Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(schedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return await GetSchedule(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }

        }

        // DELETE: schedules/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Schedule>> DeleteSchedule(Guid id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return schedule;
        }
    }
}
