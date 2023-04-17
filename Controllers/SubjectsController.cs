using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyScheduler.Data;
using MyScheduler.Models;

namespace MyScheduler.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : Controller
    {
        private readonly MySchedulerDbContext _context;

        public SubjectsController(MySchedulerDbContext context)
        {
            _context = context;
        }

        // GET: subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetTodoItems()
        {
            return await _context.Subjects.ToListAsync();
        }

        // GET: subjects/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(Guid id)
        {

            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;

        }

        // POST: subjects
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSubject), new { id = subject.Id }, subject);
        }

        // PUT: subjects/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Subject>> PutSubject(Guid id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            _context.Entry(subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return await GetSubject(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }

        }

        // DELETE: subjects/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subject>> DeleteSubject(Guid id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return subject;
        }
    }
}
