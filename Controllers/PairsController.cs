using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyScheduler.Data;
using MyScheduler.Models;

namespace MyScheduler.Controllers
{
    [Route("api/pairs")]
    [ApiController]
    public class PairsController : Controller
    {
        private readonly MySchedulerDbContext _context;

        public PairsController(MySchedulerDbContext context)
        {
            _context = context;
        }

        // GET: pairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pair>>> GetTodoItems()
        {
            return await _context.Pairs.ToListAsync();
        }

        // GET: pairs/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Pair>> GetPair(Guid id)
        {

            var pair = await _context.Pairs.FindAsync(id);

            if (pair == null)
            {
                return NotFound();
            }

            return pair;

        }

        // POST: pairs
        [HttpPost]
        public async Task<ActionResult<Pair>> PostPair(Pair pair)
        {
            _context.Pairs.Add(pair);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPair), new { id = pair.Id }, pair);
        }

        // PUT: pairs/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Pair>> PutPair(Guid id, Pair pair)
        {
            if (id != pair.Id)
            {
                return BadRequest();
            }

            _context.Entry(pair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return await GetPair(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }

        }

        // DELETE: pairs/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pair>> DeletePair(Guid id)
        {
            var pair = await _context.Pairs.FindAsync(id);
            if (pair == null)
            {
                return NotFound();
            }

            _context.Pairs.Remove(pair);
            await _context.SaveChangesAsync();

            return pair;
        }
    }
}
