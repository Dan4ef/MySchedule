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
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : Controller
    {
        private readonly MySchedulerDbContext _context;

        public TeachersController(MySchedulerDbContext context)
        {
            _context = context;
        }

        // GET: teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTodoItems()
        {
            return await _context.Teachers.ToListAsync();
        }

        // GET: teachers/:id
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(Guid id)
        {

            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;

        }

        // POST: teachers
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Id }, teacher);
        }

        // PUT: teachers/:id
        [HttpPut("{id}")]
        public async Task<ActionResult<Teacher>> PutTeacher(Guid id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return await GetTeacher(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NoContent();
            }

        }

        // DELETE: teachers/:id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(Guid id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return teacher;
        }
    }
}
