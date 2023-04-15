using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyScheduler.Data;
using MyScheduler.Models;

namespace MyScheduler.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : Controller
    {
        private readonly MySchedulerDbContext _context;

        public GroupsController(MySchedulerDbContext context)
        {
            _context = context;
        }

        // GET: groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetTodoItems()
        {
            return await _context.Groups.ToListAsync();
        }

        // GET: groups/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(Guid id)
        {

            var group = await _context.Groups.FindAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            return group;

        }

        // POST: groups
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGroup), new { id = group.Id }, group);
        }

        // PUT: groups/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Group>> PutGroup(Guid id, Group group)
        {
            if (id != group.Id)
            {
                return BadRequest();
            }

            _context.Entry(group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return await GetGroup(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }

        }

        // DELETE: groups/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Group>> DeleteGroup(Guid id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();

            return group;
        }
    }
}
